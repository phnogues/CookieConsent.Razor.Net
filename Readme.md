# CookieConsent.Razor.Net
<img src="/src/wwwroot/img/cookie-consent-logo.png" width="100" height="100" />

[![NuGet latest version](https://badgen.net/nuget/v/CookieConsent.Razor.Net/latest)](https://nuget.org/packages/CookieConsent.Razor.Net)
[![.NET](https://github.com/phnogues/CookieConsent.Razor.Net/actions/workflows/build.yml/badge.svg)](https://github.com/phnogues/CookieConsent.Razor.Net/actions/workflows/build.yml)

Demo : https://pierrehenri56-001-site10.ltempurl.com/

## Description
A Consent Management library for Blazor, ASP.NET Core Razor Pages and MVC applications. It provides a simple way to manage user consent for cookies and tracking scripts.
It's GDPR compliant and allows you to display a modal to ask the user for their consent before loading cookies and tracking scripts.
Scripts and cookies are loaded only if the user has accepted them.
Many options are available to customize the modal and the cookies list.
Feel free to contribute to this project :)

## Prerequisites
- Use Blazor Bootstrap Library

## Exemple
An example project can be found in the `example` folder.

## Setup
1. Install the NuGet package
2. Register the services in the `Startup.cs` or `Program.cs` file
- Add
```csharp
builder.Services.AddCookieConsent(options =>
{
    options.PrivacyPolicyUrl = "https://www.example.com/privacy-policy";
    options.ConsentCookieName = "DemoProject"; // Optional, default is "CookieConsent"
    options.CookieAcceptedDurationDays = 40; // Optional, default is 30
    options.CookieDeniedDurationDays = 5; // Optional, default is 4
});
```

- Use
```csharp
app.UseCookieConsent();
```

Other optional settings:
- ModalTitle : Main title of the modal
- ModalVerticallyCentered : true to center the modal vertically
- ConfirmButtonText : Text of the confirm button
- RejectButtonText : Text of the reject button
- ConsentCookieName : Name of the cookie that stores the user's consent
- PrivacyPolicyUrl : URL of your privacy policy
- CookieAcceptedDurationDays : Number of days the cookie is stored when the user accepts
- CookieDeniedDurationDays : Number of days the cookie is stored when the user rejects
- ReloadPageOnUserActions : true to reload the page when the user accepts or rejects

-- Cookies
- FunctionalCookies : List of functional cookies
- MarketingCookies : List of marketing cookies
- AnalyticsCookies : List of analytics cookies
- PreferencesCookies : List of preferences cookies

3. How to define the list of cookies that will be displayed in the modal? ?

It is very simple ! There are two ways to define your cookies :

a. Programmatically from the registration method
```csharp
builder.Services.AddCookieConsent(options =>
{
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
```

b. Adding parameters from the `CookieScriptsSection` component
 ```html
   <CookieScriptsSection CookieType="CookieTypeEnum.Marketing" Domain="Example" CookieNames="__toto, __titi" PrivacyPolicyLink="https://www.example.com/privacy-policy">
        <script type="text/javascript">
            alert('Hey I can track you');
        </script>
    </CookieScriptsSection>
```

4. Where I put my scripts ? How it works ?    ?
From your main page or main layout, you can add the `CookieScriptsSection` component. This component will display the scripts only if the user has accepted the cookies related to the appropriate category.
```html
   <CookieScriptsSection CookieType="CookieTypeEnum.Marketing" Domain="Example" CookieNames="_ga, _twiter" PrivacyPolicyLink="https://www.example.com/privacy-policy">
       Put here your marketing scripts, like Google Analytics, Facebook Pixel, etc.
    </CookieScriptsSection>
```
You can add as many `CookieScriptsSection` components as you want.
You can also mix beetween programmatically and component way.

5. Change the style of the modal
Add a CSS file in your `wwwroot` folder and you will be able to override the default style of the modal.

### Thanks
- Icon <a href="https://www.flaticon.com/fr/icones-gratuites/biscuit" title="biscuit icônes">Biscuit icônes créées par juicy_fish - Flaticon</a>
- Library <a href="https://demos.blazorbootstrap.com/" title="Blazor.Bootstrap">Blazor.Bootstrap</a>


## Enjoy !
<a href="https://www.buymeacoffee.com/phnogues" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;" ></a>
