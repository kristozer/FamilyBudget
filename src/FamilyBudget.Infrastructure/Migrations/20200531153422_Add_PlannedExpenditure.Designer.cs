﻿// <auto-generated />
using System;
using FamilyBudget.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FamilyBudget.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200531153422_Add_PlannedExpenditure")]
    partial class Add_PlannedExpenditure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FamilyBudget.Domain.Entities.Expenditure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinancialPeriodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlannedExpenditureId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FinancialPeriodId");

                    b.HasIndex("PlannedExpenditureId")
                        .IsUnique()
                        .HasFilter("[PlannedExpenditureId] IS NOT NULL");

                    b.ToTable("Expenditures");
                });

            modelBuilder.Entity("FamilyBudget.Domain.Entities.FinancialPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PeriodBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PeriodEnd")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("FinancialPeriods");
                });

            modelBuilder.Entity("FamilyBudget.Domain.Entities.PlannedExpenditure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Period")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("PlannedExpenditures");
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
                });
#pragma warning restore 612, 618
        }
    }
}