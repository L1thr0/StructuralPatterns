using WebApplication.Interfaces;
using WebApplication.Models.Entities;

namespace WebApplication.Services;

public class SomeEntityService
{
    private readonly ISomeEntityRepository _repo;

    public SomeEntityService(ISomeEntityRepository repo)
    {
        _repo = repo;
    }

    public Task<SomeEntity> Create(SomeEntity e) => _repo.CreateAsync(e);
    public Task<SomeEntity?> Get(int id) => _repo.GetByIdAsync(id);
    public Task<IEnumerable<SomeEntity>> GetAll() => _repo.GetAllAsync();
    public Task<IEnumerable<SomeEntity>> GetByStatus(string? status) => _repo.GetByFilterAsync(status);
    public Task<SomeEntity> Update(SomeEntity e) => _repo.UpdateAsync(e);
    public Task Delete(int id) => _repo.DeleteAsync(id);
    public Task DeleteMany(List<int> ids) => _repo.DeleteManyAsync(ids);
}
