using App.Modules.KWMODULENAME.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.KWMODULENAME.Domain.Domains.Examples.Structures.AtRest.Entities.Implementations;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;
using App.Modules.Sys.Shared.Repositories;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Services.Implementations
{
    /// <summary>
    /// Implementation of <see cref="IExampleBApplicationService"/>.
    /// </summary>
    /// <remarks>
    /// IMPORTANT: This is an Application Service implementation, not a domain service.
    /// Note that this service inherits from
    /// <see cref="CrustStateAppServiceBase{TEntity,TReadDto,TCreateDto,TUpdateDto}"/>
    /// using the canonical split DTO pattern:
    /// <see cref="ExampleBReadDto"/> for reads and <see cref="ExampleBWriteDto"/> for create/update.
    /// This provides a standard set of CRUD operations with state management following
    /// our IQueryable-based repository patterns.
    /// </remarks>
    public class ExampleBApplicationService
        : CrustStateAppServiceBase<ExampleB, ExampleBReadDto, ExampleBWriteDto, ExampleBWriteDto>,
          IExampleBApplicationService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleBApplicationService"/> class.
        /// </summary>
        /// <param name="repository">The ExampleB repository for CRUST persistence.</param>
        /// <param name="mapper">The object mapping service for ProjectTo and Map.</param>
        /// <param name="logger">Logger instance for diagnostics.</param>
        /// <remarks>
        /// <para>
        /// Uses the full three-type <see cref="CrustStateAppServiceBase{TEntity,TReadDto,TCreateDto,TUpdateDto}"/>
        /// base rather than the Simple variant because ExampleB uses the canonical split DTO pattern:
        /// <see cref="ExampleBReadDto"/> for reads (includes audit fields) and
        /// <see cref="ExampleBWriteDto"/> for create/update (writable scalars only).
        /// </para>
        /// <para>
        /// The <see cref="IObjectMappingService"/> drives EF-optimized ProjectTo on reads
        /// and Map on writes, keeping IQueryable composable at the API boundary.
        /// </para>
        /// </remarks>
        public ExampleBApplicationService(
            ICrustStateRepository<ExampleB> repository,
            IObjectMappingService mapper,
            IAppLogger logger)
            : base(repository, mapper, logger)
        {
        }
    }
}
