using Microsoft.AspNetCore.Http;

namespace CookieConsent.Razor.Net.Middlewares;

public class CookieConsentMiddleware
{
    private readonly RequestDelegate _next;
    private readonly CookieConsentAccessor _cookieConsent;

    public CookieConsentMiddleware(RequestDelegate next, CookieConsentAccessor cookieConsent)
    {
        _next = next;
        _cookieConsent = cookieConsent;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _cookieConsent.Consent = context.Request.Cookies[$"{_cookieConsent.Options.ConsentCookieName}.consent"] == "true";
        _cookieConsent.CanTrack = context.Request.Cookies[$"{_cookieConsent.Options.ConsentCookieName}.canTrack"] == "true";
        _cookieConsent.ShowBanner = context.Request.Cookies[$"{_cookieConsent.Options.ConsentCookieName}.consent"] == null;

        await _next(context);
    }
}