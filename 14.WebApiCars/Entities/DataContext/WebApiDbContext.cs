using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace Entities.DataContext
{
  public class WebApiDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().HasOne(x => x.Role);
    }
  }
}
