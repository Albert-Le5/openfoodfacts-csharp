using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenFoodFacts.Login
{
    public class LoginApi : ILoginApi
    {
        private readonly Uri baseUri;
        private readonly HttpClient client;

        public bool IsLoggedIn { get; protected set; }

        public LoginApi(Uri baseUri, ref HttpClient client)
        {
            this.baseUri = baseUri;
            this.client = client;
        }

        public async Task<bool> LoginAsync(string user, string pass)
        {
            var formVariables = new List<KeyValuePair<string, string>>(3);
            formVariables.Add(new KeyValuePair<string, string>(".submit", "Sign+in"));
            formVariables.Add(new KeyValuePair<string, string>("user_id", user));
            formVariables.Add(new KeyValuePair<string, string>("password", pass));

            var targetUri = new Uri(baseUri, string.Join('/', URLs.ServiceCgiSuffix, "session.pl"));
            var res = await client.PostAsync(targetUri, new FormUrlEncodedContent(formVariables));

            var content = await res.Content.ReadAsStringAsync();
            return content.Contains("You are connected as");
        }

        public async Task<bool> LogoutAsync()
        {
            var formVariables = new List<KeyValuePair<string, string>>(1);
            formVariables.Add(new KeyValuePair<string, string>(".submit", "Sign-out"));

            var targetUri = new Uri(baseUri, string.Join('/', URLs.ServiceCgiSuffix, "session.pl"));
            var res = await client.PostAsync(targetUri, new FormUrlEncodedContent(formVariables));

            var content = await res.Content.ReadAsStringAsync();
            return content.Contains("See you soon!");
        }
    }
}
