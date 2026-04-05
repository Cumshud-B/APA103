using System;
using System.Collections.Generic;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Managers;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Book book1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
            Book book2 = new Book(2, "1984", "George Orwell", 1949, 328);
            Book book3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
            Book book4 = new Book(4, "Ag Gemi", "Cingiz Aytmatov", 1970, 200);
            Book book5 = new Book(5, "Qiriq Budaq", "Elcin", 1998, 350);

            book1.DisplayInfo();
            book2.DisplayInfo();
            book3.DisplayInfo();
            book4.DisplayInfo();
            book5.DisplayInfo();

         
            Library<Book> library = new Library<Book>("Milli Kitabxana");

            library.Add(book1);
            library.Add(book2);
            library.Add(book3);
            library.Add(book4);
            library.Add(book5);

            Console.WriteLine("Kitab sayi: " + library.Count());

            library.FindByIndex(0)?.DisplayInfo();
            library.FindByIndex(2)?.DisplayInfo();

            foreach (var book in library.GetAll())
            {
                book.DisplayInfo();
            }

            
            List<Member> members = new List<Member>
            {
                new Member(1, "Ali Memmedov", "ali@mail.com"),
                new Member(2, "Leyla Hesenova", "leyla@mail.com"),
                new Member(3, "Vuqar Eliyev", "vuqar@mail.com")
            };

            members[0].BorrowBook(book1);
            members[0].BorrowBook(book2);
            members[0].DisplayBorrowedBooks();

            members[0].ReturnBook(1);
            members[0].DisplayBorrowedBooks();

            members[0].BorrowBook(book3);
            members[0].BorrowBook(book4);
            members[0].BorrowBook(book5); 

            
            BookManager manager = new BookManager();

            manager.AddBook(book1);
            manager.AddBook(book2);
            manager.AddBook(book3);
            manager.AddBook(book4);
            manager.AddBook(book5);

            var orwellBooks = manager.GetBooksByAuthor("George Orwell");
            foreach (var b in orwellBooks)
                b.DisplayInfo();

            
            manager.AddToWaitingQueue("Nigar");
            manager.AddToWaitingQueue("Resad");
            manager.AddToWaitingQueue("Sebine");

            Console.WriteLine("Xidmet edilir: " + manager.ServeNextInQueue());

            
            manager.ReturnBook(book1);
            manager.ReturnBook(book2);
            manager.ReturnBook(book3);

            Console.WriteLine("Son kitab:");
            manager.GetLastReturnedBook()?.DisplayInfo();

            manager.RecentlyReturned.Pop();

            Console.WriteLine("Son kitab:");
            manager.GetLastReturnedBook()?.DisplayInfo();

            
            var found = manager.SearchByTitle("1984");
            found?.DisplayInfo();

            var notFound = manager.SearchByTitle("Harry Potter");
            if (notFound == null)
                Console.WriteLine("Tapolmadi");

            
            Console.WriteLine("Umumi kitab: " + manager.Books.Count);
            Console.WriteLine("Uzv sayi: " + members.Count);
            Console.WriteLine("Novbe: " + manager.WaitingQueue.Count);
            Console.WriteLine("Stack: " + manager.RecentlyReturned.Count);

            int minYear = int.MaxValue;
            int maxYear = int.MinValue;

            foreach (var b in manager.Books)
            {
                if (b.Year < minYear) minYear = b.Year;
                if (b.Year > maxYear) maxYear = b.Year;
            }

            Console.WriteLine("En kohne il: " + minYear);
            Console.WriteLine("En yeni il: " + maxYear);
        }
    }
}