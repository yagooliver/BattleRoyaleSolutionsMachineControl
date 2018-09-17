using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleRoyaleSolutions.Data.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalMachines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MachineName = table.Column<string>(maxLength: 40, nullable: false),
                    InternetProtocol = table.Column<string>(maxLength: 10, nullable: true),
                    AntiVirusName = table.Column<string>(maxLength: 40, nullable: true),
                    IsFirewallActive = table.Column<bool>(nullable: false),
                    WindowsVersion = table.Column<string>(maxLength: 10, nullable: false),
                    DotNetVersion = table.Column<string>(maxLength: 20, nullable: false),
                    Ip = table.Column<string>(maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ConnectionId = table.Column<string>(maxLength: 50, nullable: true),
                    TotalSize = table.Column<double>(nullable: false),
                    TotalUsed = table.Column<double>(nullable: false),
                    TotalAvalible = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalMachines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommandLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Command = table.Column<string>(nullable: true),
                    Return = table.Column<string>(nullable: true),
                    DateCommand = table.Column<DateTime>(nullable: false),
                    MachineId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommandLog_LocalMachines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "LocalMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommandLog_MachineId",
                table: "CommandLog",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandLog");

            migrationBuilder.DropTable(
                name: "LocalMachines");
        }
    }
}
