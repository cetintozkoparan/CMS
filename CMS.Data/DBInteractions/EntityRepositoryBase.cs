using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace CMS.Data.DBInteractions
{
public abstract class EntityRepositoryBase<T> where T : class
{
    private DbContext _dataContext;
    private readonly IDbSet<T> dbset;
    protected EntityRepositoryBase()
    {
        dbset = DataContext.Set<T>();
    }

    protected DbContext DataContext
    {
        get { return _dataContext ?? (_dataContext = new BaseContext()); }
    }

    public virtual void Add(T entity)
    {
        dbset.Add(entity);
        _dataContext.SaveChanges();
    }
    public virtual void Update(T entity)
    {
        _dataContext.Entry(entity).State = EntityState.Modified;
        _dataContext.SaveChanges();
    }
    public virtual void Delete(T entity)
    {
        dbset.Remove(entity);
        _dataContext.SaveChanges();
    }
    public void Delete(Func<T, Boolean> where)
    {
        IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
        foreach (T obj in objects)
            dbset.Remove(obj);
    } 
    public virtual T GetById(long id)
    {
        return dbset.Find(id);
    }

    public virtual IEnumerable<T> GetAll()
    {
        return dbset.ToList();
    }
    public virtual IEnumerable<T> GetMany(Func<T, bool> where)
    {
        return dbset.Where(where).ToList();
    }
    public T Get(Func<T, Boolean> where)
    {
        return dbset.Where(where).FirstOrDefault<T>();
    } 
}
}
