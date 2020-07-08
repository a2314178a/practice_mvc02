using Microsoft.EntityFrameworkCore.Migrations;

namespace practice_mvc02.Migrations
{
    public partial class WTRuleDelUniqueAddType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_worktimerules_startTime_endTime",
                table: "worktimerules");

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "worktimerules",
                type: "int(1)",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "worktimerules");

            migrationBuilder.CreateIndex(
                name: "IX_worktimerules_startTime_endTime",
                table: "worktimerules",
                columns: new[] { "startTime", "endTime" },
                unique: true);
        }
    }
}
