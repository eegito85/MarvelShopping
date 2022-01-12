using Microsoft.EntityFrameworkCore;

namespace MarvelShopping.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Camiseta Capitão América",
                Price = 59.90M,
                Description = "Camiseta Capitão América Tamanho M 100% Algodão",
                CategoryName = "Vestuário",
                ImageURL = "https://cdn.awsli.com.br/600x700/566/566157/produto/38860253/09596ef929.jpg"
            });
        }
    }
}
