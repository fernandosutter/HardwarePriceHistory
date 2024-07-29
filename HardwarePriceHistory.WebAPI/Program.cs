using HardwarePriceHistory.Application.Services;
using HardwarePriceHistory.Core.Interfaces;
using HardwarePriceHistory.Infrastructure.Database;
using HardwarePriceHistory.Infrastructure.Repository.PriceHistoryRepositories;
using HardwarePriceHistory.Infrastructure.Repository.ProductRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI
builder.Services.AddSingleton<DatabaseConnection>();
builder.Services.AddSingleton<IPriceHistoryQueryRepository, PriceHistoryQueryRepository>();
builder.Services.AddSingleton<IProductQueryRepository, ProductQueryRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<PriceHistoryService>();

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

/*
app.UseCors(options =>
{
    options.WithOrigins("https://www.example.com", "https://api.example.com")
           .AllowAnyMethod()
           .AllowAnyHeader();
});
*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

