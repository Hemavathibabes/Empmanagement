using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Taskuwp.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Taskuwp.Views
{
    public sealed partial class Homepage : Page
    {
       
        public Homepage()
        {
            this.InitializeComponent();
            
            
            }
        string mailid;
        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            mailid = e.Parameter as string;
           /*  var selectquery = conn.Table<Employee>();
            foreach(Employee details in selectquery)
            {
                if (mailid == details.Emailid && details.user_as == "As a Human Resources Manager")
                {
                    
                        adduseritem.Visibility = Visibility.Visible;
                        break;
                    
                }
            }*/

        }
        private void hamburgerbutton_Click(object sender, RoutedEventArgs e)
        {
            mysplitview.IsPaneOpen = ! mysplitview.IsPaneOpen;
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(adduseritem.IsSelected==true)
            {
                mframe.Navigate(typeof(Adduser),null, new SuppressNavigationTransitionInfo());
                
            }
           if(selfserviceitem.IsSelected==true)
            {
                mframe.Navigate(typeof(Selfservice),"hemavathibabes@gmail.com", new SuppressNavigationTransitionInfo());
            }
           if(teamviewitem.IsSelected==true)
            {
                mframe.Navigate(typeof(Team), "hemavathibabes@gmail.com", new SuppressNavigationTransitionInfo());
            }
           if(allempitem.IsSelected==true)
            {
                mframe.Navigate(typeof(FavEmployees), "hemavathibabes@gmail.com", new SuppressNavigationTransitionInfo());
            }
           if(logoutitem.IsSelected==true)
            {
               Frame.Navigate(typeof(Loginpage), null, new SuppressNavigationTransitionInfo());
            }
        }
    }
}
