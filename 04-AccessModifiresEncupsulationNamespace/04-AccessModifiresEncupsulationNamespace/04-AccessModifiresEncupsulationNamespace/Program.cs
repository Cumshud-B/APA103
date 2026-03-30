using _04_AccessModifiresEncupsulationNamespace.Models;

namespace _04_AccessModifiresEncupsulationNamespace
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Student student = new Student(" ");
            //student.name = "test";
            //Console.WriteLine(student.name); 



            Car car = new Car();
            car.horsepower = 200;
            Console.WriteLine(car.horsepower);
        }
    }
}
