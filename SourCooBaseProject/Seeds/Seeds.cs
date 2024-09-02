using Microsoft.EntityFrameworkCore;
using QuinielasApi.Models.Entities;

public static class ModelBuilderExtensions
{
    public static void SeedRole(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "User", Description = "Regular user" },
            new Role { Id = 2, Name = "Administrator", Description = "User with privileges" }
        );
    }

    public static void SeedSport(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sport>().HasData(
            new Role { Id = 1, Name = "Soccer", Description = "Soccer, also known as football, is a team sport where two teams of eleven players compete to score goals by kicking a ball" },
            new Role { Id = 2, Name = "NFL", Description = "The NFL (National Football League) is a professional American football league consisting of 32 teams." }
        );
    }
}