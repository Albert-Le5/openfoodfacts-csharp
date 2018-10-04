using System;
using System.Text;

namespace OpenFoodFacts.Tools
{
    public static class Utils
    {
        public static string GetDomain(bool isTest = false)
        { return isTest ? "net" : "org"; }

        public static Uri BuildBaseUri(
            string geography = "world",
            string locale = "en",
            bool isTest = false)
        { return new Uri(string.Format(URLs.BaseUrlFormat, geography, locale, GetDomain(isTest))); }
    }
}
