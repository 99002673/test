using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    public abstract class Accounts
    {
        public List<string> AccountHolderName;
        public List<double> ListOfTransactions;
        public double BalanceAmount { get; set; }
        public string AccountNumber { get; set; }
        public DateTime AccountOpeningDate { get; set; }
        public Accounts()
        {
            AccountHolderName = new List<string>();
            ListOfTransactions = new List<double>();
        }

        public abstract double Debit(int amountToDebit);

        public double Credit(int amountToCredit)
        {
            ListOfTransactions.Add(amountToCredit);
            BalanceAmount = BalanceAmount + amountToCredit;
            return BalanceAmount;
        }

        public double CalculateBalanceAmount()
        {
            return BalanceAmount;
        }
    }
}
