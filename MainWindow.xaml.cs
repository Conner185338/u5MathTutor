/*
 * Peter McEwen
 * June 4, 2018
 * Converts numbers to binary
 */
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

namespace u5MathTutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        double RandomNumber1 = 0;
        double RandomNumber2 = 0;
        string Operation = "";
        double counter = 0;

        public MainWindow()
        {
            InitializeComponent();

            NewQuestion();
        }

        private void btnCheckAnswer_Click(object sender, RoutedEventArgs e)
        {
            
            if (counter == 0)
            {
                string InputAnswer = UserInput.Text;
                double UserAnswer = 0;
                double.TryParse(InputAnswer, out UserAnswer);

                double ActualAnswer = 0;
                if (Operation == "/")
                {
                    ActualAnswer = RandomNumber1 / RandomNumber2;
                }
                else if (Operation == "*")
                {
                    ActualAnswer = RandomNumber1 * RandomNumber2;
                }
                else if (Operation == "+")
                {
                    ActualAnswer = RandomNumber1 + RandomNumber2;
                }
                else if (Operation == "-")
                {
                    ActualAnswer = RandomNumber1 - RandomNumber2;
                }

                if (UserAnswer == ActualAnswer)
                {
                    lblRevealAnswer.Content = "Correct!";
                }
                else
                {
                    lblRevealAnswer.Content = "Incorrect" + "\r" + "\n" + "the correct answer is " + ActualAnswer;
                }
                btnCheckAnswer.Content = "Create New Question";
                counter++;
            }

            else
            {
                NewQuestion();
                lblRevealAnswer.Content = "";
                btnCheckAnswer.Content = "Check Answer";
                counter = 0;
            }
        }

        public void NewQuestion()
        {
            Operation = ChooseOperator(Operation);
            //MessageBox.Show(Operation);
            string Question = "";
            RandomNumber1 = random.Next(1, 11);
            RandomNumber2 = random.Next(1, 11);
            Question = RandomNumber1 + " " + Operation + " " + RandomNumber2;
            lblQuestion.Content = Question;
        }

        public string ChooseOperator(string operation)
        {
            int RandomNumber = random.Next(1, 5);

            if (RandomNumber == 1)
            {
                operation = "+";
                return operation;
            }

            else if (RandomNumber == 2)
            {
                operation = "-";
                return operation;
            }

            else if (RandomNumber == 3)
            {
                operation = "*";
                return operation;
            }
            else
            {
                operation = "/";
                return operation;
            }
        }

        
    } 
}
