using hm2.Models;

namespace hm2.Repositories;

public class BookRepository : IBookRepository
{
    private readonly List<Book> _books = new();

    public List<Book> GetAll() => _books;

    public Book? GetById(int id) =>
        _books.FirstOrDefault(b => b.Id == id);

    public void Add(Book book)
    {
        _books.Add(book);
    }

    public void Update(Book book)
    {
        var existing = GetById(book.Id);
        if (existing == null) return;

        existing.Title = book.Title;
        existing.Author = book.Author;
        existing.Year = book.Year;
        existing.Description = book.Description;
    }

    public void Delete(int id)
    {
        var book = GetById(id);
        if (book != null)
            _books.Remove(book);
    }
}