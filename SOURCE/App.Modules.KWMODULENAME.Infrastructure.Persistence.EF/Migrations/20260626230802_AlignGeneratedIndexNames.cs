using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.KWMODULENAME.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AlignGeneratedIndexNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_ExampleValueObject_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleValueObjects",
                newName: "IX_ExampleValueObjects_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleValueObject_Id",
                schema: "kwmodulename_examples",
                table: "ExampleValueObjects",
                newName: "IX_ExampleValueObjects_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleType_ReferenceDataType",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                newName: "IX_ExampleTypes_ReferenceDataType");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleType_RecordState",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                newName: "IX_ExampleTypes_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleType_Id",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                newName: "IX_ExampleTypes_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleB_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleBs",
                newName: "IX_ExampleBs_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleB_Id",
                schema: "kwmodulename_examples",
                table: "ExampleBs",
                newName: "IX_ExampleBs_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleA_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleAs",
                newName: "IX_ExampleAs_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleA_Id",
                schema: "kwmodulename_examples",
                table: "ExampleAs",
                newName: "IX_ExampleAs_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleAExampleB_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleAExampleBs",
                newName: "IX_ExampleAExampleBs_RecordState");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_ExampleValueObjects_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleValueObjects",
                newName: "IX_ExampleValueObject_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleValueObjects_Id",
                schema: "kwmodulename_examples",
                table: "ExampleValueObjects",
                newName: "IX_ExampleValueObject_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleTypes_ReferenceDataType",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                newName: "IX_ExampleType_ReferenceDataType");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleTypes_RecordState",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                newName: "IX_ExampleType_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleTypes_Id",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                newName: "IX_ExampleType_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleBs_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleBs",
                newName: "IX_ExampleB_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleBs_Id",
                schema: "kwmodulename_examples",
                table: "ExampleBs",
                newName: "IX_ExampleB_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleAs_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleAs",
                newName: "IX_ExampleA_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleAs_Id",
                schema: "kwmodulename_examples",
                table: "ExampleAs",
                newName: "IX_ExampleA_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleAExampleBs_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleAExampleBs",
                newName: "IX_ExampleAExampleB_RecordState");
        }
    }
}
