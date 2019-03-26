/*Ethan Shipston
 * DATE
 * Program which reads a text files info and is capable of updating said info.
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

namespace _184988Summative2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Contact contact = new Contact();
        public MainWindow()
        {
            InitializeComponent();
            contact.ReadFromFile();

            txtInOut.Text = contact.firstName
                + "\n" + contact.lastName
                + "\n" + contact.dayBorn.ToString()
                + "\n" + contact.monthBorn.ToString()
                + "\n" + contact.yearBorn.ToString()
                + "\n" + contact.email;
        }

        private void btnSetInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGetAge_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            string temp = dateTime.Date.ToString();
            int.TryParse(temp.Substring(0, temp.IndexOf("/")), out int tempMonth);
            temp = temp.Remove(0, temp.IndexOf("/") + 1);
            int.TryParse(temp.Substring(0, temp.IndexOf("/")), out int tempDay);
            temp = temp.Remove(0, temp.IndexOf("/") + 1);
            int.TryParse(temp.Substring(0, temp.IndexOf(" ")), out int tempYear);

            int age = tempYear - contact.yearBorn;
            if (tempMonth < contact.monthBorn)
            {
                age = age - 1;
            }
            else if (tempDay < contact.monthBorn)
            {
                age = age - 1;
            }

            MessageBox.Show(age.ToString() + " years old.");
        }
    }
}
