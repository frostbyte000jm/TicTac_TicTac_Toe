using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTac_TicTac_Toe
{
    class InnerBoard : Gridold
    {
        //decalarations
        private string[] arrInnerGrid;
        private int whereNextValue;
        //private enum boardState {Open, XWin, OWin, Draw };

        public InnerBoard()
        {
            Name = "Inner Board";
            arrInnerGrid = new string[9];
            boardState value = boardState.Open;
        }

        public void addX(int idx)
        {
            if (doBadInput(idx))
                return;

            arrInnerGrid[idx] = "X";
        }

        public void addO(int idx)
        {
            if (doBadInput(idx))
                return;

            arrInnerGrid[idx] = "O";
        }

        public int WhereNext()
        {
            return whereNextValue;
        }

        private bool doBadInput(int idx)
        {
            //set Default for WhereNext
            whereNextValue = -1;
            
            //Check if in array
            if (idx <= 0 && idx >= 9)
                return true;

            //Check if value already exist
            if (arrInnerGrid[idx].Length > 0)
                return true;

            //if All Good
            whereNextValue = idx;
            return false;
        }
    }
}
