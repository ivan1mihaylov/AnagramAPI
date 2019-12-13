using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordCheckResult_CheckResult_CheckResultId",
                table: "WordCheckResult");

            migrationBuilder.DropForeignKey(
                name: "FK_WordCheckResult_Anagrams_WordId",
                table: "WordCheckResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordCheckResult",
                table: "WordCheckResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckResult",
                table: "CheckResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anagrams",
                table: "Anagrams");

            migrationBuilder.DropColumn(
                name: "IsAnagram",
                table: "CheckResult");

            migrationBuilder.RenameTable(
                name: "WordCheckResult",
                newName: "WordCheckResults");

            migrationBuilder.RenameTable(
                name: "CheckResult",
                newName: "CheckResults");

            migrationBuilder.RenameTable(
                name: "Anagrams",
                newName: "Words");

            migrationBuilder.RenameIndex(
                name: "IX_WordCheckResult_WordId",
                table: "WordCheckResults",
                newName: "IX_WordCheckResults_WordId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Version",
                table: "CheckResults",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<bool>(
                name: "AreAnagrams",
                table: "CheckResults",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Version",
                table: "Words",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordCheckResults",
                table: "WordCheckResults",
                columns: new[] { "CheckResultId", "WordId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckResults",
                table: "CheckResults",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Words",
                table: "Words",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WordCheckResults_CheckResults_CheckResultId",
                table: "WordCheckResults",
                column: "CheckResultId",
                principalTable: "CheckResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordCheckResults_Words_WordId",
                table: "WordCheckResults",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordCheckResults_CheckResults_CheckResultId",
                table: "WordCheckResults");

            migrationBuilder.DropForeignKey(
                name: "FK_WordCheckResults_Words_WordId",
                table: "WordCheckResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Words",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordCheckResults",
                table: "WordCheckResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckResults",
                table: "CheckResults");

            migrationBuilder.DropColumn(
                name: "AreAnagrams",
                table: "CheckResults");

            migrationBuilder.RenameTable(
                name: "Words",
                newName: "Anagrams");

            migrationBuilder.RenameTable(
                name: "WordCheckResults",
                newName: "WordCheckResult");

            migrationBuilder.RenameTable(
                name: "CheckResults",
                newName: "CheckResult");

            migrationBuilder.RenameIndex(
                name: "IX_WordCheckResults_WordId",
                table: "WordCheckResult",
                newName: "IX_WordCheckResult_WordId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Version",
                table: "Anagrams",
                type: "timestamp(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldRowVersion: true,
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Version",
                table: "CheckResult",
                type: "timestamp(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldRowVersion: true,
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsAnagram",
                table: "CheckResult",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anagrams",
                table: "Anagrams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordCheckResult",
                table: "WordCheckResult",
                columns: new[] { "CheckResultId", "WordId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckResult",
                table: "CheckResult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WordCheckResult_CheckResult_CheckResultId",
                table: "WordCheckResult",
                column: "CheckResultId",
                principalTable: "CheckResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordCheckResult_Anagrams_WordId",
                table: "WordCheckResult",
                column: "WordId",
                principalTable: "Anagrams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
