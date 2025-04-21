using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHabbit.Api.Migrations.Application
{
    /// <inheritdoc />
    public partial class added_tags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TAGS",
                schema: "dev-habbit",
                columns: table => new
                {
                    ID = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    NAME = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CREATED_AT_UTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UPDATED_AT_UTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAGS", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAGS_NAME",
                schema: "dev-habbit",
                table: "TAGS",
                column: "NAME",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAGS",
                schema: "dev-habbit");
        }
    }
}
