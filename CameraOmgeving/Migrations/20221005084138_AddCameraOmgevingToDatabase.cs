using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraOmgeving.Migrations
{
    public partial class AddCameraOmgevingToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cameras_locations_locationID",
                table: "cameras");

            migrationBuilder.DropForeignKey(
                name: "FK_locations_Maps_mapId",
                table: "locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Users_userID",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profiles_ProfileID",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileID",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "Profiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "Maps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Maps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "mapId",
                table: "locations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "cameraID",
                table: "locations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "locationID",
                table: "cameras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_cameras_locations_locationID",
                table: "cameras",
                column: "locationID",
                principalTable: "locations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_locations_Maps_mapId",
                table: "locations",
                column: "mapId",
                principalTable: "Maps",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Users_userID",
                table: "Maps",
                column: "userID",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profiles_ProfileID",
                table: "Users",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cameras_locations_locationID",
                table: "cameras");

            migrationBuilder.DropForeignKey(
                name: "FK_locations_Maps_mapId",
                table: "locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Users_userID",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profiles_ProfileID",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "Maps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Maps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "mapId",
                table: "locations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "cameraID",
                table: "locations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "locationID",
                table: "cameras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cameras_locations_locationID",
                table: "cameras",
                column: "locationID",
                principalTable: "locations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_locations_Maps_mapId",
                table: "locations",
                column: "mapId",
                principalTable: "Maps",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Users_userID",
                table: "Maps",
                column: "userID",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profiles_ProfileID",
                table: "Users",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
