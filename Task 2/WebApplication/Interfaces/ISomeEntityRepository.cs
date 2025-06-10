using WebApplication.Models.Entities;

namespace WebApplication.Interfaces;

public interface ISomeEntityRepository
{
    Task<SomeEntity> CreateAsync(SomeEntity entity);
    Task<SomeEntity?> GetByIdAsync(int id);
    Task<IEnumerable<SomeEntity>> GetAllAsync();
    Task<IEnumerable<SomeEntity>> GetByFilterAsync(string? status);
    Task<SomeEntity> UpdateAsync(SomeEntity entity);
    Task DeleteAsync(int id);
    Task DeleteManyAsync(List<int> ids);
}
