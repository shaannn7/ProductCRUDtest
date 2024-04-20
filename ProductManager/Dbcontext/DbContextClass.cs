using Microsoft.EntityFrameworkCore;
using ProductManager.Entity;

namespace ProductManager.Dbcontext
{
    public class DbContextClass : DbContext
    {
        private readonly  IConfiguration _configuration1;
        public string CString;
        public DbContextClass(IConfiguration configuration)
        {
            _configuration1 = configuration;
            CString = _configuration1["ConnectionStrings:DefaultConnection"];
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(CString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                 .HasMany(p => p.product)
                 .WithOne(c => c.category)
                 .HasForeignKey(o => o.categoryid);

            base.OnModelCreating(modelBuilder);
        }
    }
}
