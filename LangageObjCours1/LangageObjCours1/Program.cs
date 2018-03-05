using System;

namespace LangageObjCours1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f = null;

            while(f == null) {
                System.Console.WriteLine("Entrez une fraction: (A/B)");
                string input = System.Console.ReadLine();

                try{
                    f = new Fraction(input);
                } catch (Exception ex) {
                    System.Console.WriteLine("Error: {0}", ex.Message);
                }
            }

            System.Console.WriteLine("Vous avez saisi {0}", f);
        }
    }
}
