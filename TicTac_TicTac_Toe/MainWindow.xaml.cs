using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTac_TicTac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //declarations
        //OuterBoard OuterBoard;

        #region Private Members

        private MarkType[] arrResults;
        private bool doPlayer1Turn;
        private bool doGameOver;

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            //OuterBoard = new OuterBoard();

            NewGame();

            int i = 0;
        }

        #endregion

        private void NewGame()
        {
            arrResults = new MarkType[9];

            for (int i = 0; i < arrResults.Length; i++)
                arrResults[i] = MarkType.Free;

            doPlayer1Turn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            doGameOver = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The Button that was clicked</param>
        /// <param name="e">The events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(doGameOver)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = (row * 3) + column;

            if (arrResults[index] != MarkType.Free)
                return;

            arrResults[index] = doPlayer1Turn ? MarkType.Xs : MarkType.Ohs;

            button.Content = doPlayer1Turn ? "X" : "O";

            button.Foreground = !doPlayer1Turn ? Brushes.Red: Brushes.Blue;

            //flip the value
            doPlayer1Turn ^= true;

        }

        private void CheckForWinner()
        {

        }

   
    }
}
