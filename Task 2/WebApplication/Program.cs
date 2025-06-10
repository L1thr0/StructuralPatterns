using WebApplication.Data;
using WebApplication.Data.InMemory;
using WebApplication.Interfaces;
using WebApplication.Services;
using WebApplication.Services.Clients;
using WebApplication.Services.Strategies;
using static System.Net.WebRequestMethods;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddSingleton<ISomeEntityRepository, InMemorySomeEntityRepository>();
builder.Services.AddSingleton<ISomeImageEntityRepository, InMemorySomeImageEntityRepository>();
builder.Services.AddScoped<SomeEntityService>();
builder.Services.AddHttpClient<SomeEntityApiClient>();
builder.Services.AddScoped<FlexibleEntityClient>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


//https://localhost:7222/api/SomeEntity/active-sorted

app.MapGet("/api/SomeEntity/active-sorted", async (
    FlexibleEntityClient client) =>
{
    var statusFilter = new StatusFilterStrategy("Active");
    var sortedByName = new SortByNameStrategy();

    var filtered = await client.GetProcessedAsync(statusFilter);
    var sorted = sortedByName.Process(filtered);

    return Results.Ok(sorted);
});



app.Run();
