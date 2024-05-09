﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using sda_onsite_2_csharp_backend_teamwork.src.Database;
using sda_onsite_2_csharp_backend_teamwork.src.Enums;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "role", new[] { "customer", "admin" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "status", new[] { "pending", "approved", "canceled", "preparing", "shipped", "delivered" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<int>("Zip_code")
                        .HasColumnType("integer")
                        .HasColumnName("zip_code");

                    b.HasKey("Id")
                        .HasName("pk_addresses");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_addresses_user_id");

                    b.ToTable("addresses", (string)null);
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("address_id");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("order_date");

                    b.Property<Status>("Status")
                        .HasColumnType("status")
                        .HasColumnName("status");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision")
                        .HasColumnName("total_price");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("AddressId")
                        .HasDatabaseName("ix_orders_address_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_orders_user_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("double precision")
                        .HasColumnName("unit_price");

                    b.HasKey("Id")
                        .HasName("pk_order_items");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_order_items_order_id");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_order_items_product_id");

                    b.ToTable("order_items", (string)null);
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_products_category_id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<int>("Phone")
                        .HasColumnType("integer")
                        .HasColumnName("phone");

                    b.Property<Role>("Role")
                        .HasColumnType("role")
                        .HasColumnName("role");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.Address", b =>
                {
                    b.HasOne("sda_onsite_2_csharp_backend_teamwork.src.Entity.User", null)
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_addresses_users_user_id");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.Order", b =>
                {
                    b.HasOne("sda_onsite_2_csharp_backend_teamwork.src.Entity.Address", null)
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_addresses_address_id");

                    b.HasOne("sda_onsite_2_csharp_backend_teamwork.src.Entity.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_users_user_id");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.OrderItem", b =>
                {
                    b.HasOne("sda_onsite_2_csharp_backend_teamwork.src.Entity.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_items_orders_order_id");

                    b.HasOne("sda_onsite_2_csharp_backend_teamwork.src.Entity.Product", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_items_products_product_id");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.Product", b =>
                {
                    b.HasOne("sda_onsite_2_csharp_backend_teamwork.src.Entity.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_categories_category_id");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.Address", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.Product", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entity.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
