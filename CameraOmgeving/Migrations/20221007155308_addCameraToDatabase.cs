using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameraOmgeving.Migrations
{
    public partial class addCameraToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contents",
                table: "cameras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "cameras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "cameras",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contents",
                table: "cameras");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "cameras");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "cameras");
        }
    }
}
