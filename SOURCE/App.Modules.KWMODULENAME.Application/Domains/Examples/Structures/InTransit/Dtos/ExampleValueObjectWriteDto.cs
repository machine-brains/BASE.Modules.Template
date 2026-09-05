using App.Modules.Sys.Shared.Domains.Infrastructure.Models;
using App.Modules.Sys.Shared.Domains.Persistence.Models;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Structures.InTransit.Dtos
{
    /// <summary>
    /// Write DTO for <see cref="Domain.Domains.Examples.Structures.AtRest.Entities.Implementations.ExampleValueObject"/>.
    /// Used for create and update operations.
    /// </summary>
    public record ExampleValueObjectWriteDto
    {
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
