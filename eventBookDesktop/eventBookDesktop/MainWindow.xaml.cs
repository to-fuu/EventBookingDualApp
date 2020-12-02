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

using eventBookDesktop.Data.API;
using eventBookDesktop.Data.Models;

namespace eventBookDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();
       
        public MainWindow()
        {
            InitializeComponent();
            //EventConsumer.ShowEvent(EventConsumer.GetEvent(client, 4).Result);
            // EventConsumer.ShowEvents(EventConsumer.GetEvents(client).Result);
           EventConsumer.InsertEvent(new Event { EventName = "NANI", EventDate = DateTime.Now, Location = "There" }, client);

        }

    }
}
