using Microsoft.Extensions.DependencyInjection;

namespace GeoCubed.Validation;

/// <summary>
/// Service registration class for registering the services provided by the validation library.
/// </summary>
public static class ValidationServiceRegistration
{
    // TODO: I might not need this.
    // I might make my validator both an injected service and a static class to refernce.

    /// <summary>
    /// Add the services provided by the validation library to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        // TODO: Register the service.

        return services;
    }
}
