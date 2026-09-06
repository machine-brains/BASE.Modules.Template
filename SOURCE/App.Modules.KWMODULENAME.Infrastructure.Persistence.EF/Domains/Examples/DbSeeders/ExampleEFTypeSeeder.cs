using App.Modules.KWMODULENAME.Domain.Domains.Examples.Structures.AtRest.Entities.Implementations;
using App.Modules.KWMODULENAME.Domain.Domains.Examples.Structures.AtRest.Enums;
using App.Modules.Sys.Shared.Domains.Initialisation.Services.Seeding;
using App.Modules.Sys.Substrate.Domains.Indexes;
using App.Modules.Sys.Substrate.Domains.Models.Enums;

namespace App.Modules.KWMODULENAME.Infrastructure.Domains.Examples.DbSeeders
{
    /// <summary>
    /// Seeds the <see cref="ExampleType"/> table
    /// from the <see cref="ExampleTypeCode"/> enum.
    /// </summary>
    /// <remarks>
    /// Discovered via reflection by <c>EntityDataSeederDbSeederInitialiser</c>.
    /// Each enum value gets a deterministic Guid via <see cref="DeterministicGuid.FromEnum{TEnum}"/>.
    /// End users may add custom entries beyond these built-in values.
    /// </remarks>
    public sealed class ExampleEFTypeSeeder : IEntityDataSeeder<ExampleType>
    {
        /// <inheritdoc />
        public Task<IEnumerable<ExampleType>> GetSeedDeclarationsAsync(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);

            List<ExampleType> entries = new List<ExampleType>();
            int order = 0;

            foreach (ExampleTypeCode value in Enum.GetValues<ExampleTypeCode>())
            {
                string name = value.ToString();
                bool isSentinel = value is ExampleTypeCode.Undefined
                    or ExampleTypeCode.Unknown
                    or ExampleTypeCode.Unspecified;

                entries.Add(new ExampleType
                {
                    Id = DeterministicGuid.FromEnum(value),
                    Key = name,
                    Value = value.ToString(),
                    Title = name,
                    Description = "Example type: " + name + ".",
                    Enabled = !isSentinel,
                    RecordMutability = RecordMutabilityType.System,
                    EnumValue = (int)value,
                    DisplayOrderHint = order++
                });
            }

            return Task.FromResult<IEnumerable<ExampleType>>(entries);
        }
    }
}
