using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3D_WebGame.Migrations
{
    /// <inheritdoc />
    public partial class add_column_sender_friendship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sender",
                table: "friendship",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sender",
                table: "friendship");
        }
    }
}
