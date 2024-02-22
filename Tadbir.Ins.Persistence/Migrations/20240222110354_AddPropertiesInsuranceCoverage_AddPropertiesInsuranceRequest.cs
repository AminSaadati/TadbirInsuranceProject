using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tadbir.Ins.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesInsuranceCoverage_AddPropertiesInsuranceRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalAmount",
                schema: "InsReq",
                table: "InsuranceRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CoverageConstValue",
                schema: "InsBaseInfo",
                table: "InsuranceCoverages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CoverageTypeId",
                schema: "InsBaseInfo",
                table: "InsuranceCoverages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                schema: "InsReq",
                table: "InsuranceRequests");

            migrationBuilder.DropColumn(
                name: "CoverageConstValue",
                schema: "InsBaseInfo",
                table: "InsuranceCoverages");

            migrationBuilder.DropColumn(
                name: "CoverageTypeId",
                schema: "InsBaseInfo",
                table: "InsuranceCoverages");
        }
    }
}
