using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Member(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            if (BorrowedBooks.Count >= 3)
            {
                Console.WriteLine("Maksimum 3 kitab goture bilersiniz!");
                return;
            }

            BorrowedBooks.Add(book);
            Console.WriteLine($"Kitab goturuldu: {book.Title}");
        }

        public void ReturnBook(int bookId)
        {
            foreach (var book in BorrowedBooks)
            {
                if (book.Id == bookId)
                {
                    BorrowedBooks.Remove(book);
                    Console.WriteLine($"Kitab qaytarildi: {book.Title}");
                    return;
                }
            }
        }

        public void DisplayBorrowedBooks()
        {
            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("Borc kitab yoxdur");
                return;
            }

            foreach (var book in BorrowedBooks)
            {
                book.DisplayInfo();
            }
        }
    }
}