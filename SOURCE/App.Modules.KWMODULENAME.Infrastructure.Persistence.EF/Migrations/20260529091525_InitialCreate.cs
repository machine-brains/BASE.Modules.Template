using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Modules.KWMODULENAME.Infrastructure.Persistence.EF.Migrations
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

            migrationBuilder.EnsureSchema(
                name: "kwmodulename");

            migrationBuilder.CreateTable(
                name: "ExampleBs",
                schema: "kwmodulename_examples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    ExampleAId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Example A aggregate."),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The name of the model."),
                    SortOrder = table.Column<int>(type: "int", nullable: false, comment: "Gets or sets the sort order.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleBs", x => x.Id);
                },
                comment: "Example entity B - demonstrates a child/related domain entity that references via a foreign key. Inherits from for standard identity, audit, and record-state plumbing. Replace with your actual domain entity when cloning.");

            migrationBuilder.CreateTable(
                name: "MediaContent",
                schema: "kwmodulename",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key for the Media Content record."),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Logical content key used to group culture variants together. Example: \"terms_md\", \"logo_png\"."),
                    BlobPath = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The blob path for the default (culture-neutral) content, including the container prefix (e.g. \"media-signed/agreements/agreements/{guid}.md\")."),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "MIME type of the content (e.g. \"text/markdown\", \"text/plain\", \"image/png\"). and custom ones: \"font\"\"font/woff2\"\"font/ttf\""),
                    ContentHash = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "SHA-256 hash of the default content at import/publish time."),
                    ContentHashAlgorithm = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The hash algorithm used (e.g. \"SHA-256\")."),
                    ContentSizeBytes = table.Column<long>(type: "bigint", nullable: true, comment: "Size of the blob content in bytes. Used to populate Content-Length headers for downloads, display file-size hints in the UI, and support accessible media descriptions. Null until the blob has been written and its size confirmed."),
                    WidthPx = table.Column<int>(type: "int", nullable: true, comment: "Width of the image in pixels. Only populated for image media types (e.g. image/png, image/jpeg, image/webp). Null for non-image content. Used for aspect-ratio preservation during resize operations and to emit width / height HTML attributes that prevent cumulative layout shift (CLS)."),
                    HeightPx = table.Column<int>(type: "int", nullable: true, comment: "Height of the image in pixels. See for full context."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp. Note that this is filled in when persisted in the db -- so it's usable to determine whether Record is New or not."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on. Changed To DateTimeOffset."),
                    CreatedByPrincipalId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete). Null until a state transition (soft delete, archive, etc.) occurs."),
                    StateChangedByPrincipalId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Gets or sets the principal id who changed the state (nullable).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContent", x => x.Id);
                },
                comment: "Concrete entity for culture-neutral media content. See for full documentation.");

            migrationBuilder.CreateTable(
                name: "ExampleTypes",
                schema: "kwmodulename_ref",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    Key = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false, comment: "Get/Set the list item's unique key."),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Get/Set whether the entity is enabled or not."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    ImageFK = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "FK to the MediaContent record representing the image. Null when no image is assigned."),
                    DisplayStyleHint = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "A Hint on how to display the item. Consider using the field for a Classname that will mean something to the UX interface."),
                    DisplayOrderHint = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "A Hint to the Interface (UI/API) to organise item order on initial display. Non-unique. May be overridden by MRU settings."),
                    ReferenceDataType = table.Column<int>(type: "int", nullable: false, comment: "Gets or sets the reference data classification."),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Stores the Value value for the Example Type record."),
                    FromUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the start datetime."),
                    ToUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the end datetime."),
                    EnumValue = table.Column<int>(type: "int", nullable: true, comment: "The integer value from the original . null for custom entries added beyond the built-in enum values.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExampleTypes_MediaContent_ImageFK",
                        column: x => x.ImageFK,
                        principalSchema: "kwmodulename",
                        principalTable: "MediaContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "Reference data entity that classifies instances. Many-to-one: each has one .");

            migrationBuilder.CreateTable(
                name: "ExampleAs",
                schema: "kwmodulename_examples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Gets or sets whether this entity is active."),
                    ExampleTypeFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the foreign key. Classifies this entity by a reference-data type. Since it is navigable, the property name suffix is an 'FK', not 'Id'")
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
                comment: "Example entity A - demonstrates a domain entity inheriting from with title, description, active flag, and a foreign key to reference data. Replace with your actual domain entity when cloning.");

            migrationBuilder.CreateTable(
                name: "ExampleAExampleBs",
                schema: "kwmodulename_examples",
                columns: table => new
                {
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "Optional payload: notes or context about this association."),
                    ExampleAFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the foreign key. Since it is navigable, the property name suffix is an 'FK', not 'Id'"),
                    ExampleBFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the foreign key. Since it is navigable, the property name suffix is an 'FK', not 'Id'")
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
                comment: "Explicit join entity linking and in a many-to-many relationship.");

            migrationBuilder.CreateTable(
                name: "ExampleValueObjects",
                schema: "kwmodulename_examples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The name of the model."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    SortOrder = table.Column<int>(type: "int", nullable: false, comment: "Gets or sets the sort order hint for display purposes."),
                    ExampleAFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the parent foreign key. Since it is navigable, the property name suffix is an 'FK', not 'Id'.")
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
                comment: "A value-object–style child of . One-to-many: each owns zero or more of these.");

            migrationBuilder.InsertData(
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "DisplayStyleHint", "EnumValue", "FromUtc", "ImageFK", "Key", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "ReferenceDataType", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "ToUtc", "Value" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Example type: Undefined.", null, 0, null, null, "Undefined", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Undefined", null, "Undefined" });

            migrationBuilder.InsertData(
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "EnumValue", "FromUtc", "ImageFK", "Key", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "ReferenceDataType", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "ToUtc", "Value" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Example type: NotApplicable.", 1, null, true, 1, null, null, "NotApplicable", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "NotApplicable", null, "NotApplicable" });

            migrationBuilder.InsertData(
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "DisplayOrderHint", "DisplayStyleHint", "EnumValue", "FromUtc", "ImageFK", "Key", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "ReferenceDataType", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "ToUtc", "Value" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Example type: Unspecified.", 2, null, 2, null, null, "Unspecified", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Unspecified", null, "Unspecified" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Example type: Unknown.", 3, null, 3, null, null, "Unknown", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Unknown", null, "Unknown" }
                });

            migrationBuilder.InsertData(
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "EnumValue", "FromUtc", "ImageFK", "Key", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "ReferenceDataType", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "ToUtc", "Value" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Example type: General.", 4, null, true, 4, null, null, "General", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "General", null, "General" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Example type: Specialised.", 5, null, true, 5, null, null, "Specialised", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Specialised", null, "Specialised" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Example type: Advanced.", 6, null, true, 6, null, null, "Advanced", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Advanced", null, "Advanced" }
                });

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
                name: "IX_ExampleAExampleB_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleAExampleBs",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleA_ExampleTypeFK",
                schema: "kwmodulename_examples",
                table: "ExampleAs",
                column: "ExampleTypeFK");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleA_Id",
                schema: "kwmodulename_examples",
                table: "ExampleAs",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleA_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleAs",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleB_Id",
                schema: "kwmodulename_examples",
                table: "ExampleBs",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleB_Name",
                schema: "kwmodulename_examples",
                table: "ExampleBs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleB_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleBs",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleBs_ExampleAId",
                schema: "kwmodulename_examples",
                table: "ExampleBs",
                column: "ExampleAId");

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
                name: "IX_ExampleType_Id",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleType_ImageFK",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                column: "ImageFK");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleType_Key",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleType_RecordState",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleType_ReferenceDataType",
                schema: "kwmodulename_ref",
                table: "ExampleTypes",
                column: "ReferenceDataType");

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
                name: "IX_ExampleValueObject_Id",
                schema: "kwmodulename_examples",
                table: "ExampleValueObjects",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleValueObject_Name",
                schema: "kwmodulename_examples",
                table: "ExampleValueObjects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExampleValueObject_RecordState",
                schema: "kwmodulename_examples",
                table: "ExampleValueObjects",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleValueObjects_ExampleAFK",
                schema: "kwmodulename_examples",
                table: "ExampleValueObjects",
                column: "ExampleAFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExampleAExampleBs",
                schema: "kwmodulename_examples");

            migrationBuilder.DropTable(
                name: "ExampleValueObjects",
                schema: "kwmodulename_examples");

            migrationBuilder.DropTable(
                name: "ExampleBs",
                schema: "kwmodulename_examples");

            migrationBuilder.DropTable(
                name: "ExampleAs",
                schema: "kwmodulename_examples");

            migrationBuilder.DropTable(
                name: "ExampleTypes",
                schema: "kwmodulename_ref");

            migrationBuilder.DropTable(
                name: "MediaContent",
                schema: "kwmodulename");
        }
    }
}
