using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp;
using EventBookingUWP.Data.Models;
using EventBookingUWP.Data.API;
using Windows.Storage;
using System.Text;
using MetroLog;
using Windows.UI.Popups;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EventBookingUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            APIConsumer.Init();

            InitializeComponent();
            ExtendNavbar();

            try
            {
                Debug.WriteLine("Folders");
                var items = System.IO.Directory.GetFiles("O:/games/");

                foreach (var item in items)
                {
                    Debug.WriteLine(item);
                    fileList.Items.Add(item);

                }

            }
            catch (UnauthorizedAccessException ex)
            {
                //create an exception if needed (you can create a messageBox, or nothing)!
            }


            ILogger log = LogManagerFactory.DefaultLogManager.GetLogger<MainPage>();

            log.Trace("This is a trace message.");
        }

        void ExtendNavbar()
        {
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

        }


    }
}
