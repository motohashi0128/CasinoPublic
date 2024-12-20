using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Poker
{
    public class Units
    {
        public static readonly string noMatch = "No Match";
        /// レリックごとにユニットのIDをリストで持つ
        // LTP
        public static readonly Dictionary<string, List<int>> ltp_all = new Dictionary<string, List<int>>
        {
            { "LTP_UNIT0",new List<int>(){0,14,21,25,30,}},
            { "LTP_UNIT1",new List<int>(){12,13,23,36,40,}},
            { "LTP_UNIT2",new List<int>(){1,16,19,32,}},
            { "LTP_UNIT3",new List<int>(){6,31,43,45,}},
            { "LTP_UNIT4",new List<int>(){2,15,47,49,}},
            { "LTP_UNIT5",new List<int>(){9,26,42,44,}},
            { "LTP_UNIT6",new List<int>(){4,29,35,39,}},
            { "LTP_UNIT7",new List<int>(){8,18,27,34,}},
            { "LTP_UNIT8",new List<int>(){7,20,28,41,}},
            { "LTP_UNIT9",new List<int>(){5,11,17,33,}},
            { "LTP_UNIT10",new List<int>(){3,24,37,48,}},
            { "LTP_UNIT11",new List<int>(){10,22,38,46,}},
        };
        // LTH
        public static readonly Dictionary<string, List<int>> lth_all = new Dictionary<string, List<int>>
        {
            { "LTH_UNIT0",new List<int>(){4,6,8,10,12,}},
            { "LTH_UNIT1",new List<int>(){13,15,23,25,43,}},
            { "LTH_UNIT2",new List<int>(){14,21,22,32,47,}},
            { "LTH_UNIT3",new List<int>(){1,20,31,40,49,}},
            { "LTH_UNIT4",new List<int>(){0,27,36,42,48,}},
            { "LTH_UNIT5",new List<int>(){16,19,28,39,41}},
            { "LTH_UNIT6",new List<int>(){3,5,9,33,35,}},
            { "LTH_UNIT7",new List<int>(){11,18,29,34,38,}},
            { "LTH_UNIT8",new List<int>(){2,26,30,37,46,}},
            { "LTH_UNIT9",new List<int>(){7,17,24,44,45,}},
        };
        // LTD
        public static readonly Dictionary<string, List<int>> ltd_02 = new Dictionary<string, List<int>>
        {
            { "LTD02_UNIT0",new List<int>(){0,13,}},
            { "LTD02_UNIT1",new List<int>(){23,25,}},
            { "LTD02_UNIT2",new List<int>(){19,49,}},
            { "LTD02_UNIT3",new List<int>(){4,35,}},
            { "LTD02_UNIT4",new List<int>(){32,47,}},
        };
        public static readonly Dictionary<string, List<int>> ltd_03 = new Dictionary<string, List<int>>
        {
            { "LTD03_UNIT0",new List<int>(){1,14,}},
            { "LTD03_UNIT1",new List<int>(){3,37,}},
            { "LTD03_UNIT2",new List<int>(){43,48,}},
            { "LTD03_UNIT3",new List<int>(){21,41,}},
            { "LTD03_UNIT4",new List<int>(){20,38,}},
        };
        public static readonly Dictionary<string, List<int>> ltd_04 = new Dictionary<string, List<int>>
        {
            { "LTD04_UNIT0",new List<int>(){12,15,}},
            { "LTD04_UNIT1",new List<int>(){29,30,}},
            { "LTD04_UNIT2",new List<int>(){8,44,}},
            { "LTD04_UNIT3",new List<int>(){6,31,}},
            { "LTD04_UNIT4",new List<int>(){18,26,}},
        };
        public static readonly Dictionary<string, List<int>> ltd_05 = new Dictionary<string, List<int>>
        {
            { "LTD05_UNIT0",new List<int>(){10,34,}},
            { "LTD05_UNIT1",new List<int>(){22,24,}},
            { "LTD05_UNIT2",new List<int>(){27,36,}},
            { "LTD05_UNIT3",new List<int>(){7,40,}},
            { "LTD05_UNIT4",new List<int>(){9,45,}},
        };
        public static readonly Dictionary<string, List<int>> ltd_06 = new Dictionary<string, List<int>>
        {
            { "LTD06_UNIT0",new List<int>(){16,28,}},
            { "LTD06_UNIT1",new List<int>(){11,39,}},
            { "LTD06_UNIT2",new List<int>(){5,33,}},
            { "LTD06_UNIT3",new List<int>(){2,17,}},
            { "LTD06_UNIT4",new List<int>(){42,46,}},
        };
        // LTF
        public static readonly Dictionary<string, List<int>> ltf_sun = new Dictionary<string, List<int>>
        {
            { "LTF_SUN_UNIT0",new List<int>(){31,34,36,}},
            { "LTF_SUN_UNIT1",new List<int>(){17,24,29,}},
            { "LTF_SUN_UNIT2",new List<int>(){15,18,42,}},
            { "LTF_SUN_UNIT3",new List<int>(){23,35,45,}},
            { "LTF_SUN_UNIT4",new List<int>(){2,4,8,10,11,}},
            { "LTF_SUN_UNIT5",new List<int>(){ 2, 4, 8, 10, 11, 15, 17, 18, 19, 24, 29, 31, 34, 36, 42, 43, 51, }},
        };
        public static readonly Dictionary<string, List<int>> ltf_moon = new Dictionary<string, List<int>>
        {
            { "LTF_MOON_UNIT0",new List<int>(){19,33,43,}},
            { "LTF_MOON_UNIT1",new List<int>(){30,37,44,}},
            { "LTF_MOON_UNIT2",new List<int>(){14,25,46,}},
            { "LTF_MOON_UNIT3",new List<int>(){26,47,49,}},
            { "LTF_MOON_UNIT4",new List<int>(){1,5,9,12,}},
            { "LTF_MOON_UNIT5",new List<int>(){ 1, 5, 9, 12, 14, 19, 25, 26, 30, 33, 37, 43, 44, 46, 47, 49, 50, }},
        };
        public static readonly Dictionary<string, List<int>> ltf_star = new Dictionary<string, List<int>>
        {
            { "LTF_STAR_UNIT0",new List<int>(){16,27,28,32,}},
            { "LTF_STAR_UNIT1",new List<int>(){21,22,39,}},
            { "LTF_STAR_UNIT2",new List<int>(){13,20,41,}},
            { "LTF_STAR_UNIT3",new List<int>(){38,40,48,}},
            { "LTF_STAR_UNIT4",new List<int>(){0,3,6,7,}},
            { "LTF_STAR_UNIT5",new List<int>(){ 0, 3, 6, 7, 13, 16, 20, 21, 22, 27, 28, 32, 38, 39, 40, 41, 48, }},
        };
        // MTG
        public static readonly Dictionary<string, List<int>> mtg_princess = new Dictionary<string, List<int>>
        {
            { "MTG_PR_UNIT0",new List<int>(){25,27,29,}},
            { "MTG_PR_UNIT1",new List<int>(){18,26,28,36,42,}},
            { "MTG_PR_UNIT2",new List<int>(){20,31,}},
            { "MTG_PR_UNIT3",new List<int>(){13,16,35,}},
            { "MTG_PR_UNIT4",new List<int>(){13,16,18,20,25,26,27,28,29,31,35,36,42,}},
        };
        public static readonly Dictionary<string, List<int>> mtg_fairy = new Dictionary<string, List<int>>
        {
            { "MTG_FA_UNIT0",new List<int>(){19,30,37,45,}},
            { "MTG_FA_UNIT1",new List<int>(){32,43,50,}},
            { "MTG_FA_UNIT2",new List<int>(){14,49,}},
            { "MTG_FA_UNIT3",new List<int>(){24,33,46,48,}},
            { "MTG_FA_UNIT4",new List<int>(){14,19,24,30,32,33,37,43,45,46,48,49,50,}},
        };
        public static readonly Dictionary<string, List<int>> mtg_angel = new Dictionary<string, List<int>>
        {
            { "MTG_AN_UNIT0",new List<int>(){17,41,}},
            { "MTG_AN_UNIT1",new List<int>(){38,40,47,51,}},
            { "MTG_AN_UNIT2",new List<int>(){15,22,44,}},
            { "MTG_AN_UNIT3",new List<int>(){21,23,34,39,}},
            { "MTG_AN_UNIT4",new List<int>(){15,17,21,22,23,34,48,49,40,41,44,47,51,}},
        };
        // MTW
        public static readonly Dictionary<string, List<int>> mtw_all = new Dictionary<string, List<int>>
        {
            { "MTW_UNIT0", new List<int>() { 23, 24, 25, 43, 46, } },
            { "MTW_UNIT1", new List<int>() { 2, 3, 5, 6, } },
            { "MTW_UNIT2", new List<int>() { 38, 45, } },
            { "MTW_UNIT3", new List<int>() { 1, 7, 9, } },
            { "MTW_UNIT4", new List<int>() { 30, 31, 50, } },
            { "MTW_UNIT5", new List<int>() { 18, 36, } },
            { "MTW_UNIT6", new List<int>() { 17, 28, 33, 42, } },
            { "MTW_UNIT7", new List<int>() { 21, 34, 41, 44, } },
            { "MTW_UNIT8", new List<int>() { 16, 20, 32, 51, } },
            { "MTW_UNIT9", new List<int>() { 0, 4, 12, } },
            { "MTW_UNIT10", new List<int>() { 29, 39, 48, } },
            { "MTW_UNIT11", new List<int>() { 22, 47, } },
            { "MTW_UNIT12", new List<int>() { 26, 37, 40, 49, } },
            { "MTW_UNIT13", new List<int>() { 19, 27, 35, } },
            { "MTW_UNIT14", new List<int>() { 8, 10, 11, } },
            { "MTW_UNIT15", new List<int>() { 13, 14, 15, } },
        };
        // MTS
        public static readonly Dictionary<string, List<int>> mts_diamond = new Dictionary<string, List<int>>
        {
            { "MTS_DIAMOND_UNIT0", new List<int>() { 7, 15, 19, 20, } },
            { "MTS_DIAMOND_UNIT1", new List<int>() { 3, 10, 16, 45, } },
            { "MTS_DIAMOND_UNIT2", new List<int>() { 6, 13, 41, 48, 51, } },
            { "MTS_DIAMOND_UNIT3", new List<int>() { 3, 6, 7, 10, 13, 15, 16, 19, 20, 41, 45, 48, 51, } },
        };
        public static readonly Dictionary<string, List<int>> mts_clover = new Dictionary<string, List<int>>
        {
            { "MTS_CLOVER_UNIT0", new List<int>() { 9, 21, 24, 28, } },
            { "MTS_CLOVER_UNIT1", new List<int>() { 5, 17, 37, 43, } },
            { "MTS_CLOVER_UNIT2", new List<int>() { 8, 34, 36, 38, 39, } },
            { "MTS_CLOVER_UNIT3", new List<int>() { 5, 8, 9, 17, 21, 24, 28, 34, 36, 37, 38, 39, 43, } },
        };
        public static readonly Dictionary<string, List<int>> mts_heart = new Dictionary<string, List<int>>
        {
            { "MTS_HEART_UNIT0", new List<int>() { 4, 18, 25, 30, } },
            { "MTS_HEART_UNIT1", new List<int>() { 1, 26, 27, 42, 47, } },
            { "MTS_HEART_UNIT2", new List<int>() { 0, 23, 35, 49, } },
            { "MTS_HEART_UNIT3", new List<int>() { 0, 1, 4, 18, 23, 25, 26, 27, 30, 35, 42, 47, 49, } },
        };
        public static readonly Dictionary<string, List<int>> mts_spade = new Dictionary<string, List<int>>
        {
            { "MTS_SPADE_UNIT0", new List<int>() { 2, 14, 29, 33, 44, } },
            { "MTS_SPADE_UNIT1", new List<int>() { 10, 31, 32, 46, } },
            { "MTS_SPADE_UNIT2", new List<int>() { 12, 22, 40, 50, } },
            { "MTS_SPADE_UNIT3", new List<int>() { 2, 10, 12, 14, 22, 29, 31, 32, 33, 40, 44, 46, 50, } },
        };
        // MTV
        public static readonly Dictionary<string, List<int>> mtv_all = new Dictionary<string, List<int>>
        {
            { "MTV_UNIT0", new List<int>() {12,18,29,33,44,} },
            { "MTV_UNIT1", new List<int>() {13,19,22,23,26,} },
            { "MTV_UNIT2", new List<int>() {9,20,39,42,50,} },
            { "MTV_UNIT3", new List<int>() {11,15,30,35,47,} },
            { "MTV_UNIT4", new List<int>() {3,5,14,42,46,} },
            { "MTV_UNIT5", new List<int>() {1,20,30,34,38,} },
            { "MTV_UNIT6", new List<int>() {12,28,36,41,43,} },
            { "MTV_UNIT7", new List<int>() {7,9,37,40,47,} },
            { "MTV_UNIT8", new List<int>() {6,26,33,45,46,} },
            { "MTV_UNIT9", new List<int>() {2,4,23,34,49,} },
        };
        // DRAMA
        public static readonly Dictionary<string, List<int>> drama_all = new Dictionary<string, List<int>>
        {
            { "DRAMA_UNIT0", new List<int>() {21,24,25,30,36,} },
            { "DRAMA_UNIT1", new List<int>() {34,39,42,48,49,} },
            { "DRAMA_UNIT2", new List<int>() {18,35,43,44,47,} },
            { "DRAMA_UNIT3", new List<int>() {19,26,28,36,40,} },
            { "DRAMA_UNIT4", new List<int>() {14,23,41,45,51,} },
            { "DRAMA_UNIT5", new List<int>() {16,38,43,48,50,} },
            { "DRAMA_UNIT6", new List<int>() {12,20,21,46,48,} },
            { "DRAMA_UNIT7", new List<int>() {0,1,2,5,31,} },
            { "DRAMA_UNIT8", new List<int>() {17,22,32,37,51,} },
            { "DRAMA_UNIT9", new List<int>() {7,29,38,43,48,} },
            { "DRAMA_UNIT10", new List<int>() {15,21,24,33,47,} },
            { "DRAMA_UNIT11", new List<int>() {13,16,25,32,40,} },
            { "DRAMA_UNIT12", new List<int>() {5,6,14,27,35,} },
        };
        // ANIME
        public static readonly Dictionary<string, List<int>> anime_all = new Dictionary<string, List<int>>
        {
            { "ANIME_UNIT0", new List<int>() {18,23,30,32,} },
            { "ANIME_UNIT1", new List<int>() {28,42,43,44,45,} },
            { "ANIME_UNIT2", new List<int>() {16,19,25,39,40,} },
            { "ANIME_UNIT3", new List<int>() {24,27,36,37,38,48,} },
            { "ANIME_UNIT4", new List<int>() {21,22,26,27,29,} },
            { "ANIME_UNIT5", new List<int>() {17,20,31,34,46,} },
            { "ANIME_UNIT6", new List<int>() {33,35,47,49,} },
            { "ANIME_UNIT7", new List<int>() {13,14,15,50,51,} },
        };
        // FES
        public static readonly Dictionary<string, List<int>> fes_first = new Dictionary<string, List<int>>
        {
            { "FES_FIRST_UNIT0",new List<int>(){32,35,}},
            { "FES_FIRST_UNIT1",new List<int>(){2,7,12,}},
            { "FES_FIRST_UNIT2",new List<int>(){16,17,19}},
            { "FES_FIRST_UNIT3",new List<int>(){29,48,6}},
            { "FES_FIRST_UNIT4",new List<int>(){23,25,}},
            { "FES_FIRST_UNIT5",new List<int>(){0,44,}},
            { "FES_FIRST_UNIT6",new List<int>(){20,30,41,}},
            { "FES_FIRST_UNIT7",new List<int>(){40,45,}},
            { "FES_FIRST_UNIT8",new List<int>(){18,43,}},
            { "FES_FIRST_UNIT9",new List<int>(){28,39,}},
        };
        public static readonly Dictionary<string, List<int>> fes_latter = new Dictionary<string, List<int>>
        {
            { "FES_LATTER_UNIT0",new List<int>(){47,49,}},
            { "FES_LATTER_UNIT1",new List<int>(){5,34,}},
            { "FES_LATTER_UNIT2",new List<int>(){1,26,}},
            { "FES_LATTER_UNIT3",new List<int>(){22,36,}},
            { "FES_LATTER_UNIT4",new List<int>(){24,38,}},
            { "FES_LATTER_UNIT5",new List<int>(){9,42,}},
            { "FES_LATTER_UNIT6",new List<int>(){27,46,}},
            { "FES_LATTER_UNIT7",new List<int>(){37,10,}},
            { "FES_LATTER_UNIT8",new List<int>(){3,33,}},
            { "FES_LATTER_UNIT9",new List<int>(){8,11,}},
        };
        // ex
        public static readonly Dictionary<string, List<int>> ex_all = new Dictionary<string, List<int>>
        {
            { "EX_UNIT0", new List<int>() { 50, 51, } },
            { "EX_UNIT1", new List<int>() { 17, 41, 53, } },
            { "EX_UNIT2", new List<int>() { 52, } },
            { "EX_UNIT3", new List<int>() { 53, } },
            { "EX_UNIT4", new List<int>() { 13, 14, 21, } },
            { "EX_UNIT5", new List<int>() { 15, 28, } },
            { "EX_UNIT6", new List<int>() { 5, 22, 49, 50, 51, } },
            { "EX_UNIT7", new List<int>() { 37, 38, 40, 45, 51, } },
            { "EX_UNIT8", new List<int>() { 23, 28, 50, } },
            { "EX_UNIT9", new List<int>() { 9, 28, 29, } },
            { "EX_UNIT10", new List<int>() { 18, 19, 48, 50, } },
            { "EX_UNIT11", new List<int>() { 1, 44, 46, } },
            { "EX_UNIT12", new List<int>() { 21, 28, 32, 35, } },
            { "EX_UNIT13", new List<int>() { 25, 38, 48, } },
            { "EX_UNIT14", new List<int>() { 15, 43, 49, } },
        };

        // レリックの名前と中身のDictionaryを管理するDictionary
        public static readonly Dictionary<string, Dictionary<string, List<int>>> all = new Dictionary<string, Dictionary<string, List<int>>>
        {
            {"LTP", ltp_all},
            {"LTH", lth_all},
            {"LTD_02", ltd_02},
            {"LTD_03", ltd_03},
            {"LTD_04", ltd_04},
            {"LTD_05", ltd_05},
            {"LTD_06", ltd_06},
            {"LTF_SUN", ltf_sun},
            {"LTF_MOON", ltf_moon},
            {"LTF_STAR", ltf_star},
            {"MTG_PR", mtg_princess},
            {"MTG_FA", mtg_fairy},
            {"MTG_AN", mtg_angel},
            {"MTW", mtw_all},
            {"MTS_DIAMOND", mts_diamond},
            {"MTS_CLOVER", mts_clover},
            {"MTS_HEART", mts_heart},
            {"MTS_SPADE", mts_spade},
            {"MTV", mtv_all},
            {"ANIME", anime_all},
            {"DRAMA", drama_all},
            {"FES_FIRST", fes_first},
            {"FES_LATTER", fes_latter},
            {"EX", ex_all},
        };
    }
}