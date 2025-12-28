using LibraryApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.DTOs;

/// Por que separar Create e Update? Porque cada operação pode ter regras diferentes.
public class CreateBookDto
{
	// DataAnnotations:
	// - Funcionam automaticamente com ModelState
	// - Aparecem no Swagger
	[Required]
	public string Title { get; set; }

	[Required]
	public string Author { get; set; }

	[Range(0.01, double.MaxValue)]
	public decimal Price { get; set; }

	[Required]
	public BookGenre Genre { get; set; }
}
