using System;
using System.Linq;
using System.Windows.Forms;

namespace Form
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RadForm1());
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Person()
        {
        }
    }

    public class Address
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string theAddress { get; set; }

        public Address()
        {
        }
    }
}