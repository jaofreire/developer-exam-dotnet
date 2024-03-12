using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PixApi.Data;
using PixApi.Models;
using PixApi.Repositories;
using PixApi.Repositories.Interface;
using PixApi.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseSql"));
});
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IKeyRepository, KeyRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ITransitionRepository, TransitionRepository>();

builder.Services.AddSingleton<IValidator<KeyModel>, KeyValidations>();

var app = builder.Build();

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
