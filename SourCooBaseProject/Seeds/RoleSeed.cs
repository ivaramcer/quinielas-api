using Microsoft.EntityFrameworkCore;
using SourCooBaseProject.Models.Entities;

public static class ModelBuilderExtensions
{
    public static void SeedRole(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "User", Description = "Regular user" },
            new Role { Id = 2, Name = "Administrator", Description = "User with privileges" }
        );
    }
}