using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class BankAccount
    {
        private decimal _balance;

        #region ctor

        public BankAccount(BankNumber number, decimal balance)
        {
            Number = number;
            Balance = balance;
        }

        public BankAccount(string number, decimal balance)
        {
            Number = new BankNumber(number);
            Balance = balance;
        }

        public BankAccount(BankNumber number)
            : this(number, 0)
        {

        }

        public BankAccount(string number)
            : this(number, 0)
        {

        }

        public BankAccount()
            : this(BankNumber.GenerateRandom())
        {

        }

        #endregion

        public BankNumber Number 
        { 
            get; 
            set; 
        }

        public decimal Balance
        {
            get => _balance;
            set
            {
                if (value < 0)
                    throw new ArgumentException("BankAccount balance");

                _balance = value;
            }
        }

        public BankAccount Add(decimal payment)
        {
            Balance += payment;

            return this;
        }  

        public override string ToString()
        {
            return $"BankAccount [Number: {Number}; Balance: {Balance}]";
        }
    }
}
