using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vendingbackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialZalupa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "ManufacturedDate",
                table: "TradeApparatus",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufacturedDate",
                table: "TradeApparatus");
        }
    }
}
