using AzGuidance.Domain.Entities;

namespace AzGuidance.Domain.Interfaces;

public interface IFormaEnvioRepository
{
    Task<FormaEnvio> GetByIdAsync(int id);
    Task<List<FormaEnvio>> GetAllAsync();
    Task AddAsync(FormaEnvio entity);
    Task UpdateAsync(FormaEnvio entity);
    Task DeleteAsync(int id);
}
