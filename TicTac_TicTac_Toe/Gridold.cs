using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTac_TicTac_Toe
{
    abstract class Gridold
    {
        public string Name { get; set; }
        public enum boardState { Open, XWin, OWin, Draw };

        internal static object GetColumn(Button button)
        {
            throw new NotImplementedException();
        }
    }
}
