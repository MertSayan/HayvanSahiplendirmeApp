using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_pet_and_petImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMAin",
                table: "PetImages");

            migrationBuilder.AddColumn<string>(
                name: "MainImageUrl",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImageUrl",
                table: "Pets");

            migrationBuilder.AddColumn<bool>(
                name: "IsMAin",
                table: "PetImages",
                type: "bit",
                nullable: true);
        }
    }
}
