using AzGuidance.Domain.Entities;

namespace AzGuidance.Domain.Interfaces;

public interface IClienteRepository
{
    Task<Cliente> GetByIdAsync(int id);
    Task<List<Cliente>> GetAllAsync();
    Task AddAsync(Cliente entity);
    Task UpdateAsync(Cliente entity);
    Task DeleteAsync(int id);
}
