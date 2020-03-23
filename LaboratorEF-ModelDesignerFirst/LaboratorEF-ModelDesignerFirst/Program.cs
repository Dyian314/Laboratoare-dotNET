using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratorEF_ModelDesignerFirst
{
    static class Program
    {
        static void TestPerson()
        {
            using (Model1Container context = new Model1Container())
            {
                Person p = new Person()
                {
                    FirstName = "Julie",
                    LastName = "Andrew",
                    MiddleName = "T",
                    TelephoneNumber = "1234567890"
                };
                context.People.Add(p);
                context.SaveChanges();
                var items = context.People;
                foreach (var x in items)
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName);
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Test Model Designer First");
            TestPerson();
            Console.ReadKey();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
