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
        
        string EmailId;
        public editpage(string mid)
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Employeemanagement.db");
            conn = new SQLite.Net.SQLiteConnection(new
               SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            getselfdata(mid);
            EmailId = mid;
        }
        public void getselfdata(string mid)
        {
            var selectquery = conn.Table<Employee>();
            foreach(Employee details in selectquery)
            {
                if(mid==details.Emailid)
                {
                    empid.Text = Convert.ToString(details.empid);
                    fname.Text = details.Firstname;
                    lname.Text = details.Lastname;
                    tname.Text = details.Teamname;
                    designation.Text = details.Designation;
                    email.Text = details.Emailid;
                    managername.Text = details.Managername;
                    gender.Text = details.Gender;
                    
                    mno.Text=details.Phoneno;
                    if(details.Maritialstatus=="Single")
                    {
                        mstatus.SelectedIndex = 0;
                    }
                    if(details.Maritialstatus=="Married")
                    {
                        mstatus.SelectedIndex = 1;
                    }
                    if(details.Maritialstatus=="Widow")
                    {
                        mstatus.SelectedIndex = 2;
                    }
                     
                    faname.Text=details.Fathername;
                     mtongue.Text=details.Mothertongue;
                    prstaddr.Text=details.Presentaddr;
                    emergencyno.Text=details.Emergencyno;
                    dob.Text=details.Dob;
                    accno.Text=details.Salaryaccno;
                    bgroup.Text=details.Bloodgroup;
                    permtaddr.Text=details.Permnentaddr;
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
        private async void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            mailId = email.Text;
           
            string pno = mno.Text;
            string mstatus = mstatusselected;
            string fathername = faname.Text;
            string mothertongue = mtongue.Text;
            string presentaddr = prstaddr.Text;
            string emergency = emergencyno.Text;
            string daob = dob.Text;
            string Accno = accno.Text;
            string bloodgup = bgroup.Text;
            string permnentaddr = permtaddr.Text;
            bool ustatus = false;
          
                var updatequery = conn.Table<Employee>();
                foreach(Employee items in updatequery)
                {
                   if(mailId==items.Emailid)
                    {
                        ustatus = true;
                        conn.Execute("UPDATE Employee SET Phoneno=?,Emergencyno=?,Maritialstatus=?," +
                            "Dob=?,Fathername=?,Salaryaccno=?,Presentaddr=?,Permnentaddr=?,Mothertongue=?,Bloodgroup=? Where Emailid=?"
                            ,pno,emergency,mstatus,daob,fathername,Accno,presentaddr,permnentaddr,mothertongue,bloodgup,mailId);
                        break;
                    }
                }
                if (ustatus == false)
                {
                    MessageDialog success = new MessageDialog("Data can't update");
                    await success.ShowAsync();
                }
                else
                {
                    MessageDialog failure = new MessageDialog("Data updated successfully!");
                    await failure.ShowAsync();
                }
            
           
        }

        private void  backarrow_Tapped(object sender, TappedRoutedEventArgs e)
        {

            editframe.Navigate(typeof(Selfservice), EmailId);
            
           
        }
    }
}
