using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models.Implmentations;
using App.Modules.Sys.Shared.ObjectMaps.Models;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Maps
{
    /// <summary>
    /// Reverse map: <see cref="ExampleAWriteDto"/> to <see cref="ExampleA"/> entity.
    /// Used for POST (create) and PUT (update) operations. Discovered at startup via
    /// <see cref="IObjectMap"/> reflection scan.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is the write-side map of the canonical split DTO pair.
    /// It maps the FK (<c>ExampleTypeFK</c> → <c>ExampleTypeFK</c>) and
    /// writable scalar fields. Navigation properties are explicitly NOT mapped
    /// because the write DTO carries no navigation state.
    /// </para>
    /// <para>
    /// The FK name is the same on both DTO and entity (<c>ExampleTypeFK</c>)
    /// because the FK suffix is used consistently wherever the relationship
    /// is navigable, regardless of which side of the write/read split we are on.
    /// </para>
    /// <para>
    /// Infrastructure properties (timestamps, record state, watermarks) are
    /// not mapped here — the save-changes middleware sets them on save.
    /// </para>
    /// <para>
    /// See <see cref="Dtos.ExampleAWriteDto"/> for the canonical FK/Id naming rule.
    /// See <see cref="ExampleAToExampleAReadDtoMap"/> for the complementary read-side map.
    /// </para>
    /// </remarks>
    public class ExampleAWriteDtoToExampleAMap : ObjectMapBase<ExampleAWriteDto, ExampleA>
    {
        /// <inheritdoc/>
        protected override void ConfigureMapping()
        {
            // -- Mapping instructions ------------------------------------
            // 1. Map EVERY property explicitly, one by one.
            //    No auto-mapping / convention-based magic.
            // 2. Use OUR extension methods (MapGuidId, MapTitleAndDescription,
            //    MapFrom, etc.) — never vendor-specific helpers.
            // 3. Map only the FK; navigation properties are NOT mapped.
            // 4. Infrastructure properties (timestamps, record state) are NOT
            //    mapped — middleware sets them on save.
            // -------------------------------------------------------------

            this.CreateMap()
                .MapGuidId()
                .MapFrom(dest => dest.ExampleTypeFK, src => src.ExampleTypeFK)
                .MapTitleAndDescription()
                .MapFrom(dest => dest.IsActive, src => src.IsActive);
        }
    }
}
