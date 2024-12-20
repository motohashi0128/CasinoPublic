using System.Collections.Generic;

namespace Poker
{
    public class Suits
    {
        public static readonly (string suit, string icon) heart = ("HEART", "♥");
        public static readonly (string suit, string icon) spade = ("SPADE", "♠");
        public static readonly (string suit, string icon) diamond = ("DIAMOND", "♦");
        public static readonly (string suit, string icon) clover = ("CLOVER", "♣");
        public static readonly (string suit, string icon) joker = ("JOKER", "X");
        public static readonly (string type, string icon) princess = ("PRINCESS", "<#FF0000>Pr");
        public static readonly (string type, string icon) fairly = ("FAIRLY", "<#0000FF>Fa");
        public static readonly (string type, string icon) angel = ("ANGEL", "<#AAAA00>An");
        public static readonly (string type, string icon) allstars = ("ALLSTARS", "<#AA0000>AS");
        public static readonly (string planet, string icon) star = ("STAR", "<#AAAA00>St");
        public static readonly (string planet, string icon) moon = ("MOON", "<#0000FF>M");
        public static readonly (string planet, string icon) sun = ("SUN", "<#FF0000>Su");

    }
}