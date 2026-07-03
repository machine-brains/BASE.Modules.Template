namespace App.Modules.KWMODULENAME.Domain.Domains.Examples.Structures.AtRest.Enums
{
    /// <summary>
    /// Enum whose values deterministically map to <see cref="Entities.Implementations.ExampleType"/> Guid IDs
    /// via <c>DeterministicGuid.FromEnum()</c>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// These are the built-in (System) example types. End users may add more
    /// via the UI — those custom entries will have their own Guid IDs that do
    /// not correspond to any enum member.
    /// </para>
    /// <para>
    /// Enum values are NEVER stored directly in the database.
    /// They exist solely so that code can reference well-known seed entries
    /// by a stable, deterministic identifier.
    /// </para>
    /// <para>
    /// <b>Enum convention:</b> all enums must start with the standard sentinel
    /// triple (
    /// <c>Undefined = 0</c>,
    /// <c>NotApplicable = 1</c>,
    /// <c>Unknown = 2</c>,
    /// <c>Unspecified = 3</c>)
    /// with real values beginning at 4.
    /// See <c>Tests.Solution.Quality.Maintainability.EnumConventionTests</c>
    /// for enforcement and rationale.
    /// </para>
    /// </remarks>
    public enum ExampleTypeCode
	{
		/// <summary>
		/// Not set. Indicates a programming error or
        /// uninitialised value.
		/// </summary>
		Undefined = 0,

		/// <summary>
		/// Not applicable in this context.
		/// </summary>
		NotApplicable = 1,

		/// <summary>
		/// Consciously left unspecified.
        /// The value is intentionally not provided.
		/// </summary>
		Unspecified = 2,

		/// <summary>
		/// Unknown or unresolvable state.
		/// </summary>
		Unknown = 3,

		/// <summary>A general-purpose example type.</summary>
		General = 4,

		/// <summary>A specialised example type.</summary>
		Specialised = 5,

		/// <summary>An advanced example type.</summary>
		Advanced = 6
	}
}
