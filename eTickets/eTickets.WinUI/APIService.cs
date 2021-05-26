using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using eTickets;
using eTickets.WinUI.Properties;
using eTickets.Model;

namespace eTickets.WinUI
{
    public class APIService
    {
        private string _resource = null;

        private string _endpoint = $"{Properties.Settings.Default.APIUrl}";

        public static string Username { get; set; }
        public static string Password { get; set; }
        public static eTickets.Model.Korisnik PrijavljeniKorisnik { get; set; }

        public APIService(string resource)
        {
            _resource = resource;
        }

        public async Task<T> Get<T>(object search,  string actionName = "")
        {

            var url = $"{_endpoint}{_resource}";

            if (actionName != null)
            {
                url += "/";
                url += actionName;
            }

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }
            return await url.WithBasicAuth(Username,Password).GetJsonAsync<T>();
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_endpoint}{_resource}/{id}";

            return await url.WithBasicAuth(Username,Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_endpoint}{_resource}";

            return await url.WithBasicAuth(Username,Password).PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object id,object request)
        {
            var url = $"{_endpoint}{_resource}/{id}";

            return await url.WithBasicAuth(Username,Password).PutJsonAsync(request).ReceiveJson<T>();

            
        }

      
    }
}
