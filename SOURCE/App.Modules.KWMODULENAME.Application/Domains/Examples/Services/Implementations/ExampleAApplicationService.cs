using App.Modules.KWMODULENAME.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.KWMODULENAME.Domain.Domains.Examples.Structures.AtRest.Entities.Implementations;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;
using App.Modules.Sys.Shared.Repositories;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Services.Implementations
{
    /// <summary>
    /// Implementation of <see cref="IExampleAApplicationService"/>.
    /// </summary>
    /// <remarks>
    /// IMPORTANT: This is an Application Service contract, not a domain service contract.
    /// Note that this service inherits from
    /// <see cref="SimpleCrustStateAppServiceBase{TEntity,TEntityDto}"/>
    /// This is the common pattern for the vaste majority of Application Services contracts in the system,
    /// as it provides a standard set of CRUD operations with
    /// state management following our IQueryable-based repository patterns.
    /// </remarks>
	public class ExampleAApplicationService
		: CrustStateAppServiceBase<ExampleA, ExampleAReadDto, ExampleAWriteDto, ExampleAWriteDto>,
		  IExampleAApplicationService
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ExampleAApplicationService"/> class.
		/// </summary>
		/// <param name="repository">The ExampleA repository for CRUST persistence.</param>
		/// <param name="mapper">The object mapping service for ProjectTo and Map.</param>
		/// <param name="logger">Logger instance for diagnostics.</param>
		/// <remarks>
		/// <para>
		/// Uses the full three-type <see cref="CrustStateAppServiceBase{TEntity,TReadDto,TCreateDto,TUpdateDto}"/>
		/// base rather than the Simple variant because ExampleA uses the canonical split DTO pattern:
		/// <see cref="ExampleAReadDto"/> for reads (includes navigation DTO) and
		/// <see cref="ExampleAWriteDto"/> for create/update (FK-only, no navigation).
		/// </para>
		/// <para>
		/// The <see cref="IObjectMappingService"/> drives EF-optimized ProjectTo on reads
		/// and Map on writes, keeping IQueryable composable at the API boundary.
		/// </para>
		/// </remarks>
		public ExampleAApplicationService(
			ICrustStateRepository<ExampleA> repository,
			IObjectMappingService mapper,
			IAppLogger logger)
			: base(repository, mapper, logger)
		{
		}
	}
}
