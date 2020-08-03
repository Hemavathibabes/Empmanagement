using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Taskuwp.Models;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Taskuwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FavEmployees : Page
    {
        ObservableCollection<Employee> emp = new ObservableCollection<Employee>();
        ObservableCollection<Employee> cemp = new ObservableCollection<Employee>();
       
        string mailid;

        public FavEmployees()
        {
            this.InitializeComponent();
            setitemsource(emp);
           
           
        }
        public  void setitemsource(ObservableCollection<Employee> emp)
        {
            ViewModels.Favemps.getallempdetails(emp,null);
            foreach (Employee em in emp)
            {
               if(em.Favop=="\uE1CE")
                {
                    em.Isvisible = "Collapsed";
                }
            }
            allemplist.ItemsSource = emp;
        }
       
        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            mailid = e.Parameter as string;
            ObservableCollection<Employee> tdetails = new ObservableCollection<Employee>();
            tdetails = ViewModels.Adduser.getdesignationdetails(tdetails);
            createmenuflyout(tdetails);
            
        }
        private   void empname_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
          
                StackPanel tb = (StackPanel)sender;
                var tag = (sender as StackPanel).Tag;
                int empid = (int)tag;
            starpointerentered(empid);
            
           
        }
        public void starpointerentered(int empid)
        {
            foreach (Employee em in emp)
            {
                if (em.empid == empid && em.Favop == "\uE1CE")
                {
                    em.Isvisible = "Visible";

                    break;
                }
            }
        }
        private void starbtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        { 

            var tag = (sender as TextBlock).Tag;
            int empid = (int)tag;
            starpointerentered(empid);
        }
        public void starpointerexited( int empid)
        {
            foreach (Employee em in emp)
            {
                if (em.empid == empid && em.Favop == "\uE1CE")
                {

                    em.Isvisible = "Collapsed";
                    break;
                }

            }
        }
        private void empname_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var tag = (sender as StackPanel).Tag;
            int empid = (int)tag;
            starpointerexited(empid);

        }
        public void createmenuflyout(ObservableCollection<Employee> tdetails)

        {
            MenuFlyout flyout = new MenuFlyout();
            foreach (var item in tdetails)
            {
                MenuFlyoutItem mf = new MenuFlyoutItem();
                mf.Text = item.Teamname;
                mf.Name = "teamnames";
                mf.Click += filtertname_Click;
                flyout.Items.Add(mf);
            }
            foreach (var item in flyout.Items)
            {
                filtertname.Items.Insert(filtertname.Items.Count, item);
            }
        }
        public void filtertname_Click(object sender,RoutedEventArgs e)
        {
            MenuFlyoutItem selecteditem = sender as MenuFlyoutItem;
            string val = selecteditem.Text.ToString();
            ObservableCollection<Employee> filteredemp = new ObservableCollection<Employee>();
            ViewModels.Favemps.getallempdetails(filteredemp,val);
            allemplist.ItemsSource = filteredemp;
           
           
        }
        public Employee click;
        private async void favemplist_ItemClick(object sender, ItemClickEventArgs e)
        {
            cemp.Clear();
            var clickeditem = e.ClickedItem;

            click = (Employee)clickeditem;
            string ename = click.Firstname + " " + click.Lastname;
            int  empid = click.empid;
          
            ViewModels.Favemps.getclickedempdetails(empid, ename,cemp);
          
            detailedemplist.ItemsSource = cemp;
            double actualwidth = this.ActualWidth;
            /*  if(actualwidth==300)
               {
                  // detailedemplist.Margin=new padding;
                   adaptivearrow.Visibility = Visibility.Visible;
                   allemplist.Visibility = Visibility.Collapsed;
                   detailedemplist.Visibility = Visibility.Visible;
                   Grid.SetRow(detailedemplist, 1);
                   Grid.SetColumn(detailedemplist, 0);

               }
              if(actualwidth==360)
               {
                  // MessageDialog chuma = new MessageDialog(actualwidth.ToString());
                  // await chuma.ShowAsync();
                   adaptivearrow.Visibility = Visibility.Collapsed;
                   allemplist.Visibility = Visibility.Visible;
                   detailedemplist.Visibility = Visibility.Visible;
                   Grid.SetRow(allemplist, 1);
                   Grid.SetColumn(allemplist, 0);
                   Grid.SetRow(detailedemplist, 1);
                   Grid.SetColumn(detailedemplist, 1);
               }*/
        }

        private void searchbar_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            ObservableCollection<Employee> semp = new ObservableCollection<Employee>();
            ViewModels.Favemps.getallempdetails(semp,null);
            AutoSuggestBox Auto = (AutoSuggestBox)sender;
            
            var filtered = semp.Where(i => i.Firstname.Contains(this.searchbar.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();
            if (!filtered.Any())
            {
                semp.Clear();
                var Emp = new Employee { Firstname = "No Employees Found" };
                semp.Add(Emp);
                allemplist.ItemsSource = semp;
            }
            else
            {
                allemplist.ItemsSource = filtered;
            }
        }
        private void searchbar_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            string ename = null;
            int empid = 0;

            if (args.SelectedItem is Employee item)
            {
                ename = item.Firstname + " " + item.Lastname;
                empid = item.empid;
            }
            ObservableCollection<Employee> emp = new ObservableCollection<Employee>();
            ViewModels.Favemps.getclickedempdetails(empid, ename, emp);
            detailedemplist.ItemsSource = emp;
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {

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
            foreach (Employee de in cemp)
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

        private void filterfavemp_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Employee> femp = new ObservableCollection<Employee>();
            ViewModels.Favemps.getfavemplist(mailid, femp);
            foreach (Employee em in emp)
            {
                if (em.Favop == "\uE1CE")
                {
                    em.Isvisible = "Collapsed";
                }
            }
            allemplist.ItemsSource = femp;
        }

       
        private void starbtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var tag = (sender as TextBlock).Tag;
            int empid = (int)tag;
            starpointerexited(empid);
        }

        private void adaptivearrow_Tapped(object sender, TappedRoutedEventArgs e)
        {
            adaptivearrow.Visibility = Visibility.Collapsed;
            detailedemplist.Visibility = Visibility.Collapsed;
            allemplist.Visibility = Visibility.Visible;

        }
    }
    }
