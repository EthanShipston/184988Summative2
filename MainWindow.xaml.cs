/*Ethan Shipston
 * 3/28/2019
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

            txtInOut.Text = contact.info[0]
                + "\n" + contact.info[1]
                + "\n" + contact.age.Day.ToString()
                + "\n" + contact.age.Month.ToString()
                + "\n" + contact.age.Year.ToString()
                + "\n" + contact.info[2];
        }

        /// <summary>
        /// Calculates the age based on the date given, outputs as a message box
        /// </summary>
        private void btnGetAge_Click(object sender, RoutedEventArgs e)
        {
            string temp = txtInOut.Text;
            DateTime dt;

            temp = temp.Remove(0, temp.IndexOf("\n") + 1);
            temp = temp.Remove(0, temp.IndexOf("\n") + 1);

            int.TryParse(temp.Substring(0, temp.IndexOf("\n")), out int d);
            temp = temp.Remove(0, temp.IndexOf("\n") + 1);
            int.TryParse(temp.Substring(0, temp.IndexOf("\n")), out int m);
            temp = temp.Remove(0, temp.IndexOf("\n") + 1);
            int.TryParse(temp.Substring(0, temp.IndexOf("\n")), out int y);
            temp = temp.Remove(0, temp.IndexOf("\n") + 1);

            try
            {
                dt = new DateTime(y, m, d);
                DateTime now = DateTime.Now;

                if (now.Year < dt.Year)
                {
                    MessageBox.Show("Please use a valid year");
                }
                else if (now.DayOfYear < dt.DayOfYear)
                {
                    int age = now.Year - dt.Year - 1;
                    MessageBox.Show(age.ToString());
                }
                else
                {
                    int age = now.Year - dt.Year;
                    MessageBox.Show(age.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Saves textbox data to contact.txt
        /// </summary>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            string temp = txtInOut.Text;
            DateTime dt;
            try
            {
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

                if (f.Contains(",") || l.Contains(",") || email.Contains(","))
                {
                    MessageBoxResult mbr = MessageBox.Show("Your name/email may not contain commas.", "Warning", MessageBoxButton.OK);
                    cancelClosing(e, mbr);
                }
                else
                {
                    try
                    {
                        dt = new DateTime(y, m, d);
                        contact.SaveToFile(f, l, dt, email);
                    }
                    catch (Exception ex)
                    {
                        MessageBoxResult mbr = MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK);
                        cancelClosing(e, mbr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cancels closing.
        /// </summary>
        private static void cancelClosing(CancelEventArgs e, MessageBoxResult mbr)
        {
            if (mbr == MessageBoxResult.OK)
                e.Cancel = true;
        }

        /// <summary>
        /// Resets textbox data if the user erased something.
        /// </summary>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtInOut.Text = contact.info[0]
                + "\n" + contact.info[1]
                + "\n" + contact.age.Day.ToString()
                + "\n" + contact.age.Month.ToString()
                + "\n" + contact.age.Year.ToString()
                + "\n" + contact.info[2];
        }
    }
}
