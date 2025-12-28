namespace LibraryApi.Domain.Entities;

public abstract class BaseEntity // Abastract é pq eles devem seguir/implementar a risco o que foi feito...
{
	// Em ambos estão sendo usado o protected set, o que significa que a propriedade pode ser definida apenas dentro da classe base ou em classes derivadas.
	public Guid Id { get; protected set; } = Guid.NewGuid(); // Sendo definido no momento da criação do objeto
	public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow; // Data de criação do objeto, definida no momento da criação
	public DateTime? UpdatedAt { get; protected set; }

	// Evita que qualquer um altere UpdatedAt livremente
	protected void Touch()
	{
		UpdatedAt = DateTime.UtcNow;
	}
}

