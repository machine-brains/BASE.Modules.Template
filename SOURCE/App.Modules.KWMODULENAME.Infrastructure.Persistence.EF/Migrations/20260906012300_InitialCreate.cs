using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.KWMODULENAME.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "kwmodulename_examples");

            migrationBuilder.EnsureSchema(
                name: "kwmodulename_ref");

            migrationBuilder.CreateTable(
                name: "ExampleBs",
                schema: "kwmodulename_examples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordMutability = table.Column<int>(type: "int", nullable: false, comment: "Who/what can mutate/change the record."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    ExampleAId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Example A aggregate."),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The name of the model."),
                    SortOrder = table.Column<int>(type: "int", nullable: false, comment: "Gets or sets the sort order."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Example B record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Example B record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleBs", x => x.Id);
                },
                comment: "Example entity B - demonstrates a child/related domain entity that references via a foreign key. Inherits from for standard identity, audit, and record-state plumbing. Replace with your actual domain entity when cloning.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExampleBsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "kwmodulename_examples")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "ExampleTypes",
                schema: "kwmodulename_ref",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordMutability = table.Column<int>(type: "int", nullable: false, comment: "Who/what can mutate/change the record."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    Key = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false, comment: "Get/Set the list item's unique key."),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Get/Set whether the entity is enabled or not."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    MediaReferenceKind = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Discriminator that declares which media source field is active (None, Font, Media)."),
                    MediaFontKey = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, comment: "Font/icon key media source. Should be set only when MediaReferenceKind is Font."),
                    MediaContentFK = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "FK to MediaContent when MediaReferenceKind is Media. Null otherwise."),
                    DisplayStyleHint = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "A Hint on how to display the item. Consider using the field for a Classname that will mean something to the UX interface."),
                    DisplayOrderHint = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "A Hint to the Interface (UI/API) to organise item order on initial display. Non-unique. May be overridden by MRU settings."),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Stores the Value value for the Example Type record."),
                    FromUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the start datetime."),
                    ToUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the end datetime."),
                    EnumValue = table.Column<int>(type: "int", nullable: true, comment: "The integer value from the original . null for custom entries added beyond the built-in enum values."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Example Type record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Example Type record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExampleTypes_MediaContents_MediaContentFK",
                        column: x => x.MediaContentFK,
                        principalSchema: "sys_core",
                        principalTable: "MediaContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "Reference data entity that classifies instances. Many-to-one: each has one .")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExampleTypesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "kwmodulename_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "ExampleAs",
                schema: "kwmodulename_examples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordMutability = table.Column<int>(type: "int", nullable: false, comment: "Who/what can mutate/change the record."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Gets or sets whether this entity is active."),
                    ExampleTypeFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the foreign key. Classifies this entity by a reference-data type. Since it is navigable, the property name suffix is an 'FK', not 'Id'"),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Example A record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Example A record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleAs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExampleAs_ExampleTypes_ExampleTypeFK",
                        column: x => x.ExampleTypeFK,
                        principalSchema: "kwmodulename_ref",
                        principalTable: "ExampleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Example entity A - demonstrates a domain entity inheriting from with title, description, active flag, and a foreign key to reference data. Replace with your actual domain entity when cloning.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExampleAsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "kwmodulename_examples")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "ExampleAExampleBs",
                schema: "kwmodulename_examples",
                columns: table => new
                {
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordMutability = table.Column<int>(type: "int", nullable: false, comment: "Who/what can mutate/change the record."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "Optional payload: notes or context about this association."),
                    ExampleAFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the foreign key. Since it is navigable, the property name suffix is an 'FK', not 'Id'"),
                    ExampleBFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the foreign key. Since it is navigable, the property name suffix is an 'FK', not 'Id'"),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Example A Example B record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Example A Example B record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleAExampleBs", x => new { x.ExampleAFK, x.ExampleBFK });
                    table.ForeignKey(
                        name: "FK_ExampleAExampleBs_ExampleAs_ExampleAFK",
                        column: x => x.ExampleAFK,
                        principalSchema: "kwmodulename_examples",
                        principalTable: "ExampleAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExampleAExampleBs_ExampleBs_ExampleBFK",
                        column: x => x.ExampleBFK,
                        principalSchema: "kwmodulename_examples",
                        principalTable: "ExampleBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Explicit join entity linking and in a many-to-many relationship.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExampleAExampleBsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "kwmodulename_examples")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "ExampleValueObjects",
                schema: "kwmodulename_examples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordMutability = table.Column<int>(type: "int", nullable: false, comment: "Who/what can mutate/change the record."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The name of the model."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    SortOrder = table.Column<int>(type: "int", nullable: false, comment: "Gets or sets the sort order hint for display purposes."),
                    ExampleAFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the parent foreign key. Since it is navigable, the property name suffix is an 'FK', not 'Id'."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Example Value Object record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Example Value Object record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleValueObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExampleValueObjects_ExampleAs_ExampleAFK",
                        column: x => x.ExampleAFK,
                        principalSchema: "kwmodulename_examples",
                        principalTable: "ExampleAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "A value-object–style child of . One-to-many: each owns zero or more of these.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExampleValueObjectsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "kwmodulename_examples")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleAExampleB_ExampleAFK",
                schema: "kwmodulename_examples",
                table: "ExampleAExampleBs",
                column: "ExampleAFK");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleAExampleB_ExampleBFK",
                schema: "kwmodulename_examples",
                table: "ExampleAExampleBs",
                column: "ExampleBFK");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleAExampleBs_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleAExampleBs",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleA_ExampleTypeFK",
                schema: "kwmodulename_examples",
                table: "ExampleAs",
                column: "ExampleTypeFK");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleAs_Id",
                schema: "kwmodulename_examples",
                table: "ExampleAs",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleAs_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleAs",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleB_Name",
                schema: "kwmodulename_examples",
                table: "ExampleBs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleBs_ExampleAId",
                schema: "kwmodulename_examples",
                table: "ExampleBs",
                column: "ExampleAId");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleBs_Id",
                schema: "kwmodulename_examples",
                table: "ExampleBs",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleBs_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleBs",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleType_Enabled",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                column: "Enabled");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleType_FromUtc",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                column: "FromUtc");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleType_Key",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleType_MediaContentFK",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                column: "MediaContentFK");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleType_ToUtc",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                column: "ToUtc");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleTypes_EnumValue",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                column: "EnumValue",
                unique: true,
                filter: "[EnumValue] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleTypes_Id",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleTypes_RecordState",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleValueObject_Name",
                schema: "kwmodulename_examples",
                table: "ExampleValueObjects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleValueObjects_ExampleAFK",
                schema: "kwmodulename_examples",
                table: "ExampleValueObjects",
                column: "ExampleAFK");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleValueObjects_Id",
                schema: "kwmodulename_examples",
                table: "ExampleValueObjects",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleValueObjects_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleValueObjects",
                column: "RecordState");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExampleAExampleBs",
                schema: "kwmodulename_examples")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExampleAExampleBsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "kwmodulename_examples")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "ExampleValueObjects",
                schema: "kwmodulename_examples")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExampleValueObjectsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "kwmodulename_examples")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "ExampleBs",
                schema: "kwmodulename_examples")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExampleBsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "kwmodulename_examples")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "ExampleAs",
                schema: "kwmodulename_examples")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExampleAsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "kwmodulename_examples")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "ExampleTypes",
                schema: "kwmodulename_ref")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExampleTypesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "kwmodulename_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");
        }
    }
}
