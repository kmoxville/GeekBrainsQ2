using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class RationalNumber
    {
        private int _numerator; //числитель
        private int _denominator; //знаменатель

        public RationalNumber(int numerator = 0, int denominator = 1)
        {
            Numerator = numerator;
            Denominator = denominator;

            var gcd = ((int)BigInteger.GreatestCommonDivisor(
                Math.Abs(numerator), 
                Math.Abs(denominator)));

            if (gcd > 1)
            {
                Numerator /= gcd;
                Denominator /= gcd;
            }
        }

        public RationalNumber(RationalNumber right)
        {
            Numerator = right.Numerator;
            Denominator = right.Denominator;
        }

        public int Numerator 
        { 
            get => _numerator; 
            set => _numerator = value; 
        }
        
        public int Denominator 
        { 
            get => _denominator; 
            set
            {
                if (value == 0) throw new ArgumentOutOfRangeException("Denominator = 0");

                _denominator = value;
            }
        }  

        public static bool operator ==(RationalNumber left, RationalNumber right)
        {
            CheckParameters(left, right);

            return left.Equals(right);
        }

        public static bool operator !=(RationalNumber left, RationalNumber right)
        {
            CheckParameters(left, right);

            return !left.Equals(right);
        }

        public static bool operator <(RationalNumber left, RationalNumber right)
        {
            CheckParameters(left, right);

            return left.Numerator / left.Denominator < right.Numerator / right.Denominator;
        }

        public static bool operator >(RationalNumber left, RationalNumber right)
        {
            CheckParameters(left, right);

            return !(left <= right);
        }

        public static bool operator <=(RationalNumber left, RationalNumber right)
        {
            CheckParameters(left, right);

            return left < right || left.Equals(right);
        }

        public static bool operator >=(RationalNumber left, RationalNumber right)
        {
            CheckParameters(left, right);

            return left > right || left.Equals(right);
        }

        public static RationalNumber operator +(RationalNumber left, RationalNumber right)
        {
            CheckParameters(left, right);

            return new RationalNumber(
                left.Numerator * right.Denominator + left.Denominator * right.Numerator,
                left.Denominator * right.Denominator);
        }

        public static RationalNumber operator -(RationalNumber left, RationalNumber right)
        {
            CheckParameters(left, right);

            return new RationalNumber(
                left.Numerator * right.Denominator - left.Denominator * right.Numerator,
                left.Denominator * right.Denominator);
        }

        public static RationalNumber operator ++(RationalNumber left)
        {
            CheckParameters(left);

            left.Numerator += left.Denominator;

            return left;
        }

        public static RationalNumber operator --(RationalNumber left)
        {
            CheckParameters(left);

            left.Numerator -= left.Denominator;

            return left;
        }

        public static RationalNumber operator *(RationalNumber left, RationalNumber right)
        {
            CheckParameters(left, right);

            return new RationalNumber(
                left.Numerator * right.Numerator,
                left.Denominator * right.Denominator);
        }

        public static RationalNumber operator /(RationalNumber left, RationalNumber right)
        {
            CheckParameters(left, right);

            return new RationalNumber(
                left.Numerator * right.Denominator,
                left.Denominator * right.Numerator);
        }

        public static implicit operator float(RationalNumber left)
        {
            return (float)left.Numerator / left.Denominator;
        }

        public static implicit operator int(RationalNumber left)
        {
            return left.Numerator / left.Denominator;
        }

        private static void CheckParameters(RationalNumber left, RationalNumber right)
        {
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
                throw new ArgumentNullException();
        }

        private static void CheckParameters(RationalNumber left)
        {
            if (object.ReferenceEquals(left, null))
                throw new ArgumentNullException();
        }

        public override bool Equals(object obj)
        {
            RationalNumber rightValue = obj as RationalNumber;

            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;

            return Numerator == rightValue.Numerator && Denominator == rightValue.Denominator;
        }

        public override string ToString()
        {
            return $"{Numerator} / {Denominator}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
