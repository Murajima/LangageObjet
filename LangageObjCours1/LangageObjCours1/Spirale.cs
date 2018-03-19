using System;
using LangageObjCours1.Exceptions;

namespace LangageObjCours1
{
    public class Spirale
    {
        public Matrice spirale;
        private int taille;
        public Spirale(int n)
        {
            if (n % 2 == 1)
            {
                taille = n;
                spirale = new Matrice(n);
            } else {
                throw new MatriceException("La matrice doit avoir une taille impaire");
            }

            // Depart
            int nbPassageTot = (n / 2);
            int nbPassage = 0;
            int nbDeplacement = 1;
            int depart = (n / 2);
            int cpt = 3;
            int i = depart;
            int j = depart + 1;
            int cycle = 0;
            spirale.matrice[i, i] = 1;
            spirale.matrice[i, j] = 2;
            while(nbPassage < nbPassageTot) {
                if (cycle == 0){
                    int tmpI = 0;
                    for (int x = 1; x <= nbDeplacement; x++)
                    {
                        spirale.matrice[i - x, j] = cpt;
                        cpt++;
                        tmpI = i - x;
                    }
                    i = tmpI;
                    nbDeplacement++;
                    cycle++;
                }  
                if (cycle == 1) {
                    int tmpJ = 0;
                    for (int x = 1; x <= nbDeplacement; x++){
                        spirale.matrice[i, j - x] = cpt;
                        cpt++;
                        tmpJ = j - x;
                    }
                    j = tmpJ;
                    cycle++;
                }  
                if (cycle == 2) {
                    int tmpI = 0;
                    for (int x = 1; x <= nbDeplacement; x++){
                        spirale.matrice[i + x, j] = cpt;
                        cpt++;
                        tmpI = i + x;
                    }
                    i = tmpI;
                    cycle++;
                } 
                if (cycle == 3) {
                    int tmpJ = 0;
                    for (int x = 1; x <= nbDeplacement; x++)
                    {
                        spirale.matrice[i, j + x] = cpt;
                        cpt++;
                        tmpJ = j + x;
                    }
                    cycle = 0;
                    nbPassage++;
                    j = tmpJ + 1;
                    nbDeplacement = nbDeplacement + 1;
                    if (j < n)
                    {
                        spirale.matrice[i, j] = cpt;
                        cpt++;
                    }
                }
            }

        }

        public int getDistance(int nb){
            int distance = 0;
            int depart = taille / 2;
            for (int i = 0; i < taille; i++){
                for (int j = 0; j < taille; j++){
                    if(spirale.matrice[i,j] == nb) {
                        distance = Math.Abs(depart - i) + Math.Abs(depart - j);
                    }
                }
            }
            return distance;
        }
    }
}
