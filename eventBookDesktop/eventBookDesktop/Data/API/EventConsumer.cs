using System;
using System.Collections.Generic;
using System.Text;
using eventBookDesktop.Data.Models;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace eventBookDesktop.Data.API
{
    public static class EventConsumer
    {

        public static async Task<Event> GetEvent(HttpClient client, int id)
        {

            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:" + Settings.port + "/");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/get/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<Event>();
                return content;
            }
            else
            {
                return null;
                //MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

        }

        public static async Task<IEnumerable<Event>> GetEvents(HttpClient client)
        {

            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:" + Settings.port + "/");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/get/").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<IEnumerable<Event>>();
                return content;
            }
            else
            {
                return null;
                //MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

        }

        public static async Task<string> InsertEvent(Event @event, HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:" + Settings.port + "/");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            string json = JsonConvert.SerializeObject(@event);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/create/", stringContent);

            var responseString = await response.Content.ReadAsStringAsync();
            MessageBox.Show(responseString);

            return responseString;
        }

        public static void ShowEvent(Event e)
        {

            var s = ($"Name: {e.EventName}\tLocation: " +
              $"{e.Location}\tDate: {e.EventDate}");

            MessageBox.Show(s);

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
