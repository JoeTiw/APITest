using API_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Test.DataContext;

public class DbDataContext : DbContext
{
    public DbDataContext(DbContextOptions<DbDataContext> options) : base(options){ }

    public DbSet<Customer> Customer { get; set; }

}