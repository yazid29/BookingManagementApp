using BookingManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace API.Data
{
    [DbContext(typeof(BookingManagementDBContext))]
    public class BookingManagementDBContext : DbContext
    {
        public BookingManagementDBContext(DbContextOptions<BookingManagementDBContext> options) : base (options)
        {
            
        }

        // add model to migrate
        public Microsoft.EntityFrameworkCore.DbSet<Account> Accounts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<AccountRole> AccountRoles { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Booking> Bookings { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Education> Educations { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Employee> Employees { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Role> Roles { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Room> Rooms { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasIndex(e => e.Nik).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(e => e.PhoneNumber).IsUnique();
            /*modelBuilder.Entity<Employee>().HasIndex(e => new
            {
                e.Nik,
                e.Email,
                e.PhoneNumber
            }).IsUnique();
            */

            // One University has many Educations
            modelBuilder.Entity<University>()
                        .HasMany(e => e.Educations)
                        .WithOne(u => u.University)
                        .HasForeignKey(e => e.UniversityGuid)
                        .OnDelete(DeleteBehavior.Restrict);
            // One Education has one Employee
            modelBuilder.Entity<Education>()
                        .HasOne(e => e.Employee)
                        .WithOne(e => e.Education)
                        .HasForeignKey<Education>(e => e.Guid)
                        .OnDelete(DeleteBehavior.Restrict);
            // One Room has many Bookings
            modelBuilder.Entity<Room>()
                .HasMany(b => b.Bookings)
                .WithOne(r=>r.Room)
                .HasForeignKey(b=>b.RoomGuid)
                .OnDelete(DeleteBehavior.Restrict);
            // One Role has many AccountRoles
            modelBuilder.Entity<Role>()
                .HasMany(arole => arole.AccountRoles)
                .WithOne(ar => ar.Role)
                .HasForeignKey(arole => arole.RoleGuid)
                .OnDelete(DeleteBehavior.Restrict);
            // Many AccountRoles has one Account
            modelBuilder.Entity<AccountRole>()
                .HasOne(arole => arole.Account)
                .WithMany(ar => ar.AccountRoles)
                .HasForeignKey(arole => arole.AccountGuid)
                .OnDelete(DeleteBehavior.Restrict);
            // One Account has one Employee
            modelBuilder.Entity<Account>()
                .HasOne(e => e.Employee)
                .WithOne(acc => acc.Account)
                .HasForeignKey<Account>(e => e.Guid)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
