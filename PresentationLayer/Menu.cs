using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProject
{
    class Menu
    {
        public static void menuStrings()
        {
            Console.WriteLine("Welcome to EF Crud, Please Select An Option 1-6 :)");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Delete Customer");
            Console.WriteLine("3. Update Customer");
            Console.WriteLine("4. Find Customer");
            Console.WriteLine("5. Show Customers by Filter");
            Console.WriteLine("6. QUIT");
        }
        public static void theSwitch(int caseNum)
        {
            switch (caseNum)
            {
                case 1: //Add Cust
                    Console.WriteLine("First Name: ");
                    string fName = Console.ReadLine();
                    Console.WriteLine("Last Name: ");
                    string lName = Console.ReadLine();
                    Console.WriteLine("City Name: ");
                    string city = Console.ReadLine();
                    Console.WriteLine("Country Name: ");
                    string country = Console.ReadLine();
                    Console.WriteLine("Phone Number: ");
                    string pNumber = Console.ReadLine();
                    if (string.IsNullOrEmpty(city) || string.IsNullOrWhiteSpace(city)) { city = null; }
                    if (string.IsNullOrEmpty(country) || string.IsNullOrWhiteSpace(country)) { country = null; }
                    if (string.IsNullOrEmpty(pNumber) || string.IsNullOrWhiteSpace(pNumber)) { pNumber = null; }
                    CRUD.addCust(fName, lName, city, country, pNumber);
                    Console.WriteLine(CRUD.showMeEverything());
                    break;
                case 2: //Delete Cust
                    Console.Write("Enter the Lastname of the Customer you would like to delete: ");
                    string deleteByLastName = Console.ReadLine();
                    CRUD.delCustByLastName(deleteByLastName);
                    Console.WriteLine(CRUD.showMeEverything());
                    break;
                case 3: //Update Cust
                    Console.WriteLine("Which customer would you like to update?");
                    lName = Console.ReadLine();
                    CRUD.updateCust(lName);
                    Console.WriteLine(CRUD.showMeEverything());
                    break;
                case 4: //Find Cust
                    Console.Write("Enter the last name of the customer you wish to find: ");
                    lName = Console.ReadLine();
                    Console.WriteLine(CRUD.findCustByLastName(lName));
                    break;
                case 5: //Show Cust By Filter
                    Console.WriteLine("Filter by (L)ast Name or (C)ity?");
                    string LorC = Console.ReadLine().ToUpper();
                    Console.WriteLine("Pick a letter (A-Z) to filter by: ");
                    string filterLetter = Console.ReadLine();
                    Console.WriteLine(CRUD.showCustByFilter(LorC, filterLetter));
                    break;
                case 6: //Quit App
                    Environment.Exit(0);
                    break;
                default: //Incorrect Selection
                    Console.WriteLine("Incorrect Selection Please Try Again");
                    break;
            }
        }
    }
}
