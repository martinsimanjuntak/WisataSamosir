﻿// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API.Model.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(25) CHARACTER SET utf8mb4")
                        .HasMaxLength(25);

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<int>("Role_id")
                        .HasColumnType("int");

                    b.Property<int>("Status_id")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("varchar(25) CHARACTER SET utf8mb4")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("Role_id");

                    b.HasIndex("Status_id");

                    b.ToTable("tb_account");
                });

            modelBuilder.Entity("API.Model.Harbor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Harbor_Name")
                        .HasColumnName("pelabuhan_name")
                        .HasColumnType("varchar(25) CHARACTER SET utf8mb4")
                        .HasMaxLength(25);

                    b.Property<double>("Latitude")
                        .HasColumnName("latitude")
                        .HasColumnType("double");

                    b.Property<string>("Location")
                        .HasColumnName("location")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<double>("Longitude")
                        .HasColumnName("longitude")
                        .HasColumnType("double");

                    b.Property<int?>("Route_idId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Route_idId");

                    b.ToTable("tb_harbor");
                });

            modelBuilder.Entity("API.Model.PortRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<int>("Harbor_end")
                        .HasColumnName("harbor_end")
                        .HasColumnType("int")
                        .HasMaxLength(25);

                    b.Property<int>("Harbor_start")
                        .HasColumnName("harbor_start")
                        .HasColumnType("int")
                        .HasMaxLength(25);

                    b.Property<string>("RouteName")
                        .HasColumnName("route_name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("tb_port_route");
                });

            modelBuilder.Entity("API.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Role_Name")
                        .IsRequired()
                        .HasColumnName("role_name")
                        .HasColumnType("enum('SUPERADMIN','ADMIN')");

                    b.HasKey("Id");

                    b.ToTable("tb_role");
                });

            modelBuilder.Entity("API.Model.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<int>("PortRoute_id")
                        .HasColumnType("int");

                    b.Property<string>("Session")
                        .HasColumnName("session")
                        .HasColumnType("varchar(25) CHARACTER SET utf8mb4")
                        .HasMaxLength(25);

                    b.Property<TimeSpan>("Time")
                        .HasColumnName("time")
                        .HasColumnType("time(6)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("PortRoute_id");

                    b.ToTable("tb_schedule");
                });

            modelBuilder.Entity("API.Model.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Status_Name")
                        .IsRequired()
                        .HasColumnName("status_name")
                        .HasColumnType("enum('ACTIVE','EXPIRED')");

                    b.HasKey("Id");

                    b.ToTable("tb_status");
                });

            modelBuilder.Entity("API.Model.TouristAttraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Location")
                        .HasColumnName("location")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(25) CHARACTER SET utf8mb4")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("tb_tourist_Actraction");
                });

            modelBuilder.Entity("API.Model.Account", b =>
                {
                    b.HasOne("API.Model.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("Role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.Status", "Status")
                        .WithMany("Accounts")
                        .HasForeignKey("Status_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Model.Harbor", b =>
                {
                    b.HasOne("API.Model.PortRoute", "Route_id")
                        .WithMany()
                        .HasForeignKey("Route_idId");
                });

            modelBuilder.Entity("API.Model.Schedule", b =>
                {
                    b.HasOne("API.Model.PortRoute", "PortRoute")
                        .WithMany("Schedules")
                        .HasForeignKey("PortRoute_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
