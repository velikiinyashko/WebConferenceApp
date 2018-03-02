using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebConferenceApp.Migrations
{
    public partial class addSubsr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubsrubeId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subscrubes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscrubes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscrubes_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SubsrubeId",
                table: "Rooms",
                column: "SubsrubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscrubes_AccountId",
                table: "Subscrubes",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Subscrubes_SubsrubeId",
                table: "Rooms",
                column: "SubsrubeId",
                principalTable: "Subscrubes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Subscrubes_SubsrubeId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Subscrubes");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_SubsrubeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "SubsrubeId",
                table: "Rooms");
        }
    }
}
