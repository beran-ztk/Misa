using Misa.Infrastructure.Data;
using Misa.Infrastructure.Items;
using Misa.Application.Items;
using Misa.Contract.Items;
using Microsoft.EntityFrameworkCore;
using Misa.Api.Items;
using Misa.Contract.Items;

const string connectionString =
    "Host=localhost;Port=5432;Database=misa;Username=postgres;Password=meow";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MisaDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped<ItemCreationHandler>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

var app = builder.Build();

app.MapGet("/api/items", () => "Meow");
app.MapPost("/api/items", async (
    ItemDto dto,
    ItemCreationHandler handler,
    CancellationToken ct) =>
{
    var item = dto.ToDomain();
    await handler.HandleAsync(item, ct);
    return Results.Ok();
});

app.Run();
