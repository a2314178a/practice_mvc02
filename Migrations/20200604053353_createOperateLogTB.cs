using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace practice_mvc02.Migrations
{
    public partial class createOperateLogTB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "operateLogs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    operateID = table.Column<int>(nullable: false),
                    employeeID = table.Column<int>(nullable: false),
                    active = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    createTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operateLogs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operateLogs");
        }
    }
}
