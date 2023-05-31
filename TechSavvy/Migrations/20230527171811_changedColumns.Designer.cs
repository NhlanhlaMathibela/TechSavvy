﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechSavvy.Data;

#nullable disable

namespace TechSavvy.Migrations
{
    [DbContext(typeof(TechSavvyContext))]
    [Migration("20230527171811_changedColumns")]
    partial class changedColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TechSavvy.Areas.Identity.Data.TechSavvyUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("TechSavvy.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TechSavvy.Models.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TechSavvy.Models.Department", b =>
                {
                    b.Property<int>("deptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("deptId"), 1L, 1);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("deptId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TechSavvy.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GradeLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TechSavvy.Models.Order_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<double>("quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Order_Details");
                });

            modelBuilder.Entity("TechSavvy.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("barCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TechSavvy.Models.Purchase_Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"), 1L, 1);

                    b.Property<string>("POProgress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("POTotal")
                        .HasColumnType("float");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.Property<int?>("SupllierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderID");

                    b.HasIndex("ProductId");

                    b.HasIndex("RequestId");

                    b.HasIndex("SupllierId");

                    b.ToTable("Purchase_Orders");
                });

            modelBuilder.Entity("TechSavvy.Models.Purchase_Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"), 1L, 1);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("PRStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<DateTime>("requestDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RequestId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("UserId");

                    b.HasIndex("productId");

                    b.ToTable("Purchase_Requests");
                });

            modelBuilder.Entity("TechSavvy.Models.PurchaseOrder_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("PurchaseOrder_Details");
                });

            modelBuilder.Entity("TechSavvy.Models.PurchaseRequest_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RequestId");

                    b.ToTable("PurchaseRequest_Details");
                });

            modelBuilder.Entity("TechSavvy.Models.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuoteId"), 1L, 1);

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("expiryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("quoteDate")
                        .HasColumnType("datetime2");

                    b.HasKey("QuoteId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerId1");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("TechSavvy.Models.Quote_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int?>("quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RequestId");

                    b.ToTable("Quote_Details");
                });

            modelBuilder.Entity("TechSavvy.Models.Sale_Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("QuoteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("orderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("QuoteId");

                    b.ToTable("Sale_Order");
                });

            modelBuilder.Entity("TechSavvy.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
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
                    b.HasOne("TechSavvy.Areas.Identity.Data.TechSavvyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TechSavvy.Areas.Identity.Data.TechSavvyUser", null)
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

                    b.HasOne("TechSavvy.Areas.Identity.Data.TechSavvyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TechSavvy.Areas.Identity.Data.TechSavvyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechSavvy.Models.Customer", b =>
                {
                    b.HasOne("TechSavvy.Areas.Identity.Data.TechSavvyUser", "TechSavvyUser")
                        .WithMany("Customers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TechSavvyUser");
                });

            modelBuilder.Entity("TechSavvy.Models.Employee", b =>
                {
                    b.HasOne("TechSavvy.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechSavvy.Areas.Identity.Data.TechSavvyUser", "TechSavvyUser")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Department");

                    b.Navigation("TechSavvyUser");
                });

            modelBuilder.Entity("TechSavvy.Models.Order_Details", b =>
                {
                    b.HasOne("TechSavvy.Models.Sale_Order", "SaleOrder")
                        .WithMany("Order_Details")
                        .HasForeignKey("OrderId");

                    b.HasOne("TechSavvy.Models.Product", "Product")
                        .WithMany("Order_Details")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");

                    b.Navigation("SaleOrder");
                });

            modelBuilder.Entity("TechSavvy.Models.Product", b =>
                {
                    b.HasOne("TechSavvy.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("TechSavvy.Models.Supplier", "supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");

                    b.Navigation("category");

                    b.Navigation("supplier");
                });

            modelBuilder.Entity("TechSavvy.Models.Purchase_Order", b =>
                {
                    b.HasOne("TechSavvy.Models.Product", null)
                        .WithMany("Purchase_Orders")
                        .HasForeignKey("ProductId");

                    b.HasOne("TechSavvy.Models.Purchase_Request", "Purchase_Request")
                        .WithMany("Purchase_Orders")
                        .HasForeignKey("RequestId");

                    b.HasOne("TechSavvy.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupllierId");

                    b.Navigation("Purchase_Request");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("TechSavvy.Models.Purchase_Request", b =>
                {
                    b.HasOne("TechSavvy.Models.Employee", null)
                        .WithMany("Purchase_Requests")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("TechSavvy.Areas.Identity.Data.TechSavvyUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("TechSavvy.Models.Product", "Products")
                        .WithMany("Purchase_Requests")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechSavvy.Models.PurchaseOrder_Details", b =>
                {
                    b.HasOne("TechSavvy.Models.Purchase_Order", "Purchase_Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("TechSavvy.Models.Product", "Product")
                        .WithMany("PurchaseOrder_Details")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");

                    b.Navigation("Purchase_Order");
                });

            modelBuilder.Entity("TechSavvy.Models.PurchaseRequest_Details", b =>
                {
                    b.HasOne("TechSavvy.Models.Product", "Product")
                        .WithMany("PurchaseRequest_Details")
                        .HasForeignKey("ProductId");

                    b.HasOne("TechSavvy.Models.Purchase_Request", "Purchase_Request")
                        .WithMany()
                        .HasForeignKey("RequestId");

                    b.Navigation("Product");

                    b.Navigation("Purchase_Request");
                });

            modelBuilder.Entity("TechSavvy.Models.Quote", b =>
                {
                    b.HasOne("TechSavvy.Areas.Identity.Data.TechSavvyUser", "TechSavvyUser")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("TechSavvy.Models.Customer", null)
                        .WithMany("Quotes")
                        .HasForeignKey("CustomerId1");

                    b.Navigation("TechSavvyUser");
                });

            modelBuilder.Entity("TechSavvy.Models.Quote_Details", b =>
                {
                    b.HasOne("TechSavvy.Models.Product", "Product")
                        .WithMany("Quote_Details")
                        .HasForeignKey("ProductId");

                    b.HasOne("TechSavvy.Models.Quote", "Quote")
                        .WithMany("Quotes_Details")
                        .HasForeignKey("RequestId");

                    b.Navigation("Product");

                    b.Navigation("Quote");
                });

            modelBuilder.Entity("TechSavvy.Models.Sale_Order", b =>
                {
                    b.HasOne("TechSavvy.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("TechSavvy.Models.Quote", "Quote")
                        .WithMany("Sale_Orders")
                        .HasForeignKey("QuoteId");

                    b.Navigation("Customer");

                    b.Navigation("Quote");
                });

            modelBuilder.Entity("TechSavvy.Areas.Identity.Data.TechSavvyUser", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("TechSavvy.Models.Customer", b =>
                {
                    b.Navigation("Quotes");
                });

            modelBuilder.Entity("TechSavvy.Models.Employee", b =>
                {
                    b.Navigation("Purchase_Requests");
                });

            modelBuilder.Entity("TechSavvy.Models.Product", b =>
                {
                    b.Navigation("Order_Details");

                    b.Navigation("PurchaseOrder_Details");

                    b.Navigation("PurchaseRequest_Details");

                    b.Navigation("Purchase_Orders");

                    b.Navigation("Purchase_Requests");

                    b.Navigation("Quote_Details");
                });

            modelBuilder.Entity("TechSavvy.Models.Purchase_Request", b =>
                {
                    b.Navigation("Purchase_Orders");
                });

            modelBuilder.Entity("TechSavvy.Models.Quote", b =>
                {
                    b.Navigation("Quotes_Details");

                    b.Navigation("Sale_Orders");
                });

            modelBuilder.Entity("TechSavvy.Models.Sale_Order", b =>
                {
                    b.Navigation("Order_Details");
                });

            modelBuilder.Entity("TechSavvy.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
