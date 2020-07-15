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


            BitmapImage img = new BitmapImage(new Uri(this.BaseUri, "Assets/m.jpg"));
            detailedteamview.Items.Add(img);
            team = getdetails();
            teamview.ItemsSource = team;
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
        int count = 0;
        private string[] clickedteamnames =new string[10];
        private string[] clickedmanagernames = new string[10];
        private  void teamview_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickeditem = e.ClickedItem;
            
            click = (Teamdetails)clickeditem;
            string tname = click.teamname;
            string mname = click.membermanagername;
            clickedteamnames[count] = tname;
            clickedmanagernames[count] = mname;
            count++;
           
            bool ifsubteamexist = false;
            backarrow.Visibility = Visibility.Visible;
            clickedteam.Text = tname;
            ObservableCollection<Employee> empl = new ObservableCollection<Employee>();
            ObservableCollection<Teamdetails> tdeails = new ObservableCollection<Teamdetails>();
            var selectquery = conn.Table<Employee>();
            foreach (Employee details in selectquery)
            {
                if (details.Teamname == tname || details.Firstname + " "+details.Lastname==mname)
                {
                   
                    empl.Add(details);
                }
            }
           // empl.Add(new Employee { imagesource = "Assets/f.jpg" });
            var squery = conn.Table<Teamdetails>();
            foreach(Teamdetails det in squery)
            {
                if(click.teamname==det.parentteamname)
                {
                    if(tdeails.Any(p => p.teamname == det.teamname) == false)
                     {
                        ifsubteamexist = true;
                        tdeails.Add(det);
                    }
                }
            }
            if (ifsubteamexist == false)
            {
               
                teamview.Visibility = Visibility.Collapsed;
                noteam.Visibility = Visibility.Visible;
                noteam.Text = "No subteams yet.";
            }
            else
            {
                noteam.Visibility = Visibility.Collapsed;
                teamview.Visibility = Visibility.Visible;
                teamview.ItemsSource = tdeails;
            }
            detailedteamview.Visibility = Visibility.Visible;

            detailedteamview.ItemsSource = empl;
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
            empdetails.Visibility = Visibility.Visible;
            empdetails.ItemsSource = emp;
        }

        private void empname_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            empdetails.Visibility = Visibility.Collapsed;
        }
        
        private  void Backarrow_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (count ==1 )
            {
                ObservableCollection<Teamdetails> teams = new ObservableCollection<Teamdetails>();
                var selectquery = conn.Table<Teamdetails>();
                foreach (Teamdetails details in selectquery)
                {
                    if (details.parentteamname == "None" && details.teammember == "null")
                    {
                        teams.Add(details);
                    }
                }
                teamview.Visibility = Visibility.Visible;
                detailedteamview.Visibility = Visibility.Collapsed;
                backarrow.Visibility = Visibility.Collapsed;
                teamview.ItemsSource = teams;
            }
            else
            {
               
                string tname = clickedteamnames[count - 2];
                string mname = clickedmanagernames[count - 2];

                backarrow.Visibility = Visibility.Visible;
                clickedteam.Text = tname;
                ObservableCollection<Employee> empl = new ObservableCollection<Employee>();
                ObservableCollection<Teamdetails> tdeails = new ObservableCollection<Teamdetails>();
                var selectquery = conn.Table<Employee>();
                foreach (Employee details in selectquery)
                {
                    if (details.Teamname == tname || details.Firstname + " " + details.Lastname == mname)
                    {

                        empl.Add(details);
                    }
                }

                var squery = conn.Table<Teamdetails>();
                foreach (Teamdetails det in squery)
                {
                    if (det.parentteamname == tname)
                    {
                        if (tdeails.Any(p => p.teamname == det.teamname) == false)
                        {

                            tdeails.Add(det);
                        }
                    }
                }
                noteam.Visibility = Visibility.Collapsed;
                teamview.Visibility = Visibility.Visible;
                teamview.ItemsSource = tdeails;

                detailedteamview.Visibility = Visibility.Visible;

                detailedteamview.ItemsSource = empl;
                count--;
            }
        }

       
    }
}
