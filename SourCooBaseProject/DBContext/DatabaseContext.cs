using Microsoft.EntityFrameworkCore;
using System.Xml;
using QuinielasApi.Models.Entities;

namespace QuinielasApi.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeds
            modelBuilder.SeedRole();
            modelBuilder.SeedSport();
            modelBuilder.SeedQuinielaType();
            modelBuilder.SeedQuinielaDuration();
            modelBuilder.SeedQuinielaPickDuration();


            //Rules for our entities
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

            modelBuilder.Entity<UserPermission>()
                .HasKey(up => new { up.UserId, up.PermissionId });

            modelBuilder.Entity<UserPermission>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserPermissions)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserPermission>()
                .HasOne(up => up.Permission)
                .WithMany(p => p.UserPermissions)
                .HasForeignKey(up => up.PermissionId);
        }

        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Address> Addresses { get; set; } = default!;
        public DbSet<City> Cities { get; set; } = default!;
        public DbSet<State> States { get; set; } = default!;
        public DbSet<Country> Countries { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        public DbSet<Permission> Permissions { get; set; } = default!;
        public DbSet<UserPermission> UserPermissions { get; set; } = default!;
        public DbSet<Sport> Sports { get; set; } = default!;
        public DbSet<OperationType> OperationTypes { get; set; } = default!;
        public DbSet<Preference> Preferences { get; set; } = default!;
        public DbSet<Quiniela> Quinielas { get; set; } = default!;
        public DbSet<QuinielaType> QuinielaTypes { get; set; } = default!;
        public DbSet<QuinielaTypeConfiguration> QuinielaTypeConfigurations { get; set; } = default!;
        public DbSet<SportTeam> SportTeams { get; set; } = default!;
        public DbSet<Status> Status { get; set; } = default!;

    }
}
