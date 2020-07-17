using Microsoft.EntityFrameworkCore.Migrations;

namespace practice_mvc02.Migrations
{
    public partial class annualOffsetValueChgFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "value",
                table: "annualdaysoffset",
                nullable: false,
                comment: "unit:hour",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "unit:hour");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "value",
                table: "annualdaysoffset",
                type: "int",
                nullable: false,
                comment: "unit:hour",
                oldClrType: typeof(float),
                oldComment: "unit:hour");
        }
    }
}
