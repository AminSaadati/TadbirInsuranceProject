using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tadbir.Ins.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlterTotalAmountPropertyTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                schema: "InsReq",
                table: "InsuranceRequests",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalAmount",
                schema: "InsReq",
                table: "InsuranceRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);
        }
    }
}
