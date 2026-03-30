using System;
using CafeApp.Enums;
using CafeApp.Models;

namespace CafeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1️⃣ Sifarişlər

            DrinkOrder order1 = new DrinkOrder(101, "Eli", DrinkType.Coffee, DrinkSize.Medium);
            order1.DisplayOrder();
            order1.UpdateStatus(OrderStatus.Preparing);
            order1.UpdateStatus(OrderStatus.Ready);
            order1.UpdateStatus(OrderStatus.Delivered);

            DrinkOrder order2 = new DrinkOrder(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
            order2.DisplayOrder();
            order2.UpdateStatus(OrderStatus.Ready);

            DrinkOrder order3 = new DrinkOrder(103, "Vuqar", DrinkType.Juice, DrinkSize.Small);
            order3.DisplayOrder();

            

            Console.WriteLine("\nDrinkType deyerleri:");
            foreach (var item in Enum.GetValues(typeof(DrinkType)))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nDrinkSize deyerleri:");
            foreach (var item in Enum.GetValues(typeof(DrinkSize)))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nOrderStatus deyerleri:");
            foreach (var item in Enum.GetValues(typeof(OrderStatus)))
            {
                Console.WriteLine(item);
            }

            
            Console.WriteLine("\nToString numune:");
            Console.WriteLine(DrinkType.Coffee.ToString());
            Console.WriteLine(DrinkSize.Large.ToString());

            
            Console.WriteLine("\nParse numune:");
            DrinkType parsedDrink = (DrinkType)Enum.Parse(typeof(DrinkType), "Tea");
            DrinkSize parsedSize = (DrinkSize)Enum.Parse(typeof(DrinkSize), "Medium");

            Console.WriteLine(parsedDrink);
            Console.WriteLine(parsedSize);

            // 3️⃣ Statistika

            Console.WriteLine("\nStatistika:");
            Console.WriteLine("Umumi sifaris: 3");

            Console.WriteLine($"1-ci sifaris qiymeti: {order1.Price}");
            Console.WriteLine($"2-ci sifaris qiymeti: {order2.Price}");
            Console.WriteLine($"3-cu sifaris qiymeti: {order3.Price}");

            decimal total = order1.Price + order2.Price + order3.Price;
            Console.WriteLine($"Umumi mebleg: {total}");
        }
    }
}