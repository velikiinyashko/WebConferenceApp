﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebConferenceApp.Models;

namespace WebConferenceApp.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20180221024940_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("WebConferenceApp.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int?>("RoleId");

                    b.Property<string>("SecondName");

                    b.Property<string>("SurName");

                    b.Property<int?>("TypeAccountId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RoleId");

                    b.HasIndex("TypeAccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("WebConferenceApp.Models.AccountTags", b =>
                {
                    b.Property<int?>("AccountId");

                    b.Property<int?>("TagsId");

                    b.HasKey("AccountId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("AccountTags");
                });

            modelBuilder.Entity("WebConferenceApp.Models.Avatar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<string>("Path");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Avatars");
                });

            modelBuilder.Entity("WebConferenceApp.Models.Billing.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<double>("Balance")
                        .HasColumnType("numeric(18,4)");

                    b.Property<DateTime>("CteateTime");

                    b.Property<Guid>("Uid");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("WebConferenceApp.Models.Billing.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContractId");

                    b.Property<int?>("PaymentTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("WebConferenceApp.Models.Billing.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("WebConferenceApp.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<int>("Inn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Companys");
                });

            modelBuilder.Entity("WebConferenceApp.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebConferenceApp.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<DateTime>("BegTime");

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Name");

                    b.Property<int?>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("StatusId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("WebConferenceApp.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("WebConferenceApp.Models.Tags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("WebConferenceApp.Models.TypeAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TypeAccounts");
                });

            modelBuilder.Entity("WebConferenceApp.Models.Account", b =>
                {
                    b.HasOne("WebConferenceApp.Models.Company", "Company")
                        .WithMany("Accounts")
                        .HasForeignKey("CompanyId");

                    b.HasOne("WebConferenceApp.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("WebConferenceApp.Models.TypeAccount", "TypeAccount")
                        .WithMany("Accounts")
                        .HasForeignKey("TypeAccountId");
                });

            modelBuilder.Entity("WebConferenceApp.Models.AccountTags", b =>
                {
                    b.HasOne("WebConferenceApp.Models.Account", "Account")
                        .WithMany("AccountTags")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebConferenceApp.Models.Tags", "Tags")
                        .WithMany("AccountTags")
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebConferenceApp.Models.Avatar", b =>
                {
                    b.HasOne("WebConferenceApp.Models.Account", "Account")
                        .WithOne("Avatar")
                        .HasForeignKey("WebConferenceApp.Models.Avatar", "AccountId");
                });

            modelBuilder.Entity("WebConferenceApp.Models.Billing.Contract", b =>
                {
                    b.HasOne("WebConferenceApp.Models.Account", "Account")
                        .WithOne("Contract")
                        .HasForeignKey("WebConferenceApp.Models.Billing.Contract", "AccountId");
                });

            modelBuilder.Entity("WebConferenceApp.Models.Billing.Payment", b =>
                {
                    b.HasOne("WebConferenceApp.Models.Billing.Contract")
                        .WithMany("Payments")
                        .HasForeignKey("ContractId");

                    b.HasOne("WebConferenceApp.Models.Billing.PaymentType")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentTypeId");
                });

            modelBuilder.Entity("WebConferenceApp.Models.Room", b =>
                {
                    b.HasOne("WebConferenceApp.Models.Account", "Account")
                        .WithMany("Rooms")
                        .HasForeignKey("AccountId");

                    b.HasOne("WebConferenceApp.Models.Status", "Status")
                        .WithMany("Rooms")
                        .HasForeignKey("StatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
