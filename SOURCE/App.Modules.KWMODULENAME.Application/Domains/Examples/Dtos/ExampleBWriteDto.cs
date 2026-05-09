using App.Modules.Sys.Shared.Models;
using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos
{
// -----------------------------------------------------------------------
// CANONICAL PATTERN — SPLIT READ/WRITE DTOs
// -----------------------------------------------------------------------
// ExampleBWriteDto is the write-side DTO AND the implicit base for the
// read-side DTO (ExampleBReadDto).  The relationship is:
//
//   ExampleBWriteDto          <- used for POST / PUT request bodies
//     + ExampleBReadDto       <- extends write with navigation DTO(s) for reads
//
// WRITE DTO (this class)
//   Carries the FK Guid for every reference-data relationship, plus all
//   writable scalar fields.  Navigation properties are absent — the server
//   resolves reference-data from the FK; clients must not supply nav shapes.
//
// READ DTO (ExampleBReadDto)
//   Derives from this class and adds one nullable navigation DTO per
//   reference-data relationship.  The nav DTO carries Title/Description/Key
//   so consumers can render labels without a second round-trip.
//   The inherited FK property is still present on the read side — it gives
//   stable identity even when the nav property is null (partial projection).
//
// FK / Id SUFFIX RULE
//   FK suffix  — the relationship is navigable somewhere in the object graph.
//   Id suffix  — a cross-aggregate reference that is intentionally never navigable.
//
// MAPPER NOTES
//   ExampleBToExampleBReadDtoMap    : ExampleB → ExampleBReadDto  (reads)
//   ExampleBWriteDtoToExampleBMap   : ExampleBWriteDto → ExampleB (writes)
//   Maps target the concrete leaf types; the base is transparent to AutoMapper.
// -----------------------------------------------------------------------

/// <summary>
/// Write-side DTO for <see cref="Shared.Domains.Examples.Models.Implmentations.ExampleB"/>.
/// Used as the request body for POST (create) and PUT (update) endpoints.
/// Also serves as the base class for <see cref="ExampleBReadDto"/>, which
/// extends it with navigation DTO properties for read operations.
/// </summary>
/// <remarks>
/// See the block comment at the top of this file for the canonical split DTO
/// rationale, FK naming rules, and mapper notes.
/// </remarks>
public class ExampleBWriteDto :
    IHasGuidId,
    IHasName
{
    /// <inheritdoc/>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the FK of the parent ExampleA entity.
    /// Uses the <c>Id</c> suffix because this is a cross-aggregate parent reference
    /// that is not navigable from ExampleB to ExampleA in the DTO graph.
    /// </summary>
    public Guid ExampleAId { get; set; }

    /// <inheritdoc/>
    public string Name { get; set; } = string.Empty;

    /// <summary>Gets or sets the display ordering hint.</summary>
    public int SortOrder { get; set; }
}
}
