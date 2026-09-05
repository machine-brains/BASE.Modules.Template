using App.Modules.KWMODULENAME.Domain.Domains.Examples.Constants;
using App.Modules.Sys.Shared.Attributes;
using App.Modules.Sys.Shared.Domains.Configuration.Attributes;
using App.Modules.Sys.Shared.Domains.Configuration.Models;
using App.Modules.Sys.Shared.Domains.Configuration.Services;

namespace App.Modules.KWMODULENAME.Domain.Domains.Examples.Configuration
{
    /// <summary>
    /// Example nested service configuration contract.
    /// </summary>
    /// <remarks>
    /// This demonstrates that a module-level <see cref="IConfigurationsGroup"/>
    /// can contain a nested <see cref="IServiceConfiguration"/> subtree used to configure one concrete injected service.
    /// The module object owns the broader section, while the service configuration owns the service-specific shape.
    /// </remarks>
    public interface IAnotherExampleServiceConfiguration : IServiceConfiguration
    {
        [ConfigurationPropertyDescriptionAttribute(
            true,
            false,
            KWMODULENAMEConfigKeys.AnotherExampleServiceUrl,
            "Another Example Service Url",
            "Shared base URL used by the nested AnotherExample service configuration.",
            "https://example.com/api")]
        string ServiceUrl { get; set; }
    }
}
