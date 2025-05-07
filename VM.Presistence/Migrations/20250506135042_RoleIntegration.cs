using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VM.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class RoleIntegration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cp_Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cp_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cp_Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cp_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cp_User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cp_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cp_User_cp_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "cp_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cp_UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cp_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cp_UserRoles_cp_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "cp_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cp_UserRoles_cp_User_UserId",
                        column: x => x.UserId,
                        principalTable: "cp_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cp_Roles",
                columns: new[] { "Id", "DateCreated", "DateModified", "Name", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super Admin", 1 },
                    { 2L, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", 1 },
                    { 3L, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engineering Director", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cp_User_AddressId",
                table: "cp_User",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cp_UserRoles_RoleId",
                table: "cp_UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_cp_UserRoles_UserId",
                table: "cp_UserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cp_UserRoles");

            migrationBuilder.DropTable(
                name: "cp_Roles");

            migrationBuilder.DropTable(
                name: "cp_User");

            migrationBuilder.DropTable(
                name: "cp_Address");
        }
    }
}
