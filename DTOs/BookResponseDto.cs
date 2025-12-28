using LibraryApi.Domain.Enums;

namespace BookStore.Api.DTOs;

/// Nunca retornamos a entidade diretamente. Isso desacopla API do domínio.
public class BookResponseDto
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Author { get; set; }
	public decimal Price { get; set; }
	public BookGenre Genre { get; set; }
	public DateTime CreatedAt { get; set; }
}
