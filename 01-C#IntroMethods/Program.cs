//using System;

//class Program
//{
//    static void Main()
//    {
//        Console.Write("Birinci ededi daxil edin: ");
//        double a = Convert.ToDouble(Console.ReadLine());

//        Console.Write("Emeliyyati daxil edin (+, -, *, /, %, ^): ");
//        string emel = Console.ReadLine();

//        Console.Write("Ikinci ededi daxil edin: ");
//        double b = Convert.ToDouble(Console.ReadLine());

//        double netice = Hell(a, b, emel);

//        Console.WriteLine("Netice: " + netice);
//    }

//    static double Hell(double a, double b, string emel)
//    {
//        double result = 0;

//        switch (emel)
//        {
//            case "+":
//                result = a + b;
//                break;

//            case "-":
//                result = a - b;
//                break;

//            case "*":
//                result = a * b;
//                break;

//            case "/":
//                if (b != 0)
//                    result = a / b;
//                else
//                {
//                    Console.WriteLine("0-a bolmek olmaz!");
//                }
//                break;

//            case "%":
//                result = a % b;
//                break;

//            case "^":
//                result = Math.Pow(a, b);
//                break;

//            default:
//                Console.WriteLine("Yanlis emeliyyat daxil etdiniz.");
//                break;
//        }

//        return result;
//    }
//}



// using System;

// class Program
//{
//    static void Main()
//    {
//        TekCutEdedler(14, 20, 35, 40, 57, 60, 100);
//    }

//    static void TekCutEdedler(params int[] ededler)
//    {
//        for (int i = 0; i < ededler.Length; i++)
//        {
//            if (ededler[i] % 2 == 0)
//            {
//                Console.WriteLine("Cut Eded: " + ededler[i]);
//            }
//            else
//            {
//                Console.WriteLine("Tek Eded: " + ededler[i]);
//            }
//        }
//    }
//}



// using System;

// class Program
//{
//    static void Main()
//    {
//        DordeVeBeseBolunenler(14, 20, 35, 40, 57, 60, 100);
//    }

//    static void DordeVeBeseBolunenler(params int[] ededler)
//    {
//        for (int i = 0; i < ededler.Length; i++)
//        {
//            if (ededler[i] % 4 == 0 && ededler[i] % 5 == 0)
//            {
//                Console.WriteLine(ededler[i]);
//            }
//        }
//    }
//}


// using System;

// class Program
//{
//    static void Main()
//    {
//        Console.Write("Cumle daxil et: ");
//        string cumle = Console.ReadLine();

//        Console.Write("Simvol daxil et: ");
//        char simvol = Convert.ToChar(Console.ReadLine());

//        int say = 0;

//        for (int i = 0; i < cumle.Length; i++)
//        {
//            if (cumle[i] == simvol)
//            {
//                say++;
//            }
//        }

//        Console.WriteLine("Bu simvoldan " + say + " eded var.");
//    }
//}