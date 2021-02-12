﻿// <auto-generated />
using System;
using BudgetApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BudgetApp.Migrations
{
    [DbContext(typeof(BudgetContext))]
    [Migration("20210212021127_deptrepayment")]
    partial class deptrepayment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("BudgetApp.Models.RecurringTransaction", b =>
                {
                    b.Property<int>("RecurringTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RecurringDay")
                        .HasColumnType("int");

                    b.Property<string>("RecurringType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RecurringTransactionId");

                    b.ToTable("RecurringTransactions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("RecurringTransaction");
                });

            modelBuilder.Entity("BudgetApp.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CheckNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IncomeItemRecurringTransactionId")
                        .HasColumnType("int");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecurringTransactionId")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("IncomeItemRecurringTransactionId");

                    b.HasIndex("RecurringTransactionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BudgetApp.Models.DebtRepayment", b =>
                {
                    b.HasBaseType("BudgetApp.Models.RecurringTransaction");

                    b.Property<decimal>("Interest")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Limit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Minimum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PastDue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("DebtRepayment");
                });

            modelBuilder.Entity("BudgetApp.Models.IncomeItem", b =>
                {
                    b.HasBaseType("BudgetApp.Models.RecurringTransaction");

                    b.HasDiscriminator().HasValue("IncomeItem");
                });

            modelBuilder.Entity("BudgetApp.Models.Transaction", b =>
                {
                    b.HasOne("BudgetApp.Models.IncomeItem", null)
                        .WithMany("Transactions")
                        .HasForeignKey("IncomeItemRecurringTransactionId");

                    b.HasOne("BudgetApp.Models.RecurringTransaction", "RecurringTransaction")
                        .WithMany()
                        .HasForeignKey("RecurringTransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecurringTransaction");
                });

            modelBuilder.Entity("BudgetApp.Models.IncomeItem", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
