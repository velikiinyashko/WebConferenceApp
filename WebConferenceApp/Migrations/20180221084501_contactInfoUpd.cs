using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebConferenceApp.Migrations
{
    public partial class contactInfoUpd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Companys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Companys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Accounts",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Accounts");
        }
    }
}
