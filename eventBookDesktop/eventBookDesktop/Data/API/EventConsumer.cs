using System;
using System.Collections.Generic;
using System.Text;
using eventBookDesktop.Data.Models;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace eventBookDesktop.Data.API
{
    public static class EventConsumer
    {

        public static async Task<Event> GetEvent(HttpClient client,int id)
        {

            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:" + Settings.port + "/");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/get/"+id).Result;

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

        public static void ShowEvent(Event e)
        {

            var s = ($"Name: {e.EventName}\tLocation: " +
              $"{e.Location}\tDate: {e.EventDate}");

            MessageBox.Show(s);

        }


        public static void ShowEvents(IEnumerable<Event> events)
        {
            foreach(Event e in events)
            {
                ShowEvent(e);
            }
        }

    }
}
