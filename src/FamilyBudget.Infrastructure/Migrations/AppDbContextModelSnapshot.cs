﻿// <auto-generated />
using System;
using FamilyBudget.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FamilyBudget.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.5.22302.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FamilyBudget.Domain.Entities.Expenditure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FinancialPeriodId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PlannedExpenditureId")
                        .HasColumnType("integer");

                    b.Property<decimal>("PlannedToSpendValue")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SpentValue")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("FinancialPeriodId");

                    b.HasIndex("PlannedExpenditureId")
                        .IsUnique();

                    b.ToTable("Expenditures", (string)null);
                });

            modelBuilder.Entity("FamilyBudget.Domain.Entities.FinancialPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("PeriodBegin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("PeriodEnd")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("FinancialPeriods");
                });

            modelBuilder.Entity("FamilyBudget.Domain.Entities.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FinancialPeriodId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FinancialPeriodId");

                    b.ToTable("Incomes", (string)null);
                });

            modelBuilder.Entity("FamilyBudget.Domain.Entities.PlannedExpenditure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Period")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("PlannedExpenditures", (string)null);
                });

            modelBuilder.Entity("FamilyBudget.Domain.Entities.Expenditure", b =>
                {
                    b.HasOne("FamilyBudget.Domain.Entities.FinancialPeriod", "FinancialPeriod")
                        .WithMany("Expenditures")
                        .HasForeignKey("FinancialPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FamilyBudget.Domain.Entities.PlannedExpenditure", "PlannedExpenditure")
                        .WithOne("Expenditure")
                        .HasForeignKey("FamilyBudget.Domain.Entities.Expenditure", "PlannedExpenditureId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("FinancialPeriod");

                    b.Navigation("PlannedExpenditure");
                });

            modelBuilder.Entity("FamilyBudget.Domain.Entities.Income", b =>
                {
                    b.HasOne("FamilyBudget.Domain.Entities.FinancialPeriod", "FinancialPeriod")
                        .WithMany("Incomes")
                        .HasForeignKey("FinancialPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinancialPeriod");
                });

            modelBuilder.Entity("FamilyBudget.Domain.Entities.FinancialPeriod", b =>
                {
                    b.Navigation("Expenditures");

                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("FamilyBudget.Domain.Entities.PlannedExpenditure", b =>
                {
                    b.Navigation("Expenditure")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
