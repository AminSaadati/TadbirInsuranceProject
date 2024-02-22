﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tadbir.Ins.Persistence.DataBaseContext;

#nullable disable

namespace Tadbir.Ins.Persistence.Migrations
{
    [DbContext(typeof(TadbirInsuranceContext))]
    [Migration("20240222115715_AlterTotalAmountPropertyTbl")]
    partial class AlterTotalAmountPropertyTbl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tadbir.Ins.Domain.Models.InsuranceCoverage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CoverageConstValue")
                        .HasPrecision(10, 4)
                        .HasColumnType("decimal(10,4)");

                    b.Property<string>("CoverageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CoverageTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MaxAmount")
                        .HasColumnType("int");

                    b.Property<int>("MinAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("InsuranceCoverages", "InsBaseInfo");
                });

            modelBuilder.Entity("Tadbir.Ins.Domain.Models.InsuranceRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(18, 8)
                        .HasColumnType("decimal(18,8)");

                    b.HasKey("Id");

                    b.ToTable("InsuranceRequests", "InsReq");
                });

            modelBuilder.Entity("Tadbir.Ins.Domain.Models.InsuranceRequestCoverage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("InsuranceCoverageId")
                        .HasColumnType("int");

                    b.Property<Guid>("InsuranceRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InsuranceCoverageId");

                    b.HasIndex("InsuranceRequestId");

                    b.ToTable("InsuranceRequestCoverages", "InsReq");
                });

            modelBuilder.Entity("Tadbir.Ins.Domain.Models.InsuranceRequestCoverage", b =>
                {
                    b.HasOne("Tadbir.Ins.Domain.Models.InsuranceCoverage", "InsuranceCoverage")
                        .WithMany()
                        .HasForeignKey("InsuranceCoverageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tadbir.Ins.Domain.Models.InsuranceRequest", "InsuranceRequest")
                        .WithMany("InsuranceRequestCoverages")
                        .HasForeignKey("InsuranceRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InsuranceCoverage");

                    b.Navigation("InsuranceRequest");
                });

            modelBuilder.Entity("Tadbir.Ins.Domain.Models.InsuranceRequest", b =>
                {
                    b.Navigation("InsuranceRequestCoverages");
                });
#pragma warning restore 612, 618
        }
    }
}
