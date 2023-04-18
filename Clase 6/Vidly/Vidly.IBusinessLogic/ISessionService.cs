using Vidly.Domain.Entities;

namespace Vidly.IBusinessLogic;

public interface ISessionService
{
    User? GetLoggedUser(Guid token);
    Guid Login(string email, string password);
}