using WebApplication.Interfaces;
using WebApplication.Models.Entities;

namespace WebApplication.Data.InMemory;

public class InMemorySomeImageEntityRepository : ISomeImageEntityRepository
{
    private readonly List<SomeImageEntity> _store = new();
    private int _nextId = 1;

    public Task<SomeImageEntity> CreateAsync(SomeImageEntity entity)
    {
        entity.Id = _nextId++;
        _store.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<SomeImageEntity?> GetByIdAsync(int id)
    {
        return Task.FromResult(_store.FirstOrDefault(e => e.Id == id));
    }

    public Task<IEnumerable<SomeImageEntity>> GetByFilterAsync(string? status)
    {
        var result = string.IsNullOrEmpty(status)
            ? _store
            : _store.Where(e => e.Status == status);
        return Task.FromResult(result);
    }
}
