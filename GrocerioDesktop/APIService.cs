using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;
using GrocerioModels.Login;
using GrocerioModels.Response;

namespace GrocerioDesktop
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static LoginResponse LoginData { get; set; }

        private readonly string _controller = null;

        public APIService(string controller)
        {
            _controller = controller;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_controller}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += search.ToString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Authentication failed");
                }
                throw;
            }
        }
        public async Task<T> Get<T>(object search, string callName)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_controller}/{callName}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += search.ToString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Authentication failed");
                }
                throw;
            }
        }

        public async Task<T> GetLoginData<T>()
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_controller}/{Username}";

            try
            {    
                var response = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
                LoginData = response as LoginResponse;
                return response;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Authentication failed");
                }
                throw;
            }
        }
        public async Task<T> GetUserById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_controller}/GetUserById/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_controller}/GetById/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_controller}";

            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }

        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_controller}/{id}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }

        }

        public async Task<T> SepcifiedPost<T>(object body, string callName)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_controller}/{callName}";

            try
            {
                var response = await url.WithBasicAuth(Username, Password).PostJsonAsync(body).ReceiveJson<T>();
                return response;
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<T> Update<T>(int id, object request,string method)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_controller}/{method}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }

        }
        public async Task<T> UpdateT<T>(int id, object request, string method)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_controller}/{method}/{id}";

                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }

        }

        public async Task<string> Delete<T>(object id, string method)
        {      
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_controller}/{method}/{id}";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync();
                
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
                throw;
            }
        }

        public async Task<string> HandleLock(bool flag)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_controller}/HandleLock/{flag}";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }
        public async Task<BoolResponse> ChangeUserActivity(int id, bool activity)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_controller}/ChangeUserActivity/{id}/{activity}";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }

        }




    }
}
