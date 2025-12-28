using LibraryApi.Domain.Entities;

namespace BookStore.Api.Repositories;

/// Interface do repositório.
/// - Permite trocar implementação (InMemory, EF, Dapper)
/// - Facilita testes
/// - Aplica princípio da inversão de dependência
public interface IBookRepository
{
	IEnumerable<Book> GetAll();
	Book? GetById(Guid id);
	void Add(Book book);
	void Update(Book book);
	void Delete(Guid id);
}
