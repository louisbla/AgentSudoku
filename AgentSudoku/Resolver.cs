using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSudoku
{
    class Resolver
    {
        /// <summary>
        /// Tries to resolve the grid in parameter. Returns the solution (or 'null' if no solution is found)
        /// </summary>
        /// <param name="grille"></param>
        public static Grille BackTrackingSearch(Grille grille)
        {
            grille.DefinePossibleValuesAllBoxes();
            return Recursive_Backtracking_Search(grille);
            
        }

        /// <summary>
        /// Trie le dictionnaire de Grilles par ordre croissant de la valeur int
        /// </summary>
        /// <param name="dictionary"></param>
        private static Dictionary<Grille, int> sortDictionary(Dictionary<Grille, int> dictionary)
        {
            Dictionary<Grille, int> sortedDictionary = new Dictionary<Grille, int>();

            var items = from pair in dictionary
                        orderby pair.Value ascending
                        select pair;

            // Display results.
            foreach (KeyValuePair<Grille, int> pair in items)
            {
                sortedDictionary.Add(pair.Key, pair.Value);
            }

            return sortedDictionary;
        }

        private static Grille Recursive_Backtracking_Search(Grille grille)
        {
            if (grille.IsComplete())
                return grille;

            //On créé une copie de la grille de départ
            Grille tempGrille = new Grille(grille);

            //On détecte la case vide ayant le moins de valeurs possibles
            int indexLeastMRV = -1;
            int MRV = int.MaxValue;

            int compteur = 0;
            foreach (Case box in tempGrille.cases)
            {
                if (box.Value == 0)
                {
                    int tempMRV = box.PossibleValues.Count;
                    if (tempMRV < MRV)
                    {
                        indexLeastMRV = compteur;
                        MRV = tempMRV;
                    }
                }
                compteur++;
            }

            //Si aucune valeur ne mève à une solution satisfaisante, on arrête d'explorer la branche.
            if (MRV == 0)
            {
                return null;
            }

            //On créé les noeuds 
            Dictionary<Grille, int> dic = new Dictionary<Grille, int>();

            List<Grille> grilles = new List<Grille>();
            foreach (int valeur in tempGrille.cases[indexLeastMRV].PossibleValues)
            {
                Grille nextGrille = new Grille(tempGrille);
                nextGrille.cases[indexLeastMRV].Value = valeur;
                nextGrille.DefinePossibleValuesAllBoxes();

                int nbConstraintsAdded = tempGrille.GetNbOfPossibleValues() - nextGrille.GetNbOfPossibleValues();

                dic.Add(nextGrille, nbConstraintsAdded);
            }

            sortDictionary(dic);

            foreach (KeyValuePair<Grille, int> pair in dic)
            {
                Grille result = Recursive_Backtracking_Search(pair.Key);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
