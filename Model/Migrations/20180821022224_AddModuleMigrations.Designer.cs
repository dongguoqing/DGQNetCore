﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace Model.Migrations
{
    [DbContext(typeof(ApiDBContent))]
    [Migration("20180821022224_AddModuleMigrations")]
    partial class AddModuleMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Module", b =>
                {
                    b.Property<int>("ModuleCode")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsBigTable");

                    b.Property<int>("LimitCount");

                    b.Property<string>("ModuleBrief");

                    b.Property<string>("ModuleIcon");

                    b.Property<string>("ModuleIndex");

                    b.Property<int>("ModuleLevel");

                    b.Property<string>("ModuleName");

                    b.Property<int>("ModulePosition");

                    b.Property<int>("ModuleStatus");

                    b.Property<int>("ModuleType");

                    b.Property<string>("ModuleUrl");

                    b.Property<Guid>("UpperGuid");

                    b.Property<string>("UseActions");

                    b.HasKey("ModuleCode");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("Model.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<int>("Enable");

                    b.Property<string>("Name");

                    b.Property<string>("PassWord");

                    b.Property<int>("Sex");

                    b.Property<string>("Uid");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Model.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName");

                    b.Property<int?>("UserInfoId");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Model.UserRole", b =>
                {
                    b.HasOne("Model.UserInfo")
                        .WithMany("Role")
                        .HasForeignKey("UserInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
