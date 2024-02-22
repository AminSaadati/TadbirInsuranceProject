using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tadbir.Ins.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IntDb_AddandConfigThreeTableUnderInsuranceRequestCoverage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "InsBaseInfo");

            migrationBuilder.EnsureSchema(
                name: "InsReq");

            migrationBuilder.CreateTable(
                name: "InsuranceCoverages",
                schema: "InsBaseInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MinAmount = table.Column<int>(type: "int", nullable: false),
                    MaxAmount = table.Column<int>(type: "int", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCoverages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceRequests",
                schema: "InsReq",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceRequestCoverages",
                schema: "InsReq",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceCoverageId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequestCoverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceRequestCoverages_InsuranceCoverages_InsuranceCoverageId",
                        column: x => x.InsuranceCoverageId,
                        principalSchema: "InsBaseInfo",
                        principalTable: "InsuranceCoverages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceRequestCoverages_InsuranceRequests_InsuranceRequestId",
                        column: x => x.InsuranceRequestId,
                        principalSchema: "InsReq",
                        principalTable: "InsuranceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequestCoverages_InsuranceCoverageId",
                schema: "InsReq",
                table: "InsuranceRequestCoverages",
                column: "InsuranceCoverageId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequestCoverages_InsuranceRequestId",
                schema: "InsReq",
                table: "InsuranceRequestCoverages",
                column: "InsuranceRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceRequestCoverages",
                schema: "InsReq");

            migrationBuilder.DropTable(
                name: "InsuranceCoverages",
                schema: "InsBaseInfo");

            migrationBuilder.DropTable(
                name: "InsuranceRequests",
                schema: "InsReq");
        }
    }
}
