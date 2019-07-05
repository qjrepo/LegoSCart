using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Asplego.Models;
using Newtonsoft.Json;



namespace Asplego.Models
{
    public class UsersClient
    {
        string _hostUri;
        private HttpClient client;

        public UsersClient(string hostUri)
        {
            _hostUri = hostUri;
        }

        public HttpClient CreateClient()
        {

            client = new HttpClient();

            client.BaseAddress = new Uri(new Uri(_hostUri), "api/users/");//changed from users to userss

            return client;
        }
        public HttpClient CreateActionClient(string action)
        {

            client = new HttpClient();

            client.BaseAddress = new Uri(new Uri(_hostUri), "api/users/" + action);

            return client;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {

            using (var clients = CreateClient())//changed client to clients
            {

                HttpResponseMessage response;

                response = client.GetAsync(client.BaseAddress).Result;//changed client to clients

                //var result = response.Content.ReadAsAsync<IEnumerable<Student>>().Result; 
                if (response.IsSuccessStatusCode)
                {

                    var avail = await response.Content.ReadAsStringAsync()

                        .ContinueWith<IEnumerable<User>>(postTask =>
                        {
                            return JsonConvert.DeserializeObject<IEnumerable<User>>(postTask.Result);
                        });

                    return avail;
                }
                else
                {

                    return null;
                }


            } //return result;



        }
        public async Task<IEnumerable<User>> GetUsersAsync(string ep)
        {

            using (var clients = CreateClient())//changed client to clients
            {

                HttpResponseMessage response;

                response = clients.GetAsync(new Uri(client.BaseAddress, ep)).Result;//changed client to clients
                if (response.IsSuccessStatusCode)
                {

                    var avail = await response.Content.ReadAsStringAsync()

                    .ContinueWith<IEnumerable<User>>(postTask => { return JsonConvert.DeserializeObject<IEnumerable<User>>(postTask.Result); });

                    return avail;
                }
                else
                {

                    return null;
                }
            }
        }
        public System.Net.HttpStatusCode AddUser(User user)
        {

            using (var clients = CreateActionClient("Post01"))//changed client to clients
            {
                HttpResponseMessage response = null;
                try
                {
                    var output = JsonConvert.SerializeObject(user);
                    HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                    response = client.PostAsync(client.BaseAddress, contentPost).Result;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                return response.StatusCode;

            }
        }
        public System.Net.HttpStatusCode UpdateUser(User user)
        {
            using (var clients = CreateActionClient("Put01"))//changed client to clients
            {
                HttpResponseMessage response;
                //response = client.PutAsJsonAsync(client.BaseAddress, company).Result; 
                var output = JsonConvert.SerializeObject(user);
                HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                response = clients.PostAsync(client.BaseAddress, contentPost).Result; //changed client to clients
                return response.StatusCode;

            }


        }
        public async Task<System.Net.HttpStatusCode> UpdateUserAsync(User user)
        {
            using (var clients = CreateActionClient("Post01"))//changed client to clients
            {
                HttpResponseMessage response;
                //response = client.PutAsJsonAsync(client.BaseAddress, company).Result; 
                var output = JsonConvert.SerializeObject(user);
                HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                response = await clients.PostAsync(client.BaseAddress, contentPost); //changed client to clients
                return response.StatusCode;
            }

        }


    }
}
