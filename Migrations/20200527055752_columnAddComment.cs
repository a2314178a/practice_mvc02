using Microsoft.EntityFrameworkCore.Migrations;

namespace practice_mvc02.Migrations
{
    public partial class columnAddComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "totalTime",
                table: "worktimetotals",
                nullable: false,
                comment: "unit : minute",
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "specialdate",
                nullable: false,
                comment: "1:休假 2:上班",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "warnStatus",
                table: "punchlogwarns",
                nullable: false,
                comment: "0:未處理 1:已處理 2:忽略",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "punchStatus",
                table: "punchcardlogs",
                nullable: false,
                comment: "0x01:正常 0x02:遲到 0x04:早退 0x08:加班 0x10:缺卡 0x20:曠職 0x40:請假",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "read",
                table: "msgsendreceive",
                type: "int(1)",
                nullable: false,
                comment: "0:未讀 1:已讀",
                oldClrType: typeof(int),
                oldType: "int(1)");

            migrationBuilder.AlterColumn<byte>(
                name: "unit",
                table: "leaveofficeapplys",
                nullable: false,
                comment: "1:全天 2:半天 3:小時",
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AlterColumn<int>(
                name: "applyStatus",
                table: "leaveofficeapplys",
                nullable: false,
                comment: "0:申請中 1:通過 2:沒通過",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "timeUnit",
                table: "leavenames",
                nullable: false,
                comment: "1:全天 2:半天 3:小時",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "principalID",
                table: "employeeprincipals",
                nullable: false,
                comment: "主管ID",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "principalAgentID",
                table: "employeeprincipals",
                nullable: false,
                comment: "主管代理人ID",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "employeeID",
                table: "employeeprincipals",
                nullable: false,
                comment: "員工ID",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "seniority",
                table: "annualleaverule",
                nullable: false,
                comment: "unit:year",
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "value",
                table: "annualdaysoffset",
                nullable: false,
                comment: "unit:hour",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "accLV",
                table: "accounts",
                nullable: false,
                comment: "1職員2單位主管3部門主管4處長廠長5協理6總經理7董事",
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "totalTime",
                table: "worktimetotals",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldComment: "unit : minute");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "specialdate",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldComment: "1:休假 2:上班");

            migrationBuilder.AlterColumn<int>(
                name: "warnStatus",
                table: "punchlogwarns",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldComment: "0:未處理 1:已處理 2:忽略");

            migrationBuilder.AlterColumn<int>(
                name: "punchStatus",
                table: "punchcardlogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldComment: "0x01:正常 0x02:遲到 0x04:早退 0x08:加班 0x10:缺卡 0x20:曠職 0x40:請假");

            migrationBuilder.AlterColumn<int>(
                name: "read",
                table: "msgsendreceive",
                type: "int(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(1)",
                oldComment: "0:未讀 1:已讀");

            migrationBuilder.AlterColumn<byte>(
                name: "unit",
                table: "leaveofficeapplys",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(byte),
                oldComment: "1:全天 2:半天 3:小時");

            migrationBuilder.AlterColumn<int>(
                name: "applyStatus",
                table: "leaveofficeapplys",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldComment: "0:申請中 1:通過 2:沒通過");

            migrationBuilder.AlterColumn<int>(
                name: "timeUnit",
                table: "leavenames",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldComment: "1:全天 2:半天 3:小時");

            migrationBuilder.AlterColumn<int>(
                name: "principalID",
                table: "employeeprincipals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldComment: "主管ID");

            migrationBuilder.AlterColumn<int>(
                name: "principalAgentID",
                table: "employeeprincipals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldComment: "主管代理人ID");

            migrationBuilder.AlterColumn<int>(
                name: "employeeID",
                table: "employeeprincipals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldComment: "員工ID");

            migrationBuilder.AlterColumn<float>(
                name: "seniority",
                table: "annualleaverule",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldComment: "unit:year");

            migrationBuilder.AlterColumn<int>(
                name: "value",
                table: "annualdaysoffset",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldComment: "unit:hour");

            migrationBuilder.AlterColumn<int>(
                name: "accLV",
                table: "accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldComment: "1職員2單位主管3部門主管4處長廠長5協理6總經理7董事");
        }
    }
}
