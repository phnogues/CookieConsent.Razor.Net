using BlazorApp.Components;
using CookieConsent.Razor.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCookieConsent(options =>
{
    options.PrivacyPolicyUrl = "https://www.example.com/privacy-policy";
    options.ConsentCookieName = "DemoProject";
    options.CookieAcceptedDurationDays = 40;
    options.CookieDeniedDurationDays = 5;
    options.FunctionalCookies = new()
    {
        Cookies = new()
                    {
                        new()
                        {
                            Domain = "Azure cookie",
                            Name = "__aspAzureDemo",
                            PrivacyPolicyLink = "https://azure.microsoft.com/en-us/explore/trusted-cloud/privacy"
                        },
                        new()
                        {
                            Domain = "Antiforgery Cookie",
                            Name = "NapiAntiforgeryCookie",
                            PrivacyPolicyDescription = "Security system (cookie-based authentication)"
                        }
                    }
    };
    options.MarketingCookies = new()
    {
        Cookies = new()
                {
                    new()
                    {
                        Domain = "Google Analytics",
                        Name = "_ga, _gid, _gat",
                        PrivacyPolicyLink = "https://policies.google.com/privacy?hl=en"
                    }
                }
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseCookieConsent();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
