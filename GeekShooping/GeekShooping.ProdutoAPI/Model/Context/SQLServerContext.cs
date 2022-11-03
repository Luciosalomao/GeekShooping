using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProdutoAPI.Model.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext() { }
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options)  { }
        public DbSet<Produto> Produtos { get; set; }
    }
}
