using System;
using System.Collections.Generic;
using System.Text;
using EventBookingUWP.Data.Models;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace EventBookingUWP.Data.API
{
    public static class APIConsumer
    {

        static HttpClient client = new HttpClient();

        public static void Init() // Base address and Timeout should be set only once for the client to be reuseable
        {
            client.BaseAddress = new Uri("http://localhost:" + Settings.port + "/");
            client.Timeout = TimeSpan.FromSeconds(30);
        }

        public static async Task<T> Get<T>(string path, int id)
        {

            // Update port # in the following line.

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/" + path + "/get/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<T>();
                return content;
            }
            else
            {
                return default;
            }

        }

        public static async Task<IEnumerable<T>> GetAll<T>(string path)
        {


            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/events/get/").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<IEnumerable<T>>();
                return content;
            }
            else
            {
                return null;
            }

        }

        public static async Task<string> Insert<T>(string path, T @event)
        {

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            string json = JsonConvert.SerializeObject(@event);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/events/create/", stringContent);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public static void ShowEvent(Event e)
        {

            var s = ($"Name: {e.EventName}\tLocation: " +
              $"{e.Location}\tDate: {e.EventDate}");

            //MessageBox.Show(s);

        }


        public static void ShowEvents(IEnumerable<Event> events)
        {
            foreach (Event e in events)
            {
                ShowEvent(e);
            }
        }

    }
}
