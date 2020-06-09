using Microsoft.EntityFrameworkCore.Migrations;

namespace practice_mvc02.Migrations
{
    public partial class emAnnualLeaveAddlastOpID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lastOperaAccID",
                table: "employeeannualleaves",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastOperaAccID",
                table: "employeeannualleaves");
        }
    }
}
