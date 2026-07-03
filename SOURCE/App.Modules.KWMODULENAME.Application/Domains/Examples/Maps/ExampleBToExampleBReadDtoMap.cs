using App.Modules.KWMODULENAME.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.KWMODULENAME.Domain.Domains.Examples.Structures.AtRest.Entities.Implementations;
using App.Modules.Sys.Shared.ObjectMaps.Models;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Maps
{
    /// <summary>
    /// Forward map: <see cref="ExampleB"/> entity to <see cref="ExampleBReadDto"/>.
    /// Used for all GET/query projections.
    /// Discovered at startup via <see cref="IObjectMap"/> reflection scan.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Maps both scalar fields (inherited via <see cref="ExampleBWriteDto"/>) and
    /// read-only infrastructure fields such as <see cref="ExampleBReadDto.CreatedUtc"/>.
    /// Navigation / collection properties are not mapped.
    /// </para>
    /// </remarks>
    public class ExampleBToExampleBReadDtoMap : ObjectMapBase<ExampleB, ExampleBReadDto>
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
                .MapFrom(dest => dest.SortOrder, src => src.SortOrder)
                .MapFrom(dest => dest.CreatedUtc, src => src.CreatedOnDateTimeUtc);
        }
    }
}
