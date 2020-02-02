using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YourContacts.Models;

namespace YourContacts.Services
{
    public class ApiService : IApiService
    {
        public async Task<Contact> GetContacts()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = await client.GetAsync($"{Config.ApiUrl}/");
                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    Contact getContact = JsonConvert.DeserializeObject<Contact>(jsonString);
                    return getContact;
                }
                return new Contact();
            }
        }
    }
}
