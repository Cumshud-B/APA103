using System;

namespace Homework_05.Models
{
    public class Car : Vehicle
    {
        public int DoorsCount { get; set; }
        public int TrunkCapacity { get; set; }
        public bool IsAutomatic { get; set; }
        public int MaxSpeed { get; set; }

        public Car(string brand, string model, int year, string plateNumber,
                   int doors, int trunk, bool isAutomatic, int maxSpeed)
            : base(brand, model, year, plateNumber)
        {
            this.DoorsCount = doors;
            this.TrunkCapacity = trunk;
            this.IsAutomatic = isAutomatic;
            this.MaxSpeed = maxSpeed;
        }

        public void ShowCarInfo()
        {
            ShowBasicInfo();
            Console.WriteLine($"Doors: {DoorsCount}, Trunk: {TrunkCapacity}, Auto: {IsAutomatic}, MaxSpeed: {MaxSpeed}");
        }

        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 8 * 1.50;
        }
    }
}