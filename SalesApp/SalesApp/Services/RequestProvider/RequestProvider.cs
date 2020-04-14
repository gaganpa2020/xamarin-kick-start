using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SalesApp.Services.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {
        HttpClient httpClient;

        public RequestProvider()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<string> GetAsync(string uri, string token = "", Dictionary<string, string> headers = null)
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }
            if (!string.IsNullOrEmpty(token))
            {
                headers.Add("Authorization", "Bearer " + token);
            }

            setHeaders(headers);
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }


        public async Task<string> PostAsync(string uri, object data, string token = "", Dictionary<string, string> headers = null)
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }
            if (!string.IsNullOrEmpty(token))
            {
                headers.Add("Authorization", "Bearer " + token);
            }
            setHeaders(headers);

            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<string> PatchAsync(string uri, object data, string token = "", Dictionary<string, string> headers = null)
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }
            if (!string.IsNullOrEmpty(token))
            {
                headers.Add("Authorization", "Bearer " + token);
            }
            setHeaders(headers);

            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                Content = httpContent
            };
            HttpResponseMessage response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<string> PutAsync(string uri, object data, string token = "", Dictionary<string, string> headers = null)
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }
            if (!string.IsNullOrEmpty(token))
            {
                headers.Add("Authorization", "Bearer " + token);
            }
            setHeaders(headers);

            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync(uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        private void setHeaders(Dictionary<string, string> headers)
        {
            httpClient.DefaultRequestHeaders.Clear();
            foreach (KeyValuePair<string, string> header in headers)
            {
                httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

        }
    }
}
