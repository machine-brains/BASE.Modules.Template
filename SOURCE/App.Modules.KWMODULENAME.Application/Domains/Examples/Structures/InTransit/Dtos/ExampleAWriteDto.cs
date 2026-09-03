using App.Modules.KWMODULENAME.Domain.Domains.Examples.Structures.AtRest.Entities.Implementations;
using App.Modules.Sys.Shared.Models;
using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Structures.InTransit.Dtos
{
    // -----------------------------------------------------------------------
    // CANONICAL PATTERN — SPLIT READ/WRITE DTOs
    // -----------------------------------------------------------------------
    // ExampleAWriteDto is the write-side DTO AND the implicit base for the
    // read-side DTO (ExampleAReadDto).  The relationship is:
    //
    //   ExampleAWriteDto          <- used for POST / PUT request bodies
    //     + ExampleAReadDto       <- extends write with navigation DTO(s) for reads
    //
    // WRITE DTO (this class)
    //   Carries the FK Guid for every reference-data relationship, plus all
    //   writable scalar fields.  Navigation properties are absent — the server
    //   resolves reference-data from the FK; clients must not supply nav shapes.
    //   The FK uses the Id suffix (not FK) because this side has no navigation
    //   property.  Id suffix = "identity only"; FK suffix = "has navigation".
    //
    // READ DTO (ExampleAReadDto)
    //   Derives from this class and adds one nullable navigation DTO per
    //   reference-data relationship.  The nav DTO carries Title/Description/Key
    //   so consumers can render labels without a second round-trip.
    //   The inherited FK property is still present on the read side — it gives
    //   stable identity even when the nav property is null (partial projection).
    //
    // FK / Id SUFFIX RULE (critical — applies to every DTO in every module)
    //
    //   FK suffix  — the relationship is navigable somewhere in the object graph.
    //                Use FK on the entity AND on both the write DTO and read DTO.
    //                The entity has a navigation property; the read DTO has a
    //                navigation DTO property; the write DTO has the FK only —
    //                but the suffix stays FK because the relationship IS navigable.
    //
    //   Id suffix  — a cross-aggregate reference that is intentionally never
    //                navigable anywhere (e.g. PrincipalId, WorkspaceId pointing
    //                to a different module).  Use Id on entity and both DTOs.
    //
    //   Entity side  : ExampleTypeFK   (FK suffix — navigable)
    //   Write DTO    : ExampleTypeFK   (same FK suffix — relationship is navigable)
    //   Read DTO     : ExampleTypeFK   (inherited) + ExampleType? (nav DTO added)
    //   The write map bridges ExampleTypeFK → ExampleTypeFK (same name, no rename).
    //
    //   Enum values are NEVER exposed as property types on any DTO or entity.
    //   The FK Guid (derived via DeterministicGuid from the enum int value) is
    //   the only correct representation of an enum-backed relationship.
    //
    // MAPPER NOTES
    //   ExampleAToExampleAReadDtoMap  : ExampleA → ExampleAReadDto  (reads)
    //   ExampleAWriteDtoToExampleAMap : ExampleAWriteDto → ExampleA (writes)
    //   Maps target the concrete leaf types; the base is transparent to AutoMapper.
    // -----------------------------------------------------------------------

    /// <summary>
    /// Write-side DTO for <see cref="ExampleA"/>.
    /// Used as the request body for POST (create) and PUT (update) endpoints.
    /// Also serves as the base class for <see cref="ExampleAReadDto"/>, which
    /// extends it with navigation DTO properties for read operations.
    /// </summary>
    /// <remarks>
    /// See the block comment at the top of this file for the canonical split DTO
    /// rationale, FK naming rules, and mapper notes.
    /// </remarks>
    public class ExampleAWriteDto :
    IHasGuidId,
    IHasTitleAndDescription
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the FK identifying the classifying ExampleType.
        /// Resolved server-side to the reference-data entity on save.
        /// Uses the <c>FK</c> suffix because this relationship is navigable
        /// (the entity has a navigation property; the read DTO exposes a
        /// navigation DTO).  The suffix stays FK on this write-side DTO too.
        /// </summary>
        public Guid ExampleTypeFK { get; set; }

        /// <inheritdoc/>
        public string Title { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>Gets or sets whether this entity is active.</summary>
        public bool IsActive { get; set; }
    }
}
