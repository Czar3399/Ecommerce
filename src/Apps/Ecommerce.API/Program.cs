using Ecommerce.Application.Products.Profiles;
using System.Reflection;
using SGTC.Infra.Configurations;
using Ecommerce.Application.Carts.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(CartProfile).GetTypeInfo().Assembly);
builder.Services.ConfigureDatabase("../../database.sqlite");

builder.Services.Scan(scan => scan.
            FromAssemblyOf<CartsService>()
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
app.Run();
