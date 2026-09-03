namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Structures.InTransit.Dtos
{
    /// <summary>
    /// Read-side DTO for <see cref="Domain.Domains.Examples.Structures.AtRest.Entities.Implementations.ExampleB"/>.
    /// Returned by all GET endpoints and IQueryable projections.
    /// Derives from <see cref="ExampleBWriteDto"/>, which carries the parent FK and all
    /// writable scalar fields, and adds audit/timestamp properties for rendering.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The inherited <see cref="ExampleBWriteDto.ExampleAId"/> is always
    /// populated and provides stable parent identity even in partial projections.
    /// </para>
    /// <para>
    /// <see cref="CreatedUtc"/> is infrastructure-managed and therefore read-only;
    /// it is not present on the write DTO.
    /// </para>
    /// </remarks>
    public class ExampleBReadDto : ExampleBWriteDto
    {
        /// <summary>
        /// Gets or sets the date this entity was created (UTC).
        /// Set by infrastructure on first save; read-only from the client perspective.
        /// </summary>
        public DateTime CreatedUtc { get; set; }
    }
}
