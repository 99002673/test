using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Banking_System
{
    public class CheckingAccount : Accounts
    {
        CheckingAccount sObj1;
        public CheckingAccount()
        {

            Transactions.TransactionId = 500;
            Transactions.TransactionDate = System.DateTime.Now;
        }
        public void VerifyAccountAndDoTransaction(CheckingAccount chkAccObj)
        {
            sObj1 = chkAccObj;
            Console.WriteLine("Enter the Account Number");
            sObj1.AccountNumber = Console.ReadLine();
            Regex regx = new Regex(@"^\d{9}$");
            if (regx.IsMatch(sObj1.AccountNumber))
            {
                Console.WriteLine("Valid Account Number");
                Console.WriteLine("\n------ Welcome To Checking Account -------\n");
                Console.WriteLine("Account Opening Date: {0}", sObj1.AccountOpeningDate);
                Console.WriteLine("Account Holder Name: {0} {1}", sObj1.AccountHolderName[0], sObj1.AccountHolderName[1]);
                bool choice = true;
                while (choice)
                {
                    choice = AmountTransaction(ref sObj1);
                }
            }
            else
            {
                Console.WriteLine("Invalid Account Number! Account number must contain 9 digits..");

            }

        }
        public bool AmountTransaction(ref CheckingAccount chkAccObj)
        {
            try
            {
                Console.WriteLine("Choose the Transaction \n 1. Debit \n 2. Credit \n 3. CheckBalance\n 4. List Of Transaction\n 5. Cancel\n");
                int traction = Convert.ToInt32(Console.ReadLine());
                if (traction == 1)
                {
                    Console.WriteLine("Enter amount to Debit");
                    int dbAmount = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Receiver/To Account Name");
                    Transactions.TransactionTo = Console.ReadLine();
                    var status = chkAccObj.Debit(dbAmount);
                    if (status == 0)
                    {
                        Console.WriteLine("Insufficient Balance!");
                    }
                    else
                    {
                        Console.WriteLine("\nTransaction ID: {0} ", Transactions.TransactionId);
                        Transactions.TransactionId += 1;
                        Console.WriteLine("Rs {0} successfully Debited from {1} {2} and Credited to {3} on {4} ", dbAmount, chkAccObj.AccountHolderName[0], chkAccObj.AccountHolderName[1], Transactions.TransactionTo, Transactions.TransactionDate);

                        Console.WriteLine("Balance amount after Debiting Rs {0} along with transaction Charges: {1}", dbAmount, chkAccObj.BalanceAmount);
                    }
                    return true;
                }
                else if (traction == 2)
                {
                    Console.WriteLine("Enter amount to Credit");
                    int crAmount = Convert.ToInt32(Console.ReadLine());

                    var status = chkAccObj.Credit(crAmount);
                    Console.WriteLine("\nTransaction ID {0}: ", Transactions.TransactionId);
                    Transactions.TransactionId += 1;
                    Console.WriteLine("Rs {0} successfully Credited to your account on {1}  ", crAmount, Transactions.TransactionDate);
                    Console.WriteLine("Total balance after Crediting Rs {0} : {1}", crAmount, status);
                    return true;
                }
                else if (traction == 3)
                {
                    Console.WriteLine("Current Balance: {0} ", chkAccObj.BalanceAmount);
                    return true;
                }
                else if (traction == 4)
                {
                    Console.WriteLine("List Of Transaction: ");
                    if (chkAccObj.ListOfTransactions.Count == 0)
                    {
                        Console.WriteLine("No Transaction history found!");
                    }
                    else
                    {
                        foreach (var list in chkAccObj.ListOfTransactions)
                        {
                            Console.Write(list + " ");
                        }
                    }
                    return true;
                }
                else if (traction == 5)
                {
                    Console.WriteLine("Transaction is Cancled");
                    return false;
                }
                else
                {
                    Console.WriteLine("Enter the Valid number");
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occured: " + e);
                return true;
            }
            finally
            {
                Console.WriteLine("\n\n----Press valid number to Continue else Enter 5 to exit----\n\n");
            }



        }

        public override double Debit(int amountToDebit)
        {
            if (BalanceAmount < amountToDebit)
            {
                return 0;
            }
            else
            {
                ListOfTransactions.Add(amountToDebit);
                var charges = amountToDebit * 0.025;
                BalanceAmount = BalanceAmount - (amountToDebit + charges);
                return BalanceAmount;
            }

        }
    }
}
