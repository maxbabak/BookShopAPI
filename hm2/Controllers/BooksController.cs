using hm2.Models;
using hm2.Services;
using Microsoft.AspNetCore.Mvc;

namespace hm2.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _service;

    public BooksController(IBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
        => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
        => Ok(_service.GetById(id));

    [HttpPost]
    public IActionResult Add(Book book)
    {
        _service.Add(book);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(Book book)
    {
        _service.Update(book);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok();
    }
}