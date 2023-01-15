using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JK.WSB.TaskReminder.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Groups_GroupId",
                table: "Quests");

            migrationBuilder.DropIndex(
                name: "IX_Quests_GroupId",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Quests");

            migrationBuilder.CreateTable(
                name: "GroupQuest",
                columns: table => new
                {
                    GroupsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupQuest", x => new { x.GroupsId, x.QuestsId });
                    table.ForeignKey(
                        name: "FK_GroupQuest_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupQuest_Quests_QuestsId",
                        column: x => x.QuestsId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupQuest_QuestsId",
                table: "GroupQuest",
                column: "QuestsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupQuest");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Quests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quests_GroupId",
                table: "Quests",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Groups_GroupId",
                table: "Quests",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
