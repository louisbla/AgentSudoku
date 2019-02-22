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
        }

        public void GetGrilleFromFile(String file)
        {
            string[] lines = System.IO.File.ReadAllLines(@"sudokus.txt");
        }

    }
}
