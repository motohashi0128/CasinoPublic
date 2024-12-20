using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Poker
{
    public class PokerCalc
    {
        /// <summary>
        /// 手札の役を判定
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="from"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string PorkerCheck(List<Card> cards, int from, int count)
        {
            string result = Hands.noPair;
            // _cardのfromからcountまでの数字を取得
            List<int> numHands = cards.Select(c => c.idol.num).ToList().GetRange(from, count);
            // _cardのfromからcountまでのスートを取得
            List<string> suitHands = cards.Select(c => c.idol.suit).ToList().GetRange(from, count);
            numHands.Sort();
            // ジョーカーが手札にある場合
            if (suitHands.Contains(Suits.joker.suit))
            {
                // ジョーカーありの場合 ジョーカーは-1
                // ジョーカー以外の手札で役を判定
                // 手札にジョーカーは何枚？
                int jokerCount = suitHands.Count(s => s == Suits.joker.suit);
                Debug.Log("ジョーカーあり: " + jokerCount + "枚");
                // ジョーカー以外の手札を取得
                numHands = numHands.Where(n => n != -1).ToList();
                suitHands = suitHands.Where(s => s != Suits.joker.suit).ToList();
                // ジョーカー以外の手札の数字をソート
                numHands.Sort();
                result = Hands.onePair;
                var pairCount = new Dictionary<int, int>();
                foreach (var num in numHands)
                {
                    if (pairCount.ContainsKey(num))
                    {
                        pairCount[num]++;
                    }
                    else
                    {
                        pairCount[num] = 1;
                    }
                }
                // ツーペアとスリーカードは同じ
                if (pairCount.ContainsValue(3 - jokerCount))
                {
                    result = Hands.twoPair;
                }
                // ストレート
                int diffCount = jokerCount;
                for (int i = 0; i < numHands.Count - 1; i++)
                {
                    Debug.Log("ストレート i: " + i);
                    if (numHands[i] == numHands[i + 1] - 1)
                    {
                        Debug.Log("ストレート: " + numHands[i] + ", " + numHands[i + 1]);
                        if (i == numHands.Count - 1 - 1)
                        {
                            Debug.Log("ストレート最後");
                            result = Hands.straight;
                        }
                        continue;
                    }
                    else
                    {
                        int diff = numHands[i + 1] - numHands[i];
                        if (diff > 1 && diffCount >= diff - 1)
                        {
                            diffCount -= diff - 1;
                            if (i == numHands.Count - 1 - 1)
                            {
                                Debug.Log("ストレート最後");
                                result = Hands.straight;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                // 10~Aのストレート
                if (numHands[0] == 0)
                {
                    var tmpHands = new List<int>(numHands);
                    tmpHands.Remove(0);
                    tmpHands.Add(13);
                    tmpHands.Sort();
                    diffCount = jokerCount;
                    for (int i = 0; i < tmpHands.Count - 1; i++)
                    {
                        Debug.Log("ストレート i: " + i);
                        if (tmpHands[i] == tmpHands[i + 1] - 1)
                        {
                            Debug.Log("ストレート: " + tmpHands[i] + ", " + tmpHands[i + 1]);
                            if (i == tmpHands.Count - 1 - 1)
                            {
                                Debug.Log("ストレート最後");
                                result = Hands.straight;
                            }
                            continue;
                        }
                        else
                        {
                            int diff = tmpHands[i + 1] - tmpHands[i];
                            if (diff > 1 && diffCount >= diff - 1)
                            {
                                diffCount -= diff - 1;
                                if (i == tmpHands.Count - 1 - 1)
                                {
                                    Debug.Log("ストレート最後");
                                    result = Hands.straight;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

                // フラッシュ
                if (suitHands.All(s => s == suitHands[0]))
                {
                    if (result == Hands.straight)
                    {
                        result = Hands.straightFlush;
                    }
                    else
                    {
                        result = Hands.flush;
                    }
                }
                // フラッシュより高いがストレートフラッシュより低い役
                if (result != Hands.straightFlush)
                {
                    // フルハウス
                    if (pairCount.Count(kv => kv.Value == 2) == 2)
                    {
                        result = Hands.fullHouse;
                    }
                    // フォーカード
                    if (pairCount.ContainsValue(4 - jokerCount))
                    {
                        result = Hands.fourOfAKind;
                    }
                }
                // ファイブカード
                if (pairCount.ContainsValue(5 - jokerCount))
                {
                    result = Hands.fiveOfAKind;
                }
                // ジョーカー入りなのでロイヤルストレートフラッシュはなし
            }
            // ジョーカーが手札に無い場合
            else
            {
                var pairCount = new Dictionary<int, int>();
                foreach (var num in numHands)
                {
                    if (pairCount.ContainsKey(num))
                    {
                        pairCount[num]++;
                    }
                    else
                    {
                        pairCount[num] = 1;
                    }
                }
                // ワンペア
                if (pairCount.ContainsValue(2))
                {
                    result = Hands.onePair;
                }
                // ツーペア
                if (pairCount.Count(kv => kv.Value == 2) == 2)
                {
                    result = Hands.twoPair;
                }
                // スリーカード
                if (pairCount.ContainsValue(3))
                {
                    result = Hands.threeOfAKind;
                }
                // ストレート
                if (numHands[0] == numHands[1] - 1 && numHands[1] == numHands[2] - 1 && numHands[2] == numHands[3] - 1 && numHands[3] == numHands[4] - 1)
                {
                    result = Hands.straight;
                }
                if (numHands[0] == 0 && numHands[1] == 9 && numHands[2] == 10 && numHands[3] == 11 && numHands[4] == 12)
                {
                    result = Hands.straight;
                }
                // フラッシュ
                if (suitHands.All(s => s == suitHands[0]))
                {
                    if (result == Hands.straight)
                    {
                        if (numHands[0] == 0 && numHands[4] == 12)
                        {
                            result = Hands.royalStraightFlush;
                        }
                        result = Hands.straightFlush;
                    }
                    else
                    {
                        result = Hands.flush;
                    }
                }
                if (result != Hands.straightFlush && result != Hands.royalStraightFlush)
                {
                    // フルハウス
                    if (pairCount.ContainsValue(3) && pairCount.ContainsValue(2))
                    {
                        result = Hands.fullHouse;
                    }
                    // フォーカード
                    if (pairCount.ContainsValue(4))
                    {
                        result = Hands.fourOfAKind;

                    }
                    if (result != Hands.royalStraightFlush)
                    {
                        // ファイブカード
                        if (pairCount.ContainsValue(5))
                        {
                            result = Hands.fiveOfAKind;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 場のカードにどのユニットが含まれているか判定
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cards"></param>
        /// <returns></returns>
        public static string UnitsCheck(Model model, List<Card> cards)
        {
            bool hasMatch = false;
            string result = "";
            // ユニットのリストを捜査して、場のカードに含まれているユニットを判定
            foreach (var item in Units.all)
            {
                RerlicCheck(model, item.Key, item.Value, cards, ref result, ref hasMatch);
            }

            if (!hasMatch)
            {
                Debug.Log(Units.noMatch);
                result = Units.noMatch;
            }
            else
            {
                // resultの最後の改行を削除
                result = result.Remove(result.Length - 1);
            }
            return result;
        }

        /// <summary>
        /// レリック(ユニットのまとまり)ごとに場のカードに含まれているユニットを判定
        /// 現状、最初から全レリックが利用可能となっているが、将来的には勝つたびに増えていく仕様にする
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rerlicKey"></param>
        /// <param name="dict"></param>
        /// <param name="cards"></param>
        /// <param name="result"></param>
        /// <param name="hasMatch"></param>
        static void RerlicCheck(Model model, string rerlicKey, Dictionary<string, List<int>> dict, List<Card> cards, ref string result, ref bool hasMatch)
        {
            // レリックが利用可能かどうか
            if (model.availableRerlic[rerlicKey])
            {
                // レリックのユニットを走査
                foreach (var unit in dict)
                {
                    bool isMatch = false;
                    List<int> idols = new List<int>();
                    //　場のカードのidolをリストに追加
                    cards.ForEach(c =>
                    {
                        idols.Add(c.cardId);
                    });
                    // ユニットのカードが場のカードの数以上かどうか
                    if (unit.Value.Count >= cards.Count)
                    {
                        // ユニットのカードが場のカードに全て含まれているか
                        isMatch = idols.All(x => unit.Value.Contains(x));
                        if (isMatch)
                        {
                            Debug.Log(unit.Key);
                            result += unit.Key + "\n";
                            hasMatch = true;
                        }
                    }
                    else
                    {
                        // ユニットのカードが場のカードに全て含まれているか
                        isMatch = unit.Value.All(x => idols.Contains(x));
                        if (isMatch)
                        {
                            Debug.Log(unit.Key);
                            result += unit.Key + "\n";
                            hasMatch = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ハンドの役に応じて倍率を返す
        /// </summary>
        /// <param name="resultText"></param>
        /// <param name="coef"></param>
        /// <returns></returns>
        public static float GetPokerRate(TextMeshProUGUI resultText, float coef)
        {
            float rate = 1;
            string result = resultText.text;
            if (result == Hands.noPair)
            {
                rate = 0;
            }
            else if (result == Hands.onePair)
            {
                rate = 1f;
            }
            else if (result == Hands.twoPair)
            {
                rate = 2;
            }
            else if (result == Hands.threeOfAKind)
            {
                rate = 2;
            }
            else if (result == Hands.straight)
            {
                rate = 4;
            }
            else if (result == Hands.flush)
            {
                rate = 5;
            }
            else if (result == Hands.fullHouse)
            {
                rate = 10;
            }
            else if (result == Hands.fourOfAKind)
            {
                rate = 20;
            }
            else if (result == Hands.straightFlush)
            {
                rate = 25;
            }
            else if (result == Hands.fiveOfAKind)
            {
                rate = 60;
            }
            else if (result == Hands.royalStraightFlush)
            {
                rate = 250;
            }

            return rate * coef;
        }

        /// <summary>
        /// 場のカードに含まれるユニットに応じて倍率を返す
        /// </summary>
        /// <param name="resultText"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int GetUnitRate(TextMeshProUGUI resultText, Model model)
        {
            int rate = 1;
            string result = resultText.text;
            var lines = result.Split('\n');
            int unitCount = 0;
            foreach (var item in lines)
            {
                unitCount = 0;
                if (Units.ltp_all.ContainsKey(item) && model.availableRerlic["LTP"])
                {
                    unitCount = Units.ltp_all[item].Count;
                }

                else if (Units.lth_all.ContainsKey(item) && model.availableRerlic["LTH"])
                {
                    unitCount = Units.lth_all[item].Count;
                }

                else if (Units.ltd_02.ContainsKey(item) && model.availableRerlic["LTD_02"])
                {
                    unitCount = Units.ltd_02[item].Count;
                }
                else if (Units.ltd_03.ContainsKey(item) && model.availableRerlic["LTD_03"])
                {
                    unitCount = Units.ltd_03[item].Count;
                }
                else if (Units.ltd_04.ContainsKey(item) && model.availableRerlic["LTD_04"])
                {
                    unitCount = Units.ltd_04[item].Count;
                }
                else if (Units.ltd_05.ContainsKey(item) && model.availableRerlic["LTD_05"])
                {
                    unitCount = Units.ltd_05[item].Count;
                }
                else if (Units.ltd_06.ContainsKey(item) && model.availableRerlic["LTD_06"])
                {
                    unitCount = Units.ltd_06[item].Count;
                }

                else if (Units.ltf_sun.ContainsKey(item) && model.availableRerlic["LTF_SUN"])
                {
                    unitCount = Units.ltf_sun[item].Count;
                }
                else if (Units.ltf_moon.ContainsKey(item) && model.availableRerlic["LTF_MOON"])
                {
                    unitCount = Units.ltf_moon[item].Count;
                }
                else if (Units.ltf_star.ContainsKey(item) && model.availableRerlic["LTF_STAR"])
                {
                    unitCount = Units.ltf_star[item].Count;
                }

                else if (Units.mtg_princess.ContainsKey(item) && model.availableRerlic["MTG_PR"])
                {
                    unitCount = Units.mtg_princess[item].Count;
                }
                else if (Units.mtg_fairy.ContainsKey(item) && model.availableRerlic["MTG_FA"])
                {
                    unitCount = Units.mtg_fairy[item].Count;
                }
                else if (Units.mtg_angel.ContainsKey(item) && model.availableRerlic["MTG_AN"])
                {
                    unitCount = Units.mtg_angel[item].Count;
                }

                else if (Units.mtw_all.ContainsKey(item) && model.availableRerlic["MTW"])
                {
                    unitCount = Units.mtw_all[item].Count;
                }

                else if (Units.mts_diamond.ContainsKey(item) && model.availableRerlic["MTS_DIAMOND"])
                {
                    unitCount = Units.mts_diamond[item].Count;
                }
                else if (Units.mts_clover.ContainsKey(item) && model.availableRerlic["MTS_CLOVER"])
                {
                    unitCount = Units.mts_clover[item].Count;
                }
                else if (Units.mts_heart.ContainsKey(item) && model.availableRerlic["MTS_HEART"])
                {
                    unitCount = Units.mts_heart[item].Count;
                }
                else if (Units.mts_spade.ContainsKey(item) && model.availableRerlic["MTS_SPADE"])
                {
                    unitCount = Units.mts_spade[item].Count;
                }

                else if (Units.mtv_all.ContainsKey(item) && model.availableRerlic["MTV"])
                {
                    unitCount = Units.mtv_all[item].Count;
                }

                else if (Units.drama_all.ContainsKey(item) && model.availableRerlic["DRAMA"])
                {
                    unitCount = Units.drama_all[item].Count;
                }
                else if (Units.anime_all.ContainsKey(item) && model.availableRerlic["ANIME"])
                {
                    unitCount = Units.anime_all[item].Count;
                }

                else if (Units.fes_first.ContainsKey(item) && model.availableRerlic["FES_FIRST"])
                {
                    unitCount = Units.fes_first[item].Count;
                }
                else if (Units.fes_latter.ContainsKey(item) && model.availableRerlic["FES_LATTER"])
                {
                    unitCount = Units.fes_latter[item].Count;
                }

                else if (Units.ex_all.ContainsKey(item) && model.availableRerlic["EX"])
                {
                    unitCount = Units.ex_all[item].Count;
                    if (unitCount == 1)
                    {
                        unitCount = 2;
                    }
                }
                Debug.Log("Unit: " + item);
                Debug.Log("Unit count: " + unitCount);
                switch (unitCount)
                {
                    case 2:
                        rate *= 2;
                        break;
                    case 3:
                        rate *= 3;
                        break;
                    case 4:
                        rate *= 5;
                        break;
                    case 5:
                        rate *= 10;
                        break;
                    case 6:
                        rate *= 20;
                        break;
                    case 13:
                        rate *= 60;
                        break;
                    case 16:
                        rate *= 50;
                        break;
                    case 17:
                        rate *= 50;
                        break;
                }
            }
            return rate;
        }

    }
}
