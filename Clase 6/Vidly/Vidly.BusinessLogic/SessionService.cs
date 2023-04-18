using System.Security.Authentication;
using Vidly.Domain.Entities;
using Vidly.IBusinessLogic;
using Vidly.IDataAccess;

namespace Vidly.BusinessLogic;

public class SessionService:ISessionService
{
    private IRepository<Session> _sessionRepository;
    private IRepository<User> _userRepository;
    
    public SessionService(IRepository<Session> sessionRepository, IRepository<User> userRepository)
    {
        _sessionRepository = sessionRepository;
        _userRepository = userRepository;
    }
    public User? GetLoggedUser(Guid token)
    {
        Session session = _sessionRepository.Find(s => s.Token == token);
        if (session != null)
           return session.User;
        else
        {
            throw new KeyNotFoundException("User not logged in");
        }
        
    }

    public Guid Login(string email, string password)
    {
        User user = _userRepository.Find(u => u.Email == email && u.Password == password);
        if (user == null)
        {
            throw new InvalidCredentialException("Invalid credentials");
        }

        Session sesion = new Session() { User = user };
        _sessionRepository.Add(sesion);
        return sesion.Token;
    }
}