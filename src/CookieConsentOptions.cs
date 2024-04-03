namespace CookieConsent.Razor.Net;

public class CookieConsentOptions
{
    public string ModalTitle { get; set; } = "This website uses cookies to ensure you get the best experience on our website.";

    public bool ModalVerticallyCentered { get; set; } = true;

    public string ConfirmButtonText { get; set; } = "Confirm";

    public string RejectButtonText { get; set; } = "Reject";

    public string ConsentCookieName { get; set; } = "CookieConsent";

    public int CookieAcceptedDurationDays { get; set; } = 30;

    public int CookieDeniedDurationDays { get; set; } = 4;

    public StrictlyNecessaryCookies StrictlyNecessaryCookies { get; set; } = new();

    public AnalyticsCookies AnalyticsCookies { get; set; } = new();

    public bool HasAnalyticsCookies => AnalyticsCookies.Cookies != null && AnalyticsCookies.Cookies.Any();

    public bool HasStrictlyNecessaryCookies => StrictlyNecessaryCookies.Cookies != null && StrictlyNecessaryCookies.Cookies.Any();
}

public class StrictlyNecessaryCookies
{
    public string Title { get; set; } = "Strictly Necessary";

    public List<CookieConsentCookies> Cookies { get; set; }
}

public class AnalyticsCookies
{
    public string Title { get; set; } = "Analytics";

    public List<CookieConsentCookies> Cookies { get; set; }
}

public class CookieConsentCookies
{
    public string Domain { get; set; }

    public string Name { get; set; }

    public string PrivacyPolicyLink { get; set; }

    public string PrivacyPolicyDescription { get; set; }
}
