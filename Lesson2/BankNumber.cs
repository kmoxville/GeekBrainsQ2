using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class BankNumber
    {
        public const int NUMBER_LENGTH = 20;

        private string _number;

        public BankNumber(string number)
        {
            Number = number;
        }

        public string Number
        {
            get => _number;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length != NUMBER_LENGTH || !value.All(ch => char.IsDigit(ch)))
                    throw new ArgumentException("BankNumber.set_Number");
                
                _number = value;                                  
            }
        }

        public static BankNumber GenerateRandom()
        {
            Random rand = new Random();
            string chars = "1234567890";

            return new BankNumber(new string(Enumerable.Repeat(0, NUMBER_LENGTH).Select(_ => chars[rand.Next(chars.Length)]).ToArray()));
        }

        public static BankNumber Parse(string number)
        {
            return new BankNumber(number);
        }

        public static bool TryParse(string number, out BankNumber bankNumber)
        {
            bankNumber = null;

            try
            {
                bankNumber = Parse(number);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"BankNumber [{_number.ToString()}]";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            BankNumber bn = (BankNumber)obj;

            return bn.Number == this.Number;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}
