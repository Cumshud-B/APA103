using System;
using CalculatorApp.Classes;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculation calc = new Calculation();

            Console.Write("Birinci Ededi Daxil Et: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("İkinci Ededi Daxil Et: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Riyazi emel daxil et (+, -, *, /): ");
            string op = Console.ReadLine();

            try
            {
                double result = calc.Calculate(a, b, op);
                Console.WriteLine("Netice: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xeta: " + ex.Message);
            }
        }
    }
}