using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceProcessor.Infrastructure.Migrations
{
    public partial class deleteCalumnsFromSubscriptionRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "SubscriptionRates");

            migrationBuilder.DropColumn(
                name: "TotalPeriod",
                table: "SubscriptionRates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Period",
                table: "SubscriptionRates",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalPeriod",
                table: "SubscriptionRates",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
