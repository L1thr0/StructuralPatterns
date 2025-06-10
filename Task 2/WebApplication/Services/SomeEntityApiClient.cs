using System.Net.Http.Json;
using WebApplication.Models.Entities;

namespace WebApplication.Services.Clients;

public class SomeEntityApiClient
{
    private readonly HttpClient _httpClient;

    public SomeEntityApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7222/api/SomeEntity/");
    }

    public async Task<SomeEntity?> CreateAsync(SomeEntity entity)
    {
        var response = await _httpClient.PostAsJsonAsync("create", entity);
        return await response.Content.ReadFromJsonAsync<SomeEntity>();
    }

    public async Task<SomeEntity?> GetOneAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<SomeEntity>($"{id}");
    }

    public async Task<List<SomeEntity>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<SomeEntity>>("all") ?? new();
    }

    public async Task<SomeEntity?> UpdateAsync(SomeEntity entity)
    {
        var response = await _httpClient.PutAsJsonAsync("update", entity);
        return await response.Content.ReadFromJsonAsync<SomeEntity>();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{id}");
        return response.IsSuccessStatusCode;
    }
}
