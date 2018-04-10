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

            //Initialisation des valeurs
            int nbPassageTot = (n / 2);
            int nbPassage = 0;
            int nbDeplacement = 1;
            int depart = (n / 2);
            int cpt = 3; // Placement des deux premières valeurs à la main

            // On met à jour ces valeurs comme la case de depart de chaque itération d'un cycle => facilite l'écriture du code
            int i = depart;
            int j = depart + 1;

            // Le cycle commence à zéro
            int cycle = 0;

            // On place la valeure 1 au milieu de la matrice de taille n
            spirale.matrice[i, i] = 1;

            // On initialise la case de départ du 1er cycle
            spirale.matrice[i, j] = 2;


            // Tant que le nombre de passage max n'est pas effectué, on continue de remplir le tableau en spirale, 
            // selon un cycle prédéfini en 4 étapes
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

        // Récupère la distance entre le nombre donné en paramètre et le centre de la matrice. 
        // Retourne -1 si le nombre n'existe pas dans la matrice.
        public int getDistance(int nb){
            int distance = -1;
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
