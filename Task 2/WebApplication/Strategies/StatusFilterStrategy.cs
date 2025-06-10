using WebApplication.Models.Entities;

namespace WebApplication.Services.Strategies;

public class StatusFilterStrategy : IEntityProcessingStrategy
{
    private readonly string _status;

    public StatusFilterStrategy(string status)
    {
        _status = status;
    }

    public IEnumerable<SomeEntity> Process(IEnumerable<SomeEntity> input)
    {
        return input.Where(e => e.Status.Equals(_status, StringComparison.OrdinalIgnoreCase));
    }
}
