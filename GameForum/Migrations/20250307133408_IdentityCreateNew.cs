using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameForum.Migrations
{
    /// <inheritdoc />
    public partial class IdentityCreateNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsForHire",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsForHire",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
