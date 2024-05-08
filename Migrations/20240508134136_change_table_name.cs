using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class change_table_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogames_SoftwareHouses_SoftwareHouseId",
                table: "videogames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoftwareHouses",
                table: "SoftwareHouses");

            migrationBuilder.RenameTable(
                name: "SoftwareHouses",
                newName: "software_house");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "videogames",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "software_house",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_software_house",
                table: "software_house",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_videogames_Name",
                table: "videogames",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_software_house_Name",
                table: "software_house",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_videogames_software_house_SoftwareHouseId",
                table: "videogames",
                column: "SoftwareHouseId",
                principalTable: "software_house",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogames_software_house_SoftwareHouseId",
                table: "videogames");

            migrationBuilder.DropIndex(
                name: "IX_videogames_Name",
                table: "videogames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_software_house",
                table: "software_house");

            migrationBuilder.DropIndex(
                name: "IX_software_house_Name",
                table: "software_house");

            migrationBuilder.RenameTable(
                name: "software_house",
                newName: "SoftwareHouses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "videogames",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SoftwareHouses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoftwareHouses",
                table: "SoftwareHouses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_videogames_SoftwareHouses_SoftwareHouseId",
                table: "videogames",
                column: "SoftwareHouseId",
                principalTable: "SoftwareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
