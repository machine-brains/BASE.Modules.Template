using App.Modules.KWMODULENAME;
using App.Modules.KWMODULENAME.Infrastructure.Persistence.EF.DbContexts.Implementations;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.DbContexts.Implementations.Base;

namespace App.Modules.KWMODULENAME.Infrastructure.Persistence.EF.DbContexts.DesignTime.Implementations
{
    /// <summary>
    /// Design-time factory for this module's <see cref="ModuleDbContext"/>.
    /// Automatically discovered by <c>dotnet ef migrations</c> tooling.
    /// </summary>
    public class DesignTimeModuleDbContextFactory : DesignTimeModuleDbContextFactoryBase<ModuleDbContext>
    {
        /// <inheritdoc/>
        protected override string SchemaKey => ModuleConstants.DbSchemaKey;
    }
}
