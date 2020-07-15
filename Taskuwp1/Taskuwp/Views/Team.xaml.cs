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
using System.Collections.ObjectModel;
using Taskuwp.Models;
using Windows.UI.Popups;
using Org.BouncyCastle.Security;
using Windows.Networking.NetworkOperators;
using Org.BouncyCastle.Asn1.GM;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Input;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Taskuwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Team : Page
    {
        string path;
        SQLite.Net.SQLiteConnection conn;
        ObservableCollection<Teamdetails> team = new ObservableCollection<Teamdetails>();
       
        public Team()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Employeemanagement.db");
            conn = new SQLite.Net.SQLiteConnection(new
               SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            //detailedteamview.Items.Add("Hi");

            
            team = getdetails();
            Mainteamview.ItemsSource = team;
        }
        public ObservableCollection<Teamdetails> getdetails()
        {
            var selectquery = conn.Table<Teamdetails>();
            foreach (Teamdetails details in selectquery)
            {
               if (details.parentteamname == "None" && details.teammember=="null")
                {
                     team.Add(details);
                }
            }
            return team;
            
        }

        string mailid;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mailid = e.Parameter as string;
        }
        public Teamdetails click;
        private string[] clickedteamnames = new string[10];
        private string[] clickedmanagernames = new string[20];
        int count=0;
        private  void Mainteamview_ItemClick(object sender, ItemClickEventArgs e)
        {

            Mainteamview.Margin = new Thickness(0, -80, 0, 0);
            var clickeditem = e.ClickedItem;
            bool ifsubteamexist = false;
            click = (Teamdetails)clickeditem;
            string tname = click.teamname;
            string mname = click.teamhead;
            clickedteamnames[count] = tname;
            clickedmanagernames[count] = mname;
            count++;
            Backarrow.Visibility = Visibility.Collapsed;
            centerline.Visibility = Visibility.Visible;
            ObservableCollection<Teamdetails> subteam = new ObservableCollection<Teamdetails>();
            ObservableCollection<Teamdetails> tdeails = new ObservableCollection<Teamdetails>();
            ObservableCollection<Employee> empl = new ObservableCollection<Employee>();
            ObservableCollection<Employee> thead = new ObservableCollection<Employee>();
            int c = 0;
            string pteam;
           
            var squery = conn.Table<Teamdetails>();
            foreach (Teamdetails cdetails in squery)
            {
                if (cdetails.teamname == tname)
                {
                    if(cdetails.parentteamname!="None")
                    {
                        Backarrow.Visibility = Visibility.Visible;
                    }
                    c++;
                }
              
            }
            foreach (Teamdetails detail in squery)
            {
                if (detail.teamname == tname)
                {
                    if (detail.teamhead == "null")
                    {
                        pteam = detail.parentteamname;
                        foreach (Teamdetails details in squery)
                        {
                            if (pteam == details.teamname && details.teamhead != "null")
                            {
                                mname = details.teamhead;
                                detail.teamhead = details.teamhead;
                            }
                        }
                    }
                    if (tdeails.Any(p => p.teamname == detail.teamname) == false)
                    {
                      
                       
                        detail.teamcount = c;
                        tdeails.Add(detail);
                       
                    }
                   
                }
            }
            foreach (Teamdetails det in squery)
            {
                if (tname == det.parentteamname)
                {
                    
                    if (subteam.Any(p => p.teamname == det.teamname) == false)
                    {
                        ifsubteamexist = true;
                        subteam.Add(det);
                    }
                }
            }
            var selectquery = conn.Table<Employee>();
            foreach(Employee hdetails in selectquery)
            {
                if(hdetails.Firstname + " " + hdetails.Lastname == mname )
                {
                    hdetails.imagesource = "ms-appx:///Assets/" + hdetails.empid + ".jpg";
                    thead.Add(hdetails);
                }
            }
            foreach (Employee details in selectquery)
            {
                if (details.Teamname == tname && details.Designation!= "Member Leadership Staff")
                {
                    details.imagesource = "ms-appx:///Assets/" + details.empid + ".jpg";
                    empl.Add(details);
                }
            }

            if (ifsubteamexist == false)
            {
               
                subteamview.Visibility = Visibility.Collapsed;
                noteam.Visibility = Visibility.Visible;
                noteam.Text = "No subteams yet.";
            }
            else
            {
               
                noteam.Visibility = Visibility.Collapsed;
                subteamview.Visibility = Visibility.Visible;
                subteamview.ItemsSource = subteam;

            }
            parentteamdetails.Visibility = Visibility.Visible;
            parentteamdetails.ItemsSource = tdeails;
            detailedteamview.Visibility = Visibility.Visible;
            teamheadview.Visibility = Visibility.Visible;
            teamheadview.ItemsSource = thead;
           detailedteamview.ItemsSource = empl;
        }

        
       
    
       private void teamname_PointerEntered(object sender, PointerRoutedEventArgs e)
        {

            teamdetails.IsOpen = false;
            var send = sender as Allteams;
            var view = send.DataContext as Teamdetails;
            string tname = view.teamname;
            //TextBlock tb = (TextBlock)sender;
            //string tname = tb.Text;
            int c = 0;
            string pteam;
            ObservableCollection<Teamdetails> tdetails = new ObservableCollection<Teamdetails>();
            var selectquery = conn.Table<Teamdetails>();
            foreach(Teamdetails cdetails in selectquery)
            {
                if(cdetails.teamname==tname)
                {
                    c++;
                }
            }
            foreach(Teamdetails detail in selectquery)
            {
                if (detail.teamname == tname)
                {
                    if (detail.teamhead=="null")
                     {
                    pteam = detail.parentteamname;
                    foreach(Teamdetails details in selectquery)
                    {
                        if(pteam==details.teamname && details.teamhead!="null")
                        {
                            detail.teamhead = details.teamhead;
                        }
                    }
                }
                    detail.teamcount = c;
                    tdetails.Add(detail);
                    break;
                }
            }
            PointerPoint point = e.GetCurrentPoint(send);
            var x = point.Position.X.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            var y = point.Position.Y.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            teamdetails.HorizontalOffset = Convert.ToDouble(x);
            teamdetails.VerticalOffset = Convert.ToDouble(y);

            teamdetails.IsOpen = true;
            teamdetailslist.ItemsSource = tdetails;
        }

        private void teamname_PointerExited(object sender, PointerRoutedEventArgs e)
        {
           teamdetails.IsOpen = false;
        }

        private void empname_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            string ename = tb.Text;
            ObservableCollection<Employee> emp = new ObservableCollection<Employee>();
            var selectquery = conn.Table<Employee>();
            foreach(Employee details in selectquery)
            {
                if((details.Firstname+ " " +details.Lastname)==ename)
                {
                    emp.Add(details);
                }
            }
           PointerPoint point = e.GetCurrentPoint(tb);
            var x = point.Position.X.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            var y = point.Position.Y.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            empdetails.HorizontalOffset = Convert.ToDouble(x)-40;
            empdetails.VerticalOffset = Convert.ToDouble(y); 
           
                
            empdetails.IsOpen = true;
            empdetailslist.ItemsSource = emp;
        }

        private void empname_PointerExited(object sender, PointerRoutedEventArgs e)
        {
           // empdetails.IsOpen = false;
        }
        
        private void Backarrow_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if ( count==1 )
            {
                
                Backarrow.Visibility = Visibility.Collapsed;
            }
            
           else
            {
               
                bool ifsubteamexist = false;
               
                string tname = clickedteamnames[count - 2];
               string mname=clickedmanagernames[count-2];
              

                ObservableCollection<Teamdetails> subteam = new ObservableCollection<Teamdetails>();
                ObservableCollection<Teamdetails> tdeails = new ObservableCollection<Teamdetails>();
                ObservableCollection<Employee> empl = new ObservableCollection<Employee>();
                ObservableCollection<Employee> thead = new ObservableCollection<Employee>();
                int c = 0;
                string pteam;

                var squery = conn.Table<Teamdetails>();
                foreach (Teamdetails cdetails in squery)
                {
                    if (cdetails.teamname == tname)
                    {
                        if (cdetails.parentteamname != "None")
                        {
                            Backarrow.Visibility = Visibility.Visible;
                        }
                        c++;
                    }

                }
                foreach (Teamdetails detail in squery)
                {
                    if (detail.teamname == tname)
                    {
                        if (detail.teamhead == "null")
                        {
                            pteam = detail.parentteamname;
                            foreach (Teamdetails details in squery)
                            {
                                if (pteam == details.teamname && details.teamhead != "null")
                                {
                                    mname = details.teamhead;
                                    detail.teamhead = details.teamhead;
                                }
                            }
                        }
                        if (tdeails.Any(p => p.teamname == detail.teamname) == false)
                        {


                            detail.teamcount = c;
                            tdeails.Add(detail);

                        }

                    }
                }
                foreach (Teamdetails det in squery)
                {
                    if (tname == det.parentteamname)
                    {

                        if (subteam.Any(p => p.teamname == det.teamname) == false)
                        {
                            ifsubteamexist = true;
                            subteam.Add(det);
                        }
                    }
                }
                var selectquery = conn.Table<Employee>();
                foreach (Employee hdetails in selectquery)
                {
                    if (hdetails.Firstname + " " + hdetails.Lastname == mname)
                    {
                        hdetails.imagesource = "ms-appx:///Assets/" + hdetails.empid + ".jpg";
                        thead.Add(hdetails);
                    }
                }
                foreach (Employee details in selectquery)
                {
                    if (details.Teamname == tname && details.Designation != "Member Leadership Staff")
                    {
                        details.imagesource = "ms-appx:///Assets/" + details.empid + ".jpg";
                        empl.Add(details);
                    }
                }

                if (ifsubteamexist == false)
                {

                    subteamview.Visibility = Visibility.Collapsed;
                    noteam.Visibility = Visibility.Visible;
                    noteam.Text = "No subteams yet.";
                }
                else
                {

                    noteam.Visibility = Visibility.Collapsed;
                    subteamview.Visibility = Visibility.Visible;
                    subteamview.ItemsSource = subteam;

                }
                parentteamdetails.Visibility = Visibility.Visible;
                parentteamdetails.ItemsSource = tdeails;
                detailedteamview.Visibility = Visibility.Visible;
                teamheadview.Visibility = Visibility.Visible;
                teamheadview.ItemsSource = thead;
                detailedteamview.ItemsSource = empl;

             
                count--;
            }
        }

        
    }
}
