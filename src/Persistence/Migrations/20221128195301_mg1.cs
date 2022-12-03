using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenderUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accept = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceverId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AuthenticatorType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RefreshTokenValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OperationClaimId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[] { "0460d8c9-75a6-4d68-abc3-f249523f3e93", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PhotoUrl", "Status", "Username" },
                values: new object[] { "ce1bf1ec-4854-49b0-a7cc-6c8a902e0aa9", 0, "admin@admin.com", "admin", "admin", new byte[] { 156, 253, 176, 223, 78, 176, 16, 221, 34, 239, 237, 141, 213, 207, 219, 51, 42, 117, 4, 29, 119, 114, 190, 248, 12, 78, 249, 45, 81, 130, 117, 207, 91, 120, 38, 52, 243, 133, 33, 192, 19, 26, 232, 221, 106, 150, 21, 94, 62, 218, 189, 10, 61, 171, 124, 137, 164, 5, 28, 88, 163, 233, 35, 15 }, new byte[] { 49, 85, 240, 118, 38, 151, 157, 36, 151, 133, 231, 128, 48, 131, 48, 152, 43, 41, 84, 75, 164, 180, 171, 37, 96, 136, 170, 111, 138, 40, 134, 20, 139, 4, 6, 9, 236, 65, 92, 3, 216, 90, 64, 178, 224, 210, 215, 241, 103, 120, 180, 141, 247, 195, 255, 100, 165, 76, 112, 170, 140, 124, 5, 233, 83, 255, 138, 19, 18, 206, 210, 199, 18, 94, 11, 107, 248, 180, 241, 91, 62, 190, 148, 197, 226, 150, 199, 153, 111, 231, 190, 155, 36, 243, 98, 38, 152, 151, 116, 32, 238, 58, 40, 33, 84, 181, 218, 14, 223, 8, 114, 237, 114, 110, 253, 87, 64, 141, 210, 217, 240, 215, 255, 127, 142, 24, 178, 221 }, null, true, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[] { "5565e2ed-b81d-42b6-a26c-0d08f383ce5f", "0460d8c9-75a6-4d68-abc3-f249523f3e93", "ce1bf1ec-4854-49b0-a7cc-6c8a902e0aa9" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
