using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivApartment.Migrations
{
    public partial class updatetenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_building_AbpTenants_TenantId",
                table: "building");

            migrationBuilder.DropIndex(
                name: "IX_building_TenantId",
                table: "building");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "building",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "building",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_building_TenantId",
                table: "building",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_building_AbpTenants_TenantId",
                table: "building",
                column: "TenantId",
                principalTable: "AbpTenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
