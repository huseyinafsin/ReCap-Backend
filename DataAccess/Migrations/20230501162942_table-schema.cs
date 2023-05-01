using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class tableschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarTypes_CarTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Colors_ColorId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_GearTypes_GearTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Languages_LanguageId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Languages_LanguageId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Pages_PageId",
                table: "Translations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translations",
                table: "Translations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pages",
                table: "Pages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuranceTypes",
                table: "InsuranceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GearTypes",
                table: "GearTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelTypes",
                table: "FuelTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarTypes",
                table: "CarTypes");

            migrationBuilder.EnsureSchema(
                name: "system");

            migrationBuilder.RenameTable(
                name: "Translations",
                newName: "Translation",
                newSchema: "system");

            migrationBuilder.RenameTable(
                name: "Pages",
                newName: "Page",
                newSchema: "system");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language",
                newSchema: "system");

            migrationBuilder.RenameTable(
                name: "InsuranceTypes",
                newName: "InsuranceType",
                newSchema: "system");

            migrationBuilder.RenameTable(
                name: "GearTypes",
                newName: "GearType",
                newSchema: "system");

            migrationBuilder.RenameTable(
                name: "FuelTypes",
                newName: "FuelType",
                newSchema: "system");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color",
                newSchema: "system");

            migrationBuilder.RenameTable(
                name: "CarTypes",
                newName: "CarType",
                newSchema: "system");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_PageId",
                schema: "system",
                table: "Translation",
                newName: "IX_Translation_PageId");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_LanguageId",
                schema: "system",
                table: "Translation",
                newName: "IX_Translation_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translation",
                schema: "system",
                table: "Translation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Page",
                schema: "system",
                table: "Page",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                schema: "system",
                table: "Language",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuranceType",
                schema: "system",
                table: "InsuranceType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GearType",
                schema: "system",
                table: "GearType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelType",
                schema: "system",
                table: "FuelType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                schema: "system",
                table: "Color",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarType",
                schema: "system",
                table: "CarType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarType_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalSchema: "system",
                principalTable: "CarType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Color_ColorId",
                table: "Cars",
                column: "ColorId",
                principalSchema: "system",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_FuelType_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId",
                principalSchema: "system",
                principalTable: "FuelType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_GearType_GearTypeId",
                table: "Cars",
                column: "GearTypeId",
                principalSchema: "system",
                principalTable: "GearType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Language_LanguageId",
                table: "Customers",
                column: "LanguageId",
                principalSchema: "system",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Language_LanguageId",
                schema: "system",
                table: "Translation",
                column: "LanguageId",
                principalSchema: "system",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Page_PageId",
                schema: "system",
                table: "Translation",
                column: "PageId",
                principalSchema: "system",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarType_CarTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Color_ColorId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FuelType_FuelTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_GearType_GearTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Language_LanguageId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Language_LanguageId",
                schema: "system",
                table: "Translation");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Page_PageId",
                schema: "system",
                table: "Translation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translation",
                schema: "system",
                table: "Translation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Page",
                schema: "system",
                table: "Page");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                schema: "system",
                table: "Language");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuranceType",
                schema: "system",
                table: "InsuranceType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GearType",
                schema: "system",
                table: "GearType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelType",
                schema: "system",
                table: "FuelType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                schema: "system",
                table: "Color");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarType",
                schema: "system",
                table: "CarType");

            migrationBuilder.RenameTable(
                name: "Translation",
                schema: "system",
                newName: "Translations");

            migrationBuilder.RenameTable(
                name: "Page",
                schema: "system",
                newName: "Pages");

            migrationBuilder.RenameTable(
                name: "Language",
                schema: "system",
                newName: "Languages");

            migrationBuilder.RenameTable(
                name: "InsuranceType",
                schema: "system",
                newName: "InsuranceTypes");

            migrationBuilder.RenameTable(
                name: "GearType",
                schema: "system",
                newName: "GearTypes");

            migrationBuilder.RenameTable(
                name: "FuelType",
                schema: "system",
                newName: "FuelTypes");

            migrationBuilder.RenameTable(
                name: "Color",
                schema: "system",
                newName: "Colors");

            migrationBuilder.RenameTable(
                name: "CarType",
                schema: "system",
                newName: "CarTypes");

            migrationBuilder.RenameIndex(
                name: "IX_Translation_PageId",
                table: "Translations",
                newName: "IX_Translations_PageId");

            migrationBuilder.RenameIndex(
                name: "IX_Translation_LanguageId",
                table: "Translations",
                newName: "IX_Translations_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translations",
                table: "Translations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pages",
                table: "Pages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuranceTypes",
                table: "InsuranceTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GearTypes",
                table: "GearTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelTypes",
                table: "FuelTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarTypes",
                table: "CarTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarTypes_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalTable: "CarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Colors_ColorId",
                table: "Cars",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_GearTypes_GearTypeId",
                table: "Cars",
                column: "GearTypeId",
                principalTable: "GearTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Languages_LanguageId",
                table: "Customers",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Languages_LanguageId",
                table: "Translations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Pages_PageId",
                table: "Translations",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
