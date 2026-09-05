using App.Modules.KWMODULENAME.Domain.Domains.Examples.Structures.AtRest.Entities.Implementations;
using App.Modules.Sys.Substrate.Domains.Indexes;
using Tests.Modules.KWMODULENAME.Static.Helpers;

namespace Tests.Modules.KWMODULENAME.Static.Domain
{
	/// <summary>
	/// Tests for <see cref="ExampleB"/> domain entity.
	/// Verifies entity construction, defaults, and FK constraints.
	/// </summary>
	[Trait(TestTraits.Mode, TestTraits.Modes.Static)]
	[Trait(TestTraits.Capability, TestTraits.Capabilities.Examples)]
	[Trait(TestTraits.Quality, TestTraits.Iso25010.FunctionalSuitability.Correctness)]
	public class ExampleBTests
	{
		[Fact]
		public void WhenCreated_ThenIdIsNotEmpty()
		{
			// Arrange & Act
			var entity = new ExampleB();

			// Assert — DefaultEntityBase auto-generates a Guid via UUIDFactory
			Assert.NotEqual(Guid.Empty, entity.Id);
		}

		[Fact]
		public void WhenCreated_ThenExampleAIdDefaultsToEmpty()
		{
			// Arrange & Act
			var entity = new ExampleB();

			// Assert — FK is not auto-generated, defaults to Guid.Empty
			Assert.Equal(Guid.Empty, entity.ExampleAId);
		}

		[Fact]
		public void WhenCreated_ThenNameDefaultsToEmpty()
		{
			// Arrange & Act
			var entity = new ExampleB();

			// Assert
			Assert.Equal(string.Empty, entity.Name);
		}

		[Fact]
		public void WhenCreated_ThenSortOrderDefaultsToZero()
		{
			// Arrange & Act
			var entity = new ExampleB();

			// Assert
			Assert.Equal(0, entity.SortOrder);
		}

		[Fact]
		public void WhenParentIdSet_ThenParentIdIsRetained()
		{
			// Arrange
			var entity = new ExampleB();
			var parentId = UUIDFactory.NewGuid();

			// Act
			entity.ExampleAId = parentId;

			// Assert
			Assert.Equal(parentId, entity.ExampleAId);
		}
	}
}
