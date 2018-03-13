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

            JeuDeLaVie();

        }

        public static void JeuDeLaVie()
        {
            JeuDeLaVie jdlv = new JeuDeLaVie(3, 3);
            jdlv.update();
        }
    }
}