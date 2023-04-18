using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Vidly.DataAccess.Contexts;
using Vidly.Domain.Entities;

namespace Vidly.DataAccess.Repositories;

public class SessionRepository:DataBaseRepository<Session>
{
    public SessionRepository(VidlyContext context) : base(context)
    {
    }

    public override Session? Find(Expression<Func<Session,bool>> expression)
    {
        return _context.Set<Session>().Include(a => a.User).FirstOrDefault(expression);
    }
}