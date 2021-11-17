using System;

namespace Lesson2
{
    /// <summary>
    /// BankAccount() генерирует случайный 20 значный номер
    /// снять со счета и положить на счет - метод Add
    /// свойства используются внутри конструктора
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            Console.WriteLine($"Test BankAccount: {account}");

            account.Add(100)
                .Add(200);

            Console.WriteLine($"Test BankAccount: {account}");
        }
    }
}
