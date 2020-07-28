using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLite.Net.Attributes;
using Windows.Devices.Geolocation;
using Taskuwp.Models;
using System.ServiceModel;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.UI;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Taskuwp.Views
{
    
  
    public sealed partial class Selfservice : Page
    {
       
     
        ObservableCollection<Employee> Emp = new ObservableCollection<Employee>();
        public Selfservice()
        {
            this.InitializeComponent();

                     
        }
        string mailid;
        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            mailid = e.Parameter as string;

            Emp = ViewModels.Selfservice.getdetails(mailid,Emp);
            ss.ItemsSource = Emp;
        }



        private void edit_Click(object sender, RoutedEventArgs e)
        {
            editpage ep = new editpage(mailid);

            grid1.Children.Clear();
            grid1.Children.Add(ep);

        }




    }
}
