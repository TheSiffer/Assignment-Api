using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_Api.Migrations
{
    /// <inheritdoc />
    public partial class UsersPinFieldAdditon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "Users",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Users");
        }
    }
}
