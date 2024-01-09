﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proiect_MDP.Data;

#nullable disable

namespace proiect_MDP.Migrations
{
    [DbContext(typeof(proiect_MDPContext))]
    partial class proiect_MDPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("proiect_MDP.Models.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategorieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("proiect_MDP.Models.Companie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Companie");
                });

            modelBuilder.Entity("proiect_MDP.Models.Terminal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("TerminalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Terminal");
                });

            modelBuilder.Entity("proiect_MDP.Models.Zbor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CompanieID")
                        .HasColumnType("int");

                    b.Property<string>("Destinatie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("TerminalID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ZborDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CompanieID");

                    b.HasIndex("TerminalID");

                    b.ToTable("Zbor");
                });

            modelBuilder.Entity("proiect_MDP.Models.ZborCategorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<int>("ZborID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("ZborID");

                    b.ToTable("ZborCategorie");
                });

            modelBuilder.Entity("proiect_MDP.Models.Zbor", b =>
                {
                    b.HasOne("proiect_MDP.Models.Companie", "Companie")
                        .WithMany()
                        .HasForeignKey("CompanieID");

                    b.HasOne("proiect_MDP.Models.Terminal", "Terminal")
                        .WithMany("Zboruri")
                        .HasForeignKey("TerminalID");

                    b.Navigation("Companie");

                    b.Navigation("Terminal");
                });

            modelBuilder.Entity("proiect_MDP.Models.ZborCategorie", b =>
                {
                    b.HasOne("proiect_MDP.Models.Categorie", "Categorie")
                        .WithMany("ZborCategorii")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proiect_MDP.Models.Zbor", "Zbor")
                        .WithMany("ZborCategorii")
                        .HasForeignKey("ZborID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Zbor");
                });

            modelBuilder.Entity("proiect_MDP.Models.Categorie", b =>
                {
                    b.Navigation("ZborCategorii");
                });

            modelBuilder.Entity("proiect_MDP.Models.Terminal", b =>
                {
                    b.Navigation("Zboruri");
                });

            modelBuilder.Entity("proiect_MDP.Models.Zbor", b =>
                {
                    b.Navigation("ZborCategorii");
                });
#pragma warning restore 612, 618
        }
    }
}
