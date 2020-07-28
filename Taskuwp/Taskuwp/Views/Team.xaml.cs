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
using Windows.UI.Xaml.Shapes;
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
        private string[] clickedmanagernames = new string[100];
        int count=0;
        ObservableCollection<Employee> empl = new ObservableCollection<Employee>();
        ObservableCollection<Employee> thead = new ObservableCollection<Employee>();
        bool minwidth = false;
        private  void Mainteamview_ItemClick(object sender, ItemClickEventArgs e)
        {
            
           // Mainteamview.Margin = new Thickness(0, -80, 0, 0);
            var clickeditem = e.ClickedItem;
            
            click = (Teamdetails)clickeditem;
            string tname = click.teamname;
            string mname = click.teamhead;
            
            
            clickedteamnames[count] = tname;
            clickedmanagernames[count] = mname;
            count++;
            Backarrow.Visibility = Visibility.Collapsed;
            splitline.Visibility = Visibility.Visible;
            ObservableCollection<Teamdetails> subteam = new ObservableCollection<Teamdetails>();
            ObservableCollection<Teamdetails> tdetails = new ObservableCollection<Teamdetails>();
          
            bool backarrowshow=false;
            bool ifsubteamexist = false;

            parentteamdetails.Margin = new Thickness(0, 0, 0, 0);
            backarrowshow =ViewModels.Teamview.selectedteamdetails(tname, mname,tdetails);
            if (backarrowshow == true)

            {
                Backarrow.Visibility = Visibility.Visible;
               parentteamdetails.Margin = new Thickness(-10, 0, 0, 0);

            }
           
          /*  if(this.ActualWidth<=700)
            {
                
                Backarrow.Visibility = Visibility.Visible;
                
                Grid.SetRow(firstcol, 1);
                Grid.SetColumn(firstcol, 0);
                firstcol.Visibility = Visibility.Visible;
                Mainteamview.Visibility = Visibility.Collapsed;
                tnamesearch.Visibility = Visibility.Collapsed;
                minwidth = true;
            }*/

            ifsubteamexist= ViewModels.Teamview.getsubteamdetails(tname, subteam);
            tmembersline.Visibility = Visibility.Collapsed;
            steamline.Visibility = Visibility.Visible;
            tmemeberssearch.Visibility = Visibility.Collapsed;
            teamdetailssp.Visibility = Visibility.Visible;
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
           detailedteamview.Visibility = Visibility.Collapsed;
           teamheadview.Visibility = Visibility.Collapsed;
            teamheadview.ItemsSource = thead;
           detailedteamview.ItemsSource = empl;
            
        }

      
        private  void Backarrow_Tapped(object sender, TappedRoutedEventArgs e)
        {
           /* if(this.ActualWidth<=700 && minwidth==true)
            {
                tnamesearch.Visibility = Visibility.Visible;
                Mainteamview.Visibility = Visibility.Visible;
                firstcol.Visibility = Visibility.Collapsed;
                Grid.SetColumn(firstcol, 1);
                Grid.SetRow(firstcol, 1);
                Backarrow.Visibility = Visibility.Collapsed;
                parentteamdetails.Margin = new Thickness(0, 0, 0, 0);
            }*/
           
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

                teamdetailssp.Visibility = Visibility.Visible;
                tmembersline.Visibility = Visibility.Collapsed;
                steamline.Visibility = Visibility.Visible;
                tmemeberssearch.Visibility = Visibility.Collapsed;
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
                detailedteamview.Visibility = Visibility.Collapsed;
                teamheadview.Visibility = Visibility.Collapsed;
                teamheadview.ItemsSource = thead;
                detailedteamview.ItemsSource = empl;

             
                count--;
                if(count==1)
                {
                    Backarrow.Visibility = Visibility.Collapsed;
                    parentteamdetails.Margin = new Thickness(0, 0, 0, 0);
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
            int empid = clickitem.empid;
            emp.Clear();
            ViewModels.Teamview.getempdetails(empid, emp);
            detailedemplist.Visibility = Visibility.Collapsed;
            empdetailslist.Visibility = Visibility.Visible;
            
            empdetailslist.ItemsSource = emp;
        }
        ObservableCollection<Employee> empL = new ObservableCollection<Employee>();
        private void detailedteamview_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            teamheadview.SelectedIndex = -1;
            var clickeditem = e.ClickedItem;

            clickitem = (Employee)clickeditem;
            int  empid = clickitem.empid;
            
            empL.Clear();
        
            ViewModels.Teamview.getempdetails(empid, empL);
          
            detailedemplist.Visibility = Visibility.Collapsed;
            empdetailslist.Visibility = Visibility.Visible;
            empdetailslist.ItemsSource = empL;

        }

        
        private void starbtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;


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

        private void viewprofile_Click(object sender, RoutedEventArgs e)
        {
            empL.Clear();
            var tag = (sender as Button).Tag;
            int empid = (int)tag;
            ViewModels.Teamview.getempdetails(empid, empL);
            detailedemplist.ItemsSource = empL;
            empdetailslist.Visibility = Visibility.Collapsed;
            detailedemplist.Visibility = Visibility.Visible;
        }

        private void tnamesearch_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            
            ObservableCollection<Teamdetails> tname = new ObservableCollection<Teamdetails>();
          
            tname = ViewModels.Teamview.getdetails(tname);
            
            var filtered = tname.Where(i => i.teamname.Contains(this.tnamesearch.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();
            if (!filtered.Any())
            {
                tname.Clear();
                var tdetails = new Teamdetails { teamname = "No Teams found" };
                tname.Add(tdetails);
                Mainteamview.ItemsSource = tname;


            }
            else
            {
                Mainteamview.ItemsSource = filtered;
            }
        }

        private void tmemeberssearch_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            ObservableCollection<Employee> nemp = new ObservableCollection<Employee>();
            var newlist = thead.Concat(empl);
           
            var filtered = newlist.Where(i => i.Firstname.Contains(this.tmemeberssearch.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();
            if (!filtered.Any())
            {

                var Emp = new Employee { Firstname = "No Employees found" };
                nemp.Add(Emp);
                detailedteamview.ItemsSource = nemp;
                teamheadview.ItemsSource = null;
            }
            else
            {
                detailedteamview.ItemsSource = filtered;
                teamheadview.ItemsSource = null;
            }
        }

        private void subteams_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tmembersline.Visibility = Visibility.Collapsed;
            tmemeberssearch.Visibility = Visibility.Collapsed;
            steamline.Visibility = Visibility.Visible;
            subteamview.Visibility = Visibility.Visible;
            teamheadview.Visibility = Visibility.Collapsed;
            detailedteamview.Visibility = Visibility.Collapsed;
        }

        private void tmembers_Tapped(object sender, TappedRoutedEventArgs e)
        {
            noteam.Visibility = Visibility.Collapsed;
            tmembersline.Visibility = Visibility.Visible;
            steamline.Visibility = Visibility.Collapsed;
            tmemeberssearch.Visibility = Visibility.Visible;
            subteamview.Visibility = Visibility.Collapsed;
            teamheadview.Visibility = Visibility.Visible;
            detailedteamview.Visibility = Visibility.Visible;
        }
    }
}
