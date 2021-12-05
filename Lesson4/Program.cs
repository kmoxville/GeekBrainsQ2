using System;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            var building1 = BuildingCreator.Default.Create();
            var building2 = BuildingCreator.Default.Create();

            building1.Height = 20;
            building1.Floors = 5;
            building1.Entrances = 3;

            building2.Height = 50;
            building2.Floors = 15;
            building2.Entrances = 2;

            Console.WriteLine(BuildingCreator.Default.GetById(1));
            Console.WriteLine(BuildingCreator.Default.GetById(2));
            Console.WriteLine(BuildingCreator.Default.GetById(3));

            Console.WriteLine($"Delete building with id 1: {BuildingCreator.Default.RemoveById(1)}");
            Console.WriteLine($"Delete building with id 2: {BuildingCreator.Default.RemoveById(2)}");
            Console.WriteLine($"Delete building with id 3: {BuildingCreator.Default.RemoveById(3)}");
        }
    }
}
