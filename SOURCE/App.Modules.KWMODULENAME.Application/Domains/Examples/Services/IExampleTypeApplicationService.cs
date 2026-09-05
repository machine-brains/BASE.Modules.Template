using App.Modules.KWMODULENAME.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.Sys.Shared.Domains.Application;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Services
{
    /// <summary>
    /// Application service contract for <see cref="Domain.Domains.Examples.Structures.AtRest.Entities.Implementations.ExampleType"/> CRUST operations.
    /// </summary>
    /// <remarks>
    /// IMPORTANT: This is an Application Service contract, not a domain service contract.
    /// Note that this service inherits from
    /// <see cref="ICrudStateAppService{TEntityDto,TCreateDto,TUpdateDto}"/>
    /// This is the common pattern for the vast majority of Application Services contracts in the system,
    /// as it provides a standard set of CRUD operations with
    /// state management following our IQueryable-based repository patterns.
    /// </remarks>
    public interface IExampleTypeApplicationService
        : ICrudStateAppService<ExampleTypeReadDto, ExampleTypeReadDto, ExampleTypeReadDto>
    {
    }
}
