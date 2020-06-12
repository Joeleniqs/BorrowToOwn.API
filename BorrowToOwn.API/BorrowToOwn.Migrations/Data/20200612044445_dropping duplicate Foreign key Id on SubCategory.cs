using Microsoft.EntityFrameworkCore.Migrations;

namespace BorrowToOwn.API.BorrowToOwn.Migrations.Data
{
    public partial class droppingduplicateForeignkeyIdonSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId1",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_CategoryId1",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "SubCategories");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SubCategories",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories");

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "SubCategories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "SubCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId1",
                table: "SubCategories",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId1",
                table: "SubCategories",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
