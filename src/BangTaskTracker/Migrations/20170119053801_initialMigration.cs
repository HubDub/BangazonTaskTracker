using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BangTaskTracker.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrackedTask",
                columns: table => new
                {
                    Taskid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompletedOn = table.Column<DateTime>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TaskName = table.Column<string>(nullable: false),
                    TaskOrderStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackedTask", x => x.Taskid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackedTask");
        }
    }
}
