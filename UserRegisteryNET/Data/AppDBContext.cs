using Microsoft.EntityFrameworkCore;

namespace UserRegisteryNET.Data
{
    internal sealed class AppDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User[] usersToSeed = new User[6];

            for (int i = 1; i <= usersToSeed.Length; i++)
            {
                usersToSeed[i - 1] = new User
                {
                    UserId = i,
                    Name = $"name{i}",
                    LastName = $"lastName{i}",
                    Password = $"password_{i}_123",
                    TCKN = $"1234567891{i}"
                };
            }
            // Veritabanını otomatik olarak doldur - Entity Framework
            modelBuilder.Entity<User>().HasData(usersToSeed);
        }
    }
}
