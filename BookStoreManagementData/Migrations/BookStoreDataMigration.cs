using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreManagementData.Migrations
{
    public partial class BookStoreDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerPhoneID = table.Column<string>(maxLength: 12, nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    DayFirstPurchase = table.Column<DateTime>(nullable: false),
                    Decribe = table.Column<string>(nullable: true),
                    FriendlyCustomer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerPhoneID);
                });

            migrationBuilder.CreateTable(
                name: "BookType",
                columns: table => new
                {
                    BookTypeID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    BookTypeName = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookType", x => x.BookTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true),
                    StatusCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Right",
                columns: table => new
                {
                    RightID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Describe = table.Column<string>(nullable: true),
                    RightName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Right", x => x.RightID);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    ProviderID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Adress = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    ProviderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ProviderID);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    PublisherID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Adress = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PublisherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.PublisherID);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Address = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Describe = table.Column<string>(nullable: true),
                    Gender = table.Column<bool>(nullable: false),
                    ImageStaff = table.Column<byte[]>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    StaffName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    CustomerPhoneID = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true),
                    OrderDay = table.Column<DateTime>(nullable: false),
                    OrderValueSum = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerPhoneID",
                        column: x => x.CustomerPhoneID,
                        principalTable: "Customer",
                        principalColumn: "CustomerPhoneID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    ReceiptID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    DayCreateReceipt = table.Column<DateTime>(nullable: false),
                    Describe = table.Column<string>(nullable: true),
                    ProviderID = table.Column<int>(nullable: false),
                    ReceiptValueSum = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.ReceiptID);
                    table.ForeignKey(
                        name: "FK_Receipt_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountID = table.Column<string>(nullable: false),
                    DayofCreate = table.Column<DateTime>(nullable: false),
                    Describe = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    StaffID = table.Column<int>(nullable: false),
                    StatusAccount = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Account_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<string>(nullable: false),
                    AuthorBook = table.Column<string>(nullable: true),
                    BookCount = table.Column<long>(nullable: false),
                    BookCoverImage = table.Column<byte[]>(nullable: true),
                    BookName = table.Column<string>(nullable: true),
                    BookPage = table.Column<long>(nullable: false),
                    BookPrice = table.Column<double>(nullable: false),
                    BookStatus = table.Column<string>(nullable: true),
                    BookTypeID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    Describe = table.Column<string>(nullable: true),
                    ProviderID = table.Column<int>(nullable: true),
                    PublisherID = table.Column<int>(nullable: false),
                    ReceiptID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Book_BookType_BookTypeID",
                        column: x => x.BookTypeID,
                        principalTable: "BookType",
                        principalColumn: "BookTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publisher",
                        principalColumn: "PublisherID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Receipt_ReceiptID",
                        column: x => x.ReceiptID,
                        principalTable: "Receipt",
                        principalColumn: "ReceiptID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffRight",
                columns: table => new
                {
                    RightID = table.Column<int>(nullable: false),
                    AccountID = table.Column<string>(nullable: false),
                    DateGrant = table.Column<DateTime>(nullable: false),
                    Describe = table.Column<string>(nullable: true),
                    RightID1 = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRight", x => new { x.RightID, x.AccountID });
                    table.ForeignKey(
                        name: "FK_StaffRight_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffRight_Right_RightID1",
                        column: x => x.RightID1,
                        principalTable: "Right",
                        principalColumn: "RightID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookReceipt",
                columns: table => new
                {
                    BookID = table.Column<string>(nullable: false),
                    ReceiptID = table.Column<int>(nullable: false),
                    DescribeReceiptBookDetail = table.Column<string>(nullable: true),
                    Quantity = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReceipt", x => new { x.BookID, x.ReceiptID });
                    table.ForeignKey(
                        name: "FK_BookReceipt_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReceipt_Receipt_ReceiptID",
                        column: x => x.ReceiptID,
                        principalTable: "Receipt",
                        principalColumn: "ReceiptID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: false),
                    BookID1 = table.Column<string>(nullable: true),
                    DescribeOrderBookDetail = table.Column<string>(nullable: true),
                    Money = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    StaffID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => new { x.BookID, x.OrderID });
                    table.ForeignKey(
                        name: "FK_OrderDetail_Book_BookID1",
                        column: x => x.BookID1,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookTypeID",
                table: "Book",
                column: "BookTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryID",
                table: "Book",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_ProviderID",
                table: "Book",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherID",
                table: "Book",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_ReceiptID",
                table: "Book",
                column: "ReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_StaffID",
                table: "Account",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_BookReceipt_BookID",
                table: "BookReceipt",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookReceipt_ReceiptID",
                table: "BookReceipt",
                column: "ReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_BookID1",
                table: "OrderDetail",
                column: "BookID1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_StaffID",
                table: "OrderDetail",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRight_AccountID",
                table: "StaffRight",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRight_RightID1",
                table: "StaffRight",
                column: "RightID1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerPhoneID",
                table: "Order",
                column: "CustomerPhoneID");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_ProviderID",
                table: "Receipt",
                column: "ProviderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookReceipt");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "StaffRight");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Right");

            migrationBuilder.DropTable(
                name: "BookType");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Provider");
        }
    }
}
