using WebApplication.Models.Entities;
using WebApplication.Services.Strategies;

namespace WebApplication.Services.Clients;

public class FlexibleEntityClient
{
    private readonly SomeEntityApiClient _apiClient;

    public FlexibleEntityClient(SomeEntityApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<SomeEntity>> GetProcessedAsync(IEntityProcessingStrategy strategy)
    {
        var all = await _apiClient.GetAllAsync();
        return strategy.Process(all).ToList();
    }
}
