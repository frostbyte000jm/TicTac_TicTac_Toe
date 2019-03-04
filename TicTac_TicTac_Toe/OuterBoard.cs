using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTac_TicTac_Toe
{
    class OuterBoard : Gridold
    {
        //declaration
        InnerBoard[] arrInnerBoards;

        public OuterBoard()
        {
            Name = "OuterBoard";
            boardState value = boardState.Open;

            arrInnerBoards = new InnerBoard[9]; //Create boards

            for (int i = 0; i < arrInnerBoards.Length; i++)
            {
                arrInnerBoards[i] = new InnerBoard();
            }
        }
    }
}
