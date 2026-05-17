using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BanckManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BanckManagmentSystem.Data
{
    public class BankDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BankDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Account
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e=>e.AccountNumber).IsRequired().HasMaxLength(30);
                entity.HasIndex(e=>e.AccountNumber).IsUnique();
                entity.Property(e=>e.AccountStatus).HasConversion<string>().IsRequired();
                entity.Property(e=>e.AccountType).HasConversion<string>().IsRequired();
                entity.Property(e=>e.Balance).IsRequired().HasColumnType("decimal(8,2)");
                entity.HasOne(e=>e.Branch).WithMany(b=>b.Accounts).HasForeignKey(b=>b.BranchId).OnDelete(DeleteBehavior.Restrict);
            });
           #endregion
            #region Branch
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branches");
                entity.HasKey(e=>e.Id);
                entity.Property(e=>e.BranchCode).IsRequired().HasMaxLength(100);
                entity.HasIndex(e=>e.BranchCode).IsUnique();
                entity.Property(e=>e.Name).IsRequired().HasMaxLength(250);
                entity.Property(e=>e.PhoneNumber).IsRequired().HasMaxLength(20);
                entity.HasOne(e=>e.Manger).WithOne(m=>m.Branch).HasForeignKey<Branch>(e=>e.managerId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(e=>e.Address).IsRequired().HasMaxLength(250);
            });
           #endregion
            #region Manger
                
            modelBuilder.Entity<Manger>(entity =>
            {
                entity.HasKey(e=>e.Id);
                entity.Property(e=>e.Email).IsRequired().HasMaxLength(200);
                entity.HasIndex(e=>e.Email).IsUnique();
                entity.Property(e=>e.FullName).IsRequired().HasMaxLength(50);
                entity.HasOne(e=>e.Branch).WithOne(b=>b.Manger).HasForeignKey<Branch>(b=>b.managerId);
            });
            #endregion
            #region Customer
                
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e=>e.FullName).IsRequired().HasMaxLength(200);
                entity.Property(e=>e.Email).IsRequired().HasMaxLength(200);
                entity.HasIndex(e=>e.Email).IsUnique();
                entity.Property(e=>e.Address).IsRequired().HasMaxLength(250);
                entity.Property(e=>e.PhoneNumber).IsRequired().HasMaxLength(20);
                entity.Property(e=>e.NationalId).IsRequired().HasMaxLength(20);
                entity.HasIndex(e=>e.NationalId).IsUnique();
                entity.Property(e=>e.CustomerType).HasConversion<string>().IsRequired();
            });
            #endregion
            #region CustomerAccount
            modelBuilder.Entity<CustomerAccount>(entity =>
            {
                entity.HasKey(ca => new
                {
                    ca.CustomerId,
                    ca.AccountId
                });
                entity.Property(ca=>ca.OwnerShipRole).HasConversion<string>().IsRequired();
                entity.HasOne(ca=>ca.Account).WithMany(a=>a.CustomerAccounts).HasForeignKey(ca=>ca.AccountId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(ca=>ca.Customer).WithMany(c=>c.CustomerAccounts).HasForeignKey(ca=>ca.CustomerId).OnDelete(DeleteBehavior.Restrict);


            });
            #endregion
            #region BankTransactions
            modelBuilder.Entity<BankTransaction>(entity =>
            {
                entity.Property(bt=>bt.TransactionType).HasConversion<string>().IsRequired();
                entity.Property(bt=>bt.Amount).IsRequired().HasColumnType("decimal(8,2)");
                entity.Property(bt=>bt.TransactionDate).IsRequired();
                entity.HasOne(bt=>bt.Account).WithMany(a=>a.Transactions).HasForeignKey(bt=>bt.AccountId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(bt=>bt.TransactionType).HasConversion<string>().IsRequired();
                entity.Property(bt=>bt.Description).HasMaxLength(250);
                
            });
            #endregion
            #region SeedData 
            modelBuilder.Entity<Manger>().HasData(
            new Manger
            {
                Id = 1,
                FullName = "Ahmed Ali",
                PhoneNumber = "0123456789",
                Email = "ahmed.ali@example.com",
                HireDate= new DateTime(2020, 1, 15)
            },
            new Manger
            {
                Id = 2,
                FullName = "Mohamed Hassan",
                PhoneNumber = "0987654321",
                Email = "mohamed.hassan@example.com",
                HireDate= new DateTime(2020, 5, 15)
            }
            );
            #endregion
            #region SeedData Branch
            modelBuilder.Entity<Branch>().HasData(
                new Branch
                {
                    Id = 1,
                    BranchCode = "BR001",
                    Name = "Main Branch",
                    PhoneNumber = "0123456789",
                    Address = "123 Main St, City",
                    managerId=1
                },
                new Branch
                {
                    Id = 2,
                    BranchCode = "BR002",
                    Name = "Second Branch",
                    PhoneNumber = "0987654321",
                    Address = "456 Second St, City",
                    managerId=2
                }
            );
            #endregion
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manger> Mangers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }
    }
}