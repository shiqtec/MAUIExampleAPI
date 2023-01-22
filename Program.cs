using MAUIExampleAPI.Models.Database;
using MAUIExampleAPI.DAO;
using MAUIExampleAPI.DAO.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddScoped<ITodoDAO, TodoDAO>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
