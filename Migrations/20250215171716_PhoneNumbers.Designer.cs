﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SimpleWebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250215171716_PhoneNumbers")]
    partial class PhoneNumbers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SimpleWebApi.Models.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("SimpleWebApi.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SimpleWebApi.Models.StudentAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddressName")
                        .HasColumnType("longtext");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentAddress");
                });

            modelBuilder.Entity("SimpleWebApi.Models.PhoneNumber", b =>
                {
                    b.HasOne("SimpleWebApi.Models.Student", "Student")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SimpleWebApi.Models.StudentAddress", b =>
                {
                    b.HasOne("SimpleWebApi.Models.Student", "Student")
                        .WithOne("StudentAddress")
                        .HasForeignKey("SimpleWebApi.Models.StudentAddress", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SimpleWebApi.Models.Student", b =>
                {
                    b.Navigation("PhoneNumbers");

                    b.Navigation("StudentAddress");
                });
#pragma warning restore 612, 618
        }
    }
}
