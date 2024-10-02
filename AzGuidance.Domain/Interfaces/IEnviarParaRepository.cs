using AzGuidance.Domain.Entities;

namespace AzGuidance.Domain.Interfaces;

public interface IEnviarParaRepository
{
    Task<EnviarPara> GetByIdAsync(int id);
    Task<List<EnviarPara>> GetAllAsync();
    Task AddAsync(EnviarPara entity);
    Task UpdateAsync(EnviarPara entity);
    Task DeleteAsync(int id);
}
