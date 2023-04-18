using System.Linq.Expressions;
using Vidly.DataAccess.Contexts;
using Vidly.IDataAccess;

namespace Vidly.DataAccess.Repositories;

public class DataBaseRepository<T> : IRepository<T> where T : class
{
    protected readonly VidlyContext _context;

    public DataBaseRepository(VidlyContext context)
    {
        _context = context;
    }
    
    public virtual IEnumerable<T> GetAllBy(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public virtual T? Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().FirstOrDefault(expression);
    }

    public virtual void Add(T elem)
    {
        _context.Set<T>().Add(elem);
        _context.SaveChanges();
    }

    public virtual void Delete(T elem)
    {
        _context.Set<T>().Remove(elem);
        _context.SaveChanges();
    }

    public virtual void Update(T elem)
    {
        _context.Set<T>().Update(elem);
        _context.SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}