
namespace CookieConsent.Razor.Net;

public class CookieConsentAccessor
{
    public CookieConsentOptions Options = new();

    public CookieConsentAccessor(CookieConsentOptions options)
    {
        this.Options = options;
    }

    public bool CanTrack { get; set; }

    public bool Consent { get; set; }

    public bool ShowBanner { get; set; }
}
