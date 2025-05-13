using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using BuffTeksPackageSystem;


namespace BuffTeksPackageSystem
{
    public class BuffTeksContext : DbContext
    {
        public BuffTeksContext(DbContextOptions<BuffTeksContext> options)
            : base(options)
        {
        }

        public DbSet<Resident> Residents { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Pickup> Pickups { get; set; }
        public DbSet<UnknownPackage> UnknownPackages { get; set; }
        public DbSet<Staff> StaffLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().HasKey(staff => staff.staff_username);
        }
    }
}
