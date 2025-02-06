using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeBlogFitness.BL.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "Eatings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eatings_FoodId",
                table: "Eatings",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eatings_Foods_FoodId",
                table: "Eatings",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eatings_Foods_FoodId",
                table: "Eatings");

            migrationBuilder.DropIndex(
                name: "IX_Eatings_FoodId",
                table: "Eatings");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Eatings");
        }
    }
}
