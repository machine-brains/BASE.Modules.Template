using App.Modules.Sys.Shared.Models;
using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Structures.InTransit.Dtos
{
    /// <summary>
    /// DTO for <see cref="Domain.Domains.Examples.Structures.AtRest.Entities.Implementations.ExampleValueObject"/>.
    /// </summary>
    public record ExampleValueObjectReadDto : IHasGuidId, IHasName
    {
        /// <summary>Gets or sets the unique identifier.</summary>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the parent ExampleA identifier.</summary>
        public Guid ExampleAId { get; set; }

        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Gets or sets the description.</summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>Gets or sets the sort order.</summary>
        public int SortOrder { get; set; }
    }
}
