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
using Windows.UI.Popups;
using System.Runtime.InteropServices.ComTypes;
using Windows.UI.Xaml.Media.Animation;
using Windows.Data.Text;
using Taskuwp.ViewModels;
using Windows.Devices.Printers.Extensions;
using System.Collections.ObjectModel;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Taskuwp.Views
{
   
    public sealed partial class Adduser : Page
    {
      
        string newuserval;
        public Adduser()
        {
            this.InitializeComponent();
            
            if (newuser1.IsChecked == true)
            {
                newuserval = Convert.ToString(newuser1.Content);
            }
           
            empid.Text = ViewModels.Adduser.getempid();
        }

      
        private  void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (newuser1.IsChecked == true)
            {
                newuserval = Convert.ToString(newuser1.Content);
            }
            else
            {
                newuserval = Convert.ToString(newuser2.Content);
                designationHR.Visibility = Visibility.Visible;
                designationemp.Visibility = Visibility.Collapsed;
            }
        }

      
        string designationselected;
        private void designation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
           
            designationselected = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
           

        }
     

        string genderval;
        private void gender_Checked(object sender, RoutedEventArgs e)
        {
        if(gender.IsChecked==true)
            {
                genderval = Convert.ToString(gender.Content);
            }
        if(gender2.IsChecked==true)
            {
                genderval = Convert.ToString(gender2.Content);
            }
        }
    
        string mstatusselected;
        private void mstatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            mstatusselected = (combo.SelectedItem as ComboBoxItem).Content.ToString();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            string date = dob.Date.ToString();
            string formateddate=date.Split(" ")[0];

            ViewModels.Adduser.insertdata(empid.Text,"1234", newuserval, designationselected, fname.Text, lname.Text,
                   mno.Text, email.Text, tname.Text, managername.Text, genderval, emergencyno.Text, mstatus.Text,formateddate,
            faname.Text, accno.Text, prstaddr.Text, permtaddr.Text, mtongue.Text, bgroup.Text);
          
        }

       
        private  void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            ObservableCollection<Employee> emp = new ObservableCollection<Employee>();
            emp =ViewModels.Adduser.getdesignationdetails(emp);
            AutoSuggestBox Auto = (AutoSuggestBox)sender;
            var filtered = emp.Where(i => i.Teamname.Contains(this.tname.Text,StringComparison.CurrentCultureIgnoreCase)).ToList();
            
            
            Auto.ItemsSource = filtered;
        }

       

        private  void managername_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            ObservableCollection<Employee> thead = new ObservableCollection<Employee>();
             thead= ViewModels.Adduser.getmanagerdetails(tname.Text,thead );
            var Auto = (AutoSuggestBox)sender;
            var filtered = thead.Where(i => i.Firstname.Contains(this.managername.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();
            Auto.ItemsSource = filtered;
          //  Auto.TextMemberPath="Firstname + Lastname";
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Adduser au = new Adduser();
            headgrid.Children.Clear();
            headgrid.Children.Add(au);
            adduser.Focus(FocusState.Keyboard);
        }

       
    }
}
