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
                tbkResult.Foreground = Brushes.Black;
                tbkResult.Text = $"Förnamn: {person.firstName}\nEfternamn: {person.lastName}\nPersonnummer: {person.idNumber}";
            }
            catch (ArgumentException ex)
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
                throw new ArgumentException(errorMessage);
            }

            this.firstName = firstName;
            this.lastName = lastName;
            this.idNumber = idNumber;
        }
    }
}
