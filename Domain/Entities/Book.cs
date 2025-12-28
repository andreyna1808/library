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
	public BookGenre Genre { get; private set; }

	/// Construtor da entidade.
	/// Ele define como um Livro NASCE no sistema.
	/// Se os dados não forem válidos, o Livro simplesmente NÃO EXISTE.
	public Book(string title, string author, decimal price, BookGenre genre)
	{
		Validate(title, price);

		Title = title;
		Author = author;
		Price = price;
		Genre = genre;
	}

	public void Update(string title, string author, decimal price, BookGenre genre)
	{
		Validate(title, price);

		Title = title;
		Author = author;
		Price = price;
		Genre = genre;
	}

	/// Método privado de validação.
	/// Centraliza regras repetidas
	/// Evita duplicação de código
	private static void Validate(string title, decimal price)
	{
		if (string.IsNullOrWhiteSpace(title))
			throw new ArgumentException(
				"Title cannot be null or empty.",
				nameof(title)
			);

		if (price <= 0)
			throw new ArgumentOutOfRangeException(
				nameof(price),
				"Price must be greater than zero."
			);
	}
}
