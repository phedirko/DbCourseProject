using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbCourse.Data.Migrations
{
    public partial class binda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Client");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Client",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Client");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Client",
                nullable: false,
                defaultValue: 0);
        }
    }
}
