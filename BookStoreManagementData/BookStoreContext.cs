using BookStoreManagementData.Models;
using BookStoreManagementData.Models.CustomModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementData
{
    public class BookStoreContext : DbContext
    {
        #region DbSet
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Right> Right { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<BookType> BookType { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<StaffRight> StaffRight { get; set; }
        public DbSet<StaffRight> BookReceipt { get; set; }
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=BookStoreDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderDetail>().HasKey(o =>
                new
                {
                    o.BookID,
                    o.OrderID
                });

            builder.Entity<OrderDetail>()
                .HasOne(b => b.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(pc => pc.OrderID);
            builder.Entity<OrderDetail>()
                .HasOne(pc => pc.Book);


            builder.Entity<StaffRight>().HasKey(o =>
               new
               {
                   o.RightID,
                   o.AccountID
               });

            builder.Entity<StaffRight>()
                .HasOne(b => b.Account)
                .WithMany(o => o.StaffRights)
                .HasForeignKey(pc => pc.AccountID);
            builder.Entity<StaffRight>()
                .HasOne(b => b.Right);


            builder.Entity<Models.CustomModels.BookReceipt>().HasKey(o =>
                new
                {
                    o.BookID,
                    o.ReceiptID
                });

            builder.Entity<BookReceipt>()
                .HasOne(b => b.Book)
                .WithMany(o => o.BookReceipts)
                .HasForeignKey(pc => pc.BookID);
            builder.Entity<BookReceipt>()
                .HasOne(b => b.Receipt)
                .WithMany(o => o.BookReceipts)
                .HasForeignKey(pc => pc.ReceiptID);
        }
    }
}
