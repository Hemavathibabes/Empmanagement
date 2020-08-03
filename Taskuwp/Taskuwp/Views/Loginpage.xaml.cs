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
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Animation;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Taskuwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Loginpage : Page
    {
       
        public Loginpage()
        {
            this.InitializeComponent();
           
        }
       

        private  async void login_Click(object sender, RoutedEventArgs e)
        {
           

           int loginstatus = 0;
           loginstatus= ViewModels.Loginuser.checkvaliduser(email.Text, password.Password);
           
             if(loginstatus==1)
            {
                MessageDialog faillogin = new MessageDialog("Username and password does not match!");
                await faillogin.ShowAsync();

            }
            if (loginstatus==0)
            {
               MessageDialog failurelogin = new MessageDialog("You didn't created a account...!");
                await failurelogin.ShowAsync();
            }
            if (loginstatus == 2)
            {
                App.CurrentUser = email.Text;
               this.Frame.Navigate(typeof(Homepage), email.Text,new SuppressNavigationTransitionInfo());
            }
        }

        private void forgotpassword_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Forgotpassword), null, new SuppressNavigationTransitionInfo());
        }
    }
}
