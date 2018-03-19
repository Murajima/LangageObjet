using System;
using LangageObjCours1.Exceptions;
using System.Text.RegularExpressions;

namespace LangageObjCours1
{
    public class Matrice
    {
        public int[,] matrice;
        // { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 } }
        public const string MATRICE_PATTERN = @"([0-9]+)(,?)+";

        public Matrice(int [,] matrice)
        {
            this.matrice = matrice;
        }

        public Matrice(int n)
        {
            this.matrice = new int[n, n];
        }

        public Matrice(int tailleI, int tailleJ) {
            matrice = new int[tailleI, tailleJ];
        }

        public Matrice(string input) {
            Regex r = new Regex(MATRICE_PATTERN);
            Match m = r.Match(input);
            if (m.Success)
            {
                for (int i = 0; i < m.Groups.Count; i++) {
                    
                }
                
            }
            else
            {
                throw new MatriceException("Format de matrice invalide.");
            }
            
        }

        public static Matrice operator +(Matrice a, Matrice b)
        {
            if (a.matrice.GetLength(0) != b.matrice.GetLength(0) || b.matrice.GetLength(1) != a.matrice.GetLength(1))
            {
                throw new MatriceException("Matrices not at the same size");
            }
            else
            {
                int[,] returnMat = new int[a.matrice.GetLength(0), a.matrice.GetLength(1)];

                for (int i = 0; i < a.matrice.GetLength(0); i++)
                    for (int j = 0; j < a.matrice.GetLength(1); j++)
                        returnMat[i, j] = a.matrice[i, j] + b.matrice[i, j];
                return new Matrice(returnMat);
            }
        }

        public static Matrice operator *(Matrice a, Matrice b) {
            if (a.matrice.GetLength(1) != b.matrice.GetLength(0))
            {
                throw new MatriceException("Matrices not at the correct size");
            } else {
                int[,] c = new int[a.matrice.GetLength(0), b.matrice.GetLength(1)];
                for (int i = 0; i < c.GetLength(0); i++)
                {
                    for (int j = 0; j < c.GetLength(1); j++)
                    {
                        c[i, j] = 0;
                        for (int k = 0; k < a.matrice.GetLength(1); k++) // OR k<b.GetLength(0)
                            c[i, j] = c[i, j] + a.matrice[i, k] * b.matrice[k, j];
                    }
                }
                return new Matrice(c);
            }
        }
    }
}
