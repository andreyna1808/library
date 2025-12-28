using BookStore.Api.DTOs;
using BookStore.Api.Repositories;
using LibraryApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
	private readonly IBookRepository _repository;

	/// Injeção de dependência.
	/// Controller depende da interface
	public BooksController(IBookRepository repository)
	{
		_repository = repository;
	}

	[HttpGet]
	public ActionResult<IEnumerable<BookResponseDto>> GetAll()
	{
		var books = _repository.GetAll()
			.Select(b => new BookResponseDto
			{
				Id = b.Id,
				Title = b.Title,
				Author = b.Author,
				Price = b.Price,
				Genre = b.Genre,
				CreatedAt = b.CreatedAt
			});

		return Ok(books);
	}

	[HttpGet("{id}")]
	public ActionResult<BookResponseDto> GetById(Guid id)
	{
		var book = _repository.GetById(id);
		if (book is null)
			return NotFound();

		return Ok(new BookResponseDto
		{
			Id = book.Id,
			Title = book.Title,
			Author = book.Author,
			Price = book.Price,
			Genre = book.Genre,
			CreatedAt = book.CreatedAt
		});
	}

	[HttpPost]
	public IActionResult Create(CreateBookDto dto)
	{
		if (_repository.ExistsByTitleAndAuthor(dto.Title, dto.Author))
			return Conflict("A book with the same title and author already exists.");

		try
		{
			var book = new Book(
				dto.Title,
				dto.Author,
				dto.Price,
				dto.Stock,
				dto.Genre
			);

			_repository.Add(book);

			return CreatedAtAction(
				nameof(GetById),
				new { id = book.Id },
				null
			);
		}
		catch (ArgumentException ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPut("{id}")]
	public IActionResult Update(Guid id, UpdateBookDto dto)
	{
		var book = _repository.GetById(id);
		if (book is null)
			return NotFound();

		if (_repository.ExistsByTitleAndAuthorExceptId(dto.Title, dto.Author, id))
			return Conflict("Another book with the same title and author already exists.");

		try
		{
			book.Update(
				dto.Title,
				dto.Author,
				dto.Price,
				dto.Stock,
				dto.Genre
			);

			_repository.Update(book);

			return NoContent();
		}
		catch (ArgumentException ex)
		{
			return BadRequest(ex.Message);
		}
	}


	[HttpDelete("{id}")]
	public IActionResult Delete(Guid id)
	{
		var book = _repository.GetById(id);
		if (book is null)
			return NotFound();

		_repository.Delete(id);
		return NoContent();
	}
}
