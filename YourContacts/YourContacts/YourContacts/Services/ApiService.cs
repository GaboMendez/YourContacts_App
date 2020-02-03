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
        public async Task<Contact> GetRandomContacts()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = new HttpResponseMessage();
                Contact ret = new Contact();
                
                ret.results = new List<Result>();
                for (int i = 0; i < 20; i++)
                {
                    Result value = new Result();
                    value = await GetContactsById(i);
                    if (value.CatchError)
                    {
                        i--;
                        continue;
                    }
                    ret.results.Add(value);
                    if (ret.results.Count.Equals(10))
                    {
                        break;
                    }
                }
                return ret;
            }
        }

        public async Task<Result> GetContactsById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.GetAsync($"{Config.ApiUrl}/?result={id}");
                    if (response != null)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        Contact getContact = JsonConvert.DeserializeObject<Contact>(jsonString);
                        Result ret = getContact.results[0];
                        return ret;
                    }
                    return new Result();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Result ret = new Result();
                    ret.CatchError = true;
                    return ret;

                }
            }
        }
    }
}
