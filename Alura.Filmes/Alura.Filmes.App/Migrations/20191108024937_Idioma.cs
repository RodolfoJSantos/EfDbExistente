﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Alura.Filmes.App.Migrations
{
    public partial class Idioma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "film",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    release_year = table.Column<string>(type: "varchar(4)", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    length = table.Column<short>(type: "smallint", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film", x => x.film_id);
                });

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    language_id = table.Column<byte>(type: "tinyint", nullable: false),
                    name = table.Column<string>(type: "char(20)", nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_language", x => x.language_id);
                });

            migrationBuilder.CreateTable(
                name: "film_actor",
                columns: table => new
                {
                    actor_id = table.Column<int>(type: "int", nullable: false),
                    film_id = table.Column<int>(type: "int", nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film_actor", x => new { x.actor_id, x.film_id });
                    table.ForeignKey(
                        name: "FK_film_actor_actor_actor_id",
                        column: x => x.actor_id,
                        principalTable: "actor",
                        principalColumn: "actor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_film_actor_film_film_id",
                        column: x => x.film_id,
                        principalTable: "film",
                        principalColumn: "film_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_film_actor_film_id",
                table: "film_actor",
                column: "film_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "film_actor");

            migrationBuilder.DropTable(
                name: "language");

            migrationBuilder.DropTable(
                name: "film");
        }
    }
}
