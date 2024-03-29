﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tadbir.Ins.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlterCoverageConstValueInInsuranceCoverageTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CoverageConstValue",
                schema: "InsBaseInfo",
                table: "InsuranceCoverages",
                type: "decimal(10,4)",
                precision: 10,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CoverageConstValue",
                schema: "InsBaseInfo",
                table: "InsuranceCoverages",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,4)",
                oldPrecision: 10,
                oldScale: 4);
        }
    }
}
