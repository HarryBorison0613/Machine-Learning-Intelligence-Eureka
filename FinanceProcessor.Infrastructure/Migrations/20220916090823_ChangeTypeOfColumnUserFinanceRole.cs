using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceProcessor.Infrastructure.Migrations
{
    public partial class ChangeTypeOfColumnUserFinanceRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FinanceRole_UserFinanceRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FinanceRole");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserFinanceRoleId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserFinanceRoleId",
                table: "AspNetUsers",
                newName: "UserFinanceRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserFinanceRole",
                table: "AspNetUsers",
                newName: "UserFinanceRoleId");

            migrationBuilder.CreateTable(
                name: "FinanceRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserFinanceRoleId",
                table: "AspNetUsers",
                column: "UserFinanceRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FinanceRole_UserFinanceRoleId",
                table: "AspNetUsers",
                column: "UserFinanceRoleId",
                principalTable: "FinanceRole",
                principalColumn: "Id");
        }
    }
}
