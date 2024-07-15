public abstract class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int ID { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string title, string author, int id)
    {
        Title = title;
        Author = author;
        ID = id;
        IsAvailable = true;
    }

    public abstract void DisplayInfo();
}

public class FictionBook : Book
{
    public string Genre { get; set; }

    public FictionBook(string title, string author, int id, string genre)
        : base(title, author, id)
    {
        Genre = genre;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Book ID: {ID}, Genre: {Genre}");
    }
}

public class NonFictionBook : Book
{
    public string Subject { get; set; }

    public NonFictionBook(string title, string author, int id, string subject)
        : base(title, author, id)
    {
        Subject = subject;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Book ID: {ID}, Subject: {Subject}");
    }
}

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

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Person ID: {ID}");
    }
}

public class Librarian : Person
{
    public int EmployeeCode { get; set; }

    public Librarian(string name, int age, int id, int employeeCode)
        : base(name, age, id)
    {
        EmployeeCode = employeeCode;
    }

    public void IssueBook(Book book, Person person)
    {
        if (book.IsAvailable)
        {
            book.IsAvailable = false;
            person.BorrowedBooks.Add(book);
            Console.WriteLine($"Book '{book.Title}' issued to {person.Name} by librarian");
        }
        else
        {
            Console.WriteLine($"Book '{book.Title}' is not available!");
        }
    }

    public void ReturnBook(Book book, Person person)
    {
        if (person.BorrowedBooks.Contains(book))
        {
            book.IsAvailable = true;
            person.BorrowedBooks.Remove(book);
            Console.WriteLine($"Book '{book.Title}' returned by {person.Name}");
        }
        else
        {
            Console.WriteLine($"{person.Name} does not have book '{book.Title}' to return");
        }
    }
}

public class Library
{
    public string LibraryName { get; set; }
    public int LibraryID { get; set; }
    public List<Book> BookList { get; set; }
    public List<Person> PersonList { get; set; }
    public Librarian Librarian { get; set; }

    public Library(string libraryName, int libraryId, Librarian librarian)
    {
        LibraryName = libraryName;
        LibraryID = libraryId;
        BookList = new List<Book>();
        PersonList = new List<Person>();
        Librarian = librarian;
    }

    public void AddBook(Book book)
    {
        BookList.Add(book);
        Console.WriteLine($"Congratulations! Your book '{book.Title}' has been added");
    }

    public void RemoveBook(Book book)
    {
        if (BookList.Contains(book))
        {
            BookList.Remove(book);
            Console.WriteLine($"Congratulations! The book '{book.Title}' has been removed");
        }
        else
        {
            Console.WriteLine("Book not found");
        }
    }

    public void ViewBooks()
    {
        if (BookList.Count != 0)
        {
            Console.WriteLine("Books in the library are: ");
            foreach (Book book in BookList)
            {
                book.DisplayInfo();
            }
        }
        else
        {
            Console.WriteLine("No books found!");
        }
    }

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

    public void GetIssuedBooks(Person person)
    {
        if (person.BorrowedBooks.Count > 0)
        {
            Console.WriteLine($"Books issued to {person.Name} are: ");
            foreach (Book book in person.BorrowedBooks)
            {
                book.DisplayInfo();
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
        // Create a librarian
        Librarian librarian = new Librarian("John Doe", 30, 1234, 09);

        // Create a library
        Library myLibrary = new Library("My Library", 1, librarian);

        // Create books
        FictionBook book1 = new FictionBook("Book 1", "Wali", 1, "Romance");
        FictionBook book2 = new FictionBook("Book 2", "Hadi", 2, "Thriller");
        NonFictionBook book3 = new NonFictionBook("Book 3", "Maryam", 3, "Science");

        // Add books to the library
        myLibrary.AddBook(book1);
        myLibrary.AddBook(book2);
        myLibrary.AddBook(book3);

        // View books in the library
        myLibrary.ViewBooks();

        // Remove a book from the library
        myLibrary.RemoveBook(book2);

        // View books in the library after removal
        myLibrary.ViewBooks();

        // Create persons
        Person person1 = new Person("Hadi", 23, 53);
        Person person2 = new Person("Wali", 22, 50);

        // Add persons to the library
        myLibrary.PersonList.Add(person1);
        myLibrary.PersonList.Add(person2);

        // Issue a book to a person
        librarian.IssueBook(book1, person1);

        // Return a book from a person
        librarian.ReturnBook(book1, person1);

        // Search for a book by title
        Book bookFound = myLibrary.SearchBook("Book 3");
        if (bookFound != null)
        {
            Console.WriteLine($"Congratulations! Your book '{bookFound.Title}' is found written by {bookFound.Author}");
        }

        // Get issued books for a person
        myLibrary.GetIssuedBooks(person2);
    }
}