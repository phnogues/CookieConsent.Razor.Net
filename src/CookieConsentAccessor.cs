
namespace CookieConsent.Razor.Net;

public class CookieConsentAccessor
{
    public CookieConsentOptions Options = new();

    public CookieConsentAccessor(CookieConsentOptions options)
    {
        this.Options = options;
    }

    public bool MarketingEnabled { get; set; } = true;

    public bool PreferencesEnabled { get; set; } = true;

    public bool AnalyticsEnabled { get; set; } = true;

    public bool Consent { get; set; }

    public bool ShowBanner { get; set; }

    public void RegisterCookie(CookieTypeEnum cookieType, string domain, string cookieNames, string? privacyPolicyDescription = null, string? privacyPolicyLink = null)
    {
        // Functional
        if (cookieType == CookieTypeEnum.Functional && !string.IsNullOrEmpty(domain) && !Options.FunctionalCookies.Cookies.Any(c => c.Domain.Equals(domain)))
        {
            Options.FunctionalCookies.Cookies.Add(new CookieConsentCookies
            {
                Domain = domain,
                Name = cookieNames,
                PrivacyPolicyLink = privacyPolicyLink,
                PrivacyPolicyDescription = privacyPolicyDescription
            });
        }

        // Marketing
        if (cookieType == CookieTypeEnum.Marketing && !string.IsNullOrEmpty(domain) && !Options.MarketingCookies.Cookies.Any(c => c.Domain.Equals(domain)))
        {
            Options.MarketingCookies.Cookies.Add(new CookieConsentCookies
            {
                Domain = domain,
                Name = cookieNames,
                PrivacyPolicyLink = privacyPolicyLink,
                PrivacyPolicyDescription = privacyPolicyDescription
            });
        }

        // Analytics
        if (cookieType == CookieTypeEnum.Analytics && !string.IsNullOrEmpty(domain) && !Options.AnalyticsCookies.Cookies.Any(c => c.Domain.Equals(domain)))
        {
            Options.AnalyticsCookies.Cookies.Add(new CookieConsentCookies
            {
                Domain = domain,
                Name = cookieNames,
                PrivacyPolicyLink = privacyPolicyLink,
                PrivacyPolicyDescription = privacyPolicyDescription
            });
        }

        // Preferences
        if (cookieType == CookieTypeEnum.Preferences && !string.IsNullOrEmpty(domain) && !Options.PreferencesCookies.Cookies.Any(c => c.Domain.Equals(domain)))
        {
            Options.PreferencesCookies.Cookies.Add(new CookieConsentCookies
            {
                Domain = domain,
                Name = cookieNames,
                PrivacyPolicyLink = privacyPolicyLink,
                PrivacyPolicyDescription = privacyPolicyDescription
            });
        }
    }
}
