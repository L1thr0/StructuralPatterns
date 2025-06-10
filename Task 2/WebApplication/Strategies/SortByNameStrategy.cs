using WebApplication.Models.Entities;

namespace WebApplication.Services.Strategies;

public class SortByNameStrategy : IEntityProcessingStrategy
{
    public IEnumerable<SomeEntity> Process(IEnumerable<SomeEntity> input)
    {
        return input.OrderBy(e => e.Name);
    }
}
