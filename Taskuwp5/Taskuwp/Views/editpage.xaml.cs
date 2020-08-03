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
using System.Globalization;
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Taskuwp.Views
{
    public sealed partial class editpage : UserControl
    {
       
        ObservableCollection<Employee> emp = new ObservableCollection<Employee>();
        string EmailId;
        public editpage(string mid)
        {
            this.InitializeComponent();
           
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
                  // dob.Date= new DateTimeOffset(Convert.ToDateTime(em.Dob));
                 // if(dob.Date!=null)
                    {
                        dob.Date = DateTime.ParseExact(em.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    }
                  
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
            string date = dob.Date.ToString();
            string formateddate = date.Split(" ")[0];
            ViewModels.Selfservice.updatedetails(mailId, mno.Text, mstatusselected, faname.Text, mtongue.Text,
                prstaddr.Text, emergencyno.Text, formateddate, accno.Text, bgroup.Text, permtaddr.Text);
           
                     
        }
        private string[] motongue = new string[] {"Assamese","Bengali","Bodo","Dogri","English","Gujarati","Hindi","Kannada",
        "Kashmiri","Konkani","Maithili","Malayalam","Manipuri","Marathi","Nepali","Odia","Punjabi","Sanskrit","Santhali","Sindhi",
        "Sourashtra","Tamil","Telugu","Urdu"};
        private void mtongue_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

            var Suggestion = motongue.Where(p => p.StartsWith(this.mtongue.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
            mtongue.ItemsSource = Suggestion;
        }
        private string[] blgroup = new string[] {"A2-ve","AB-ve","A1B-ve","A1-ve","B-ve","O-ve","A-ve","A1+ve","O+ve","A+ve",
        "B+ve","AB+ve","A1B+ve","A2+ve","A2B+ve","A3+ve","A1+ve","A1","O+ve","A1B+ve","O+ve","B+ve","A+ve","A1B+",
        "B+","O+","A+","O-","A1B+","A1+","B+ve","A+ve","AB+ve","A1-ve","O-ve","A-ve","AB-ve","A2+ve","A2B+ve","A1B-ve"};
        private void bgroup_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var Suggestion = blgroup.Where(p => p.StartsWith(this.bgroup.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
            bgroup.ItemsSource = Suggestion;
        }
        private void  backarrow_Tapped(object sender, TappedRoutedEventArgs e)
        {

            editframe.Navigate(typeof(Selfservice), EmailId);
            
           
        }
    }
}
