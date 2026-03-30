using System;

namespace Homework_05.Models
{
    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string PlateNumber { get; set; }
        public double FuelLevel { get; set; }

        public Vehicle(string brand, string model, int year, string plateNumber)
        {
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.PlateNumber = plateNumber;
            this.FuelLevel = 100;
        }

        public string GetVehicleInfo()
        {
            return $"{Brand} {Model} ({Year}) - {PlateNumber} - Fuel: {FuelLevel}%";
        }

        public void ShowBasicInfo()
        {
            Console.WriteLine(GetVehicleInfo());
        }
    }
}