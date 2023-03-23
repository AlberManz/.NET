using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataContext;

namespace DataAccess.Generic
{
  public interface IUnitOfWork : IDisposable
  {
    WebApiDbContext Context { get; } // WebApiDbContext es el nombre que le hemos querido poner como acceso a la BD
    void Commit();
  }
  public class UnitOfWork : IUnitOfWork
  {
    public WebApiDbContext Context { get; }
    public UnitOfWork(WebApiDbContext context)
    {
      Context = context;
    }
    public void Commit()
    {
      Context.SaveChanges();
    }
    public void Dispose()
    {
      Context.Dispose();
    }

  }
}
