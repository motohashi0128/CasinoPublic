using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using System.Linq;
using System.Threading;

namespace Poker
{
    public class Card : MonoBehaviour
    {

        [SerializeField]
        Color _front, _back;
        public int cardId { get; private set; }
        // public (string name, string suit, int num) idol { get; private set; }
        public (string name, string suit, string type, string planets, int num) idol { get; private set; }
        [HideInInspector]
        public Model model;


        [HideInInspector]
        public bool canClick;

        [HideInInspector]
        public ReactiveProperty<bool> isSelectedSubject = new ReactiveProperty<bool>(false);
        [HideInInspector]

        TextMeshProUGUI _idolText, _suitText, _typeText;
        Image _image;
        RectTransform _rect;

        const float _turnSpeed = 0.1f;
        const float _moveSpeed = 0.2f;

        const float _moveY = 50;

        void Awake()
        {
            // 子オブジェクトから取得
            _idolText = transform.Find("IdolText").GetComponent<TextMeshProUGUI>();
            _suitText = transform.Find("SuitText").GetComponent<TextMeshProUGUI>();
            _typeText = transform.Find("TypeText").GetComponent<TextMeshProUGUI>();
            _image = GetComponent<Image>();
            _rect = GetComponent<RectTransform>();
            cardId = -1;
            canClick = false;
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        /// <summary>
        /// カードをクリックしたときに呼ばれる処理
        /// </summary>
        void OnClick()
        {
            if (!canClick) return;
            if (isSelectedSubject.Value)
            {
                transform.DOLocalMoveY(-_moveY, 0.1f).SetRelative(true);
            }
            else
            {
                transform.DOLocalMoveY(_moveY, 0.1f).SetRelative(true);
            }
            isSelectedSubject.Value = !isSelectedSubject.Value;
        }

        /// <summary>
        /// カードを選択したとき、場にユニットの組み合わせがあるかどうかを確認して、あればカードを振る
        /// </summary>
        /// <param name="selected"></param>
        /// <param name="ct"></param>
        public void OutStandCard(int selected, CancellationToken ct)
        {
            // unitDictsを捜査して、List<int>にこのカードとselectedが両方あるかどうか
            for (int i = 0; i < model.availableRerlic.Count; i++)
            {
                var item = model.availableRerlic.ElementAt(i);
                ct.ThrowIfCancellationRequested();
                if (item.Value)
                {
                    CheckUnits(selected, item.Value, Units.all[item.Key], ct);
                }
            }
        }

        /// <summary>
        /// 利用可能なレリック内のユニットの組み合わせがあるかどうかを確認する
        /// </summary>
        /// <param name="selected"></param>
        /// <param name="availableRerlic"></param>
        /// <param name="unitDicts"></param>
        /// <param name="ct"></param>
        void CheckUnits(int selected, bool availableRerlic, Dictionary<string, List<int>> unitDicts, CancellationToken ct)
        {
            if (availableRerlic)
            {
                foreach (var item in unitDicts)
                {
                    ct.ThrowIfCancellationRequested();
                    if (item.Value.Contains(cardId) && item.Value.Contains(selected))
                    {
                        ShakeCard(ct).Forget();
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// カードを振る処理
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        async UniTask ShakeCard(CancellationToken ct)
        {
            await transform.DOLocalRotate(new Vector3(0, 0, 10), 0.1f).WithCancellation(ct);
            await transform.DOLocalRotate(new Vector3(0, 0, -10), 0.1f).WithCancellation(ct);
            await transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f).WithCancellation(ct);
        }

        /// <summary>
        /// カードを配る処理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pos"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async UniTask DealCard(int id, Vector2 pos, CancellationToken ct)
        {
            cardId = id;
            Debug.Log("id: " + id);
            // idからスートを取得して、スートによって文字色を変える
            string suit = Idols.idolList[id].suit == Suits.heart.suit ? Suits.heart.icon : Idols.idolList[id].suit == Suits.spade.suit ? Suits.spade.icon : Idols.idolList[id].suit == Suits.diamond.suit ? Suits.diamond.icon : Idols.idolList[id].suit == Suits.clover.suit ? Suits.clover.icon : Suits.joker.icon;
            if (suit == Suits.diamond.icon || suit == Suits.heart.icon)
            {
                _suitText.color = Color.red;
            }
            else
            {
                _suitText.color = Color.black;
            }
            // idから数字を取得して、AJQKを文字に変換
            string num = Idols.idolList[id].num == 0 ? "A" : Idols.idolList[id].num == 10 ? "J" : Idols.idolList[id].num == 11 ? "Q" : Idols.idolList[id].num == 12 ? "K" : (Idols.idolList[id].num + 1).ToString();
            // idからタイプを取得して、アイコンを設定
            string type = Idols.idolList[id].type == Suits.princess.type ? Suits.princess.icon : Idols.idolList[id].type == Suits.fairly.type ? Suits.fairly.icon : Idols.idolList[id].type == Suits.angel.type ? Suits.angel.icon : Idols.idolList[id].type == Suits.allstars.type ? Suits.allstars.icon : "";
            string planet = Idols.idolList[id].planets == Suits.star.planet ? Suits.star.icon : Idols.idolList[id].planets == Suits.moon.planet ? Suits.moon.icon : Idols.idolList[id].planets == Suits.sun.planet ? Suits.sun.icon : "";
            // 反映
            _suitText.text = suit + "\n" + num;
            _typeText.text = type + "\n" + planet;
            _idolText.text = Idols.idolList[id].name;
            idol = Idols.idolList[id];

            FaceDown();
            await transform.DOLocalMove(pos, _moveSpeed).WithCancellation(ct);
            await TurnFaceUp(ct);
        }

        /// <summary>
        /// カードを捨てる処理
        /// </summary>
        /// <param name="trashPos"></param>
        /// <param name="deckPos"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async UniTask TrashCard(Vector2 trashPos, Vector2 deckPos, CancellationToken ct)
        {

            await TurnFaceDown(ct);
            await transform.DOLocalMove(trashPos, _moveSpeed).WithCancellation(ct);
            _rect.anchoredPosition = deckPos;
        }

        /// <summary>
        /// カードを移動する処理
        /// </summary>
        /// <param name="pos"></param>
        public async UniTask MoveCard(Vector2 pos, CancellationToken ct)
        {
            await transform.DOLocalMove(pos, _moveSpeed).WithCancellation(ct);
        }

        /// <summary>
        /// カードをリセットする処理
        /// </summary>
        /// <param name="pos"></param>
        public void ResetCard(Vector2 pos)

        {
            isSelectedSubject.Value = false;
            cardId = -1;
            FaceDown();
            _rect.anchoredPosition = pos;
        }

        /// <summary>
        /// カードを裏返す処理（動きなし）
        /// </summary>
        public void FaceDown()
        {
            _image.color = _back;
            _suitText.gameObject.SetActive(false);
            _typeText.gameObject.SetActive(false);
            _idolText.gameObject.SetActive(false);
        }

        /// <summary>
        /// カードを裏返す処理（動きあり）
        /// </summary>
        async public UniTask TurnFaceDown(CancellationToken ct)
        {
            await transform.DORotate(new Vector3(0, 90, 0), _turnSpeed).WithCancellation(ct);
            _suitText.gameObject.SetActive(false);
            _typeText.gameObject.SetActive(false);
            _idolText.gameObject.SetActive(false);
            _image.color = _back;
            await transform.DORotate(new Vector3(0, 0, 0), _turnSpeed).WithCancellation(ct);
        }

        /// <summary>
        /// カードを表にする処理（動きあり）
        /// </summary>
        async public UniTask TurnFaceUp(CancellationToken ct)
        {
            await transform.DORotate(new Vector3(0, 90, 0), _turnSpeed).WithCancellation(ct);
            _suitText.gameObject.SetActive(true);
            _typeText.gameObject.SetActive(true);
            _idolText.gameObject.SetActive(true);
            _image.color = _front;
            await transform.DORotate(new Vector3(0, 0, 0), _turnSpeed).WithCancellation(ct);
        }
    }
}
