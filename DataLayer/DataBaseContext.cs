using Microsoft.EntityFrameworkCore;
using Models.TModels;

namespace DataLayer
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext() : base()
        {

        }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (optionsBuilder.IsConfigured == false)
            {
               
                optionsBuilder.UseSqlServer(connectionString: "data source=.;initial catalog=ResturantDataBase;trusted_connection=true;multipleactiveresultsets=true");
            }
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<FoodEntity> Foods { get; set; }
        //public DbSet<OrderDetails> OrderDetails  { get; set; }

    }
}
