using IBusinessLogic;
using Vidly.Domain.Entities;
using Vidly.IDataAccess;

namespace Vidly.BusinessLogic;

public class UserService:IUserService
{
    private IRepository<User> _userRepository;
    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
    public void AddUser(User user)
    {
        _userRepository.Add(user);
    }
}