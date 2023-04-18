using Vidly.Factory;
using Vidly.WebApi.filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var factory = new ServiceFactory();
factory.RegisterServices(builder.Services);
builder.Services.AddScoped<AuthorizationFilter>();
//builder.Services.AddScoped<ProtectFilter>();
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
