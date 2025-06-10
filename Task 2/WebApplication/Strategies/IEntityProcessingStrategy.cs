using WebApplication.Models.Entities;

namespace WebApplication.Services.Strategies;

public interface IEntityProcessingStrategy
{
    IEnumerable<SomeEntity> Process(IEnumerable<SomeEntity> input);
}
