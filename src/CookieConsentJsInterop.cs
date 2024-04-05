using Microsoft.JSInterop;

namespace CookieConsent.Razor.Net;

public class CookieConsentJsInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
    private readonly CookieConsentAccessor _cookieConsentAccessor;

    public CookieConsentJsInterop(IJSRuntime jsRuntime, CookieConsentAccessor cookieConsentAccessor)
    {
        _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/CookieConsent.Razor.Net/js/cookieConsentJsInterop.js").AsTask());

        _cookieConsentAccessor = cookieConsentAccessor;
    }

    public async Task Accept(bool canTrack)
    {
        var module = await _moduleTask.Value;

        var cookieOptions = new CookiesJsOptions
        {
            ConsentOptions = _cookieConsentAccessor.Options,
            Consent = true,
            CanTrack = canTrack
        };

        await module.InvokeVoidAsync("acceptCookies", cookieOptions);
    }

    public async Task Deny()
    {
        var module = await _moduleTask.Value;

        var cookieOptions = new CookiesJsOptions
        {
            ConsentOptions = _cookieConsentAccessor.Options,
            Consent = false
        };

        await module.InvokeVoidAsync("denyCookies", cookieOptions);
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}

public class CookiesJsOptions
{
    public CookieConsentOptions ConsentOptions { get; set; }

    public bool Consent { get; set; }

    public bool CanTrack { get; set; }
}