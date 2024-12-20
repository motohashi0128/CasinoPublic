using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Poker
{
    public class Decks
    {
        public enum DECK_TYPE
        {
            PR,
            FA,
            AN,
            PRFA,
            PRAN,
            FAAN,
            ALL,
        }
        public static readonly List<int> single_pr = new List<int> {
        25, 27, 29, 18, 26, 28, 36, 42, 20, 31, 13, 16, 35,
        25, 27, 29, 18, 26, 28, 36, 42, 20, 31, 13, 16, 35,
        25, 27, 29, 18, 26, 28, 36, 42, 20, 31, 13, 16, 35,
        25, 27, 29, 18, 26, 28, 36, 42, 20, 31, 13, 16, 35,
        52, 53,
    };
        public static readonly List<int> single_fa = new List<int> {
        19, 30, 37, 45, 32, 43, 50, 14, 49, 24, 33, 46, 48,
        19, 30, 37, 45, 32, 43, 50, 14, 49, 24, 33, 46, 48,
        19, 30, 37, 45, 32, 43, 50, 14, 49, 24, 33, 46, 48,
        19, 30, 37, 45, 32, 43, 50, 14, 49, 24, 33, 46, 48,
        52, 53,
    };
        public static readonly List<int> single_an = new List<int>{
        17, 41, 38, 40, 47, 51, 15, 22, 44, 21, 23, 34, 39,
        17, 41, 38, 40, 47, 51, 15, 22, 44, 21, 23, 34, 39,
        17, 41, 38, 40, 47, 51, 15, 22, 44, 21, 23, 34, 39,
        17, 41, 38, 40, 47, 51, 15, 22, 44, 21, 23, 34, 39,
        52, 53,
    };
        public static readonly List<int> double_prfa = new List<int> {
        25, 27, 29, 18, 26, 28, 36, 42, 20, 31, 13, 16, 35,
        25, 27, 29, 18, 26, 28, 36, 42, 20, 31, 13, 16, 35,
        19, 30, 37, 45, 32, 43, 50, 14, 49, 24, 33, 46, 48,
        19, 30, 37, 45, 32, 43, 50, 14, 49, 24, 33, 46, 48,
        52, 53,
    };
        public static readonly List<int> double_pran = new List<int> {
        25, 27, 29, 18, 26, 28, 36, 42, 20, 31, 13, 16, 35,
        25, 27, 29, 18, 26, 28, 36, 42, 20, 31, 13, 16, 35,
        17, 41, 38, 40, 47, 51, 15, 22, 44, 21, 23, 34, 39,
        17, 41, 38, 40, 47, 51, 15, 22, 44, 21, 23, 34, 39,
        52, 53,
    };
        public static readonly List<int> double_faan = new List<int> {
        19, 30, 37, 45, 32, 43, 50, 14, 49, 24, 33, 46, 48,
        19, 30, 37, 45, 32, 43, 50, 14, 49, 24, 33, 46, 48,
        17, 41, 38, 40, 47, 51, 15, 22, 44, 21, 23, 34, 39,
        17, 41, 38, 40, 47, 51, 15, 22, 44, 21, 23, 34, 39,
        52, 53,
    };
        public static readonly List<int> all = new List<int> {
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
        13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25,
        26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38,
        39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51,
        52, 53,
    };
    }
}