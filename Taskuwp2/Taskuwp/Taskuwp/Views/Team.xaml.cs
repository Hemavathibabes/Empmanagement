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
using System.Diagnostics.Tracing;
using System.Drawing;
using Windows.UI;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Taskuwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Team : Page
    {
       
        ObservableCollection<Teamdetails> team = new ObservableCollection<Teamdetails>();
       
        public Team()
        {
            this.InitializeComponent();
          
            team = ViewModels.Teamview.getdetails(team);
            Mainteamview.ItemsSource = team;
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
        ObservableCollection<Employee> empl = new ObservableCollection<Employee>();
        ObservableCollection<Employee> thead = new ObservableCollection<Employee>();
        private  void Mainteamview_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            Mainteamview.Margin = new Thickness(0, -80, 0, 0);
            var clickeditem = e.ClickedItem;
            
            click = (Teamdetails)clickeditem;
            string tname = click.teamname;
            string mname = click.teamhead;
            
            
            clickedteamnames[count] = tname;
            clickedmanagernames[count] = mname;
            count++;
            Backarrow.Visibility = Visibility.Collapsed;
            centerline.Visibility = Visibility.Visible;
            ObservableCollection<Teamdetails> subteam = new ObservableCollection<Teamdetails>();
            ObservableCollection<Teamdetails> tdetails = new ObservableCollection<Teamdetails>();
          
            bool backarrowshow=false;
            bool ifsubteamexist = false;


            backarrowshow =ViewModels.Teamview.selectedteamdetails(tname, mname,tdetails);
            if (backarrowshow == true)

            {
                Backarrow.Visibility = Visibility.Visible;
            }

            ifsubteamexist= ViewModels.Teamview.getsubteamdetails(tname, subteam);
           
           
            
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
           empl.Clear();
           thead.Clear();
           
            ViewModels.Teamview.getselectedempdetails(tname, mname, thead, empl);
          
            parentteamdetails.Visibility = Visibility.Visible;
            parentteamdetails.ItemsSource = tdetails;
            detailedteamview.Visibility = Visibility.Visible;
            teamheadview.Visibility = Visibility.Visible;
            teamheadview.ItemsSource = thead;
           detailedteamview.ItemsSource = empl;
        }

      
        private  void Backarrow_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if ( count==1 || count==0 || count<0 )
            {
                
                Backarrow.Visibility = Visibility.Collapsed;
            }
            
           else
            {

              /*  MessageDialog chuma = new MessageDialog((count).ToString());
                await chuma.ShowAsync();*/
                string tname = clickedteamnames[count - 2];
               string mname=clickedmanagernames[count-2];
              

                ObservableCollection<Teamdetails> subteam = new ObservableCollection<Teamdetails>();
                ObservableCollection<Teamdetails> tdetails = new ObservableCollection<Teamdetails>();
                ObservableCollection<Employee> empl = new ObservableCollection<Employee>();
                ObservableCollection<Employee> thead = new ObservableCollection<Employee>();
                bool backarrowshow = false;
                bool ifsubteamexist = false;


                backarrowshow = ViewModels.Teamview.selectedteamdetails(tname, mname, tdetails);
                if (backarrowshow == true)

                {
                    
                    Backarrow.Visibility = Visibility.Visible;
                }

                ifsubteamexist = ViewModels.Teamview.getsubteamdetails(tname, subteam);



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

                ViewModels.Teamview.getselectedempdetails(tname, mname, thead, empl);
                parentteamdetails.Visibility = Visibility.Visible;
                parentteamdetails.ItemsSource = tdetails;
                detailedteamview.Visibility = Visibility.Visible;
                teamheadview.Visibility = Visibility.Visible;
                teamheadview.ItemsSource = thead;
                detailedteamview.ItemsSource = empl;

             
                count--;
                if(count==1)
                {
                    Backarrow.Visibility = Visibility.Collapsed;
                }
            }
        }
        public Employee clickitem;
        ObservableCollection<Employee> emp = new ObservableCollection<Employee>();
        private void teamheadview_ItemClick(object sender, ItemClickEventArgs e)
        {
            detailedteamview.SelectedIndex = -1;
            var clickeditem = e.ClickedItem;

            clickitem = (Employee)clickeditem;
            string empname = clickitem.Firstname + " " + clickitem.Lastname;
            emp.Clear();
            ViewModels.Teamview.getempdetails(empname, emp);
            
            /*PointerPoint point = e.GetCurrentPoint(tb);
            var x = point.Position.X.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            var y = point.Position.Y.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            empdetails.HorizontalOffset = Convert.ToDouble(x) - 40;
            empdetails.VerticalOffset = Convert.ToDouble(y);*/


           // empdetails.IsOpen = true;
            empdetailslist.ItemsSource = emp;
        }
        ObservableCollection<Employee> empL = new ObservableCollection<Employee>();
        private void detailedteamview_ItemClick(object sender, ItemClickEventArgs e)
        {
            teamheadview.SelectedIndex = -1;
            var clickeditem = e.ClickedItem;

            clickitem = (Employee)clickeditem;
            int  empid = clickitem.empid;
            string empname = clickitem.Firstname + " " + clickitem.Lastname;
            empL.Clear();
            // ObservableCollection<Employee> empL = new ObservableCollection<Employee>();
            ViewModels.Teamview.getempdetails(empname, empL);



            
            empdetailslist.Visibility = Visibility.Visible;
            empdetailslist.ItemsSource = empL;

        }


        private void starbtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

          //  tb.Background = new SolidColorBrush(Colors.Transparent);

            var tag = (sender as TextBlock).Tag;
            int empid = (int)tag;
            string iffav;


            iffav = ViewModels.Favemps.favemp(mailid, empid);

            if (iffav == "True")
            {
                tb.Text = "\uE1CF";
            }
            else
            {
                tb.Text = "\uE1CE";
            }

            foreach (Employee de in empL)
            {
                if (empid == de.empid)
                {
                    if (iffav == "True")
                    {
                        de.Favop = "\uE1CF";
                    }
                    else
                    {
                        de.Favop = "\uE1CE";
                    }
                }
            }
            foreach (Employee de in emp)
            {
                if (empid == de.empid)
                {
                    if (iffav == "True")
                    {
                        de.Favop = "\uE1CF";
                    }
                    else
                    {
                        de.Favop = "\uE1CE";
                    }
                }
            }
            foreach (Employee de in empl)
            {
                if (empid == de.empid)
                {
                    if (iffav == "True")
                    {
                        de.Favop = "\uE1CF";
                    }
                    else
                    {
                        de.Favop = "\uE1CE";
                    }
                }
            }
            foreach (Employee de in thead)
            {
                if (empid == de.empid)
                {
                    if (iffav == "True")
                    {
                        de.Favop = "\uE1CF";
                    }
                    else
                    {
                        de.Favop = "\uE1CE";
                    }
                }
            }
        }
    }
}
