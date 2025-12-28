using LibraryApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.DTOs;

public class UpdateBookDto
{
	[Required]
	public string Title { get; set; }

	[Required]
	public string Author { get; set; }

	[Range(0.01, double.MaxValue)]
	public decimal Price { get; set; }

	[Required]
	public BookGenre Genre { get; set; }
}
