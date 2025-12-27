using hm2.Models;
using hm2.Repositories;

namespace hm2.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly IDescriptionValidator _descriptionValidator;

    public BookService(
        IBookRepository repository,
        IDescriptionValidator descriptionValidator)
    {
        _repository = repository;
        _descriptionValidator = descriptionValidator;
    }

    public List<Book> GetAll() =>
        _repository.GetAll();

    public Book GetById(int id)
    {
        var book = _repository.GetById(id);
        if (book == null)
            throw new KeyNotFoundException("Книжку не знайдено");

        return book;
    }

    public void Add(Book book)
    {
        ValidateBook(book);
        _repository.Add(book);
    }

    public void Update(Book book)
    {
        ValidateBook(book);
        _repository.Update(book);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    private void ValidateBook(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Назва книжки обовʼязкова");

        if (book.Year < 868 || book.Year > DateTime.Now.Year)
            throw new ArgumentException("Некоректний рік видання");

        _descriptionValidator.Validate(book.Description);
    }
}