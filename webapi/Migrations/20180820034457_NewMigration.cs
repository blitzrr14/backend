using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace webapi.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AS_UserRole_ST_Role_RoleId",
                table: "AS_UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_AS_UserRole_AS_User_UserId",
                table: "AS_UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AS_UserRole",
                table: "AS_UserRole");

            migrationBuilder.DropIndex(
                name: "IX_AS_UserRole_UserId",
                table: "AS_UserRole");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AS_UserRole",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "AS_UserRole",
                newName: "RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_AS_UserRole_RoleId",
                table: "AS_UserRole",
                newName: "IX_AS_UserRole_RoleID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "AS_UserRole",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleID",
                table: "AS_UserRole",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AS_UserRole",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AS_UserRole_Id",
                table: "AS_UserRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AS_UserRole",
                table: "AS_UserRole",
                columns: new[] { "UserID", "RoleID" });

            migrationBuilder.AddForeignKey(
                name: "FK_AS_UserRole_ST_Role_RoleID",
                table: "AS_UserRole",
                column: "RoleID",
                principalTable: "ST_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AS_UserRole_AS_User_UserID",
                table: "AS_UserRole",
                column: "UserID",
                principalTable: "AS_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AS_UserRole_ST_Role_RoleID",
                table: "AS_UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_AS_UserRole_AS_User_UserID",
                table: "AS_UserRole");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AS_UserRole_Id",
                table: "AS_UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AS_UserRole",
                table: "AS_UserRole");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "AS_UserRole",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "AS_UserRole",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AS_UserRole_RoleID",
                table: "AS_UserRole",
                newName: "IX_AS_UserRole_RoleId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AS_UserRole",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "AS_UserRole",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AS_UserRole",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AS_UserRole",
                table: "AS_UserRole",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AS_UserRole_UserId",
                table: "AS_UserRole",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AS_UserRole_ST_Role_RoleId",
                table: "AS_UserRole",
                column: "RoleId",
                principalTable: "ST_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AS_UserRole_AS_User_UserId",
                table: "AS_UserRole",
                column: "UserId",
                principalTable: "AS_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
