using System;
using Day04.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Day04.Data;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly UniversityContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(UniversityContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public List<T> GetAll() => _dbSet.ToList();

    public T GetById(int id) => _dbSet.Find(id)!;

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }
}