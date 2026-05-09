using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models.Implmentations;
using App.Modules.Sys.Shared.ObjectMaps.Models;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Maps
{
    /// <summary>
    /// Forward map: <see cref="ExampleA"/> entity to <see cref="ExampleAReadDto"/>.
    /// Used for all GET/query operations. Discovered at startup via <see cref="IObjectMap"/>
    /// reflection scan.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is the read-side map of the canonical split DTO pair.
    /// It maps the FK (<c>ExampleTypeFK</c> → <c>ExampleTypeFK</c>) — same name
    /// on both sides because the FK suffix is used consistently on both entity
    /// and DTO when the relationship is navigable.
    /// The navigation DTO (<c>ExampleType</c>) is resolved automatically by the
    /// mapping engine via the registered <c>ExampleTypeToExampleTypeDtoMap</c>;
    /// no explicit MapFrom is needed for the nested navigation.
    /// </para>
    /// <para>
    /// The navigation DTO will only be non-null when the entity navigation
    /// property was populated (e.g. via ProjectTo). When null the inherited
    /// <c>ExampleTypeFK</c> still provides identity.
    /// </para>
    /// <para>
    /// See <see cref="Dtos.ExampleAWriteDto"/> for the canonical FK/Id naming rule.
    /// See <see cref="ExampleAWriteDtoToExampleAMap"/> for the complementary write-side map.
    /// </para>
    /// </remarks>
    public class ExampleAToExampleAReadDtoMap : ObjectMapBase<ExampleA, ExampleAReadDto>
    {
        /// <inheritdoc/>
        protected override void ConfigureMapping()
        {
            // -- Mapping instructions ------------------------------------
                // 1. Map EVERY property explicitly, one by one.
                //    No auto-mapping / convention-based magic.
                // 2. Use OUR extension methods (MapGuidId, MapTitleAndDescription,
                //    MapFrom, etc.) — never vendor-specific helpers.
                // 3. Map both the FK and the navigation DTO for read operations.
                //    The ExampleType navigation DTO is resolved automatically by the
                //    mapping engine at projection time via the registered
                //    ExampleTypeToExampleTypeDtoMap — it does not need an explicit
                //    MapFrom call here because source and destination navigation
                //    types differ (entity vs DTO) and the mapper resolves the nested
                //    map by convention when both maps are registered.
                // 4. Navigation collections are NOT mapped on this DTO.
                // -------------------------------------------------------------

                this.CreateMap()
                    .MapGuidId()
                    .MapFrom(dest => dest.ExampleTypeFK, src => src.ExampleTypeFK)
                    .MapTitleAndDescription()
                    .MapFrom(dest => dest.IsActive, src => src.IsActive);
        }
    }
}
