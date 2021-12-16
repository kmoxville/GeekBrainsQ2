using System;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            ICoder coder = new ACoder();
            string testStr = "AZHello World!";

            Console.WriteLine($"ACoder test");
            Console.WriteLine($"Test string = {testStr}");

            testStr = coder.Encode(testStr);
            Console.WriteLine($"Encoded test string = {testStr}");

            testStr = coder.Decode(testStr);
            Console.WriteLine($"Dencoded test string = {testStr}");

            coder = new BCoder();
            testStr = "AZHello World!";

            Console.WriteLine($"BCoder test");
            Console.WriteLine($"Test string = {testStr}");

            testStr = coder.Encode(testStr);
            Console.WriteLine($"Encoded test string = {testStr}");

            testStr = coder.Decode(testStr);
            Console.WriteLine($"Dencoded test string = {testStr}");
        }
    }
}
