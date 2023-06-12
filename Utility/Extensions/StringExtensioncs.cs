using Azure.Core;
using System.Runtime.CompilerServices;

namespace UrlShortener.Utility.Extensions
{
    public static class StringExtensioncs
    {
        public static bool IsValidUrl(this string url)
        {
            Uri urlOrigin;
            return Uri.TryCreate(url, UriKind.Absolute, out urlOrigin);
        }
    }
}
