using LibraryApi.Domain.Enums;

namespace LibraryApi.Domain.Entities;

/// Entidade de domínio que representa um Livro.
/// Ela herda de BaseEntity aquelas duas propriedades Id e CreatedAt :
public class Book : BaseEntity
{
	// get: qualquer um pode ler
	// private set: SOMENTE a própria entidade pode alterar
	// Isso força que qualquer mudança passe por regras internas
	public string Title { get; private set; }
	public string Author { get; private set; }
	public decimal Price { get; private set; }
	public int Stock { get; private set; }
	public BookGenre Genre { get; private set; }

	/// Construtor da entidade.
	/// Ele define como um Livro NASCE no sistema.
	/// Se os dados não forem válidos, o Livro simplesmente NÃO EXISTE.
	public Book(
		string title,
		string author,
		decimal price,
		int stock,
		BookGenre genre)
	{
		Validate(title, author, price, stock);

		Title = title;
		Author = author;
		Price = price;
		Genre = genre;
	}

	public void Update(
		string title,
		string author,
		decimal price,
		int stock,
		BookGenre genre)
	{
		Validate(title, author, price, stock);

		Title = title;
		Author = author;
		Price = price;
		Genre = genre;

		// Chama a o método privado do BaseEntity para atualizar o UpdatedAt
		Touch();
	}

	/// Método privado de validação.
	/// Centraliza regras repetidas
	/// Evita duplicação de código
	private static void Validate(
		   string title,
		   string author,
		   decimal price,
		   int stock)
	{
		if (string.IsNullOrWhiteSpace(title) || title.Length < 2 || title.Length > 120)
			throw new ArgumentException("Title must be between 2 and 120 characters.");

		if (string.IsNullOrWhiteSpace(author) || author.Length < 2 || author.Length > 120)
			throw new ArgumentException("Author must be between 2 and 120 characters.");

		if (price < 0)
			throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");

		if (stock < 0)
			throw new ArgumentOutOfRangeException(nameof(stock), "Stock cannot be negative.");
	}
}
