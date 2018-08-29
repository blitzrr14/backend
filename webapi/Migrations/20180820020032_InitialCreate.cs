using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace webapi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaffleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaffleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ST_Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    city = table.Column<string>(maxLength: 50, nullable: true),
                    country = table.Column<string>(maxLength: 50, nullable: true),
                    housenumber = table.Column<string>(maxLength: 50, nullable: true),
                    province = table.Column<string>(maxLength: 50, nullable: true),
                    street = table.Column<string>(maxLength: 100, nullable: true),
                    zipcode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ST_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ST_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ST_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ST_Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1Id = table.Column<int>(nullable: true),
                    Address2Id = table.Column<int>(nullable: true),
                    ContactNo = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ST_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ST_Person_ST_Address_Address1Id",
                        column: x => x.Address1Id,
                        principalTable: "ST_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ST_Person_ST_Address_Address2Id",
                        column: x => x.Address2Id,
                        principalTable: "ST_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AS_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    isActivate = table.Column<int>(nullable: false),
                    personId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AS_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AS_User_ST_Person_personId",
                        column: x => x.personId,
                        principalTable: "ST_Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AS_UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    RoleId = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AS_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AS_UserRole_ST_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ST_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AS_UserRole_AS_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AS_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Raffles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    RaffleDate = table.Column<DateTime>(nullable: true),
                    RaffleTypeId = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raffles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raffles_RaffleTypes_RaffleTypeId",
                        column: x => x.RaffleTypeId,
                        principalTable: "RaffleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Raffles_AS_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AS_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TR_Balance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Credits = table.Column<decimal>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Points = table.Column<decimal>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Wallet = table.Column<decimal>(nullable: false),
                    userId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TR_Balance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TR_Balance_AS_User_userId",
                        column: x => x.userId,
                        principalTable: "AS_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    RaffleId = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TransTypeId = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Raffles_RaffleId",
                        column: x => x.RaffleId,
                        principalTable: "Raffles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_TransTypes_TransTypeId",
                        column: x => x.TransTypeId,
                        principalTable: "TransTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_AS_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AS_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RaffleEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    RaffleId = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TransactionId = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaffleEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaffleEntries_Raffles_RaffleId",
                        column: x => x.RaffleId,
                        principalTable: "Raffles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaffleEntries_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaffleEntries_AS_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AS_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AS_User_personId",
                table: "AS_User",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_AS_UserRole_RoleId",
                table: "AS_UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AS_UserRole_UserId",
                table: "AS_UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RaffleEntries_RaffleId",
                table: "RaffleEntries",
                column: "RaffleId");

            migrationBuilder.CreateIndex(
                name: "IX_RaffleEntries_TransactionId",
                table: "RaffleEntries",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_RaffleEntries_UserId",
                table: "RaffleEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Raffles_RaffleTypeId",
                table: "Raffles",
                column: "RaffleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Raffles_UserId",
                table: "Raffles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ST_Person_Address1Id",
                table: "ST_Person",
                column: "Address1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ST_Person_Address2Id",
                table: "ST_Person",
                column: "Address2Id");

            migrationBuilder.CreateIndex(
                name: "IX_TR_Balance_userId",
                table: "TR_Balance",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RaffleId",
                table: "Transactions",
                column: "RaffleId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransTypeId",
                table: "Transactions",
                column: "TransTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AS_UserRole");

            migrationBuilder.DropTable(
                name: "RaffleEntries");

            migrationBuilder.DropTable(
                name: "TR_Balance");

            migrationBuilder.DropTable(
                name: "ST_Role");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Raffles");

            migrationBuilder.DropTable(
                name: "TransTypes");

            migrationBuilder.DropTable(
                name: "RaffleTypes");

            migrationBuilder.DropTable(
                name: "AS_User");

            migrationBuilder.DropTable(
                name: "ST_Person");

            migrationBuilder.DropTable(
                name: "ST_Address");
        }
    }
}
