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

        public BankAccount(BankNumber number, BankAccountKind kind, decimal balance)
        {
            Number = number;
            Balance = balance;
            Kind = kind;
        }

        public BankAccount(string number, BankAccountKind kind, decimal balance)
            : this(new BankNumber(number), kind, balance)
        {

        }

        public BankAccount(BankNumber number)
            : this(number, BankAccountKind.VISA, 0)
        {

        }

        public BankAccount(string number)
            : this(number, BankAccountKind.VISA, 0)
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
            init; 
        }

        public BankAccountKind Kind
        {
            get;
            init;
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

        public void Transfer(BankAccount anotherBankAccount, Decimal value)
        {
            anotherBankAccount.Add(value);
            this.Add(-value);
        }

        public override string ToString()
        {
            return $"BankAccount [Number: {Number}; Kind: {Kind}; Balance: {Balance}]";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            BankAccount ba = (BankAccount)obj;

            return ba.Number == this.Number;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public static bool operator ==(BankAccount leftBA, BankAccount rightBA)
        {
            if (leftBA is null)
                return rightBA is null;

            return leftBA.Equals(rightBA);
        }

        public static bool operator !=(BankAccount leftBA, BankAccount rightBA)
        {

            return leftBA == rightBA;
        }
    }

    enum BankAccountKind
    {
        VISA,
        MASTERCARD
    }
}
