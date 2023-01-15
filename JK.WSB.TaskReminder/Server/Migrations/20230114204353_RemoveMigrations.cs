using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JK.WSB.TaskReminder.Server.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupQuest");

            migrationBuilder.DropTable(
                name: "Groups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

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
    }
}
