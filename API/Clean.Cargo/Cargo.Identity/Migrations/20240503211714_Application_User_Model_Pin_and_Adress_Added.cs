using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cargo.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Application_User_Model_Pin_and_Adress_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PinCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "Adress", "ConcurrencyStamp", "PasswordHash", "PinCode", "SecurityStamp" },
                values: new object[] { "Baku", "93271d3d-8577-436f-88f2-fd37c4eff8b2", "AQAAAAIAAYagAAAAEPqIFXXLc2W0QO1c0ksrVVwZRTMHlag9Hb13uZEKQGgmX7IepCV1MDdWAevvk9YLdA==", "1234567", "c8a8ffbf-3bb3-4aba-9a34-a0efd75e5624" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "Adress", "ConcurrencyStamp", "PasswordHash", "PinCode", "SecurityStamp" },
                values: new object[] { "Baku", "24967f6a-f079-4fac-9006-d69d742747c6", "AQAAAAIAAYagAAAAEE/ZbtkqBC6WUaAG+j2p7FYpieafwWww12snJTvc7osKjDK5cHX5dOdxh6RbIWqwTg==", "1234567", "715978c4-e119-44f6-8436-b8181f517e56" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9732e51f-870c-46ea-8676-162756acaa25", "AQAAAAIAAYagAAAAEAiNian/zW7wRv8wL3/rDrFyj23MlvH3EYowX6zWI7yPqnHhZc14ku5Fvc+YQwBVkA==", "53471e8e-bfe2-4df7-844f-29dab1c3b54e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f116711-85fe-4995-a1f9-c6982bef5403", "AQAAAAIAAYagAAAAEJAWaRfAPXVDpN5PzhPgQ4y6UobgbY6mkEiSF16K7fFr4jDJHgwgtw3ElGpQDmL1ug==", "b81858d0-1f20-4110-9d8b-d1864916ed03" });
        }
    }
}
