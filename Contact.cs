using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _184988Summative2
{
    class Contact
    {
        //Public Variables
        string firstName;
        string lastName;
        int yearBorn;
        int monthBorn;
        int dayBorn;
        string email;
        public string[] info = new string[3];
        public DateTime age;

        /// <summary>
        /// Method that reads contact.txt and outputs the info in a usable format.
        /// </summary>
        public void ReadFromFile()
        {
            try
            {
                System.IO.StreamReader streamReader = new System.IO.StreamReader("contact.txt");
                string temp = streamReader.ReadLine();
                streamReader.Close();

                firstName = temp.Substring(0, temp.IndexOf(","));
                temp = temp.Remove(0, temp.IndexOf(",") + 1);

                lastName = temp.Substring(0, temp.IndexOf(","));
                temp = temp.Remove(0, temp.IndexOf(",") + 1);

                int.TryParse(temp.Substring(0, temp.IndexOf(",")), out yearBorn);
                temp = temp.Remove(0, temp.IndexOf(",") + 1);

                int.TryParse(temp.Substring(0, temp.IndexOf(",")), out monthBorn);
                temp = temp.Remove(0, temp.IndexOf(",") + 1);

                int.TryParse(temp.Substring(0, temp.IndexOf(",")), out dayBorn);
                temp = temp.Remove(0, temp.IndexOf(",") + 1);

                email = temp;

                info[0] = firstName;
                info[1] = lastName;
                info[2] = email;
                age = new DateTime(yearBorn, monthBorn, dayBorn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Logic for writing data to contact.txt
        /// </summary>
        /// <param name="f">First name</param>
        /// <param name="l">Last name</param>
        /// <param name="date">Birth date</param>
        /// <param name="e">Email</param>
        public void SaveToFile(string f, string l, DateTime date, string e)
        {
            string temp = date.Date.ToString();
            int.TryParse(temp.Substring(0, temp.IndexOf("/")), out int m);
            temp = temp.Remove(0, temp.IndexOf("/") + 1);
            int.TryParse(temp.Substring(0, temp.IndexOf("/")), out int d);
            temp = temp.Remove(0, temp.IndexOf("/") + 1);
            int.TryParse(temp.Substring(0, temp.IndexOf(" ")), out int y);


            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("contact.txt");
            temp = f + "," + l + "," + y.ToString() + "," + m.ToString() + "," + d.ToString() + "," + e;
            streamWriter.Write(temp);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
