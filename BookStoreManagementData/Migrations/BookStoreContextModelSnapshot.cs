using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BookStoreManagementData;

namespace BookStoreManagementData.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    partial class BookStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("BookStoreManagementData.Models.Book", b =>
            {
                b.Property<string>("BookID");

                b.Property<string>("AuthorBook");

                b.Property<long>("BookCount");

                b.Property<byte[]>("BookCoverImage");

                b.Property<string>("BookName");

                b.Property<long>("BookPage");

                b.Property<double>("BookPrice");

                b.Property<string>("BookStatus");

                b.Property<int>("BookTypeID");

                b.Property<int>("CategoryID");

                b.Property<string>("Describe");

                b.Property<int?>("ProviderID");

                b.Property<int>("PublisherID");

                b.Property<int?>("ReceiptID");

                b.HasKey("BookID");

                b.HasIndex("BookTypeID");

                b.HasIndex("CategoryID");

                b.HasIndex("ProviderID");

                b.HasIndex("PublisherID");

                b.HasIndex("ReceiptID");

                b.ToTable("Book");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.Customer", b =>
            {
                b.Property<string>("CustomerPhoneID")
                    .HasMaxLength(12);

                b.Property<string>("Address");

                b.Property<string>("CustomerName");

                b.Property<DateTime>("DayFirstPurchase");

                b.Property<string>("Decribe");

                b.Property<bool>("FriendlyCustomer");

                b.HasKey("CustomerPhoneID");

                b.ToTable("Customer");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.CustomModels.Account", b =>
            {
                b.Property<string>("AccountID");

                b.Property<DateTime>("DayofCreate");

                b.Property<string>("Describe");

                b.Property<string>("Password");

                b.Property<bool>("StatusAccount");

                b.HasKey("AccountID");

                b.ToTable("Account");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.CustomModels.BookReceipt", b =>
            {
                b.Property<string>("BookID");

                b.Property<int>("ReceiptID");

                b.Property<string>("DescribeReceiptBookDetail");

                b.Property<long>("Quantity");

                b.HasKey("BookID", "ReceiptID");

                b.HasIndex("BookID");

                b.HasIndex("ReceiptID");

                b.ToTable("BookReceipt");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.CustomModels.BookType", b =>
            {
                b.Property<int>("BookTypeID")
                    .ValueGeneratedOnAdd();

                b.Property<string>("BookTypeName");

                b.Property<string>("Describe");

                b.HasKey("BookTypeID");

                b.ToTable("BookType");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.CustomModels.Category", b =>
            {
                b.Property<int>("CategoryID")
                    .ValueGeneratedOnAdd();

                b.Property<string>("CategoryName");

                b.Property<string>("Describe");

                b.Property<string>("StatusCategory");

                b.HasKey("CategoryID");

                b.ToTable("Category");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.CustomModels.OrderDetail", b =>
            {
                b.Property<string>("BookID");

                b.Property<int>("OrderID");

                b.Property<string>("BookID1");

                b.Property<string>("DescribeOrderBookDetail");

                b.Property<double>("Money");

                b.Property<int>("Quantity");

                b.Property<int>("StaffID");

                b.HasKey("BookID", "OrderID");

                b.HasIndex("BookID1");

                b.HasIndex("OrderID");

                b.HasIndex("StaffID");

                b.ToTable("OrderDetail");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.CustomModels.Right", b =>
            {
                b.Property<int>("RightID")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Describe");

                b.Property<string>("RightName");

                b.Property<bool>("Status");

                b.HasKey("RightID");

                b.ToTable("Right");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.CustomModels.StaffRight", b =>
            {
                b.Property<int>("RightID");

                b.Property<string>("AccountID");

                b.Property<DateTime>("DateGrant");

                b.Property<string>("Describe");

                b.Property<int?>("RightID1");

                b.Property<bool>("Status");

                b.HasKey("RightID", "AccountID");

                b.HasIndex("AccountID");

                b.HasIndex("RightID1");

                b.ToTable("StaffRight");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.Order", b =>
            {
                b.Property<int>("OrderID")
                    .ValueGeneratedOnAdd();

                b.Property<string>("CustomerPhoneID");

                b.Property<string>("Describe");

                b.Property<DateTime>("OrderDay");

                b.Property<double>("OrderValueSum");

                b.HasKey("OrderID");

                b.HasIndex("CustomerPhoneID");

                b.ToTable("Order");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.Provider", b =>
            {
                b.Property<int>("ProviderID")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Adress");

                b.Property<string>("Describe");

                b.Property<string>("Phone");

                b.Property<string>("ProviderName");

                b.HasKey("ProviderID");

                b.ToTable("Provider");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.Publisher", b =>
            {
                b.Property<int>("PublisherID")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Adress");

                b.Property<string>("Describe");

                b.Property<string>("Phone");

                b.Property<string>("PublisherName");

                b.HasKey("PublisherID");

                b.ToTable("Publisher");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.Receipt", b =>
            {
                b.Property<int>("ReceiptID")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("DayCreateReceipt");

                b.Property<string>("Describe");

                b.Property<int>("ProviderID");

                b.Property<double>("ReceiptValueSum");

                b.HasKey("ReceiptID");

                b.HasIndex("ProviderID");

                b.ToTable("Receipt");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.Staff", b =>
            {
                b.Property<int>("StaffID")
                    .ValueGeneratedOnAdd();

                b.Property<string>("AccountID");

                b.Property<string>("Address");

                b.Property<DateTime>("Birthday");

                b.Property<string>("Describe");

                b.Property<bool>("Gender");

                b.Property<byte[]>("ImageStaff");

                b.Property<string>("PhoneNumber");

                b.Property<string>("StaffName");

                b.Property<bool>("Status");

                b.HasKey("StaffID");

                b.HasIndex("AccountID")
                    .IsUnique();

                b.ToTable("Staff");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.Book", b =>
            {
                b.HasOne("BookStoreManagementData.Models.CustomModels.BookType", "BookType")
                    .WithMany("Books")
                    .HasForeignKey("BookTypeID")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("BookStoreManagementData.Models.CustomModels.Category", "Category")
                    .WithMany("Books")
                    .HasForeignKey("CategoryID")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("BookStoreManagementData.Models.Provider")
                    .WithMany("Books")
                    .HasForeignKey("ProviderID");

                b.HasOne("BookStoreManagementData.Models.Publisher", "Publisher")
                    .WithMany()
                    .HasForeignKey("PublisherID")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("BookStoreManagementData.Models.Receipt")
                    .WithMany("Books")
                    .HasForeignKey("ReceiptID");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.CustomModels.BookReceipt", b =>
            {
                b.HasOne("BookStoreManagementData.Models.Book", "Book")
                    .WithMany("BookReceipts")
                    .HasForeignKey("BookID")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("BookStoreManagementData.Models.Receipt", "Receipt")
                    .WithMany("BookReceipts")
                    .HasForeignKey("ReceiptID")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("BookStoreManagementData.Models.CustomModels.OrderDetail", b =>
            {
                b.HasOne("BookStoreManagementData.Models.Book", "Book")
                    .WithMany()
                    .HasForeignKey("BookID1");

                b.HasOne("BookStoreManagementData.Models.Order", "Order")
                    .WithMany("OrderDetails")
                    .HasForeignKey("OrderID")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("BookStoreManagementData.Models.Staff", "Staff")
                    .WithMany("OrderDetails")
                    .HasForeignKey("StaffID")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("BookStoreManagementData.Models.CustomModels.StaffRight", b =>
            {
                b.HasOne("BookStoreManagementData.Models.CustomModels.Account", "Account")
                    .WithMany("StaffRights")
                    .HasForeignKey("AccountID")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("BookStoreManagementData.Models.CustomModels.Right", "Right")
                    .WithMany("StaffRights")
                    .HasForeignKey("RightID1");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.Order", b =>
            {
                b.HasOne("BookStoreManagementData.Models.Customer", "Customer")
                    .WithMany("Orders")
                    .HasForeignKey("CustomerPhoneID");
            });

            modelBuilder.Entity("BookStoreManagementData.Models.Receipt", b =>
            {
                b.HasOne("BookStoreManagementData.Models.Provider", "Providers")
                    .WithMany("Receipts")
                    .HasForeignKey("ProviderID")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("BookStoreManagementData.Models.Staff", b =>
            {
                b.HasOne("BookStoreManagementData.Models.CustomModels.Account", "Account")
                    .WithOne("Staff")
                    .HasForeignKey("BookStoreManagementData.Models.Staff", "AccountID");
            });
        }
    }
}
