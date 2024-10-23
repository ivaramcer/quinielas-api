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
            
            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.User)       
                .WithOne(u => u.Wallet)     
                .HasForeignKey<Wallet>(w => w.UserId); 

            modelBuilder.Entity<Game>()
                .HasOne(g => g.WinnerTeam)
                .WithMany()
                .HasForeignKey(g => g.WinnerTeamId)
                .OnDelete(DeleteBehavior.SetNull);
            

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Gamepass> Gamepasses { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Quiniela> Quinielas { get; set; }
        public DbSet<QuinielaConfiguration> QuinielaConfigurations { get; set; }
        public DbSet<QuinielaDuration> QuinielaDurations { get; set; }
        public DbSet<QuinielaGame> QuinielaGames { get; set; }
        public DbSet<QuinielaPickDuration> QuinielaPickDurations { get; set; }
        public DbSet<QuinielaType> QuinielaTypes { get; set; }
        public DbSet<QuinielaTypeConfiguration> QuinielaTypeConfigurations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPicks> UserPicks { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
