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
        /// Tries to resolve the grid in parameter
        /// </summary>
        /// <param name="grille"></param>
        /// <returns></returns>
        public static Grille BackTrackingSearch(Grille grille)
        {
            //On créé une copie de la grille de départ
            Grille tempGrille = new Grille(grille);


            return grille;
            
            //return recursive_Backtracking_Search(grille);
            
        }

        private static Grille Recursive_Backtracking_Search(Grille grille)
        {
            throw new NotImplementedException();
        }
    }
}
