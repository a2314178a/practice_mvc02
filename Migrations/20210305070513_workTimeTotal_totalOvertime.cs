using Microsoft.EntityFrameworkCore.Migrations;

namespace practice_mvc02.Migrations
{
    public partial class workTimeTotal_totalOvertime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "totalOvertime",
                table: "worktimetotals",
                nullable: false,
                defaultValue: 0,
                comment: "unit : minute");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalOvertime",
                table: "worktimetotals");
        }
    }
}
