using Microsoft.AspNetCore.Http;

namespace CookieConsent.Razor.Net;

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
        _cookieConsent.MarketingEnabled = context.Request.Cookies[$"{_cookieConsent.Options.ConsentCookieName}.marketing"] is not null ? context.Request.Cookies[$"{_cookieConsent.Options.ConsentCookieName}.marketing"] == "true" : true;
        _cookieConsent.PreferencesEnabled = context.Request.Cookies[$"{_cookieConsent.Options.ConsentCookieName}.preferences"] is not null ? context.Request.Cookies[$"{_cookieConsent.Options.ConsentCookieName}.preferences"] == "true" : true;
        _cookieConsent.AnalyticsEnabled = context.Request.Cookies[$"{_cookieConsent.Options.ConsentCookieName}.analytics"] is not null ? context.Request.Cookies[$"{_cookieConsent.Options.ConsentCookieName}.analytics"] == "true" : true;
        _cookieConsent.ShowBanner = context.Request.Cookies[$"{_cookieConsent.Options.ConsentCookieName}.consent"] == null;

        await _next(context);
    }
}