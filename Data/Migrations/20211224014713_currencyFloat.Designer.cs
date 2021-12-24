﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test_Crud_Carlos_Arrieta.Data;

namespace Test_Crud_Carlos_Arrieta.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211224014713_currencyFloat")]
    partial class currencyFloat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Test_Crud_Carlos_Arrieta.Models.AlquilerPermanente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("filmId")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("alquilerPermanente");
                });

            modelBuilder.Entity("Test_Crud_Carlos_Arrieta.Models.VentaPermanente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("filmId")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("ventaPermanente");
                });

            modelBuilder.Entity("Test_Crud_Carlos_Arrieta.Models.tAlquiler", b =>
                {
                    b.Property<int>("cod_adquiler")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cod_pelicula")
                        .HasColumnType("int");

                    b.Property<int>("cod_usuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("momento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("peliculacod_pelicula")
                        .HasColumnType("int");

                    b.Property<float>("precio")
                        .HasColumnType("real");

                    b.Property<int?>("usuariocod_usuario")
                        .HasColumnType("int");

                    b.HasKey("cod_adquiler");

                    b.HasIndex("peliculacod_pelicula");

                    b.HasIndex("usuariocod_usuario");

                    b.ToTable("tAlquiler");
                });

            modelBuilder.Entity("Test_Crud_Carlos_Arrieta.Models.tGenero", b =>
                {
                    b.Property<int>("cod_genero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("txt_desc")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("cod_genero");

                    b.ToTable("tGenero");
                });

            modelBuilder.Entity("Test_Crud_Carlos_Arrieta.Models.tGeneroPelicula", b =>
                {
                    b.Property<int>("cod_genero_pelicula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cod_genero")
                        .HasColumnType("int");

                    b.Property<int>("cod_pelicula")
                        .HasColumnType("int");

                    b.Property<int?>("generocod_genero")
                        .HasColumnType("int");

                    b.Property<int?>("peliculacod_pelicula")
                        .HasColumnType("int");

                    b.HasKey("cod_genero_pelicula");

                    b.HasIndex("generocod_genero");

                    b.HasIndex("peliculacod_pelicula");

                    b.ToTable("tGeneroPelicula");
                });

            modelBuilder.Entity("Test_Crud_Carlos_Arrieta.Models.tPelicula", b =>
                {
                    b.Property<int>("cod_pelicula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cant_disponibles_alquiler")
                        .HasColumnType("int");

                    b.Property<int>("cant_disponibles_venta")
                        .HasColumnType("int");

                    b.Property<float>("precio_alquiler")
                        .HasColumnType("real");

                    b.Property<float>("precio_venta")
                        .HasColumnType("real");

                    b.Property<string>("txt_desc")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("cod_pelicula");

                    b.ToTable("tPelicula");
                });

            modelBuilder.Entity("Test_Crud_Carlos_Arrieta.Models.tRol", b =>
                {
                    b.Property<int>("cod_rol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("sn_activo")
                        .HasColumnType("int");

                    b.Property<string>("txt_desc")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("cod_rol");

                    b.ToTable("tRol");
                });

            modelBuilder.Entity("Test_Crud_Carlos_Arrieta.Models.tUsers", b =>
                {
                    b.Property<int>("cod_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cod_rol")
                        .HasColumnType("int");

                    b.Property<string>("nro_doc")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("sn_activo")
                        .HasColumnType("int");

                    b.Property<int?>("trolcod_rol")
                        .HasColumnType("int");

                    b.Property<string>("txt_apellido")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("txt_nombre")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("txt_password")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("txt_user")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("cod_usuario");

                    b.HasIndex("trolcod_rol");

                    b.ToTable("tUsers");
                });

            modelBuilder.Entity("Test_Crud_Carlos_Arrieta.Models.tVenta", b =>
                {
                    b.Property<int>("cod_venta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cod_pelicula")
                        .HasColumnType("int");

                    b.Property<int>("cod_usuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("momento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("peliculacod_pelicula")
                        .HasColumnType("int");

                    b.Property<float>("precio")
                        .HasColumnType("real");

                    b.Property<int?>("usuariocod_usuario")
                        .HasColumnType("int");

                    b.HasKey("cod_venta");

                    b.HasIndex("peliculacod_pelicula");

                    b.HasIndex("usuariocod_usuario");

                    b.ToTable("tVenta");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Test_Crud_Carlos_Arrieta.Models.tAlquiler", b =>
                {
                    b.HasOne("Test_Crud_Carlos_Arrieta.Models.tPelicula", "pelicula")
                        .WithMany("alquileres")
                        .HasForeignKey("peliculacod_pelicula");

                    b.HasOne("Test_Crud_Carlos_Arrieta.Models.tUsers", "usuario")
                        .WithMany("alquileres")
                        .HasForeignKey("usuariocod_usuario");
                });

            modelBuilder.Entity("Test_Crud_Carlos_Arrieta.Models.tGeneroPelicula", b =>
                {
                    b.HasOne("Test_Crud_Carlos_Arrieta.Models.tGenero", "genero")
                        .WithMany("peliculas")
                        .HasForeignKey("generocod_genero");

                    b.HasOne("Test_Crud_Carlos_Arrieta.Models.tPelicula", "pelicula")
                        .WithMany("generos")
                        .HasForeignKey("peliculacod_pelicula");
                });

            modelBuilder.Entity("Test_Crud_Carlos_Arrieta.Models.tUsers", b =>
                {
                    b.HasOne("Test_Crud_Carlos_Arrieta.Models.tRol", "trol")
                        .WithMany("users")
                        .HasForeignKey("trolcod_rol");
                });

            modelBuilder.Entity("Test_Crud_Carlos_Arrieta.Models.tVenta", b =>
                {
                    b.HasOne("Test_Crud_Carlos_Arrieta.Models.tPelicula", "pelicula")
                        .WithMany("ventas")
                        .HasForeignKey("peliculacod_pelicula");

                    b.HasOne("Test_Crud_Carlos_Arrieta.Models.tUsers", "usuario")
                        .WithMany("compras")
                        .HasForeignKey("usuariocod_usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
