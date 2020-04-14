using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Services.RequestProvider
{
    public interface IRequestProvider
    {
        Task<string> GetAsync(string uri, string token = "", Dictionary<string, string> headers = null);

        Task<string> PostAsync(string uri, object data, string token = "", Dictionary<string, string> headers = null);

        Task<string> PutAsync(string uri, object data, string token = "", Dictionary<string, string> headers = null);

        Task<string> PatchAsync(string uri, object data, string token = "", Dictionary<string, string> headers = null);


    }
}
