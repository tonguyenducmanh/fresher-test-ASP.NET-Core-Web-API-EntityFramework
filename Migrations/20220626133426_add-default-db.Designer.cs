﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fresher_test_ASP.NET_Core_Web_API.Models;

#nullable disable

namespace fresher_test_ASP.NET_Core_Web_API.Migrations
{
    [DbContext(typeof(customerDatabaseContext))]
    [Migration("20220626133426_add-default-db")]
    partial class adddefaultdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("fresher_test_ASP.NET_Core_Web_API.Models.customer", b =>
                {
                    b.Property<string>("_id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("anh")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("doanhthu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("dtcoquan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("dtdidong")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("dungchung")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("emailcanhan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("emailcoquan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("hovadem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("linhvuc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("loaihinh")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("masothue")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("mota")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("motainganhang")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nganhnghe")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ngaythanhlap")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nguongoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phongban")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phuongxa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("quanhuyen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("quocgia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("sonha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("taikhoannganhang")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ten")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("tinhthanhpho")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("tochuc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("xungho")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("zalo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("_id");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("fresher_test_ASP.NET_Core_Web_API.Models.history", b =>
                {
                    b.Property<string>("historyId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("customerId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("historyContent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("historyId");

                    b.HasIndex("customerId");

                    b.ToTable("history");
                });

            modelBuilder.Entity("fresher_test_ASP.NET_Core_Web_API.Models.loaitiemnang", b =>
                {
                    b.Property<string>("loaitiemnangId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("customerId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("loaitiemnangContent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("loaitiemnangId");

                    b.HasIndex("customerId");

                    b.ToTable("loaitiemnang");
                });

            modelBuilder.Entity("fresher_test_ASP.NET_Core_Web_API.Models.the", b =>
                {
                    b.Property<string>("theId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("customerId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("theContent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("theId");

                    b.HasIndex("customerId");

                    b.ToTable("the");
                });

            modelBuilder.Entity("fresher_test_ASP.NET_Core_Web_API.Models.history", b =>
                {
                    b.HasOne("fresher_test_ASP.NET_Core_Web_API.Models.customer", "customer")
                        .WithMany("history")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("fresher_test_ASP.NET_Core_Web_API.Models.loaitiemnang", b =>
                {
                    b.HasOne("fresher_test_ASP.NET_Core_Web_API.Models.customer", "customer")
                        .WithMany("loaitiemnang")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("fresher_test_ASP.NET_Core_Web_API.Models.the", b =>
                {
                    b.HasOne("fresher_test_ASP.NET_Core_Web_API.Models.customer", "customer")
                        .WithMany("the")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("fresher_test_ASP.NET_Core_Web_API.Models.customer", b =>
                {
                    b.Navigation("history");

                    b.Navigation("loaitiemnang");

                    b.Navigation("the");
                });
#pragma warning restore 612, 618
        }
    }
}