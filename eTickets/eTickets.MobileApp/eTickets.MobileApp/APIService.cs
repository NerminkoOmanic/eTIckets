using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using eTickets.Model;
using Flurl.Http;
using Xamarin.Forms;


namespace eTickets.MobileApp
{
    public class APIService
    {
        private string _resource = null;
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static eTickets.Model.Korisnik PrijavljeniKorisnik { get; set; }

#if DEBUG
        private string _apiUrl = "http://localhost:65010/api/";
#endif
#if RELEASE
        private string _apiUrl = "https://mywebsite.com/api/";
#endif

        public APIService(string resource)
        {
            _resource = resource;
        }

        public async Task<T> Get<T>(object search,  string actionName = "")
        {

            var url = $"{_apiUrl}{_resource}";

            
                if (!actionName.Equals(""))
                {
                    url += "/";
                    url += actionName;
                }

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }
                if (_resource.Equals("korisnik") && string.IsNullOrEmpty(actionName) )
                {
                    return await url.GetJsonAsync<T>();
                }
                return await url.WithBasicAuth(Username,Password).GetJsonAsync<T>();
            
            
        }

        public async Task<T> GetById<T>(object id)
        {

            try
            {
                var url = $"{_apiUrl}{_resource}/{id}";
                return await url.WithBasicAuth(Username,Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                throw;
            }
        }

        public async Task<T> Insert<T>(object request)
        {

            try
            {
                var url = $"{_apiUrl}{_resource}";

                if (_resource.Equals("korisnik"))
                {
                    return  await url.PostJsonAsync(request).ReceiveJson<T>();
                }

                return await url.WithBasicAuth(Username,Password).PostJsonAsync(request).ReceiveJson<T>();

            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }

        public async Task<T> Update<T>(object id,object request)
        {
            
            try
            {
                var url = $"{_apiUrl}{_resource}/{id}";

                return await url.WithBasicAuth(Username,Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");

                return default(T);
            }
            
        }

        public async Task<bool> Remove(int id)
        {
            var url = $"{_apiUrl}{_resource}/{id}";

            try
            {
                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return false;
            }
        }
      
    }
}
