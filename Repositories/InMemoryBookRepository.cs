using LibraryApi.Domain.Entities;

namespace BookStore.Api.Repositories;

public class InMemoryBookRepository : IBookRepository
{
	private readonly List<Book> _books = new();

	public IEnumerable<Book> GetAll()
		=> _books;

	public Book? GetById(Guid id)
		=> _books.FirstOrDefault(b => b.Id == id);

	public void Add(Book book)
		=> _books.Add(book);

	public void Update(Book book)
	{
		var index = _books.FindIndex(b => b.Id == book.Id);
		if (index >= 0)
			_books[index] = book;
	}

	public void Delete(Guid id)
	{
		var book = GetById(id);
		if (book != null)
			_books.Remove(book);
	}

	public bool ExistsByTitleAndAuthor(string title, string author)
	{
		return _books.Any(b =>
			b.Title.Equals(title, StringComparison.OrdinalIgnoreCase) &&
			b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)
		);
	}

	public bool ExistsByTitleAndAuthorExceptId(
		string title,
		string author,
		Guid id)
	{
		return _books.Any(b =>
			b.Id != id &&
			b.Title.Equals(title, StringComparison.OrdinalIgnoreCase) &&
			b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)
		);
	}
}
