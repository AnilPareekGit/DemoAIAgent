using Microsoft.EntityFrameworkCore;
using SupplierManagement.Domain.Repositories;
using SupplierManagement.Infrastructure.Data;
using SupplierManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add OpenAPI/Swagger
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext with in-memory database
builder.Services.AddDbContext<SupplierDbContext>(options =>
    options.UseInMemoryDatabase("SupplierDb"));

// Add repositories
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SupplierDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
