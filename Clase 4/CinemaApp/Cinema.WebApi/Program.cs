using System.Collections.Immutable;
using Cinema.BusinessLogic;
using cinema.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieLogic, MoviesLogic>();
builder.Services.AddScoped<IMovieRepository,MoviesRepository>();


//builder.Services.AddTransient<IMovieLogic, MoviesLogic>();
//builder.Services.AddSingleton<IMovieLogic, MoviesLogic>();

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
