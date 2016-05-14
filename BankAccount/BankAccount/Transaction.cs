using System;

namespace BankAccount
{
    public class Transaction
    {
        public Transaction(string date, int amount)
        {
            Date = date;
            Amount = amount;
        }

        public string Date { get; private set; }
        public int Amount { get; private set; }

        public override bool Equals(object obj)
        {
            Transaction transaction = obj as Transaction;

            return Date.Equals(transaction.Date) && Amount == transaction.Amount;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}