using App.Modules.Sys.Shared.Models.Dtos;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos
{
    /// <summary>
    /// Write DTO for <see cref="Shared.Domains.Examples.Models.Implmentations.ExampleType"/> reference data.
    /// Used for create and update operations.
    /// </summary>
    public class ExampleTypeWriteDto
    {
        /// <summary>Stable code/key.</summary>
        public string Key { get; set; } = string.Empty;

        /// <summary>Display title.</summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>Optional description.</summary>
        public string? Description { get; set; }

        /// <summary>Display order hint.</summary>
        public int DisplayOrderHint { get; set; }

        /// <summary>Whether this entry is currently enabled.</summary>
        public bool Enabled { get; set; } = true;
    }
}
