using System;

namespace Homework_05.Models;


class Program
{
    static void Main()
    {
        var car1 = new Car("Mercedes", "E200", 2023, "10-AA-001", 4, 500, true, 220);
        var car2 = new Car("BMW", "320i", 2022, "10-AA-002", 4, 480, true, 235);
        var car3 = new Car("Toyota", "Camry", 2021, "10-AA-003", 4, 524, true, 210);

        var m1 = new Motorcycle("Yamaha", "R1", 2023, "10-BB-001", 998, false, 299, "Sport");
        var m2 = new Motorcycle("Harley-Davidson", "HD", 2022, "10-BB-002", 1868, true, 180, "Cruiser");

        var t1 = new Truck("MAN", "TGX", 2020, "10-CC-001", 18, 3, 12, 120);
        var t2 = new Truck("Volvo", "FH16", 2021, "10-CC-002", 25, 4, 18, 110);

        car1.ShowCarInfo();
        Console.WriteLine(car1.CalculateFuelCost(500));

        car2.ShowCarInfo();
        Console.WriteLine(car2.CalculateFuelCost(500));

        car3.ShowCarInfo();
        Console.WriteLine(car3.CalculateFuelCost(500));

        m1.ShowMotorcycleInfo();
        Console.WriteLine(m1.CalculateFuelCost(300));

        m2.ShowMotorcycleInfo();
        Console.WriteLine(m2.CalculateFuelCost(300));

        t1.ShowTruckInfo();
        Console.WriteLine(t1.CalculateFuelCost(800));

        t2.ShowTruckInfo();
        Console.WriteLine(t2.CalculateFuelCost(800));

        t1.LoadCargo(5);
        Console.WriteLine(t1.CalculateFuelCost(800));

        Console.WriteLine("Total: 7");

        double avgSpeed = (220 + 235 + 210 + 299 + 180 + 120 + 110) / 7.0;
        Console.WriteLine("Average speed: " + avgSpeed);
    }
}