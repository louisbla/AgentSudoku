using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSudoku
{
    class Grille
    {
        private Grille grille;

        public List<Case> cases { get; set; }
        
        public Grille()
        {
            cases = new List<Case>();
            for(int i = 0; i < 81; i++)
            {
                cases.Add(new Case(0, i));
            }
        }

        public Grille(Grille grille)
        {
            this.grille = grille;
            cases = new List<Case>();
            for (int i = 0; i < 81; i++)
            {
                cases.Add(new Case(grille.cases[i]));
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

        public int GetNbOfPossibleValues()
        {
            int nbPossibleValues = 0;

            foreach (Case box in cases)
            {
                nbPossibleValues += box.PossibleValues.Count;
            }

            return nbPossibleValues;
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

        /// <summary>
        /// Retourne vrai si toutes les cases possèdent une valeur.
        /// </summary>
        public bool IsComplete()
        {
            foreach(Case box in cases)
            {
                if(box.Value == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Retourne vrai si toutes les valeurs attribuées sont valides
        /// </summary>
        public bool IsValid()
        {
            foreach(Case box in cases)
            {
                if(box.Value != 0)
                {
                    foreach(Case box2 in cases)
                    {
                        if(box != box2)
                        {
                            if(box.PosX == box2.PosX && box.Value == box2.Value)
                            {
                                return false;
                            }
                            if (box.PosY == box2.PosY && box.Value == box2.Value)
                            {
                                return false;
                            }
                            if (box.GetRegion() == box2.GetRegion() && box.Value == box2.Value)
                            {
                                return false;
                            }
                        }
                    }

                }
            }

            return true;

        }

        /// <summary>
        /// 
        /// </summary>
        public void DefinePossibleValuesOfABox(Case box)
        {
            List<int> possibleValues = new List<int>{1,2,3,4,5,6,7,8,9};

            foreach(Case box2 in cases)
            {
                if (box != box2)
                {
                    if (box.PosX == box2.PosX && box2.Value != 0)
                    {
                        possibleValues.Remove(box2.Value);
                    }
                    if (box.PosY == box2.PosY && box2.Value != 0)
                    {
                        possibleValues.Remove(box2.Value);
                    }
                    if (box.GetRegion() == box2.GetRegion() && box2.Value != 0)
                    {
                        possibleValues.Remove(box2.Value);
                    }
                }
            }

            box.PossibleValues = possibleValues;
        }

        /// <summary>
        /// Pour chaque case de la grille, met à jour les valeurs possibles.
        /// </summary>
        public void DefinePossibleValuesAllBoxes()
        {
            foreach (Case box in cases)
            {
                DefinePossibleValuesOfABox(box);
            }
        }

        /// <summary>
        /// Return false if a box has no possible move
        /// </summary>
        public bool IsThereAPossibleMoveForEachBox()
        {
            foreach(Case box in cases)
            {
                if(box.PossibleValues.Count == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
