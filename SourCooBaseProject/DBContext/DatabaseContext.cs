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
            

            // RELATIONS
            /*modelBuilder.Entity<Team>()
                       .HasMany(t => t.HomeGames)
                       .WithOne(g => g.HomeTeam)
                       .HasForeignKey(g => g.HomeTeamId)
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.AwayGames)
                .WithOne(g => g.AwayTeam)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.WinnerGames)
                .WithOne(g => g.WinnerTeam)
                .HasForeignKey(g => g.WinnerTeamId)
                .OnDelete(DeleteBehavior.Restrict);*/

            modelBuilder.Entity<Game>()
                .HasOne(g => g.WinnerTeam)
                .WithMany()
                .HasForeignKey(g => g.WinnerTeamId)
                .OnDelete(DeleteBehavior.SetNull);
            

        }

        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        public DbSet<Permission> Permissions { get; set; } = default!;
        public DbSet<Sport> Sports { get; set; } = default!;
        public DbSet<OperationType> OperationTypes { get; set; } = default!;
        public DbSet<Preference> Preferences { get; set; } = default!;
        public DbSet<Quiniela> Quinielas { get; set; } = default!;
        public DbSet<QuinielaConfiguration> QuinielaConfigurations { get; set; } = default!;
        public DbSet<QuinielaType> QuinielaTypes { get; set; } = default!;
        public DbSet<QuinielaTypeConfiguration> QuinielaTypeConfigurations { get; set; } = default!;
        public DbSet<QuinielaGame> QuinielaGames { get; set; }

        public DbSet<Status> Status { get; set; } = default!;


        public DbSet<League> Leagues { get; set; } = default!;
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }

        
        

    }
}
