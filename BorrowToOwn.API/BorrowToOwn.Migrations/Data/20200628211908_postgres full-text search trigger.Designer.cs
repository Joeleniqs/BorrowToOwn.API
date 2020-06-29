﻿// <auto-generated />
using System;
using System.Collections.Generic;
using BorrowToOwn.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

namespace BorrowToOwn.API.BorrowToOwn.Migrations.Data
{
    [DbContext(typeof(BorrowContext))]
    [Migration("20200628211908_postgres full-text search trigger")]
    partial class postgresfulltextsearchtrigger
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BorrowToOwn.Data.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("HomeAddressId")
                        .HasColumnType("bigint");

                    //ad

                    b.Property<long?>("OfficeAddressId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("HomeAddressId");

                    b.HasIndex("OfficeAddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.AddressDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("StreetName")
                        .HasColumnType("text");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("AddressDetails");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsOrderLevelReady")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<Guid>("SurrogateIdentifier")
                        .HasColumnType("uuid");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("UserProfilePicUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("SurrogateIdentifier")
                        .IsUnique();

                    b.HasIndex("FirstName", "LastName", "Email", "UserName");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.AppUserBankStatement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<string>("DocumentUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("AppUserBankStatement");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.Card", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<int>("CVV")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("Number")
                        .HasColumnType("bigint");

                    b.Property<int>("Pin")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("TimeStampCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("TimeStampModified")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApprovalComment")
                        .HasColumnType("text");

                    b.Property<long?>("OrderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.IdentityDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<string>("DocumentUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IdentityName")
                        .HasColumnType("text");

                    b.Property<int>("IdentityType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("IdentityDocument");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<string>("ApprovedBy")
                        .HasColumnType("text");

                    b.Property<int>("DeliveryPrice")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAdminApproved")
                        .HasColumnType("boolean");

                    b.Property<decimal>("MonthlyAmortizationValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OrderAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderState")
                        .HasColumnType("integer");

                    b.Property<int>("OrderedQuantity")
                        .HasColumnType("integer");

                    b.Property<int?>("PaymentPlanId")
                        .HasColumnType("integer");

                    b.Property<decimal>("PenaltyFeeInduced")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("TimeStampApproved")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("UpFrontAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("PaymentPlanId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("TimeStampRegistered")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.PaymentHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<decimal>("NewBalnce")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("PaymentId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("PreviousBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("TimeStampRegistered")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("PaymentId");

                    b.ToTable("PaymentHistories");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.PaymentPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("PlanName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlanType")
                        .HasColumnType("integer");

                    b.Property<int>("TenureInMonths")
                        .HasColumnType("integer");

                    b.Property<double>("UpFrontRate")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("PaymentPlans");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("ActualPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<List<string>>("AvailableColours")
                        .HasColumnType("text[]");

                    b.Property<List<string>>("AvailableSizes")
                        .HasColumnType("text[]");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("ProductState")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<NpgsqlTsVector>("SearchVector")
                        .HasColumnType("tsvector");

                    b.Property<long>("SubCategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("TimeStampCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("TimeStampModified")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("SearchVector")
                        .HasAnnotation("Npgsql:IndexMethod", "GIN");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("Name", "Description", "Model");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.ProductImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<bool>("IsCoverImage")
                        .HasColumnType("boolean");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.ProductPaymentPlan", b =>
                {
                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("PaymentPlanId")
                        .HasColumnType("integer");

                    b.Property<string>("PaymentPlanName")
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .HasColumnType("text");

                    b.HasKey("ProductId", "PaymentPlanId");

                    b.HasIndex("PaymentPlanId");

                    b.ToTable("ProductPaymentPlan");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.SubCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.Address", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.AddressDetails", "HomeAddress")
                        .WithMany()
                        .HasForeignKey("HomeAddressId");

                    b.HasOne("BorrowToOwn.Data.Models.AddressDetails", "OfficeAddress")
                        .WithMany()
                        .HasForeignKey("OfficeAddressId");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.AppUser", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.AppUserBankStatement", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.AppUser", "AppUser")
                        .WithMany("BankStatements")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.Card", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.AppUser", "AppUser")
                        .WithMany("Cards")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.Comment", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.Order", null)
                        .WithMany("ApprovalComments")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.IdentityDocument", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.AppUser", "AppUser")
                        .WithMany("IdentityDocuments")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.Order", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.AppUser", "AppUser")
                        .WithMany("Orders")
                        .HasForeignKey("AppUserId");

                    b.HasOne("BorrowToOwn.Data.Models.PaymentPlan", "PaymentPlan")
                        .WithMany()
                        .HasForeignKey("PaymentPlanId");

                    b.HasOne("BorrowToOwn.Data.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.Payment", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.AppUser", null)
                        .WithMany("Payments")
                        .HasForeignKey("AppUserId");

                    b.HasOne("BorrowToOwn.Data.Models.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.PaymentHistory", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.AppUser", null)
                        .WithMany("PaymentHistories")
                        .HasForeignKey("AppUserId");

                    b.HasOne("BorrowToOwn.Data.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.Product", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.SubCategory", "ProductSubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.ProductImage", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.ProductPaymentPlan", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.PaymentPlan", "PaymentPlan")
                        .WithMany("ProductsAssociatedWith")
                        .HasForeignKey("PaymentPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BorrowToOwn.Data.Models.Product", "Product")
                        .WithMany("AllowedPaymentPlans")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BorrowToOwn.Data.Models.SubCategory", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("BorrowToOwn.Data.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.AppUser", null)
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

                    b.HasOne("BorrowToOwn.Data.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BorrowToOwn.Data.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
