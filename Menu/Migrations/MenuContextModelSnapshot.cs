﻿// <auto-generated />
using Menu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Menu.Migrations
{
    [DbContext(typeof(MenuContext))]
    partial class MenuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Menu.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BasePrice")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("MenuItemId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Menu.Models.MenuItemSize", b =>
                {
                    b.Property<int>("MenuItemSizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("MenuItemSizeId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("SizeId");

                    b.ToTable("MenuItemSize");
                });

            modelBuilder.Entity("Menu.Models.Size", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("SizeName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("SizePrice")
                        .HasColumnType("int");

                    b.HasKey("SizeId");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Menu.Models.MenuItemSize", b =>
                {
                    b.HasOne("Menu.Models.MenuItem", "MenuItem")
                        .WithMany("JoinEntities")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Menu.Models.Size", "Size")
                        .WithMany("JoinEntities")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Menu.Models.MenuItem", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("Menu.Models.Size", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
