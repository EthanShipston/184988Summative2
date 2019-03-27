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
using System.ComponentModel;

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

        private void btnGetAge_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            string temp = txtInOut.Text;

            string f = temp.Substring(0, temp.IndexOf("\n"));
            temp = temp.Remove(0, temp.IndexOf("\n") + 1);
            string l = temp.Substring(0, temp.IndexOf("\n"));
            temp = temp.Remove(0, temp.IndexOf("\n") + 1);

            int.TryParse(temp.Substring(0, temp.IndexOf("\n")), out int d);
            temp = temp.Remove(0, temp.IndexOf("\n") + 1);
            int.TryParse(temp.Substring(0, temp.IndexOf("\n")), out int m);
            temp = temp.Remove(0, temp.IndexOf("\n") + 1);
            int.TryParse(temp.Substring(0, temp.IndexOf("\n")), out int y);
            temp = temp.Remove(0, temp.IndexOf("\n") + 1);

            string email = temp.Substring(0, temp.Length);

            try
            {
                DateTime dt = new DateTime(y, m, d);
                contact.WriteToFile(f, l, dt, email);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
