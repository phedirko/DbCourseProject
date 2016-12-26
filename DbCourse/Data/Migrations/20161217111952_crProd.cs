using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbCourse.Data.Migrations
{
    public partial class crProd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Sum = table.Column<double>(nullable: false),
                    Years = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaxMonth = table.Column<int>(nullable: false),
                    MaxPercentage = table.Column<double>(nullable: false),
                    MaxSum = table.Column<double>(nullable: false),
                    MinMonth = table.Column<int>(nullable: false),
                    MinPercentage = table.Column<double>(nullable: false),
                    MinSumm = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditType", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "CreditTypeId",
                table: "Contract",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_CreditTypeId",
                table: "Contract",
                column: "CreditTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_CreditType_CreditTypeId",
                table: "Contract",
                column: "CreditTypeId",
                principalTable: "CreditType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_CreditType_CreditTypeId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_CreditTypeId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "CreditTypeId",
                table: "Contract");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "CreditType");
        }
    }
}
