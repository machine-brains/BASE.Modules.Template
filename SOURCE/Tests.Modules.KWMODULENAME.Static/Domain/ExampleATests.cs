using App.Modules.KWMODULENAME.Domain.Domains.Examples.Structures.AtRest.Entities.Implementations;
using Tests.Modules.KWMODULENAME.Static.Helpers;

namespace Tests.Modules.KWMODULENAME.Static.Domain
{
	/// <summary>
	/// Tests for <see cref="ExampleA"/> domain entity.
	/// Verifies entity construction, defaults, and basic constraints.
	/// </summary>
	[Trait(TestTraits.Mode, TestTraits.Modes.Static)]
	[Trait(TestTraits.Capability, TestTraits.Capabilities.Examples)]
	[Trait(TestTraits.Quality, TestTraits.Iso25010.FunctionalSuitability.Correctness)]
	public class ExampleATests
	{
		[Fact]
		public void WhenCreated_ThenIdIsNotEmpty()
		{
			// Arrange & Act
			var entity = new ExampleA();

			// Assert — DefaultEntityBase auto-generates a Guid via UUIDFactory
			Assert.NotEqual(Guid.Empty, entity.Id);
		}

		[Fact]
		public void WhenCreated_ThenTitleDefaultsToEmpty()
		{
			// Arrange & Act
			var entity = new ExampleA();

			// Assert
			Assert.Equal(string.Empty, entity.Title);
		}

		[Fact]
		public void WhenCreated_ThenDescriptionDefaultsToEmpty()
		{
			// Arrange & Act
			var entity = new ExampleA();

			// Assert
			Assert.Equal(string.Empty, entity.Description);
		}

		[Fact]
		public void WhenCreated_ThenIsActiveDefaultsToFalse()
		{
			// Arrange & Act
			var entity = new ExampleA();

			// Assert
			Assert.False(entity.IsActive);
		}

		[Fact]
		public void WhenTitleSet_ThenTitleIsRetained()
		{
			// Arrange
			var entity = new ExampleA();
			const string expected = "Test Title";

			// Act
			entity.Title = expected;

			// Assert
			Assert.Equal(expected, entity.Title);
		}

		[Fact]
		public void WhenCreated_ThenTwoInstancesHaveDifferentIds()
		{
			// Arrange & Act
			var a = new ExampleA();
			var b = new ExampleA();

			// Assert — each instance gets a unique auto-generated Id
			Assert.NotEqual(a.Id, b.Id);
		}
	}
}
