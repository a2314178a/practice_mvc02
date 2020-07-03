using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace practice_mvc02.Migrations
{
    public partial class workTimeRuleChgColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lateTime",
                table: "worktimerules");

            migrationBuilder.AddColumn<int>(
                name: "elasticityMin",
                table: "worktimerules",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "elasticityMin",
                table: "worktimerules");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "lateTime",
                table: "worktimerules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
