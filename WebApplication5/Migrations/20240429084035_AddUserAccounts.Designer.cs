﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication5.Models;

#nullable disable

namespace WebApplication5.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20240429084035_AddUserAccounts")]
    partial class AddUserAccounts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("WebApplication5.Models.BankBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("branchManager")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("employeeCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("locationURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BankBranches");
                });

            modelBuilder.Entity("WebApplication5.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BankBranchId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("civilId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BankBranchId");

                    b.HasIndex("civilId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApplication5.Models.UserAccounts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("WebApplication5.Models.Employee", b =>
                {
                    b.HasOne("WebApplication5.Models.BankBranch", "BankBranch")
                        .WithMany("Employees")
                        .HasForeignKey("BankBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankBranch");
                });

            modelBuilder.Entity("WebApplication5.Models.BankBranch", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
