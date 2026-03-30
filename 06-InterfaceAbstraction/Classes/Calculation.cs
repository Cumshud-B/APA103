using CalculatorApp.Interfaces;
using System;

namespace CalculatorApp.Classes
{
    public class Calculation : ICalculation
    {
        public double Calculate(double a, double b, string operation)
        {
            switch (operation)
            {
                case "+":
                    return a + b;

                case "-":
                    return a - b;

                case "*":
                    return a * b;

                case "/":
                    if (b == 0)
                        throw new DivideByZeroException("0-a bolmek olmaz!");
                    return a / b;

                default:
                    throw new InvalidOperationException("Yanlis Emel!");
            }
        }
    }
}