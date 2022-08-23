//1. USINGS para trabajar con EntityFramework
using Microsoft.EntityFrameworkCore;
using universityApi.DataAccess;

var builder = WebApplication.CreateBuilder(args);

//2. Conexion con la BBDD
const string ConectionName = "UniversityDB";
var conectionString = builder.Configuration.GetConnectionString(ConectionName);

// 3. Añadir contexto
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(conectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
