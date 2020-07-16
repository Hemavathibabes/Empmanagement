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
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Animation;
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Taskuwp.Views
{
    public sealed partial class editpage : UserControl
    {
        string path;
        SQLite.Net.SQLiteConnection conn;
        ObservableCollection<Employee> emp = new ObservableCollection<Employee>();
        string EmailId;
        public editpage(string mid)
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Employeemanagement.db");
            conn = new SQLite.Net.SQLiteConnection(new
               SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
           emp= ViewModels.Selfservice.getdetails(mid, emp);
            foreach(Employee em in emp)
            {
                if(em.Emailid==mid)
                {
                    fname.Text = em.Firstname;
                    lname.Text = em.Lastname;
                    tname.Text = em.Teamname;
                    empid.Text = Convert.ToString(em.empid);

                    designation.Text = em.Designation;
                    email.Text = em.Emailid;
                    managername.Text = em.Managername;
                    gender.Text = em.Gender;

                    mno.Text = em.Phoneno;
                    if (em.Maritialstatus == "Single")
                    {
                        mstatus.SelectedIndex = 0;
                    }
                    if (em.Maritialstatus == "Married")
                    {
                        mstatus.SelectedIndex = 1;
                    }
                    if (em.Maritialstatus == "Widow")
                    {
                        mstatus.SelectedIndex = 2;
                    }

                    faname.Text = em.Fathername;
                    mtongue.Text = em.Mothertongue;
                    prstaddr.Text = em.Presentaddr;
                    emergencyno.Text = em.Emergencyno;
                    dob.Text = em.Dob;
                    accno.Text = em.Salaryaccno;
                    bgroup.Text = em.Bloodgroup;
                    permtaddr.Text = em.Permnentaddr;
                    EmailId = mid;
                }
            }
          
        }
      
        string mstatusselected;
        private void mstatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            mstatusselected = (combo.SelectedItem as ComboBoxItem).Content.ToString();
        }

        private void cancelbutton_Click(object sender, RoutedEventArgs e)
        {
            Selfservice ss = new Selfservice();
            headgrid.Children.Clear();
            headgrid.Children.Add(ss);
        }

        string mailId;
        private  void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            mailId = email.Text;
            ViewModels.Selfservice.updatedetails(mailId, mno.Text, mstatusselected, faname.Text, mtongue.Text,
                prstaddr.Text, emergencyno.Text, dob.Text, accno.Text, bgroup.Text, permtaddr.Text);
           
           
         
           
        }

        private void  backarrow_Tapped(object sender, TappedRoutedEventArgs e)
        {

            editframe.Navigate(typeof(Selfservice), EmailId);
            
           
        }
    }
}
