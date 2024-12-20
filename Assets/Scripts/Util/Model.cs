using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Poker
{
    public class Model : MonoBehaviour
    {
        // 今は全員入りのデッキを使っているが、選択可能なデッキを増やすことを考慮してリストで持つ
        public ReactiveProperty<List<int>> selectedDeck = new ReactiveProperty<List<int>>(Decks.all);
        // レリックの入手状況を管理するDictionary
        // 今はまだ入手フェーズができていないので、開始時に全てのレリックをtrueにしている
        public Dictionary<string, bool> availableRerlic = new Dictionary<string, bool>(){
            {"LTP", false},

            {"LTH", false},

            {"LTD_02", false},
            {"LTD_03", false},
            {"LTD_04", false},
            {"LTD_05", false},
            {"LTD_06", false},

            {"LTF_SUN", false},
            {"LTF_MOON", false},
            {"LTF_STAR", false},

            {"MTG_PR",false},
            {"MTG_FA",false},
            {"MTG_AN",false},

            {"MTW",false},

            {"MTS_DIAMOND",false},
            {"MTS_CLOVER",false},
            {"MTS_HEART",false},
            {"MTS_SPADE",false},

            {"MTV",false},

            {"ANIME",false},

            {"DRAMA",false},

            {"FES_FIRST",false},
            {"FES_LATTER",false},

            {"EX",false},
        };
        // 全てのレリックをtureにする
        public void SetAllAvailable()
        {
            var tmp = new List<string>(availableRerlic.Keys);
            foreach (var key in tmp)
            {
                availableRerlic[key] = true;
            }
        }
        // 全てのレリックをfalseにする
        public void SetAllUnavailable()
        {
            var tmp = new List<string>(availableRerlic.Keys);
            foreach (var key in tmp)
            {
                availableRerlic[key] = false;
            }
        }
    }
}