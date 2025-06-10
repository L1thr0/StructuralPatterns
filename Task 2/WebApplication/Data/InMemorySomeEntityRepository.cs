using WebApplication.Interfaces;
using WebApplication.Models.Entities;

namespace WebApplication.Data;

public class InMemorySomeEntityRepository : ISomeEntityRepository
{
    private readonly List<SomeEntity> _store = new();
    private int _nextId = 1;

    public Task<SomeEntity> CreateAsync(SomeEntity entity)
    {
        entity.Id = _nextId++;
        _store.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<SomeEntity?> GetByIdAsync(int id)
    {
        var entity = _store.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(entity);
    }

    public Task<IEnumerable<SomeEntity>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<SomeEntity>>(_store);
    }

    public Task<IEnumerable<SomeEntity>> GetByFilterAsync(string? status)
    {
        var result = string.IsNullOrEmpty(status)
            ? _store
            : _store.Where(e => e.Status == status).ToList();

        return Task.FromResult<IEnumerable<SomeEntity>>(result);
    }

    public Task<SomeEntity> UpdateAsync(SomeEntity updated)
    {
        var index = _store.FindIndex(e => e.Id == updated.Id);
        if (index != -1)
            _store[index] = updated;

        return Task.FromResult(updated);
    }

    public Task DeleteAsync(int id)
    {
        _store.RemoveAll(e => e.Id == id);
        return Task.CompletedTask;
    }

    public Task DeleteManyAsync(List<int> ids)
    {
        _store.RemoveAll(e => ids.Contains(e.Id));
        return Task.CompletedTask;
    }
}
