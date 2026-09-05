using App.Modules.KWMODULENAME.Application.Domains.Examples.Services.Implementations;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;
using App.Modules.Sys.Shared.Domains.Persistence.Repositories;
using NSubstitute;
using App.Modules.Sys.Substrate.Domains.Indexes;
using App.Modules.KWMODULENAME.Domain.Domains.Examples.Structures.AtRest.Entities.Implementations;
using App.Modules.KWMODULENAME.Application.Domains.Examples.Structures.InTransit.Dtos;
using Tests.Modules.KWMODULENAME.Static.Helpers;

namespace Tests.Modules.KWMODULENAME.Static.Application
{
	/// <summary>
	/// Tests for <see cref="ExampleAApplicationService"/>.
	/// Verifies that the CRUST service correctly delegates to the
	/// repository and mapper via the base class plumbing.
	/// </summary>
	[Trait(TestTraits.Mode, TestTraits.Modes.Static)]
	[Trait(TestTraits.Capability, TestTraits.Capabilities.Examples)]
	[Trait(TestTraits.Quality, TestTraits.Iso25010.FunctionalSuitability.Correctness)]
	public class ExampleAApplicationServiceTests
	{
		private readonly ICrustStateRepository<ExampleA> _repository;
		private readonly IObjectMappingService _mapper;
		private readonly IAppLogger _logger;
		private readonly ExampleAApplicationService _service;

		/// <summary>
		/// Sets up mocked dependencies for each test.
		/// </summary>
		public ExampleAApplicationServiceTests()
		{
			this._repository = Substitute.For<ICrustStateRepository<ExampleA>>();
			this._mapper = Substitute.For<IObjectMappingService>();
			this._logger = Substitute.For<IAppLogger>();
			this._service = new ExampleAApplicationService(
				this._repository, this._mapper, this._logger);
		}

		[Fact]
		public void WhenQueryCalled_ThenProjectToIsInvokedOnce()
		{
			// Arrange
			var entities = new List<ExampleA>().AsQueryable();
			var expectedDtos = new List<ExampleAReadDto>().AsQueryable();
			this._repository.Query().Returns(entities);
			this._mapper
				.ProjectTo<ExampleA, ExampleAReadDto>(Arg.Any<IQueryable<ExampleA>>())
				.Returns(expectedDtos);

			// Act
			var result = this._service.Query();

			// Assert
			Assert.NotNull(result);
			this._mapper.Received(1)
				.ProjectTo<ExampleA, ExampleAReadDto>(Arg.Any<IQueryable<ExampleA>>());
		}

		[Fact]
		public void WhenQueryByIdCalled_ThenProjectToIsInvokedOnce()
		{
			// Arrange
			var id = UUIDFactory.NewGuid();
			var entities = new List<ExampleA>().AsQueryable();
			var expectedDtos = new List<ExampleAReadDto>().AsQueryable();
			this._repository.QueryById(id).Returns(entities);
			this._mapper
				.ProjectTo<ExampleA, ExampleAReadDto>(Arg.Any<IQueryable<ExampleA>>())
				.Returns(expectedDtos);

			// Act
			var result = this._service.QueryById(id);

			// Assert
			Assert.NotNull(result);
			this._mapper.Received(1)
				.ProjectTo<ExampleA, ExampleAReadDto>(Arg.Any<IQueryable<ExampleA>>());
		}

		[Fact]
		public void WhenConstructedWithNullRepository_ThenThrowsArgumentNullException()
		{
			// Arrange, Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				new ExampleAApplicationService(null!, this._mapper, this._logger));
		}

		[Fact]
		public void WhenConstructedWithNullMapper_ThenThrowsArgumentNullException()
		{
			// Arrange, Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				new ExampleAApplicationService(this._repository, null!, this._logger));
		}
	}
}
