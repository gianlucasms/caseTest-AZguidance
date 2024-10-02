using AzGuidance.Domain.Entities;

namespace AzGuidance.Domain.Interfaces;

public interface ITipoEmailRepository
{
    Task<TipoEmail> GetByIdAsync(int id);
    Task<List<TipoEmail>> GetAllAsync();
    Task AddAsync(TipoEmail entity);
    Task UpdateAsync(TipoEmail entity);
    Task DeleteAsync(int id);
}
