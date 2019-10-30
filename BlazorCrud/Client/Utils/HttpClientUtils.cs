using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorCrud.Client.Utils
{
    public static class HttpClientUtils
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string action, string controller)
        {
            return await httpClient.GetJsonAsync<T>($"/api/{controller}/{action}");
        }
    }
}
