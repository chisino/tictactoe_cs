using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int totalClicks = 0;

        private string[,] checkArray = { { "", "", "" },
                                         { "", "", "" }, 
                                         { "", "", "" } };

        public MainWindow()
        {
            InitializeComponent();
        }

        private string ValChecker(string buttonContent)
        {

            string newButtonContent;


            if (totalClicks % 2 == 0)
            {
                if (buttonContent == "")
                {
                    newButtonContent = "X";
                } else
                {
                    newButtonContent = "FULL";
                }
            } else {
                if (buttonContent == "")
                {
                    newButtonContent = "O";
                } else
                {
                    newButtonContent = "FULL";
                }
            }

            return newButtonContent;
        }

        private bool WinCondition(int x, int y, string newButtonContent)
        {
            // top to bottom

            if (x - 1 >= 0)
            {
                if (checkArray[x - 1, y] == newButtonContent)
                {
                    if (x - 2 >= 0)
                    {
                        if (checkArray[x - 2, y] == newButtonContent)
                        {
                            return true;
                        }
                    }
                    else if (x + 1 <= 2)
                    {
                        if (checkArray[x + 1, y] == newButtonContent)
                        {
                            return true;
                        }
                    }
                }
            } else if (x + 1 >= 0)
            {
                if (checkArray[x + 1, y] == newButtonContent)
                {
                    if (x + 2 <= 2)
                    {
                        if (checkArray[x + 2, y] == newButtonContent)
                        {
                            return true;
                        }
                    }
                }
            }

            // left to right

            if (y - 1 >= 0)
            {
                if (checkArray[x, y - 1] == newButtonContent)
                {
                    if (y - 2 >= 0)
                    {
                        if (checkArray[x, y - 2] == newButtonContent)
                        {
                            return true;
                        }
                    }
                    else if (y + 1 <= 2)
                    {
                        if (checkArray[x, y + 1] == newButtonContent)
                        {
                            return true;
                        }
                    }
                }
            } else if (y + 1 <= 2)
            {
                if (checkArray[x, y + 1] == newButtonContent)
                {
                    if (y + 2 <= 2)
                    {
                        if (checkArray[x, y + 2] == newButtonContent)
                        {
                            return true;
                        }
                    }
                }
            }

            // diagonal

            if (x - 1 >= 0 && y - 1 >= 0)
            {
                if (checkArray[x - 1, y - 1] == newButtonContent)
                {
                    if (x - 2 >= 0 && y - 2 >= 0)
                    {
                        if (checkArray[x - 2, y - 2] == newButtonContent)
                        {
                            return true;
                        }
                    }
                    else if (x + 1 <= 2 && y + 1 <= 2)
                    {
                        if (checkArray[x + 1, y + 1] == newButtonContent)
                        {
                            return true;
                        }
                    }
                }
            } else if (x + 1 <= 2 && y + 1 <= 2)
            {
                if (checkArray[x + 1, y + 1] == newButtonContent)
                {
                    if (x + 2 <= 2 && y + 2 <= 2)
                    {
                        if (checkArray[x + 2, y + 2] == newButtonContent)
                        {
                            return true;
                        }
                    }
                } else if (x - 1 >= 0 && y - 1 >= 0)
                {
                    if (checkArray[x - 1, y - 1] == newButtonContent)
                    {
                        return true;
                    }
                }
            }

            if (x + 1 <= 2 && y - 1 >= 0)
            {
                if (checkArray[x + 1, y - 1] == newButtonContent)
                {
                    if (x + 2 <= 2 && y - 2 >= 0)
                    {
                        if (checkArray[x + 2, y - 2] == newButtonContent)
                        {
                            return true;
                        }
                    } else if (x - 1 >= 0 && y + 1 <= 2)
                    {
                        if (checkArray[x - 1, y + 1] == newButtonContent)
                            {
                                return true;
                            }
                    }
                } 
            }

            if (x - 1 >= 0 && y + 1 <= 2)
            {
                if (checkArray[x - 1, y + 1] == newButtonContent)
                {
                    if (x - 2 >= 0 && y + 2 <= 2)
                    {
                        if (checkArray[x - 2, y + 2] == newButtonContent)
                            {
                                return true;
                            }
                    }
                }
            }

            return false;
        }

        private void resetGame()
        {
            OneB.Content = "";
            TwoB.Content = "";
            ThreeB.Content = "";
            FourB.Content = "";
            FiveB.Content = "";
            SixB.Content = "";
            SevenB.Content = "";
            EightB.Content = "";
            NineB.Content = "";
            Array.Clear(checkArray, 0, checkArray.Length);
            totalClicks = 0;
        }

        private bool tieChecker()
        {
            if (OneB.Content.ToString() != "" && TwoB.Content.ToString() != "" &&  ThreeB.Content.ToString() != "" && FourB.Content.ToString() != "" && FiveB.Content.ToString() != "" 
                && SixB.Content.ToString() != "" && SevenB.Content.ToString() != "" && EightB.Content.ToString() != "" && NineB.Content.ToString() != "") {
                return true;
            }
            return false;
        }

        private void messageDisplayer(string msgType, string newButtonContent)
        {
            String message = "";
            if (msgType == "tie") {
                message = String.Format("Tie game! Do you want to play again?", newButtonContent);
            } else if (msgType == "win")
            {
                message = String.Format("{0} wins! Do you want to play again?", newButtonContent);
            }

            MessageBoxResult result = MessageBox.Show(message, "Game Over", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                resetGame();
            }
            else
            {
                this.Close();
            }

        }

        private void Assigner(Button button, int x, int y)
        {
            string newButtonContent = ValChecker(button.Content.ToString());

            if (newButtonContent == "FULL") {
                return;
            }

            totalClicks += 1;

            button.Content = newButtonContent;
            checkArray[x, y] = newButtonContent;

            if (tieChecker()) {
                messageDisplayer("tie", newButtonContent);
            }

            if (WinCondition(x, y, newButtonContent))
            {
                messageDisplayer("win", newButtonContent);
            }

        }

        private void OneB_Click(object sender, RoutedEventArgs e)
        {
            Assigner(OneB, 0, 0);
        }

        private void TwoB_Click(object sender, RoutedEventArgs e)
        {
            Assigner(TwoB, 0, 1);
        }

        private void ThreeB_Click(object sender, RoutedEventArgs e)
        {
            Assigner(ThreeB, 0, 2);
        }

        private void FourB_Click(object sender, RoutedEventArgs e)
        {
            Assigner(FourB, 1, 0);
        }

        private void FiveB_Click(object sender, RoutedEventArgs e)
        {
            Assigner(FiveB, 1, 1);
        }

        private void SixB_Click(object sender, RoutedEventArgs e)
        {
            Assigner(SixB, 1, 2);
        }

        private void SevenB_Click(object sender, RoutedEventArgs e)
        {
            Assigner(SevenB, 2, 0);
        }

        private void EightB_Click(object sender, RoutedEventArgs e)
        {
            Assigner(EightB, 2, 1);
        }

        private void NineB_Click(object sender, RoutedEventArgs e)
        {
            Assigner(NineB, 2, 2);
        }

    }
}
