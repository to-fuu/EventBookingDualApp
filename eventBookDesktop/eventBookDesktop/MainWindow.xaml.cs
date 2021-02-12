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
    public partial class MainWindow
    {
       
        public MainWindow()
        {
            InitializeComponent();

            APIConsumer.Init();

          //  UpdateTable();


        }

        public async void InsertLineTest(object sender, RoutedEventArgs e)
        {
            await APIConsumer.Insert<Event>("events",new Event { EventName = "NANI", EventDate = DateTime.Now, Location = "There" });
            UpdateTable();
        }

        public void UpdateTable()
        {
            grdEvents.ItemsSource = APIConsumer.GetAll<Event>("events").Result;
        }
    }
}
