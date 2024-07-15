using System;
using System.Collections.Generic;

namespace MyNamespace
{
    // Define a Book class
    public  class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ID { get; set; }
        public bool IsAvaliable { get; set; }

        public Book(string title, string author, int id)
        {
            Title = title;
            Author = author;
            ID = id;
            IsAvaliable = true;
        }
    }

    // Define a Person class
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Person(string name, int age, int id)
        {
            Name = name;
            Age = age;
            ID = id;
            BorrowedBooks = new List<Book>();
        }
    }

    // Define a Librarian class that inherits from Person
    public class Librarian : Person
    {
        public int Employee_code { get; set; }

        public Librarian(string name, int age, int id, int employee_code) : base(name, age, id)
        {
            Employee_code = employee_code;
        }
    }

    // Define a Library class
    public class Library
    {
        public string Libraryname { get; set; }
        public int LibraryId { get; set; }
        public List<Book> BookList { get; set; }
        public List<Person> PersonList { get; set; }

        public Library(string libraryname, int libraryId)
        {
            Libraryname = libraryname;
            LibraryId = libraryId;
            BookList = new List<Book>();
            PersonList = new List<Person>();
        }

        // Add a book to the library
        public void AddBook(Book book)
        {
            BookList.Add(book);
            Console.WriteLine($"Congratulations! Your book {book.Title} has been added");
        }

        // Remove a book from the library
        public void RemoveBook(Book book)
        {
            if (BookList.Contains(book))
            {
                BookList.Remove(book);
                Console.WriteLine($"Congratulations! The book {book.Title} has been removed");
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }

        // View all books in the library
        public void ViewBook()
        {
            if (BookList.Count != 0)
            {
                Console.WriteLine("Books in the library are : ");
                foreach (Book book in BookList)
                {
                    Console.WriteLine($"Book Title {book.Title}, Author : {book.Author}, Book_ID {book.ID}");
                }
            }
            else
            {
                Console.WriteLine("No books found!");
            }
        }

        // Issue a book to a person
        public void IssueBook(Book book, Person person)
        {
            if (book.IsAvaliable)
            {
                book.IsAvaliable = false;
                person.BorrowedBooks.Add(book);
                Console.WriteLine($"Book {book.Title} issued to a user {person.Name} by librarian");
            }
            else
            {
                Console.WriteLine($"Book {book.Title} is not avaliable!");
            }
        }

        // Return a book from a person
        public void ReturnBook(Book book, Person person)
        {
            if (person.BorrowedBooks.Contains(book))
            {
                book.IsAvaliable = true;
                person.BorrowedBooks.Remove(book);
                Console.WriteLine($"Book {book.Title} is returned by the user {person.Name}");
            }
            else
            {
                Console.WriteLine($"User {person.Name} does not have book '{book.Title}' to return");
            }
        }

        // Search for a book by title
        public Book SearchBook(string title)
        {
            foreach (Book book in BookList)
            {
                if (book.Title.ToLower() == title.ToLower())
                {
                    return book;
                }
            }
            return null;
        }

        // Get issued books for a person
        public void GetIssuedBooks(Person person)
        {
            if (person.BorrowedBooks.Count > 0)
            {
                Console.WriteLine($"Books issued to {person.Name} are: ");
                foreach (Book book in person.BorrowedBooks)
                {
                    Console.WriteLine($"Book Title {book.Title}, Author : {book.Author}, Book ID {book.ID}");
                }
            }
            else
            {
                Console.WriteLine($"{person.Name} has not borrowed any books");
            }
        }

       
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a book
            Book book_1 = new Book("book1", "hammad", 1);
            GetInfo(book_1);

            // Create persons
            Person person_1 = new Person("Hadi", 23, 53);
            Person person_2 = new Person("Wali", 22, 50);
            

            Person_Info(person_1);
            // Person_Info(person_2);

            Library myLibrary = new Library("My Library", 1);
            Book book1 = new Book("Book 1", "wali", 1);
            Book book2 = new Book("Book 2", "hadi", 2);
            Book book3 = new Book("Book 3", "maryam", 3);

            myLibrary.AddBook(book1);
            myLibrary.AddBook(book2);
            myLibrary.AddBook(book3);

            
           

            myLibrary.ViewBook();

            myLibrary.RemoveBook(book2);

            myLibrary.ViewBook();

            Librarian librarian = new Librarian("John Doe", 30, 1234, 09);



            myLibrary.IssueBook(book1, person_1);
            myLibrary.ReturnBook(book1, person_1);

            Book bookfound = myLibrary.SearchBook("Book 3");
            if (bookfound != null)
            {
                Console.WriteLine($"Congratulations ! your {bookfound.Title} is found written by {bookfound.Author}");
            }

            myLibrary.GetIssuedBooks(person_2);
        }

        public static void GetInfo(Book book_1)
        {
            Console.WriteLine("book_1");
            Console.WriteLine($"Title : {book_1.Title} , Author : {book_1.Author}, ID : {book_1.ID}");
        }

        public static void Person_Info(Person person_1)
        {
            Console.WriteLine("Person_1");
            Console.WriteLine($"Name : {person_1.Name} , Age : {person_1.Age}, ID : {person_1.ID}");
        }
    }
}
