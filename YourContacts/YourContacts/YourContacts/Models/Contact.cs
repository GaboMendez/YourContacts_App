using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourContacts.Models
{
    public class Contact
    {
        [JsonProperty("results")]
        public List<Result> results { get; set; }

    }

    public class Result
    {
        [JsonProperty("gender")]
        public string gender { get; set; }

        [JsonProperty("name")]
        public Name name { get; set; }

        [JsonProperty("location")]
        public Location location { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("dob")]
        public Dob dob { get; set; }

        [JsonProperty("phone")]
        public string phone { get; set; }

        [JsonProperty("cell")]
        public string cell { get; set; }

        [JsonProperty("picture")]
        public Picture picture { get; set; }

        [JsonProperty("nat")]
        public string nat { get; set; }

        public bool CatchError { get; set; }
    }

    public class Name
    {
        [JsonProperty("title")]
        public string title { get; set; }
        
        [JsonProperty("first")]
        public string first { get; set; }

        [JsonProperty("last")]
        public string last { get; set; }

        public string fullName { get; set; }

        public override string ToString()
        {
            return $"{title}. {first} {last}";
        }
    }
    public class Location
    {
        [JsonProperty("street")]
        public Street street { get; set; }

        [JsonProperty("city")]
        public string city { get; set; }

        [JsonProperty("state")]
        public string state { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("postcode")]
        public int postcode { get; set; }


    }

    public class Street
    {
        [JsonProperty("number")]
        public int number { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Dob
    {
        [JsonProperty("date")]
        public DateTime date { get; set; }

        [JsonProperty("age")]
        public int age { get; set; }
    }

    public class Picture
    {
        [JsonProperty("large")]
        public string large { get; set; }

        [JsonProperty("medium")]
        public string medium { get; set; }

        [JsonProperty("thumbnail")]
        public string thumbnail { get; set; }
    }
}
