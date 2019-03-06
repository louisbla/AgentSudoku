using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Grille grille = new Grille();
            grille.GetGrilleFromFile("sudokus.txt", 0);
            grille.AfficherGrille();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Grille solution = Resolver.BackTrackingSearch(grille);

            stopwatch.Stop();
            Console.WriteLine("Temps de résolution : " + stopwatch.Elapsed.TotalMilliseconds + " ms");

            if (solution != null)
            {
                Console.WriteLine("Solution trouvée : ");
                solution.AfficherGrille();
            }
            else
            {
                Console.WriteLine("Pas de solution trouvée.");
            }

            Console.WriteLine("Press 'Enter' to exit");
            Console.ReadLine();
        }
    }
}
