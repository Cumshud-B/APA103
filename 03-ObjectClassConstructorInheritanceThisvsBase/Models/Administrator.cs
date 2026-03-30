
using System;

namespace UniversitySystem.Models
{
    public class Administrator : Person
    {
        public string Position;
        public string Department;
        public int AccessLevel;

        public Administrator(string firstName, string lastName, int age, string email, string id,
                             string position, string department, int accessLevel)
            : base(firstName, lastName, age, email, id)
        {
            this.Position = position;
            this.Department = department;
            this.AccessLevel = accessLevel;
        }

        public void ShowAdminInfo()
        {
            ShowBasicInfo();
            Console.WriteLine($"Vezife: {Position}");
            Console.WriteLine($"Sobe: {Department}");
            Console.WriteLine($"Giris seviyyesi: {AccessLevel}");
        }

        public void GrantAccess(Student student)
        {
            Console.WriteLine($"{student.GetFullName()} telebesine sisteme giris icazesi verildi.");
        }
    }
}