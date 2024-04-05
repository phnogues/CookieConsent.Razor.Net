function setCookie(cName, cValue, expDays) {
    let date = new Date();
    date.setTime(date.getTime() + (expDays * 24 * 60 * 60 * 1000));
    const expires = "expires=" + date.toUTCString();
    document.cookie = cName + "=" + cValue + "; " + expires + "; path=/;secure;SameSite=Strict";
}

export function acceptCookies(options) {
    setCookie(options.consentOptions.consentCookieName + '.consent', true, options.consentOptions.cookieAcceptedDurationDays);
    setCookie(options.consentOptions.consentCookieName + '.marketing', options.marketingEnabled, options.consentOptions.cookieAcceptedDurationDays);
    setCookie(options.consentOptions.consentCookieName + '.preferences', options.preferencesEnabled, options.consentOptions.cookieAcceptedDurationDays);
    setCookie(options.consentOptions.consentCookieName + '.analytics', options.analyticsEnabled, options.consentOptions.cookieAcceptedDurationDays);

}

export function denyCookies(options) {
    setCookie(options.consentOptions.consentCookieName + '.consent', false, options.consentOptions.cookieDeniedDurationDays);
    setCookie(options.consentOptions.consentCookieName + '.marketing', false, options.consentOptions.cookieDeniedDurationDays);
    setCookie(options.consentOptions.consentCookieName + '.preferences', false, options.consentOptions.cookieAcceptedDurationDays);
    setCookie(options.consentOptions.consentCookieName + '.analytics', false, options.consentOptions.cookieAcceptedDurationDays);
}
