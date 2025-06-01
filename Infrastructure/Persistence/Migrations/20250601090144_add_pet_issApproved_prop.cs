using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_pet_issApproved_prop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AdoptionRequests_PetId",
                table: "AdoptionRequests");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_PetId_SenderId",
                table: "AdoptionRequests",
                columns: new[] { "PetId", "SenderId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AdoptionRequests_PetId_SenderId",
                table: "AdoptionRequests");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Pets");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_PetId",
                table: "AdoptionRequests",
                column: "PetId");
        }
    }
}
