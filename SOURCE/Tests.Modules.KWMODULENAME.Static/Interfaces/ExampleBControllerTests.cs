using App.Modules.KWMODULENAME.Application.Domains.Examples.Services;
using App.Modules.KWMODULENAME.Interfaces.API.REST.Domains.V1.Examples;
using NSubstitute;
using App.Modules.Sys.Shared.Domains.Indexes;
using App.Modules.KWMODULENAME.Application.Domains.Examples.Structures.InTransit.Dtos;
using Tests.Modules.KWMODULENAME.Static.Helpers;

namespace Tests.Modules.KWMODULENAME.Static.Interfaces
{
	/// <summary>
	/// Tests for <see cref="ExampleBController"/>.
	/// Verifies the CRUST controller delegates to the service
	/// via the base class plumbing.
	/// </summary>
	[Trait(TestTraits.Mode, TestTraits.Modes.Static)]
	[Trait(TestTraits.Capability, TestTraits.Capabilities.Examples)]
	[Trait(TestTraits.Quality, TestTraits.Iso25010.FunctionalSuitability.Correctness)]
	public class ExampleBControllerTests
	{
		private readonly IExampleBApplicationService _mockService;
		private readonly ExampleBController _controller;

		/// <summary>
		/// Sets up a mocked service and controller for each test.
		/// </summary>
		public ExampleBControllerTests()
		{
			this._mockService = Substitute.For<IExampleBApplicationService>();
			this._controller = new ExampleBController(this._mockService);
		}

		[Fact]
		public void WhenGetAllCalled_ThenDelegatesToServiceQuery()
		{
			// Arrange
			var expectedDtos = new List<ExampleBReadDto>
			{
				new ExampleBReadDto { Id = UUIDFactory.NewGuid(), Name = "First" },
				new ExampleBReadDto { Id = UUIDFactory.NewGuid(), Name = "Second" }
			}.AsQueryable();

			this._mockService.Query().Returns(expectedDtos);

			// Act
			var result = this._controller.GetAll();

			// Assert
			Assert.NotNull(result);
			Assert.Equal(2, result.Count());
			this._mockService.Received(1).Query();
		}

		[Fact]
		public void WhenGetByIdCalled_ThenDelegatesToServiceQueryById()
		{
			// Arrange
			var id = UUIDFactory.NewGuid();
			var expectedDtos = new List<ExampleBReadDto>
			{
				new ExampleBReadDto { Id = id, Name = "Found" }
			}.AsQueryable();

			this._mockService.QueryById(id).Returns(expectedDtos);

			// Act
			var result = this._controller.GetById(id);

			// Assert
			Assert.NotNull(result);
			Assert.Single(result);
			this._mockService.Received(1).QueryById(id);
		}

		[Fact]
		public void WhenConstructedWithNullService_ThenThrowsArgumentNullException()
		{
			// Arrange, Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				new ExampleBController(null!));
		}
	}
}
