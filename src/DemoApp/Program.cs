using DemoApp.Repositories;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IItemRepository, InMemoryItemRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();
