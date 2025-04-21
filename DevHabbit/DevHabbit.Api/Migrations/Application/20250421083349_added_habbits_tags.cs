using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHabbit.Api.Migrations.Application
{
    /// <inheritdoc />
    public partial class added_habbits_tags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HABBIT_TAGS",
                schema: "dev-habbit",
                columns: table => new
                {
                    HABBIT_ID = table.Column<string>(type: "character varying(500)", nullable: false),
                    TAG_ID = table.Column<string>(type: "character varying(500)", nullable: false),
                    CREATED_AT_UTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HABBIT_TAGS", x => new { x.HABBIT_ID, x.TAG_ID });
                    table.ForeignKey(
                        name: "FK_HABBIT_TAGS_HABBITS_HABBIT_ID",
                        column: x => x.HABBIT_ID,
                        principalSchema: "dev-habbit",
                        principalTable: "HABBITS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HABBIT_TAGS_TAGS_TAG_ID",
                        column: x => x.TAG_ID,
                        principalSchema: "dev-habbit",
                        principalTable: "TAGS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HABBIT_TAGS_TAG_ID",
                schema: "dev-habbit",
                table: "HABBIT_TAGS",
                column: "TAG_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HABBIT_TAGS",
                schema: "dev-habbit");
        }
    }
}
