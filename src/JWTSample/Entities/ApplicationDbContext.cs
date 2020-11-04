using Microsoft.EntityFrameworkCore;

namespace JWTSample.Entities
{
    //DbContext sınıfından kalıtım alarak bunun bir context olacağını belirtiyorum.
    public class ApplicationDbContext : DbContext
    {

        //Veritabanına hazırladığım modeli tablo olarak eklemesini söylüyorum.
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //Veritabanı olarak mssql kullanacağımı söylüyorum.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=my_db;User=sa;Password=qwertY12@3;");

        //Veritabanı oluşturulurken dummy data ile oluşturulmasını istiyorum.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = 1,
                FirstName = "test",
                Username = "testUser",
                Password = "testPassword"
            });
        }

    }

}