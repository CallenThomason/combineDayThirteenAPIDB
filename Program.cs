using combineDayThirteenAPIDB.Data;
using combineDayThirteenAPIDB.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//This will connect our Database to our project, by using SQLite
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); 
//dotnet ef migrations add init

//whenever our interface for student services is called it knows to pass the requests to our services
builder.Services.AddScoped<IStudentServices, StudentServices>(); 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
