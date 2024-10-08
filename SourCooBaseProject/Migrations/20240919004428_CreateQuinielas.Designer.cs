﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuinielasApi.DBContext;

#nullable disable

namespace QuinielasApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240919004428_CreateQuinielas")]
    partial class CreateQuinielas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QuinielasApi.Models.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ISOCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.OperationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OperationTypes");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfBirthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Preference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.Property<int>("SportId")
                        .HasColumnType("integer");

                    b.Property<int>("SportTeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("SportId");

                    b.HasIndex("SportTeamId");

                    b.ToTable("Preferences");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Quiniela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("QuinielaDurationId")
                        .HasColumnType("integer");

                    b.Property<int>("QuinielaPickDurationId")
                        .HasColumnType("integer");

                    b.Property<int>("QuinielaTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("QuotaPeople")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<double>("ViudaPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("QuinielaDurationId");

                    b.HasIndex("QuinielaPickDurationId");

                    b.HasIndex("QuinielaTypeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Quinielas");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.QuinielaDuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("QuinielaTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QuinielaTypeId");

                    b.ToTable("QuinielaDuration");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.QuinielaPickDuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("QuinielaDurationId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuinielaDurationId");

                    b.ToTable("QuinielaPickDuration");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.QuinielaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("QuinielaTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Participants predict the outcomes of multiple sports matches or races.",
                            Name = "Regular"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A survivor-type quiniela involves picking a winner for each round, with elimination upon incorrect predictions until one remains.",
                            Name = "Survivor"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A spread-type quiniela requires predicting the point difference (spread) between teams, not just the match winner.",
                            Name = "Spread"
                        });
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.QuinielaTypeConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("OperationTypeId")
                        .HasMaxLength(100)
                        .HasColumnType("integer");

                    b.Property<int>("QuinielaTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.HasIndex("OperationTypeId");

                    b.HasIndex("QuinielaTypeId");

                    b.ToTable("QuinielaTypeConfigurations");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Regular user",
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            Description = "User with privileges",
                            Name = "Administrator"
                        });
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Soccer, also known as football, is a team sport where two teams of eleven players compete to score goals by kicking a ball",
                            Name = "Soccer"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The NFL (National Football League) is a professional American football league consisting of 32 teams.",
                            Name = "NFL"
                        });
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.SportTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SportId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SportId");

                    b.ToTable("SportTeams");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("ISOCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PersonId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.UserPermission", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Address", b =>
                {
                    b.HasOne("QuinielasApi.Models.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.City", b =>
                {
                    b.HasOne("QuinielasApi.Models.Entities.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Person", b =>
                {
                    b.HasOne("QuinielasApi.Models.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Preference", b =>
                {
                    b.HasOne("QuinielasApi.Models.Entities.Person", "Person")
                        .WithMany("Preferences")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuinielasApi.Models.Entities.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuinielasApi.Models.Entities.SportTeam", "SportTeam")
                        .WithMany()
                        .HasForeignKey("SportTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Sport");

                    b.Navigation("SportTeam");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Quiniela", b =>
                {
                    b.HasOne("QuinielasApi.Models.Entities.QuinielaDuration", "QuinielaDuration")
                        .WithMany()
                        .HasForeignKey("QuinielaDurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuinielasApi.Models.Entities.QuinielaPickDuration", "QuinielaPickDuration")
                        .WithMany()
                        .HasForeignKey("QuinielaPickDurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuinielasApi.Models.Entities.QuinielaType", "QuinielaType")
                        .WithMany()
                        .HasForeignKey("QuinielaTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuinielasApi.Models.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuinielaDuration");

                    b.Navigation("QuinielaPickDuration");

                    b.Navigation("QuinielaType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.QuinielaDuration", b =>
                {
                    b.HasOne("QuinielasApi.Models.Entities.QuinielaType", "QuinielaType")
                        .WithMany("QuinielaDurations")
                        .HasForeignKey("QuinielaTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuinielaType");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.QuinielaPickDuration", b =>
                {
                    b.HasOne("QuinielasApi.Models.Entities.QuinielaDuration", "QuinielaDuration")
                        .WithMany("QuinielaPickDurations")
                        .HasForeignKey("QuinielaDurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuinielaDuration");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.QuinielaTypeConfiguration", b =>
                {
                    b.HasOne("QuinielasApi.Models.Entities.OperationType", "OperationType")
                        .WithMany()
                        .HasForeignKey("OperationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuinielasApi.Models.Entities.QuinielaType", "QuinielaType")
                        .WithMany("QuinielaTypeConfigurations")
                        .HasForeignKey("QuinielaTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationType");

                    b.Navigation("QuinielaType");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.SportTeam", b =>
                {
                    b.HasOne("QuinielasApi.Models.Entities.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.State", b =>
                {
                    b.HasOne("QuinielasApi.Models.Entities.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.User", b =>
                {
                    b.HasOne("QuinielasApi.Models.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuinielasApi.Models.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.UserPermission", b =>
                {
                    b.HasOne("QuinielasApi.Models.Entities.Permission", "Permission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuinielasApi.Models.Entities.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Permission", b =>
                {
                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.Person", b =>
                {
                    b.Navigation("Preferences");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.QuinielaDuration", b =>
                {
                    b.Navigation("QuinielaPickDurations");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.QuinielaType", b =>
                {
                    b.Navigation("QuinielaDurations");

                    b.Navigation("QuinielaTypeConfigurations");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.State", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("QuinielasApi.Models.Entities.User", b =>
                {
                    b.Navigation("UserPermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
