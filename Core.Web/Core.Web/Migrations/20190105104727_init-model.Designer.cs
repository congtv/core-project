﻿// <auto-generated />
using System;
using Core.Web.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Web.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20190105104727_init-model")]
    partial class initmodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Core.Model.Models.ContactDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(250);

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<double?>("Lat");

                    b.Property<double?>("Lng");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Other");

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("Website")
                        .HasMaxLength(250);

                    b.HasKey("ID");

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("Core.Model.Models.Error", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("ID");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("Core.Model.Models.Feedback", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("Message")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Status");

                    b.HasKey("ID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Core.Model.Models.Footer", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Footers");
                });

            modelBuilder.Entity("Core.Model.Models.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DisplayOrder");

                    b.Property<int>("GroupID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("Target")
                        .HasMaxLength(10);

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Core.Model.Models.MenuGroup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("MenuGroups");
                });

            modelBuilder.Entity("Core.Model.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("CustomerMessage")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("CustomerMobile")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("PaymentMethod")
                        .HasMaxLength(256);

                    b.Property<string>("PaymentStatus");

                    b.Property<bool>("Status");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Core.Model.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderID");

                    b.Property<int>("ProductID");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Core.Model.Models.Page", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ID");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Core.Model.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("CategoryID");

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool?>("HomeFlag");

                    b.Property<bool?>("HotFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(256);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("ViewCount");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Core.Model.Models.PostCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int?>("DisplayOrder");

                    b.Property<bool?>("HomeFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(256);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int?>("ParentID");

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ID");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("Core.Model.Models.PostTag", b =>
                {
                    b.Property<string>("TagID")
                        .HasMaxLength(50);

                    b.Property<int>("PostID");

                    b.HasKey("TagID", "PostID");

                    b.HasAlternateKey("PostID", "TagID");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("Core.Model.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("CategoryID");

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool?>("HomeFlag");

                    b.Property<bool?>("HotFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(256);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(256);

                    b.Property<string>("MoreImages")
                        .HasColumnType("json");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<decimal>("OriginalPrice");

                    b.Property<decimal>("Price");

                    b.Property<decimal?>("PromotionPrice");

                    b.Property<int>("Quantity");

                    b.Property<bool>("Status");

                    b.Property<string>("Tags");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("ViewCount");

                    b.Property<int?>("Warranty");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Core.Model.Models.ProductCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int?>("DisplayOrder");

                    b.Property<bool?>("HomeFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(256);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int?>("ParentID");

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ID");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Core.Model.Models.ProductTag", b =>
                {
                    b.Property<string>("TagID")
                        .HasMaxLength(50);

                    b.Property<int>("ProductID");

                    b.HasKey("TagID", "ProductID");

                    b.HasAlternateKey("ProductID", "TagID");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("Core.Model.Models.Slide", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<int?>("DisplayOrder");

                    b.Property<string>("Image")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("Status");

                    b.Property<string>("Url")
                        .HasMaxLength(256);

                    b.HasKey("ID");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("Core.Model.Models.Tag", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Core.Model.Models.VisitorStatistic", b =>
                {
                    b.Property<byte[]>("ID")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("IPAddress")
                        .HasMaxLength(50);

                    b.Property<DateTime>("VisitedDate");

                    b.HasKey("ID");

                    b.ToTable("VisitorStatistics");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Core.Model.Models.Menu", b =>
                {
                    b.HasOne("Core.Model.Models.MenuGroup", "MenuGroup")
                        .WithMany("Menus")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Model.Models.OrderDetail", b =>
                {
                    b.HasOne("Core.Model.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Model.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Model.Models.Post", b =>
                {
                    b.HasOne("Core.Model.Models.PostCategory", "PostCategory")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Model.Models.PostTag", b =>
                {
                    b.HasOne("Core.Model.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Model.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Model.Models.Product", b =>
                {
                    b.HasOne("Core.Model.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Model.Models.ProductTag", b =>
                {
                    b.HasOne("Core.Model.Models.Product", "Product")
                        .WithMany("ProductTags")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Model.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}