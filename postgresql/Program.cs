using Microsoft.EntityFrameworkCore;
using postgresql;

Console.WriteLine("Hello, World!");

var book = new Book() {id=9, title = "Дворянин поневоле", author_ = new Author() { name = "Ерофей Трофимов" }, public_year = 2024 };

book.public_year = 1999;
//RemoveBook(10);
//AddBook(book);
UpdateBook(book);

var b = getBook();

print(b);



List<Book> getBook()
{
    List<Book> books = new List<Book>();
    using (ApplicationContext db = new ApplicationContext())
    {
        books = db.book.Include(x => x.author_).ToList();
    }
    return books;
}

void AddBook(Book b)
{
    using (ApplicationContext db = new ApplicationContext())
    {
        db.book.Add(b);
        db.SaveChanges();
    }
}

void UpdateBook(Book b)
{
    using (ApplicationContext db = new ApplicationContext())
    {
        var book = db.book.FirstOrDefault(x => x.id == b.id);
        if (book == null)
        {
            Console.WriteLine("not found book");
            return;
        }
        book.title = b.title;
        book.author_ = b.author_;
        book.public_year = b.public_year;
        db.book.Update(book);
        db.SaveChanges();
    }
}

void RemoveBook(int id)
{
    using (ApplicationContext db = new ApplicationContext())
    {
        var book = db.book.FirstOrDefault(x => x.id == id);
        if (book == null)
        {
            Console.WriteLine("not found book");
            return;
        }
        db.book.Remove(book);
        db.SaveChanges();
    }
}

void print(List<Book> bo)
{
    bo.ForEach(x => Console.WriteLine($"{x.id} : {x.title} - {x.author_.name} - {x.public_year}"));
}
