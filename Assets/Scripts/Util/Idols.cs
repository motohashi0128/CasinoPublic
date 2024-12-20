using System;
using System.Collections;
using System.Collections.Generic;

namespace Poker
{
    public class Idols
    {
        // 52枚のカードに対応するキャラクターのリスト
        public static readonly List<(string name, string suit, string type, string planets, int num)> idolList = new List<(string name, string suit, string type, string planets, int num)>() {
            ("Character0",      Suits.heart.suit,       Suits.allstars.type,    Suits.star.planet,  0   ),  ("Character1",      Suits.heart.suit,       Suits.allstars.type,    Suits.moon.planet,  12  ),
            ("Character2",      Suits.spade.suit,       Suits.allstars.type,    Suits.sun.planet,   3   ),  ("Character3",      Suits.diamond.suit,     Suits.allstars.type,    Suits.star.planet,  5   ),
            ("Character4",      Suits.heart.suit,       Suits.allstars.type,    Suits.sun.planet,   8   ),  ("Character5",      Suits.clover.suit,      Suits.allstars.type,    Suits.moon.planet,  11  ),
            ("Character6",      Suits.diamond.suit,     Suits.allstars.type,    Suits.star.planet,  3   ),  ("Character7",      Suits.diamond.suit,     Suits.allstars.type,    Suits.star.planet,  10  ),
            ("Character8",      Suits.clover.suit,      Suits.allstars.type,    Suits.sun.planet,   0   ),  ("Character9",      Suits.clover.suit,      Suits.allstars.type,    Suits.moon.planet,  3   ),
            ("Character10",     Suits.spade.suit,       Suits.allstars.type,    Suits.sun.planet,   4   ),  ("Character11",     Suits.diamond.suit,     Suits.allstars.type,    Suits.sun.planet,   4   ),
            ("Character12",     Suits.spade.suit,       Suits.allstars.type,    Suits.moon.planet,  12  ),  ("Character13",     Suits.diamond.suit,     Suits.princess.type,    Suits.star.planet,  12  ),
            ("Character14",     Suits.spade.suit,       Suits.fairly.type,      Suits.moon.planet,  1   ),  ("Character15",     Suits.diamond.suit,     Suits.angel.type,       Suits.sun.planet,   0   ),
            ("Character16",     Suits.diamond.suit,     Suits.princess.type,    Suits.star.planet,  8   ),  ("Character17",     Suits.clover.suit,      Suits.angel.type,       Suits.sun.planet,   8   ),
            ("Character18",     Suits.heart.suit,       Suits.princess.type,    Suits.sun.planet,   10  ),  ("Character19",     Suits.diamond.suit,     Suits.fairly.type,      Suits.moon.planet,  6   ),
            ("Character20",     Suits.diamond.suit,     Suits.princess.type,    Suits.star.planet,  7   ),  ("Character21",     Suits.clover.suit,      Suits.angel.type,       Suits.star.planet,  6   ),
            ("Character22",     Suits.spade.suit,       Suits.angel.type,       Suits.star.planet,  5   ),  ("Character23",     Suits.heart.suit,       Suits.angel.type,       Suits.sun.planet,   2   ),
            ("Character24",     Suits.clover.suit,      Suits.fairly.type,      Suits.sun.planet,   1   ),  ("Character25",     Suits.heart.suit,       Suits.princess.type,    Suits.star.planet,  5   ),
            ("Character26",     Suits.heart.suit,       Suits.princess.type,    Suits.moon.planet,  7   ),  ("Character27",     Suits.heart.suit,       Suits.princess.type,    Suits.star.planet,  3   ),
            ("Character28",     Suits.clover.suit,      Suits.princess.type,    Suits.star.planet,  9   ),  ("Character29",     Suits.spade.suit,       Suits.princess.type,    Suits.sun.planet,   7   ),
            ("Character30",     Suits.heart.suit,       Suits.fairly.type,      Suits.moon.planet,  6   ),  ("Character31",     Suits.spade.suit,       Suits.princess.type,    Suits.sun.planet,   0   ),
            ("Character32",     Suits.spade.suit,       Suits.fairly.type,      Suits.star.planet,  11  ),  ("Character33",     Suits.spade.suit,       Suits.fairly.type,      Suits.moon.planet,  2   ),
            ("Character34",     Suits.clover.suit,      Suits.angel.type,       Suits.sun.planet,   10  ),  ("Character35",     Suits.heart.suit,       Suits.princess.type,    Suits.sun.planet,   1   ),
            ("Character36",     Suits.clover.suit,      Suits.princess.type,    Suits.sun.planet,   2   ),  ("Character37",     Suits.clover.suit,      Suits.fairly.type,      Suits.moon.planet,  7   ),
            ("Character38",     Suits.clover.suit,      Suits.angel.type,       Suits.star.planet,  5   ),  ("Character39",     Suits.clover.suit,      Suits.angel.type,       Suits.star.planet,  12  ),
            ("Character40",     Suits.spade.suit,       Suits.angel.type,       Suits.star.planet,  8   ),  ("Character41",     Suits.diamond.suit,     Suits.angel.type,       Suits.star.planet,  2   ),
            ("Character42",     Suits.heart.suit,       Suits.princess.type,    Suits.sun.planet,   4   ),  ("Character43",     Suits.clover.suit,      Suits.fairly.type,      Suits.moon.planet,  4   ),
            ("Character44",     Suits.spade.suit,       Suits.angel.type,       Suits.moon.planet,  10  ),  ("Character45",     Suits.diamond.suit,     Suits.fairly.type,      Suits.sun.planet,   1   ),
            ("Character46",     Suits.spade.suit,       Suits.fairly.type,      Suits.moon.planet,  6   ),  ("Character47",     Suits.heart.suit,       Suits.angel.type,       Suits.moon.planet,  11  ),
            ("Character48",     Suits.diamond.suit,     Suits.fairly.type,      Suits.star.planet,  9   ),  ("Character49",     Suits.heart.suit,       Suits.fairly.type,      Suits.moon.planet,  9   ),
            ("Character50",     Suits.spade.suit,       Suits.fairly.type,      Suits.moon.planet,  9   ),  ("Character51",     Suits.diamond.suit,     Suits.angel.type,       Suits.sun.planet,   11  ),
            ("Joker0",          Suits.joker.suit,       "",                     "",                 -1  ),  ("Joker1",          Suits.joker.suit,       "",                     "",                 -1  ),
        };
    }
}