using BankAccount;
using System;

namespace BankAccount
{
    public class DateGenerator : IDateGenerator
    {
        public string TodayAsString()
        {
            return Today.ToString("dd/MM/yyyy");
        }

        protected virtual DateTime Today
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}