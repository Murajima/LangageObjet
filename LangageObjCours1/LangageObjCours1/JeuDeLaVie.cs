using System;
namespace LangageObjCours1
{
    public class JeuDeLaVie
    {
        public Matrice tableauJeu;
        public Matrice tableauJeuNext;
        int tailleI;
        int tailleJ;
        public JeuDeLaVie(int tailleI, int tailleJ)
        {
            this.tailleI = tailleI;
            this.tailleJ = tailleJ;
            this.tableauJeu = new Matrice(tailleI, tailleJ);
            Random rnd = new Random();
            for (int i = 0; i < tailleI; i ++){
                for (int j = 0; j < tailleJ; j++) {
                    int value = rnd.Next(0, 2);
                    tableauJeu.matrice[i, j] = value;
                }
            }
            this.tableauJeuNext = this.tableauJeu;
        }


        public void update(){
            for (int i = 0; i < tailleI; i++)
            {
                for (int j = 0; j < tailleJ; j++)
                {
                    ApplyRules(i, j, this.tableauJeu.matrice[i, j]);
                }
            }
            this.tableauJeu = this.tableauJeuNext;
        }

        public void ApplyRules(int i, int j, int CellState){
            int nbCellsAlive = 0;

            if (i + 1 < tailleI)
            {
                if (tableauJeu.matrice[i + 1, j] == 1)
                {
                    nbCellsAlive += 1;
                }
            }

            if (i - 1 >= 0)
            {
                if (tableauJeu.matrice[i - 1, j] == 1)
                {
                    nbCellsAlive += 1;
                }
            }

            if (j + 1 < tailleJ)
            {
                if (tableauJeu.matrice[i, j + 1] == 1)
                {
                    nbCellsAlive += 1;
                }
            }

            if (j - 1 >= 0)
            {
                if (tableauJeu.matrice[i, j - 1] == 1)
                {
                    nbCellsAlive += 1;
                }
            }

            if (i - 1 >= 0 && j - 1 >= 0)
            {
                if (tableauJeu.matrice[i - 1, j - 1] == 1)
                {
                    nbCellsAlive += 1;
                }
            }

            if (i + 1 < tailleI && j + 1 < tailleJ)
            {
                if (tableauJeu.matrice[i + 1, j + 1] == 1)
                {
                    nbCellsAlive += 1;
                }
            }

            if (i + 1 < tailleI && j - 1 >= 0)
            {
                if (tableauJeu.matrice[i + 1, j - 1] == 1 )
                {
                    nbCellsAlive += 1;
                }
            }

            if (j + 1 < tailleJ && i - 1 >= 0)
            {
                if (tableauJeu.matrice[i - 1, j + 1] == 1)
                {
                    nbCellsAlive += 1;
                }
            }

            if(CellState == 0) {
                Dead(nbCellsAlive, i, j);
            } else if (CellState == 1) {
                Alive(nbCellsAlive, i, j);
            }
        }

        public void Alive(int nbCellsAlive, int i, int j) {
            if (nbCellsAlive == 0 || nbCellsAlive == 1){
                this.tableauJeuNext.matrice[i, j] = 0;
            }

            if (nbCellsAlive == 2 || nbCellsAlive == 3) {
                this.tableauJeuNext.matrice[i, j] = 1;
            }

            if (nbCellsAlive > 3){
                this.tableauJeuNext.matrice[i, j] = 0;
            }

        }

        public void Dead(int nbCellsAlive, int i, int j) {
            if(nbCellsAlive == 3) {
                this.tableauJeuNext.matrice[i, j] = 1;
            } else {
                this.tableauJeuNext.matrice[i, j] = 0;
            }
        }

    }
}
