using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");

            Grille grille = new Grille();
            grille.GetGrilleFromFile("sudokus.txt", 0);
            grille.AfficherGrille();

            Console.WriteLine("valide = " + grille.IsValid());
            grille.DefinePossibleValues(grille.cases[0]);

            Console.WriteLine("possible values of case 0 : " + grille.cases[0].PossibleValues);

            Grille solution = Resolver.BackTrackingSearch(grille);

            solution.AfficherGrille();

            Console.ReadLine();
        }
    }
}
