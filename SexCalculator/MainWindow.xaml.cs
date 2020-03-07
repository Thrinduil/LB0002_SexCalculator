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
            Person person = new Person(tbxFirstName.Text, tbxLastName.Text, tbxIdNumber.Text);

            tbkResult.Text = $"Förnamn: {person.firstName}\nEfternamn: {person.lastName}\nPersonnummer: {person.idNumber}";
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
            this.firstName = firstName;
            this.lastName = lastName;
            this.idNumber = idNumber;
        }
    }
}
