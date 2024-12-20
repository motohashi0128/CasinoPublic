using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using Poker;

namespace Poker
{
    public class PokerManager : MonoBehaviour
    {
        [SerializeField]
        Transform _handParent;
        [SerializeField]
        Model _model;
        List<Card> _cards;
        [SerializeField]
        TextMeshProUGUI _buttonText, _resultText, _potText, _bonusText, _scoreText, _stackText, _betText;
        [SerializeField]
        UnityEngine.UI.Image _resultBG;
        [SerializeField]
        GameObject _deck, _trash;
        [SerializeField]
        int _stack, _bet, _pot;

        List<Vector2> _handPosList;
        List<Vector2> _stockPosList;
        List<Vector2> _stockPosList2;
        Vector2 _deckPos, _deckPosOffset = new Vector2(-480, 0);
        Vector2 _trashPos;
        List<int> _masterList = new List<int>();
        [SerializeField]
        List<int> _trashList = new List<int>();
        bool _isClicked, _goChange, _isChanging;
        [SerializeField]
        int _selectedCardId;
        CancellationTokenSource _cts;
        CancellationToken _ct;
        DOTweenTMPAnimator _resultAnimator;

        [SerializeField]
        bool _isDebugDeck, _isDebugRerlics;
        [SerializeField]
        List<int> _debugList = new List<int>()
        {
            15,22,44,24,12
        };
        [SerializeField]
        float _coef = 1.0f;
        const string BUTTON_CHECK = "Check", BUTTON_DEAL = "Deal", BUTTON_NEXT = "Next";
        void Awake()
        {
            initPos();
        }
        async void Start()
        {
            _masterList = _model.selectedDeck.Value;
            _cts = new CancellationTokenSource();
            _ct = _cts.Token;
            _cards = _handParent.GetComponentsInChildren<Card>().ToList();
#if UNITY_EDITOR
            if (_isDebugRerlics)
            {
                _model.SetAllAvailable();
            }
#endif
            foreach (var item in _cards)
            {
                item.model = _model;
                // クリックされたカード以外の処理
                item.isSelectedSubject.Subscribe(_ =>
                {
                    // 手札が一枚でも選択されていたら
                    if (_cards.Any(c => c.isSelectedSubject.Value))
                    {
                        Debug.Log("Change: " + item.isSelectedSubject.Value);
                        _goChange = true;
                        _selectedCardId = item.cardId;

                        // カードの状態をすべてリセットするとき、二枚以上選択されていたら一枚目をfalseにした時点でこのネストを通ってしまうので、それを防ぎたい
                        if (!_isChanging)
                        {
                            _cards.ForEach(c =>
                            {
                                if (c.cardId != _selectedCardId)
                                {
                                    Debug.Log("OutStand: " + Idols.idolList[_selectedCardId].name);
                                    // 選択されているカード以外を走査して、選択されているカードが含まれているユニットがあれば、そのカードを振る
                                    c.OutStandCard(_selectedCardId, _ct);
                                }
                            });
                        }
                    }
                    // 一枚も選択されていなかったら
                    else
                    {
                        _buttonText.text = BUTTON_CHECK;
                        _goChange = false;
                        _selectedCardId = -1;
                    }
                }).AddTo(this);
            }
            await PokerLoop(_ct);
        }
        void OnDestroy()
        {
            _cts.Cancel();
            _cts.Dispose();
        }
        /// <summary>
        /// ハンド5枚x3回をワンセットとしてループ
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        async UniTask PokerLoop(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                _cards.ForEach(c => c.ResetCard(_deckPos));
                _trash.SetActive(false);
                _cards.ForEach(c => c.canClick = false);
                _resultText.text = "";
                _buttonText.text = BUTTON_DEAL;
                _pot = 0;
                _potText.text = "0";
                _bonusText.text = "1";
                _scoreText.text = "0";
                _stackText.text = _stack.ToString();
                _betText.text = _bet.ToString();
                _trashList.Clear();
                // スタートボタンが押されるまで待つ
                await UniTask.WaitUntil(() => _isClicked, cancellationToken: ct);
                // 山札の枚数をリセット
                List<int> deckList = new List<int>(_masterList);
                // 手持ちが場代より少ない場合、シャッフルしてやり直し
                if (_stack < _bet)
                {
                    _isClicked = false;
                    _resultText.text = "";

                    await Shuffle(ct);
                    continue;
                }
                // 手持ちから場代を引く
                _stackText.DOCounter(_stack, _stack - _bet, 1f).ToUniTask().Forget();
                _stack -= _bet;
                // １回目のハンドの処理
                await PokerTerm(0, 5, deckList, ct);
                // １回目のハンドを奥に移動
                await UniTask.WhenAll(_cards.Select(async (c, i) =>
            {
                if (i < 5)
                    await c.MoveCard(_stockPosList[i % 5], ct);
            }));
                // 手持ちが場代より少ない場合、シャッフルしてやり直し
                if (_stack < _bet)
                {
                    _isClicked = false;
                    _resultText.text = "";

                    await Shuffle(ct);
                    continue;
                }
                // 手持ちから場代を引く
                _stackText.DOCounter(_stack, _stack - _bet, 1f).ToUniTask().Forget();
                _stack -= _bet;
                // ２回目のハンドの処理
                await PokerTerm(5, 5, deckList, ct);
                // １，２回目のハンドを奥に移動
                await UniTask.WhenAll(_cards.Select(async (c, i) =>
            {
                if (i < 5)
                    await c.MoveCard(_stockPosList2[i % 5], ct);
                if (5 <= i && i < 10)
                    await c.MoveCard(_stockPosList[i % 5], ct);
            }));
                // 手持ちが場代より少ない場合、シャッフルしてやり直し
                if (_stack < _bet)
                {
                    _isClicked = false;
                    _resultText.text = "";

                    await Shuffle(ct);
                    continue;
                }
                // 手持ちから場代を引く
                _stackText.DOCounter(_stack, _stack - _bet, 1f).ToUniTask().Forget();
                _stack -= _bet;
                // ３回目のハンドの処理
                await PokerTerm(10, 5, deckList, ct);
                // ３回分のハンドに、どのユニットが含めれているかチェック
                string unitHand = PokerCalc.UnitsCheck(_model, _cards);
                int up = 1;
                // ユニットが含まれていたら、そのユニットの名前を取得
                if (unitHand != Units.noMatch)
                {
                    await ShowResult(unitHand, ct);
                    await UniTask.Delay(750, cancellationToken: ct);
                    await HideResult(ct);
                }

                // ユニットの倍率を取得
                up = PokerCalc.GetUnitRate(_resultText, _model);
                await _bonusText.DOCounter(1, up, 1f).WithCancellation(ct);
                await UniTask.Delay(500, cancellationToken: ct);
                // ３回分のハンドの役の点数xボーナス倍率をスコアに反映
                await _scoreText.DOCounter(0, _pot * up, 1f).WithCancellation(ct);
                await UniTask.Delay(500, cancellationToken: ct);
                // スタックにスコアを追加
                _stackText.DOCounter(_stack, _stack + _pot * up, 1f).ToUniTask().Forget();
                _stack += up * _pot;
                // ポットをリセット
                _scoreText.DOCounter(_pot * up, 0, 1f).ToUniTask().Forget();
                _potText.DOCounter(_pot, 0, 1f).ToUniTask().Forget();
                _bonusText.DOCounter(up, 1, 1f).ToUniTask().Forget();
                _isClicked = false;
                _resultText.text = "";

                await Shuffle(ct);
            }
        }

        /// <summary>
        /// ポーカー部分の処理
        /// </summary>
        /// <param name="from"></param>
        /// <param name="count"></param>
        /// <param name="deckList"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        async UniTask PokerTerm(int from, int count, List<int> deckList, CancellationToken ct)
        {
            for (int i = from; i < from + count; i++)
            {
#if UNITY_EDITOR
                if (_isDebugDeck)
                {
                    // 順番が決まっているデッキを使う
                    await _cards[i].DealCard(_debugList[i], _handPosList[i % 5], ct);
                }
                else
                {
                    // デッキからランダムにカードを引く
                    int r = UnityEngine.Random.Range(0, deckList.Count);
                    _cards[i].DealCard(deckList[r], _handPosList[i % 5], ct).Forget();
                    deckList.RemoveAt(r);
                }
#else
                int r = UnityEngine.Random.Range(0, deckList.Count);
                _cards[i].DealCard(deckList[r], _handPosList[i % 5]).Forget();
                deckList.RemoveAt(r);
#endif
            }
            _buttonText.text = BUTTON_CHECK;

            _isClicked = false;
            // 手元の5枚のカードを選択可能にする
            _cards.Select((c, i) => new { c, i }).ToList().ForEach(x =>
            {
                ct.ThrowIfCancellationRequested();
                if (from <= x.i && x.i < from + count)
                    x.c.canClick = true;
            });
            // ボタンが押されるまで待つ
            await UniTask.WaitUntil(() => _isClicked, cancellationToken: ct);
            _cards.ForEach(c => c.canClick = false);
            // カードが選択されていたら交換する
            if (_goChange)
            {
                _goChange = false;
                await Change(from, count, deckList, ct);
            }
            // ポーカーの役をチェック
            string pokerHand = PokerCalc.PorkerCheck(_cards, from, count);
            // 役を表示
            await ShowResult(pokerHand, ct);
            await UniTask.Delay(750, cancellationToken: ct);
            await HideResult(ct);
            // 役に応じてポットを増やす
            float win = _pot + (_bet * PokerCalc.GetPokerRate(_resultText, _coef));
            if (pokerHand != Hands.noPair)
                _potText.DOCounter(_pot, (int)win, 1f).ToUniTask().Forget();
            _pot = (int)win;
            // ボタンを押されるまで待つ
            _buttonText.text = BUTTON_NEXT;
            _isClicked = false;
            await UniTask.WaitUntil(() => _isClicked, cancellationToken: ct);
        }

        /// <summary>
        /// 場のカードをすべてリセットしてシャッフル
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        async UniTask Shuffle(CancellationToken ct)
        {
            _isClicked = false;

            // カードを裏返してデッキに戻す

            await UniTask.WhenAll(_cards.Select(async c =>
            {
                await c.TurnFaceDown(ct);
            }));

            await UniTask.WhenAll(_cards.Select(async (c, i) =>
            {
                await c.MoveCard(_deckPos, ct);
            }));

            // トラッシュをデッキに戻す
            await _trash.transform.DOLocalMove(_deckPos + _deckPosOffset, 0.1f).WithCancellation(ct);
            Debug.Log("deckPos: " + _deckPos);
            Debug.Log("trashPos: " + _trash.GetComponent<RectTransform>().anchoredPosition);
            _trash.SetActive(false);
            _trash.GetComponent<RectTransform>().anchoredPosition = _trashPos;
        }

        /// <summary>
        /// 役・ユニットの結果を表示
        /// </summary>
        /// <param name="result"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        async UniTask ShowResult(string result, CancellationToken ct)
        {
            // 行ごとに表示させる
            _resultText.text = "";
            var lines = result.Split('\n');

            // resultにある改行の位置を取得
            var lineBreaks = Enumerable.Range(0, result.Length).Where(i => result[i] == '\n').ToArray();

            _resultText.text = result;
            Debug.Log("result: " + _resultText.text);
            _resultAnimator = new DOTweenTMPAnimator(_resultText);
            // まず文字を消す
            await UniTask.WhenAll(Enumerable.Range(0, _resultAnimator.textInfo.characterCount).Select(async i =>
            {
                if (result[i] != ' ' && result[i] != '\n')
                {
                    await _resultAnimator.DOFadeChar(i, 0, 0).WithCancellation(ct);
                }
            }));
            _resultBG.gameObject.SetActive(true);
            await _resultBG.DOFade(0.7f, 0.1f).WithCancellation(ct);
            // 改行ごとに文字を表示
            for (int i = 0; i < lines.Length; i++)
            {
                await UniTask.WhenAll(Enumerable.Range(i == 0 ? 0 : lineBreaks[i - 1], i == 0 ? lines[i].Length : lines[i].Length + 1).Select(async j =>
                {
                    if (result[j] != ' ' && result[j] != '\n')
                    {
                        await _resultAnimator.DOFadeChar(j, 1, 0.3f);
                    }
                }));
            }

        }

        /// <summary>
        /// 結果を非表示
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        async UniTask HideResult(CancellationToken ct)
        {
            // すべての文字を消す
            await UniTask.WhenAll(Enumerable.Range(0, _resultAnimator.textInfo.characterCount).Select(async i =>
            {
                if (_resultText.text[i] != ' ' && _resultText.text[i] != '\n')
                    await _resultAnimator.DOFadeChar(i, 0, 0.3f).WithCancellation(ct);
            }));
            await _resultBG.DOFade(0, 0.1f).WithCancellation(ct);
            _resultBG.gameObject.SetActive(false);
        }

        /// <summary>
        /// 選択されているカードを捨てて新しいカードを引く
        /// </summary>
        /// <param name="from"></param>
        /// <param name="count"></param>
        /// <param name="deck"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        async UniTask Change(int from, int count, List<int> deck, CancellationToken ct)
        {
            _isChanging = true;
            // 選択されているカードをトラッシュリストに追加
            _cards.ForEach(c =>
            {
                if (c.isSelectedSubject.Value)
                {
                    _trashList.Add(c.cardId);
                }
            });
            // 選択したカードを捨てる
            for (int i = from; i < from + count; i++)
            {
                if (_cards[i].isSelectedSubject.Value)
                {
                    await _cards[i].TrashCard(_trashPos, _deckPos, ct);
                    _trash.SetActive(true);
                }
            }
            // 捨てたカードの枚数分新しいカードを引く
            for (int i = from; i < from + count; i++)
            {
                if (_cards[i].isSelectedSubject.Value)
                {
                    int r = UnityEngine.Random.Range(0, deck.Count);
                    await _cards[i].DealCard(deck[r], _handPosList[i % 5], ct);
                    deck.RemoveAt(r);
                }
            }
            // カードの選択状態をすべてリセット
            _cards.ForEach(c => c.isSelectedSubject.Value = false);
            _isChanging = false;
        }

        /// <summary>
        /// ボタンが押されたときの処理
        /// </summary>
        public void OnClick()
        {
            if (_isClicked)
            {
                return;
            }
            _isClicked = true;
        }

        /// <summary>
        /// カードの初期位置を取得
        /// </summary>
        void initPos()
        {
            // 各カードの初期位置を取得
            List<RectTransform> cardRects = _handParent.GetComponentsInChildren<Card>().Select(c => c.GetComponent<RectTransform>()).ToList();

            // 0<=i<5
            var handRects = cardRects.Where((c, i) => i < 5).ToList();
            // 5<=i<10
            var stockRects = cardRects.Where((c, i) => 5 <= i && i < 10).ToList();
            // 10<=i<15
            var stockRects2 = cardRects.Where((c, i) => 10 <= i && i < 15).ToList();

            _handPosList = handRects.Select(r => r.anchoredPosition).ToList();
            _stockPosList = stockRects.Select(r => r.anchoredPosition).ToList();
            _stockPosList2 = stockRects2.Select(r => r.anchoredPosition).ToList();

            _deckPos = _deck.GetComponent<RectTransform>().anchoredPosition;
            _trashPos = _trash.GetComponent<RectTransform>().anchoredPosition;
        }
    }
}