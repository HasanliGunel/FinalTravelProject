using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BookNowMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookNow_Destinations_DestinationID",
                table: "BookNow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookNow",
                table: "BookNow");

            migrationBuilder.RenameTable(
                name: "BookNow",
                newName: "BookNows");

            migrationBuilder.RenameIndex(
                name: "IX_BookNow_DestinationID",
                table: "BookNows",
                newName: "IX_BookNows_DestinationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookNows",
                table: "BookNows",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookNows_Destinations_DestinationID",
                table: "BookNows",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookNows_Destinations_DestinationID",
                table: "BookNows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookNows",
                table: "BookNows");

            migrationBuilder.RenameTable(
                name: "BookNows",
                newName: "BookNow");

            migrationBuilder.RenameIndex(
                name: "IX_BookNows_DestinationID",
                table: "BookNow",
                newName: "IX_BookNow_DestinationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookNow",
                table: "BookNow",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookNow_Destinations_DestinationID",
                table: "BookNow",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
