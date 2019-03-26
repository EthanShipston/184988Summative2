using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _184988Summative2
{
    class Contact
    {
        //Public Variables
        public string firstName;
        public string lastName;
        public int yearBorn;
        public int monthBorn;
        public int dayBorn;
        public string email;

        /// <summary>
        /// Method that reads contact.txt and outputs the info in a usable format.
        /// </summary>
        public void ReadFromFile()
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
        }
    }

}
