
using IBusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Vidly.BusinessLogic;
using Vidly.DataAccess;
using Vidly.DataAccess.Contexts;
using Vidly.DataAccess.Repositories;
using Vidly.Domain.Entities;
using Vidly.IBusinessLogic;
using Vidly.IDataAccess;

namespace Vidly.Factory;

public class ServiceFactory
{
    public void RegisterServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IRepository<Movie>, DataBaseRepository<Movie>>();
        serviceCollection.AddScoped<IRepository<User>, DataBaseRepository<User>>();
        serviceCollection.AddScoped<IRepository<Session>, SessionRepository>();

        serviceCollection.AddScoped<IMovieService, MovieService>();
        serviceCollection.AddScoped<ISessionService, SessionService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        
        serviceCollection.AddDbContext<VidlyContext>();
    }
}