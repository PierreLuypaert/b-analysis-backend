using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace B_Analysis_BackEnd.Migrations // Adjust namespace as needed
{
    public partial class Match : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    RedDefenderId = table.Column<long>(nullable: true),
                    RedAttackerId = table.Column<long>(nullable: true),
                    BlueDefenderId = table.Column<long>(nullable: true),
                    BlueAttackerId = table.Column<long>(nullable: true),
                    MatchDuration = table.Column<int>(nullable: false),
                    BallPositionSerialized = table.Column<string>(nullable: true),
                    BallSpeedSerialized = table.Column<string>(nullable: true),
                    FrameRate = table.Column<int>(nullable: true),
                    PredictedGoalsSerialized = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Players_RedDefenderId",
                        column: x => x.RedDefenderId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Players_RedAttackerId",
                        column: x => x.RedAttackerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Players_BlueDefenderId",
                        column: x => x.BlueDefenderId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Players_BlueAttackerId",
                        column: x => x.BlueAttackerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_BlueAttackerId",
                table: "Matches",
                column: "BlueAttackerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_BlueDefenderId",
                table: "Matches",
                column: "BlueDefenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RedAttackerId",
                table: "Matches",
                column: "RedAttackerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RedDefenderId",
                table: "Matches",
                column: "RedDefenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
