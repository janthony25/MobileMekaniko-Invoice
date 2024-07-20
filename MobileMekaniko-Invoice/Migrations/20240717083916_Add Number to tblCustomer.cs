using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileMekaniko_Invoice.Migrations
{
    /// <inheritdoc />
    public partial class AddNumbertotblCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerNumber",
                table: "tblCustomer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                table: "tblCustomer");
        }
    }
}
