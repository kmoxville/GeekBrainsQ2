using System;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber rt1 = new RationalNumber(5, 6);
            RationalNumber rt2 = new RationalNumber(8, 12);

            Console.WriteLine($"{rt1} + {rt2} = {rt1 + rt2}");
            Console.WriteLine($"{rt1} - {rt2} = {rt1 - rt2}");
            Console.WriteLine($"{rt1} * {rt2} = {rt1 * rt2}");
            Console.WriteLine($"{rt1} / {rt2} = {rt1 / rt2}");

            Console.WriteLine($"{rt1} > {rt2} = {rt1 > rt2}");
            Console.WriteLine($"{rt1} < {rt2} = {rt1 < rt2}");
            Console.WriteLine($"{rt1} >= {rt2} = {rt1 >= rt2}");
            Console.WriteLine($"{rt1} <= {rt2} = {rt1 <= rt2}");

            var test = new RationalNumber(rt1);
            Console.WriteLine($"{rt1}++ = {test++}");

            test = new RationalNumber(rt1);
            Console.WriteLine($"{rt1}-- = {test--}");

            Console.WriteLine($"(float){rt1} = {(float)rt1}");
            Console.WriteLine($"(int){rt1} = {(int)rt1}");
        }
    }
}
