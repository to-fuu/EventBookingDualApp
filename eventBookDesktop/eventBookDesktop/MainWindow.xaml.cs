using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace eventBookDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();
        public class Event
        {
            public int ID { get; set; }
            public string EventName { get; set; }
            public DateTime EventDate { get; set; }
            public string Location { get; set; }

        }

        public MainWindow()
        {
            InitializeComponent();
            RunAsync();
        }

        public static void ShowEvent(Event e){
            var s = ($"Name: {e.EventName}\tLocation: " +
              $"{e.Location}\tDate: {e.EventDate}");

            MessageBox.Show(s);

        }


        static async void RunAsync()
        {

            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:52213/");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/get/4").Result;
   
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<Event>();
                ShowEvent(content);
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

        }

    }
}
