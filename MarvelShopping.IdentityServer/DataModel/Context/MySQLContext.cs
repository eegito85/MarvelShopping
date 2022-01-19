using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarvelShopping.IdentityServer.DataModel.Context
{
    public class MySQLContext : IdentityDbContext<ApplicationUser>
    {

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        //public DbSet<Product> Products { get; set; }
    }
}
