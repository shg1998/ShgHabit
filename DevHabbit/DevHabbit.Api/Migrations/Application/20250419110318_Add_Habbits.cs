using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHabbit.Api.Migrations.Application
{
    /// <inheritdoc />
    public partial class Add_Habbits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dev-habbit");

            migrationBuilder.CreateTable(
                name: "HABBITS",
                schema: "dev-habbit",
                columns: table => new
                {
                    ID = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TYPE = table.Column<int>(type: "integer", nullable: false),
                    FREQUENCY_TYPE = table.Column<int>(type: "integer", nullable: false),
                    FREQUENCY_TIMES_PER_PERIOD = table.Column<int>(type: "integer", nullable: false),
                    TARGET_VALUE = table.Column<int>(type: "integer", nullable: false),
                    TARGET_UNIT = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    STATUE = table.Column<int>(type: "integer", nullable: false),
                    IS_ARCHIVED = table.Column<bool>(type: "boolean", nullable: false),
                    END_DATE = table.Column<DateOnly>(type: "date", nullable: true),
                    MILESTONE_TARGET = table.Column<int>(type: "integer", nullable: true),
                    MILESTONE_CURRENT = table.Column<int>(type: "integer", nullable: true),
                    CREATED_AT_UTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UPDATED_AT_UTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LAST_COMPLETED_AT_UTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HABBITS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HABBITS",
                schema: "dev-habbit");
        }
    }
}
