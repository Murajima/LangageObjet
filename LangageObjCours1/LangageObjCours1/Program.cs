using System;

namespace LangageObjCours1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] matrice = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] matriceTest = new int[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 } };

            Matrice m1 = new Matrice(matrice);
            Matrice m2 = new Matrice(matrice);

            Matrice mTest = m1 * m2;

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
