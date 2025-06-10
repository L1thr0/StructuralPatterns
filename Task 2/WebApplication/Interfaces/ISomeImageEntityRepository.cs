using WebApplication.Models.Entities;

namespace WebApplication.Interfaces;

public interface ISomeImageEntityRepository
{
    Task<SomeImageEntity> CreateAsync(SomeImageEntity entity);
    Task<SomeImageEntity?> GetByIdAsync(int id);
    Task<IEnumerable<SomeImageEntity>> GetByFilterAsync(string? status);
}
