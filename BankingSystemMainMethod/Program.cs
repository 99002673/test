using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Banking_System;

namespace BankingSystemMainMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            SavingAccount savAccObj = new SavingAccount();
            savAccObj.AccountHolderName.Add("Virat");
            savAccObj.AccountHolderName.Add("Kohli");
            savAccObj.AccountOpeningDate = System.DateTime.Now.AddDays(-600);
            savAccObj.BalanceAmount = 50000;

            CheckingAccount chkAccObj = new CheckingAccount();
            chkAccObj.AccountHolderName.Add("Yuvraj");
            chkAccObj.AccountHolderName.Add("Singh");
            chkAccObj.AccountOpeningDate = System.DateTime.Now.AddDays(-450);
            chkAccObj.BalanceAmount = 35000;

            bool check = true;
            while(check)
            {
                try
                {
                    Console.WriteLine("\n\nSelect the Account Type:");
                    Console.WriteLine("1.Saving Account\n2.Checking Account\n3.Exit");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        savAccObj.VerifyAccountAndDoTransaction(savAccObj);

                    }
                    else if (choice == 2)
                    {
                        chkAccObj.VerifyAccountAndDoTransaction(chkAccObj);

                    }
                    else if (choice == 3)
                    {
                        check = false;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid number");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception Occured: {0}", e);
                }
                finally
                {
                    Console.WriteLine("\n\n---- Press valid number to Continue else Enter 3 to exit ----");
                }
                }
        }
    }
}
