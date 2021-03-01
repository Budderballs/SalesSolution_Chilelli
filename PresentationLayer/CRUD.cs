using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProject;

namespace PresentationProject
{
    class CRUD
    {
        static SalesContext salesContext = new SalesContext();
        public static string showMeEverything()
        {
            StringBuilder sME = new StringBuilder();
            foreach (Customer c in salesContext.Customers)
            {
                sME.Append("Last Name: " + c.LastName + " | First Name: " + c.FirstName + " | Phone: " + c.Phone + "\n");
            }
            return sME.ToString();
        }
        public static void addCust(string fName, string lName, string city, string country, string pNumber)
        {
            Customer addNewCust = new Customer();
            addNewCust.FirstName = fName;
            addNewCust.LastName = lName;
            addNewCust.City = city;
            addNewCust.Country = country;
            addNewCust.Phone = pNumber;
            salesContext.Add(addNewCust);
            salesContext.SaveChanges();
        }
        public static void delCustByLastName(string byebye)
        {
            int helperInt = 0;
            foreach (Customer c in salesContext.Customers.Where(z => z.LastName.ToLower() == byebye.ToLower()))
            {
                helperInt++;
            }
            if (helperInt == 1)
            {
                Customer removeCust = salesContext.Customers.Single(set4Del => set4Del.LastName.ToLower() == byebye);
                Console.WriteLine("Removing :" + removeCust.LastName + ", " + removeCust.FirstName);
                salesContext.Customers.Remove(removeCust);
            }
            else if (helperInt > 1)
            {
                Customer removeDupeCust;
                Console.WriteLine("Multiple Matches Found");
                foreach (Customer c in salesContext.Customers.Where(z => z.LastName.ToLower() == byebye.ToLower()))
                {
                    Console.WriteLine("Delete: " + c.LastName + ", " + c.FirstName + "? Y/N");
                    string yN = Console.ReadLine().ToLower();
                    if (yN == "y")
                    {
                        removeDupeCust = c;
                        salesContext.Customers.Remove(removeDupeCust);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("No Matches Found");
                return;
            }
            salesContext.SaveChanges();
        }
        public static void updateCust(string lname)
        {
            int helperInt = 0;
            foreach (Customer c in salesContext.Customers.Where(z => z.LastName.ToLower() == lname.ToLower()))
            {
                helperInt++;
            }
            if (helperInt == 1)
            {
                Customer updateCust = salesContext.Customers.Single(set4Up => set4Up.LastName.ToLower() == lname);
                Console.WriteLine("Updating :" + updateCust.LastName + ", " + updateCust.FirstName);
                Console.WriteLine("Update first name Y/N?");
                string yN = Console.ReadLine().ToLower();
                if (yN == "y") 
                {
                    Console.WriteLine("What is the first name? ");
                    updateCust.FirstName = Console.ReadLine();
                    while (string.IsNullOrEmpty(updateCust.FirstName))
                    {
                        Console.WriteLine("Invalid please enter something");
                        updateCust.FirstName = Console.ReadLine();
                    }
                }
                Console.WriteLine("Update last name Y/N?");
                yN = Console.ReadLine().ToLower();
                if (yN == "y")
                {
                    Console.WriteLine("What is the last name? ");
                    updateCust.LastName = Console.ReadLine();
                    while (string.IsNullOrEmpty(updateCust.LastName))
                    {
                        Console.WriteLine("Invalid please enter something");
                        updateCust.LastName = Console.ReadLine();
                    }
                }
                Console.WriteLine("Update city name Y/N?");
                yN = Console.ReadLine().ToLower();
                if (yN == "y")
                {
                    Console.WriteLine("What is the city name? ");
                    updateCust.City = Console.ReadLine();
                }
                Console.WriteLine("Update country name Y/N?");
                yN = Console.ReadLine().ToLower();
                if (yN == "y")
                {
                    Console.WriteLine("What is the country name? ");
                    updateCust.Country = Console.ReadLine();
                }
                Console.WriteLine("Update phone number Y/N?");
                yN = Console.ReadLine().ToLower();
                if (yN == "y")
                {
                    Console.WriteLine("What is the phone number? ");
                    updateCust.Phone = Console.ReadLine();
                }
            }
            else if (helperInt > 1)
            {
                Customer removeDupeCust;
                Console.WriteLine("Multiple Matches Found");
                foreach (Customer c in salesContext.Customers.Where(z => z.LastName.ToLower() == lname.ToLower()))
                {
                    Console.WriteLine("Delete: " + c.LastName + ", " + c.FirstName + "? Y/N");
                    string yN = Console.ReadLine().ToLower();
                    if (yN == "y")
                    {
                        removeDupeCust = c;
                        salesContext.Customers.Remove(removeDupeCust);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("No Matches Found");
                return;
            }
            salesContext.SaveChanges();
        }
        public static string findCustByLastName(string lName)
        {
            bool exists = false;
            StringBuilder b = new StringBuilder();
            foreach (Customer c in salesContext.Customers.Where(z => z.LastName == lName))
            {
                b.Append("Last Name: " + c.LastName + " | First Name: " + c.FirstName + " | Phone: " + c.Phone
                    + " | City: " + c.City + " | Country: " + c.Country + "\n");
                exists = true;
            }
            if (!exists)
            {
                b.Append("There were no mathces to that name");
            }
            return b.ToString();
        }
        public static string showCustByFilter(string LorC, string filterLetter)
        {
            StringBuilder sCBF = new StringBuilder();
            if (LorC == "L")
            {
                foreach (Customer c in salesContext.Customers.Where(z => z.LastName.StartsWith(filterLetter)))
                {
                    sCBF.Append("Last Name: " + c.LastName + " | First Name: " + c.FirstName + " | Phone: " + c.Phone
                    + " | City: " + c.City + " | Country: " + c.Country + "\n");
                }
            }
            else if (LorC == "C")
            {
                foreach (Customer c in salesContext.Customers.Where(z => z.City.StartsWith(filterLetter)))
                {
                    sCBF.Append("Last Name: " + c.LastName + " | First Name: " + c.FirstName + " | Phone: " + c.Phone
                    + " | City: " + c.City + " | Country: " + c.Country + "\n");
                }
            }
            else 
            {
                sCBF.Append("Dunno yet?");
                //Ask in Class what mean?
            }
            return sCBF.ToString();
        }
    }
}
