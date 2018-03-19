using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LangageObjCours1.Exceptions;

namespace LangageObjCours1
{
    class Program
    {
        static void Main(string[] args)
        {
            int dist;
            Spirale sp = new Spirale(5);
            dist = sp.getDistance(8);

        }

        public static void JeuDeLaVie()
        {
            JeuDeLaVie jdlv = new JeuDeLaVie(3, 3);
            jdlv.update();
        }
    }
}