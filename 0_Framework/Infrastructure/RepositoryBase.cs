using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastructure;

public class RepositoryBase<Tkey, T> : IRepository<Tkey, T> where T : class
{
    private readonly DbContext _context;

    public RepositoryBase(DbContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Add(entity);
    }

    public bool Exists(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Any(predicate);
    }

    public T Get(Tkey key)
    {
        return _context.Find<T>(key);
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }


}
