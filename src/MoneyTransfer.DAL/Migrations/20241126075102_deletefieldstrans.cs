using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTransfer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class deletefieldstrans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverTransactionId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "SenderTransactionId",
                table: "Transaction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiverTransactionId",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderTransactionId",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
