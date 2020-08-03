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
using Taskuwp.Models;
using Google.Apis.Discovery;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Taskuwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class updatepassword : Page
    {
       
        public updatepassword()
        {
            this.InitializeComponent();
           
        }
        string tomail;
        int u_id;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           var param=(Employee)e.Parameter;
            tomail = param.Emailid;
            u_id = param.empid;
          
        }

        private async void upassword_Click(object sender, RoutedEventArgs e)
        {
            string password;
            int userid;
            bool ifupdate = false;
            userid  =Convert.ToInt32(uid.Text);
            password = pwd.Password;

            
            if (pwd.Password == reenterpwd.Password)

            {
             if(u_id==userid)
                {
                    ifupdate=ViewModels.Loginuser.updatepassword(tomail, password);
                }
              if(ifupdate==true)
                {
                    MessageDialog sucessdialog = new MessageDialog("Password update successfully!");
                    await sucessdialog.ShowAsync();

                    this.Frame.Navigate(typeof(Loginpage),null, new SuppressNavigationTransitionInfo());
                }
                if(ifupdate==false)
                {
                    MessageDialog errdialog = new MessageDialog("Password update failed! ");
                    await errdialog.ShowAsync();

                }
            }
            else
            {
                MessageDialog errdialog = new MessageDialog("password and conform password does not match!");
                await errdialog.ShowAsync();
            }
        }
    }
}
