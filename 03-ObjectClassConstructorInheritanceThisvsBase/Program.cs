using System;
using UniversitySystem.Models;

class Program
{
    static void Main(string[] args)
    {

        Student student1 = new Student("Jumshud", "Bakhtiyarli", 20, "baktiyarli2006@gmail.com", "APA103", "ST1001", "IT", 88.5, 2);
        Student student2 = new Student("Hamid", "Aliyev", 21, "hamidali@gmail.com", "APA104", "ST1002", "IT", 92.0, 3);
        Student student3 = new Student("Murad", "Huseynov", 19, "murad@mail.com", "APA105", "ST1003", "IT", 68.5, 1);


        Teacher t1 = new Teacher("Kamran", "Hasanov", 45, "kamran@mail.com", "P010", "Computer Science", "Programming", 800, 15);
        Teacher t2 = new Teacher("Nigar", "Quliyeva", 38, "nigar@mail.com", "P011", "Computer Science", "Database", 800, 8);


        Administrator admin = new Administrator("Said", "Nuraliyev", 38, "saidn@gmail.com", "P100", "teacher", "IT Faculty", 5);

        int totalScholarship = 0;
        decimal totalSalary = 0;


        Student[] students = { student1, student2, student2 };

        foreach (var student in students)
        {
            student.ShowStudentInfo();
            int scholarship = student.CalculateScholarship();
            Console.WriteLine($"Teqaud: {scholarship} AZN\n");
            totalScholarship += scholarship;
        }


        Teacher[] teachers = { t1, t2 };

        foreach (var teacher in teachers)
        {
            teacher.ShowTeacherInfo();
            decimal salary = teacher.CalculateSalary();
            Console.WriteLine($"Maas: {salary} AZN\n");
            totalSalary += salary;
        }


        admin.ShowAdminInfo();

        Console.WriteLine();
        admin.GrantAccess(student1);

        Console.WriteLine($"Umumi teqaud xerci: {totalScholarship} AZN");
        Console.WriteLine($"Umumi maas xerci: {totalSalary} AZN");
    }
}