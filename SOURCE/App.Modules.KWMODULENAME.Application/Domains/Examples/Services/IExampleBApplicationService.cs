using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Services
{
    /// <summary>
    /// Application service contract for ExampleB operations.
    /// Extends <see cref="ICrudStateAppService{TReadDto,TCreateDto,TUpdateDto}"/>
    /// for standard CRUST operations.
    /// Returns IQueryable for OData filtering, paging, sorting at the API boundary.
    /// </summary>
    /// <remarks>
    /// IMPORTANT: This is an Application Service contract, not a domain service contract.
    /// Note that this service inherits from
    /// <see cref="ICrudStateAppService{TReadDto,TCreateDto,TUpdateDto}"/>
    /// and uses the canonical split DTO pattern:
    /// <see cref="ExampleBReadDto"/> for reads (includes audit/infrastructure fields) and
    /// <see cref="ExampleBWriteDto"/> for create/update (writable scalar fields only).
    /// This is the common pattern for the vast majority of Application Services contracts
    /// in the system, providing a standard set of CRUD operations with state management
    /// following our IQueryable-based repository patterns.
    /// </remarks>
	public interface IExampleBApplicationService
		: ICrudStateAppService<ExampleBReadDto, ExampleBWriteDto, ExampleBWriteDto>
	{
	}
}
