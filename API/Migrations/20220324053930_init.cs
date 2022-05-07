using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_port_route",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    route_name = table.Column<string>(nullable: true),
                    harbor_start = table.Column<int>(maxLength: 25, nullable: false),
                    harbor_end = table.Column<int>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_port_route", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_role",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role_name = table.Column<string>(type: "enum('SUPERADMIN','ADMIN')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_status",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status_name = table.Column<string>(type: "enum('ACTIVE','EXPIRED')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tourist_Actraction",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    location = table.Column<string>(maxLength: 100, nullable: true),
                    name = table.Column<string>(maxLength: 25, nullable: true),
                    description = table.Column<string>(nullable: true),
                    picture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tourist_Actraction", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_harbor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pelabuhan_name = table.Column<string>(maxLength: 25, nullable: true),
                    location = table.Column<string>(maxLength: 100, nullable: true),
                    description = table.Column<string>(nullable: true),
                    Route_idId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_harbor", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_harbor_tb_port_route_Route_idId",
                        column: x => x.Route_idId,
                        principalTable: "tb_port_route",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_schedule",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    session = table.Column<string>(maxLength: 25, nullable: true),
                    time = table.Column<TimeSpan>(maxLength: 25, nullable: false),
                    PortRoute_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_schedule", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_schedule_tb_port_route_PortRoute_id",
                        column: x => x.PortRoute_id,
                        principalTable: "tb_port_route",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_account",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(maxLength: 25, nullable: true),
                    email = table.Column<string>(maxLength: 25, nullable: true),
                    password = table.Column<string>(maxLength: 100, nullable: true),
                    Role_id = table.Column<int>(nullable: false),
                    Status_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_account", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_account_tb_role_Role_id",
                        column: x => x.Role_id,
                        principalTable: "tb_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_account_tb_status_Status_id",
                        column: x => x.Status_id,
                        principalTable: "tb_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_account_Role_id",
                table: "tb_account",
                column: "Role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_account_Status_id",
                table: "tb_account",
                column: "Status_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_harbor_Route_idId",
                table: "tb_harbor",
                column: "Route_idId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_schedule_PortRoute_id",
                table: "tb_schedule",
                column: "PortRoute_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_account");

            migrationBuilder.DropTable(
                name: "tb_harbor");

            migrationBuilder.DropTable(
                name: "tb_schedule");

            migrationBuilder.DropTable(
                name: "tb_tourist_Actraction");

            migrationBuilder.DropTable(
                name: "tb_role");

            migrationBuilder.DropTable(
                name: "tb_status");

            migrationBuilder.DropTable(
                name: "tb_port_route");
        }
    }
}
