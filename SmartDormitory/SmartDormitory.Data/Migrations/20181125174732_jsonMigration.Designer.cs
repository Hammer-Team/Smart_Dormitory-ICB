﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartDormitory.Data.Context;

namespace SmartDormitory.Data.Migrations
{
    [DbContext(typeof(DormitoryContext))]
    [Migration("20181125174732_jsonMigration")]
    partial class jsonMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = "959596e5-93e4-4272-8cfb-6e71a4254370", ConcurrencyStamp = "20d35162-b35c-4b2e-80c1-81a15bc1b2f3", Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                        new { Id = "5197310d-5d42-4337-bb59-2fd06e6a8fcd", ConcurrencyStamp = "a3bc9d45-276b-442f-bc6b-b1a5763df30d", Name = "User", NormalizedName = "USER" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new { UserId = "45a3335a-44de-44f7-b77c-bfa7d3c10a7c", RoleId = "959596e5-93e4-4272-8cfb-6e71a4254370" },
                        new { UserId = "31d4807f-7f5f-4ffa-90c1-a131e2d3855e", RoleId = "5197310d-5d42-4337-bb59-2fd06e6a8fcd" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SmartDormitory.Data.Models.Sensor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Alarm");

                    b.Property<string>("ApiId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsPublic");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<string>("MeasurmentType");

                    b.Property<string>("Name");

                    b.Property<int>("PoolInterval");

                    b.Property<int>("SensorTypeId");

                    b.Property<string>("SensorTypeId1");

                    b.Property<string>("URLSensorData");

                    b.Property<string>("UserId");

                    b.Property<double>("Value");

                    b.Property<double>("ValueRangeMax");

                    b.Property<double>("ValueRangeMin");

                    b.HasKey("ID");

                    b.HasIndex("SensorTypeId1");

                    b.HasIndex("UserId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("SmartDormitory.Data.Models.SensorType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("SensorType");
                });

            modelBuilder.Entity("SmartDormitory.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "45a3335a-44de-44f7-b77c-bfa7d3c10a7c", AccessFailedCount = 0, ConcurrencyStamp = "9d737330-f5d9-410c-a9e1-f8aec11903f9", Email = "shaban9726@gmail.com", EmailConfirmed = false, LockoutEnabled = false, NormalizedEmail = "SHABAN9726@GMAIL.COM", NormalizedUserName = "SHABAN9726@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEFlZ3okaz7hZUfZV1qgvOLac2WRWCxSNuhzwaB9Of93MvQncQQYZj2fb6bLSH4VFRw==", PhoneNumberConfirmed = false, SecurityStamp = "FJBKMINGFQAZNGSMZAIYUUQEVK4T74RU", TwoFactorEnabled = false, UserName = "shaban9726@gmail.com" },
                        new { Id = "31d4807f-7f5f-4ffa-90c1-a131e2d3855e", AccessFailedCount = 0, ConcurrencyStamp = "715dad2a-9a3f-4a7d-bca1-e40799bb172c", Email = "user_pesho@abv.bg", EmailConfirmed = false, LockoutEnabled = false, NormalizedEmail = "USER_PESHO@ABV.BG", NormalizedUserName = "USER_PESHO@ABV.BG", PasswordHash = "AQAAAAEAACcQAAAAECewgbwibVC/7nEpYLbJB26wOJyT9i8Dfcx6WFFCTnGy5xqwptVYNBIZEWK37eaaMA==", PhoneNumberConfirmed = false, SecurityStamp = "WNDRYHCTXU3MSZ7NYBDFJQDL5VU2LBXS", TwoFactorEnabled = false, UserName = "user_pesho@abv.bg" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SmartDormitory.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SmartDormitory.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartDormitory.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SmartDormitory.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartDormitory.Data.Models.Sensor", b =>
                {
                    b.HasOne("SmartDormitory.Data.Models.SensorType", "SensorType")
                        .WithMany("Sensors")
                        .HasForeignKey("SensorTypeId1");

                    b.HasOne("SmartDormitory.Data.Models.User", "User")
                        .WithMany("Sensors")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
