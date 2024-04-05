namespace CookieConsent.Razor.Net;

public class CookieConsentOptions
{
    public string ModalTitle { get; set; } = "This website uses cookies to ensure you get the best experience on our website.";

    public bool ModalVerticallyCentered { get; set; } = true;

    public string ConfirmButtonText { get; set; } = "Confirm";

    public string RejectButtonText { get; set; } = "Reject";

    public string ConsentCookieName { get; set; } = "CookieConsent";

    public string PrivacyPolicyUrl { get; set; }

    public int CookieAcceptedDurationDays { get; set; } = 30;

    public int CookieDeniedDurationDays { get; set; } = 4;

    public bool ReloadPageOnUserActions { get; set; } = true;

    public StrictlyNecessaryCookies FunctionalCookies { get; set; } = new();

    public MarketingCookies MarketingCookies { get; set; } = new();

    public AnalyticsCookies AnalyticsCookies { get; set; } = new();

    public PreferencesCookies PreferencesCookies { get; set; } = new();

    public bool HasMarketingCookies => MarketingCookies.Cookies != null && MarketingCookies.Cookies.Any();

    public bool HasFunctionalCookies => FunctionalCookies.Cookies != null && FunctionalCookies.Cookies.Any();

    public bool HasAnalyticsCookies => AnalyticsCookies.Cookies != null && AnalyticsCookies.Cookies.Any();

    public bool HasPreferencesCookies => PreferencesCookies.Cookies != null && PreferencesCookies.Cookies.Any();
}

public class StrictlyNecessaryCookies
{
    public string Title { get; set; } = "Strictly Necessary";

    public List<CookieConsentCookies> Cookies { get; set; } = new();
}

public class AnalyticsCookies
{
    public string Title { get; set; } = "Analytics";

    public List<CookieConsentCookies> Cookies { get; set; } = new();
}

public class MarketingCookies
{
    public string Title { get; set; } = "Marketing";

    public List<CookieConsentCookies> Cookies { get; set; } = new();
}

public class PreferencesCookies
{
    public string Title { get; set; } = "Preferences";

    public List<CookieConsentCookies> Cookies { get; set; } = new();
}

public class CookieConsentCookies
{
    public string Domain { get; set; }

    public string Name { get; set; }

    public string? PrivacyPolicyLink { get; set; }

    public string? PrivacyPolicyDescription { get; set; }
}
