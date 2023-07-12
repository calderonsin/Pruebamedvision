using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pruebamedvision.Migrations
{
    /// <inheritdoc />
    public partial class thirdon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CitaId",
                table: "MotivoCitas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CitaId",
                table: "MotivoCitas");
        }
    }
}
