using System;
using DataProject;
using System.Text;

namespace PresentationProject
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool Open = true;
            SalesContext salesContext = new SalesContext();
            while (Open)
            {
                Menu.menuStrings();
                int caseNum = Convert.ToInt32(Console.ReadLine());
                Menu.theSwitch(caseNum);
            }
        }
    }
}
