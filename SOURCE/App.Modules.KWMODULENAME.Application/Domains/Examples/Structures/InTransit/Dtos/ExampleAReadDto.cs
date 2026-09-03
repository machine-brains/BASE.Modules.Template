using App.Modules.KWMODULENAME.Domain.Domains.Examples.Structures.AtRest.Entities.Implementations;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Structures.InTransit.Dtos
{
    // See ExampleAWriteDto for the full canonical split DTO rationale and FK naming rules.

    /// <summary>
    /// Read-side DTO for <see cref="ExampleA"/>.
    /// Returned by all GET endpoints and IQueryable projections.
    /// Derives from <see cref="ExampleAWriteDto"/>, which carries the FK and all
    /// writable scalar fields, and adds navigation DTO properties for rendering.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The inherited <see cref="ExampleAWriteDto.ExampleTypeFK"/> is always
    /// populated and provides stable identity for the reference-data relationship
    /// even when <see cref="ExampleType"/> is null (partial projection).
    /// </para>
    /// <para>
    /// <see cref="ExampleType"/> is populated by the mapping engine when the entity
    /// was loaded with its <c>ExampleType</c> navigation.  It carries Title,
    /// Description, Key, etc. so consumers can render the reference-data label
    /// without a second round-trip.  The nested map is resolved automatically
    /// via the registered <c>ExampleTypeToExampleTypeDtoMap</c>.
    /// </para>
    /// </remarks>
    public class ExampleAReadDto : ExampleAWriteDto
    {
        /// <summary>
        /// Gets or sets the enriched reference-data shape for the classifying type.
        /// Populated when the entity navigation was loaded; <c>null</c> when not
        /// included in the projection.  Use <see cref="ExampleAWriteDto.ExampleTypeFK"/>
        /// for identity when null.
        /// </summary>
        public ExampleTypeReadDto? ExampleType { get; set; }
    }
}
