using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddVisitsCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisitTime",
                table: "VisitorLogs",
                newName: "LastSeen");

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstVisit",
                table: "VisitorLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "VisitCount",
                table: "VisitorLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstVisit",
                table: "VisitorLogs");

            migrationBuilder.DropColumn(
                name: "VisitCount",
                table: "VisitorLogs");

            migrationBuilder.RenameColumn(
                name: "LastSeen",
                table: "VisitorLogs",
                newName: "VisitTime");
        }
    }
}
