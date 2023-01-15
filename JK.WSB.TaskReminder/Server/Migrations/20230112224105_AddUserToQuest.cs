using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JK.WSB.TaskReminder.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToQuest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Quests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Quests_UserId",
                table: "Quests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Users_UserId",
                table: "Quests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Users_UserId",
                table: "Quests");

            migrationBuilder.DropIndex(
                name: "IX_Quests_UserId",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Quests");
        }
    }
}
