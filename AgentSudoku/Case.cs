using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSudoku
{
    class Case
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Value { get; set; }
        public List<int> PossibleValues { get; set; }

        /// <param name="indexCase">Index de la case [0-80]</param>
        public Case(int value, int indexCase)
        {
            PosX = indexCase % 9;
            PosY = indexCase / 9;
            this.Value = value;
        }

        /// <summary>
        /// Retourne le numéro de la région de la case
        /// </summary>
        public int GetRegion()
        {
            return 3 * (PosX / 3) + PosY / 3;
        }

    }
}
