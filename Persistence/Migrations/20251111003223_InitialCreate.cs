using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ranchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranchers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ranches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RancherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ranches_Ranchers_RancherId",
                        column: x => x.RancherId,
                        principalTable: "Ranchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpecieId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breeds_Species_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Corrals",
                columns: table => new
                {
                    IdCorral = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    RanchId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corrals", x => x.IdCorral);
                    table.ForeignKey(
                        name: "FK_Corrals_Ranches_RanchId",
                        column: x => x.RanchId,
                        principalTable: "Ranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    IdRegistration = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdRanch = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdBreed = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IdSpecie = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CorralId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.IdRegistration);
                    table.ForeignKey(
                        name: "FK_Animals_Breeds_IdBreed",
                        column: x => x.IdBreed,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Animals_Corrals_CorralId",
                        column: x => x.CorralId,
                        principalTable: "Corrals",
                        principalColumn: "IdCorral");
                    table.ForeignKey(
                        name: "FK_Animals_Ranches_IdRanch",
                        column: x => x.IdRanch,
                        principalTable: "Ranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_Species_IdSpecie",
                        column: x => x.IdSpecie,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Goats",
                columns: table => new
                {
                    IdRegistration = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MilkProductionPerDay = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goats", x => x.IdRegistration);
                    table.ForeignKey(
                        name: "FK_Goats_Animals_IdRegistration",
                        column: x => x.IdRegistration,
                        principalTable: "Animals",
                        principalColumn: "IdRegistration",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    IdRegistration = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Speed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.IdRegistration);
                    table.ForeignKey(
                        name: "FK_Horses_Animals_IdRegistration",
                        column: x => x.IdRegistration,
                        principalTable: "Animals",
                        principalColumn: "IdRegistration",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CorralId",
                table: "Animals",
                column: "CorralId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_IdBreed",
                table: "Animals",
                column: "IdBreed");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_IdRanch",
                table: "Animals",
                column: "IdRanch");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_IdSpecie",
                table: "Animals",
                column: "IdSpecie");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_SpecieId",
                table: "Breeds",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Corrals_RanchId",
                table: "Corrals",
                column: "RanchId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranchers_Username",
                table: "Ranchers",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ranches_RancherId",
                table: "Ranches",
                column: "RancherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goats");

            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Corrals");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Ranches");

            migrationBuilder.DropTable(
                name: "Ranchers");
        }
    }
}
