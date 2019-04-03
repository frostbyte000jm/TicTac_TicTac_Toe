using System;
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
                arrResults[i] = MarkType.Blank;

            doPlayer1Turn = true;

            var buttns = Container.Children.OfType<Button>().ToList();
           
            /*
             * What i need to do is gather up the buttons into a list. Then make a formula to see when there is a winner. 
            */
            buttns.ForEach(button =>
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

            var index = row * 3 + column;

            if (arrResults[index] != MarkType.Blank)
                return;

            arrResults[index] = doPlayer1Turn ? MarkType.Xs : MarkType.Ohs;

            button.Content = doPlayer1Turn ? "X" : "O";

            button.Foreground = doPlayer1Turn ? Brushes.Blue : Brushes.Red;

            doPlayer1Turn ^= true;

            DoWinnerCheck();

        }

        private void DoWinnerCheck()
        {
            if(arrResults[0] != MarkType.Blank && (arrResults[0] & arrResults[1] & arrResults[2]) == arrResults[0])
            {
                doGameOver = true;

                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }

            else if (arrResults[3] != MarkType.Blank && (arrResults[3] & arrResults[4] & arrResults[5]) == arrResults[3])
            {
                doGameOver = true;

                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }

            else if (arrResults[6] != MarkType.Blank && (arrResults[6] & arrResults[7] & arrResults[8]) == arrResults[6])
            {
                doGameOver = true;

                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }

            else if (arrResults[0] != MarkType.Blank && (arrResults[0] & arrResults[3] & arrResults[6]) == arrResults[0])
            {
                doGameOver = true;

                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }

            else if (arrResults[1] != MarkType.Blank && (arrResults[1] & arrResults[4] & arrResults[7]) == arrResults[1])
            {
                doGameOver = true;

                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }

            else if (arrResults[2] != MarkType.Blank && (arrResults[2] & arrResults[5] & arrResults[8]) == arrResults[2])
            {
                doGameOver = true;

                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }

            else if (arrResults[0] != MarkType.Blank && (arrResults[0] & arrResults[4] & arrResults[8]) == arrResults[0])
            {
                doGameOver = true;

                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }

            else if (arrResults[2] != MarkType.Blank && (arrResults[2] & arrResults[4] & arrResults[6]) == arrResults[2])
            {
                doGameOver = true;

                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
            }

            if (!arrResults.Any(f => f == MarkType.Blank))
            {
                doGameOver = true;

                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;                    
                });
            }
                
        }
    }
}
