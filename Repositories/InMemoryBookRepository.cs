using LibraryApi.Domain.Entities;
using System.Xml.Linq;

namespace BookStore.Api.Repositories;

/// Implementação simples em memória.
/// Não depende de banco
public class InMemoryBookRepository : IBookRepository
{
	// Lista simulando um banco de dados
	private readonly List<Book> _books = new();

	public IEnumerable<Book> GetAll() => _books;

	public Book? GetById(Guid id)
		=> _books.FirstOrDefault(b => b.Id == id);

	public void Add(Book book)
		=> _books.Add(book);

	public void Update(Book book)
	{
		// Nada a fazer aqui porque:
		// - O objeto já foi alterado
		// - A lista mantém referência
	}

	public void Delete(Guid id)
	{
		var book = GetById(id);
		if (book is not null)
			_books.Remove(book);
	}
}
