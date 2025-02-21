﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using N5.Permissions.Infrastructure.Persistence;

#nullable disable

namespace N5.Permissions.Infrastructure.Migrations
{
    [DbContext(typeof(PermissionDbContext))]
    partial class PermissionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("N5.Permissions.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameEmployee")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("PermissionDate")
                        .HasColumnType("datetime");

                    b.Property<int>("PermissionTypeId")
                        .HasColumnType("int");

                    b.Property<string>("SurnameEmployee")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("PermissionTypeId");

                    b.ToTable("Permission", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameEmployee = "Johans",
                            PermissionDate = new DateTime(2024, 7, 26, 19, 42, 59, 258, DateTimeKind.Local).AddTicks(7942),
                            PermissionTypeId = 1,
                            SurnameEmployee = "Cuellar Faraco"
                        });
                });

            modelBuilder.Entity("N5.Permissions.Domain.Entities.PermissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("PermissionType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Permission for marriege"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Permission for healt"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Permission for course"
                        });
                });

            modelBuilder.Entity("N5.Permissions.Domain.Entities.Permission", b =>
                {
                    b.HasOne("N5.Permissions.Domain.Entities.PermissionType", "PermissionType")
                        .WithMany()
                        .HasForeignKey("PermissionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionType");
                });
#pragma warning restore 612, 618
        }
    }
}
