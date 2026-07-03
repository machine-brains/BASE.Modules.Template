using App.Modules.KWMODULENAME.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.KWMODULENAME.Domain.Domains.Examples.Structures.AtRest.Entities.Implementations;
using App.Modules.Sys.Shared.ObjectMaps.Models;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Maps
{
    /// <summary>
    /// Write map: <see cref="ExampleBWriteDto"/> to <see cref="ExampleB"/> entity.
    /// Used for Create and Update operations.
    /// Discovered at startup via <see cref="IObjectMap"/> reflection scan.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Only scalar fields that a client may supply are mapped here.
    /// Infrastructure properties (Timestamp, RecordState, audit fields)
    /// remain at their entity defaults — the framework sets them on save.
    /// Navigation properties are not mapped; the FK is sufficient for persistence.
    /// </para>
    /// </remarks>
    public class ExampleBWriteDtoToExampleBMap : ObjectMapBase<ExampleBWriteDto, ExampleB>
    {
        /// <inheritdoc/>
        protected override void ConfigureMapping()
        {
            // -- Mapping instructions ------------------------------------
            // 1. Map EVERY property explicitly, one by one.
            //    No auto-mapping / convention-based magic.
            // 2. Use OUR extension methods (MapGuidId, MapTitleAndDescription,
            //    MapFrom, etc.) — never vendor-specific helpers.
            // 3. Navigation / collection properties are NOT mapped.
            // -------------------------------------------------------------

            this.CreateMap()
                .MapGuidId()
                .MapFrom(dest => dest.ExampleAId, src => src.ExampleAId)
                .MapFrom(dest => dest.Name, src => src.Name)
                .MapFrom(dest => dest.SortOrder, src => src.SortOrder);
        }
    }
}
