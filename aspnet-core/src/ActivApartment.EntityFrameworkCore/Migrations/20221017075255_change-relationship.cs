using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivApartment.Migrations
{
    public partial class changerelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_building_building_type_BuildingTypeId",
                table: "building");

            migrationBuilder.DropForeignKey(
                name: "FK_building_country_CountryId",
                table: "building");

            migrationBuilder.DropForeignKey(
                name: "FK_building_district_DistrictId",
                table: "building");

            migrationBuilder.DropForeignKey(
                name: "FK_building_province_ProvinceId",
                table: "building");

            migrationBuilder.DropForeignKey(
                name: "FK_building_ward_WardId",
                table: "building");

            migrationBuilder.DropForeignKey(
                name: "FK_ward_district_DistrictId",
                table: "ward");

            migrationBuilder.DropIndex(
                name: "IX_ward_DistrictId",
                table: "ward");

            migrationBuilder.DropIndex(
                name: "IX_country_Code",
                table: "country");

            migrationBuilder.DropIndex(
                name: "IX_building_BuildingTypeId",
                table: "building");

            migrationBuilder.DropIndex(
                name: "IX_building_CountryId",
                table: "building");

            migrationBuilder.DropIndex(
                name: "IX_building_DistrictId",
                table: "building");

            migrationBuilder.DropIndex(
                name: "IX_building_ProvinceId",
                table: "building");

            migrationBuilder.DropIndex(
                name: "IX_building_WardId",
                table: "building");

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceCode",
                table: "province",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<long>(
                name: "ProvinceId",
                table: "district",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "country",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsActivated",
                table: "building",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_province_ProvinceCode",
                table: "province",
                column: "ProvinceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_country_Code_CountryName",
                table: "country",
                columns: new[] { "Code", "CountryName" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_province_ProvinceCode",
                table: "province");

            migrationBuilder.DropIndex(
                name: "IX_country_Code_CountryName",
                table: "country");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "district");

            migrationBuilder.DropColumn(
                name: "IsActivated",
                table: "building");

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceCode",
                table: "province",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "country",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ward_DistrictId",
                table: "ward",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_country_Code",
                table: "country",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_BuildingTypeId",
                table: "building",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_building_CountryId",
                table: "building",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_building_DistrictId",
                table: "building",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_building_ProvinceId",
                table: "building",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_building_WardId",
                table: "building",
                column: "WardId");

            migrationBuilder.AddForeignKey(
                name: "FK_building_building_type_BuildingTypeId",
                table: "building",
                column: "BuildingTypeId",
                principalTable: "building_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_building_country_CountryId",
                table: "building",
                column: "CountryId",
                principalTable: "country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_building_district_DistrictId",
                table: "building",
                column: "DistrictId",
                principalTable: "district",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_building_province_ProvinceId",
                table: "building",
                column: "ProvinceId",
                principalTable: "province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_building_ward_WardId",
                table: "building",
                column: "WardId",
                principalTable: "ward",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ward_district_DistrictId",
                table: "ward",
                column: "DistrictId",
                principalTable: "district",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
