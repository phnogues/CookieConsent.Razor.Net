using BlazorBootstrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CookieConsent.Razor.Net;

public static class CookieConsentMiddlewareExtensions
{
    public static IApplicationBuilder UseCookieConsent(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CookieConsentMiddleware>();
    }

    public static IServiceCollection AddCookieConsent(this IServiceCollection services, Action<CookieConsentOptions> optionsBuilder = null)
    {
        services.AddScoped<CookieConsentJsInterop>();
        if (!services.Any(x => x.ServiceType == typeof(ModalService)))
        {
            services.AddBlazorBootstrap();
        }

        var options = new CookieConsentOptions();

        if (optionsBuilder != null)
        {
            optionsBuilder(options);
        }

        services.AddSingleton(new CookieConsentAccessor(options));

        return services;
    }
}