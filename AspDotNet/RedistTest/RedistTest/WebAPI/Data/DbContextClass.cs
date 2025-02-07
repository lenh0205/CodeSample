using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPI.Model;

namespace WebAPI.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options) { }
        public DbSet<Product> Products
        {
            get;
            set;
        }
    }
}
