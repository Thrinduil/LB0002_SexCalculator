using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace SexCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbxFirstName.Focus();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person person = new Person(tbxFirstName.Text, tbxLastName.Text, tbxIdNumber.Text);

                if (!person.IsIdNumberValid())
                {
                    throw new Exception("Personnumret är inte giltigt!");
                }

                tbkResult.Foreground = Brushes.Black;
                tbkResult.Text = $"Förnamn: {person.firstName}\nEfternamn: {person.lastName}\nPersonnummer: {person.idNumber}\nKön: {person.Sex()}";
            }
            catch (Exception ex)
            {
                tbkResult.Foreground = Brushes.Red;
                tbkResult.Text = ex.Message;
            }
        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

    public class Person
    {
        public string firstName;
        public string lastName;
        public string idNumber;

        public Person(string firstName, string lastName, string idNumber)
        {
            string errorMessage = "";

            if (string.IsNullOrWhiteSpace(firstName))
            {
                errorMessage += "Du måste ange förnamn.\n";
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                errorMessage += "Du måste ange efternamn.\n";
            }

            if (string.IsNullOrWhiteSpace(idNumber))
            {
                errorMessage += "Du måste ange personnummer.\n";
            } else if (idNumber.Length != 10)
            {
                errorMessage += "Personnumret måste vara 10 siffror.\n";
            } else if (!idNumber.All(char.IsDigit))
            {
                errorMessage += "Personnumret får endast innehålla siffror.\n";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new Exception(errorMessage);
            }

            this.firstName = firstName;
            this.lastName = lastName;
            this.idNumber = idNumber;
        }

        public bool IsIdNumberValid()
        {
            string controlString = "";
            int controlSum = 0;

            for (int i = 0; i < idNumber.Length; i++)
            {
                if (i % 2 == 0)
                {
                    int digit = int.Parse(idNumber[i].ToString());
                    controlString += (digit * 2).ToString();
                }
                else
                {
                    controlString += idNumber[i];
                }
            }

            foreach (char digit in controlString)
            {
                controlSum += int.Parse(digit.ToString());
            }

            if (controlSum % 10 == 0)
            {
                return true;
            }
            return false;
        }

        public string Sex()
        {
            if(idNumber[8] % 2 == 0)
            {
                return "Kvinna";
            }
            return "Man";
        }
    }
}
