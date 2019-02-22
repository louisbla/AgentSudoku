using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSudoku
{
    class Grille
    {
        List<Case> cases;
        
        public Grille()
        {
            cases = new List<Case>();
            for(int i = 0; i < 81; i++)
            {
                cases.Add(new Case(0, i));
            }
        }

        /// <summary>
        /// Read the file and extracts the sudoku of the corresponding line
        /// </summary>
        /// <param name="file"></param>
        /// <param name="line"></param>
        public void GetGrilleFromFile(String file, int line)
        {
            cases.Clear();
            string[] lines = System.IO.File.ReadAllLines(@"../../sudokus.txt");

            string sudoku = lines[line];

            CharEnumerator enumerator = sudoku.GetEnumerator();
            int i = 0;
            while (enumerator.MoveNext())
            {
                cases.Add(new Case(enumerator.Current - 48, i));
                i++;
            }
        }

        public void AfficherGrille()
        {
            string line = "";
            int index = 0;

            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    line += cases[index].Value + " ";
                    if(j == 2 || j == 5)
                    {
                        line += "| ";
                    }
                    index++;
                }
                Console.WriteLine(line);
                if(i == 2 || i == 5)
                {
                    Console.WriteLine("---------------------");
                }
                line = "";
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
