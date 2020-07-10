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
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Taskuwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Adduser : Page
    {
        string path;

        SQLite.Net.SQLiteConnection conn;
        string newuserval;
        public Adduser()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,"Employeemanagement.db");
            conn = new SQLite.Net.SQLiteConnection(new
               SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            if (newuser1.IsChecked == true)
            {
                newuserval = Convert.ToString(newuser1.Content);
            }
            // conn.DropTable<Employee>();
            conn.CreateTable<Employee>();
           
            conn.CreateTable<Teamdetails>();
            var query = conn.Table<Employee>();
            int max = 0;
            foreach(Employee emp in query)
            {
                if(emp.empid>=max)
                {
                    max = emp.empid;
                }
            }
            max = max + 1;
            empid.Text =Convert.ToString(max);
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

        private async void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool pteam = false;
                string parent="None";
                var checkquery = conn.Table<Employee>();
                var insert = conn.Table<Team>();
                  string teamname = tname.Text;
                    foreach(Employee det in checkquery)
                    {
                     if(teamname==det.Teamname && det.Designation== "Member Leadership Staff")
                        {
                            pteam = true;
                            break;
                        }
                    }
                    if(pteam==false) 
                    {
                        //parent = "Childteam";
                        string[] words = new string[2];
                             words= teamname.Split("-");
                        foreach(Employee de in checkquery)
                        {
                            if (de.Designation == "Member Leadership Staff")
                            {
                                string[] words2 = new string[2];
                                 words2 = de.Teamname.Split("-");
                                if (words[1] == words2[1])
                                {
                                    parent = de.Teamname;
                                    
                                    break;
                                }
                            }
                        }
                    
                   if(pteam==true)
                    {
                        parent = "None";
                        
                    }
                }
                var insertquery = conn.Insert(new Employee
                {

                    password = "1234",
                    user_as = newuserval,
                    Designation = designationselected,
                    Firstname = fname.Text,
                    Lastname = lname.Text,
                    Phoneno = mno.Text,
                    Emailid = email.Text,
                    Teamname = tname.Text,

                    Managername = managername.Text,
                    Gender = genderval,
                    Emergencyno = emergencyno.Text,
                    Maritialstatus = mstatus.Text,
                    Dob = dob.DateFormat,
                    Fathername = faname.Text,
                    Salaryaccno = accno.Text,
                    Presentaddr = prstaddr.Text,
                    Permnentaddr = permtaddr.Text,
                    Mothertongue = mtongue.Text,
                    Bloodgroup = bgroup.Text,


                }) ;
                string teamlead=null;
                string teammember = null;
                string tmailid = null;
                if (designationselected == "Member Leadership Staff")
                {
                    teamlead = fname.Text + " " + lname.Text;
                    teammember = "null";
                }
                if(designationselected== "Member Technical Staff" || designationselected== "Project Trainee")
                {
                    teammember = fname.Text + " " + lname.Text;
                    teamlead = "null";
                }
                tmailid = (tname.Text).ToLower();
                tmailid = tmailid + "@gmail.com";
                var insertteam = conn.Insert(new Teamdetails
                {
                    Empid = Convert.ToInt32(empid.Text),
                    teamname=tname.Text,
                   teamhead=teamlead,
                   teammember=teammember,
                   membermanagername=managername.Text,
                   parentteamname=parent,
                   teammailid=tmailid,
                });
                
                MessageDialog successdia = new MessageDialog("Datas added successfully!");
                await successdia.ShowAsync();
            }
            catch(Exception ex)
            {
                MessageDialog faildia = new MessageDialog(ex.Message);
                await faildia.ShowAsync();
            }
            
        }

        private string[] Autoitems = new string[20];
        private  void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
           
            bool ifexist = false;
            int count = 0;
            var selquery = conn.Table<Employee>();
            foreach (Employee det in selquery)
            {
                ifexist = false;
              for(int i=0;i<count;i++)
                {
                    if (det.Teamname == Autoitems[i])
                    {
                        ifexist = true;
                        break;
                    }
                }
                if (ifexist == false)
                {
                    Autoitems[count] = det.Teamname;
                    count++;
                }
             }
               
            var Auto = (AutoSuggestBox)sender;
           // var Suggestion = Autoitems.Where(p => p.StartsWith(Auto.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
            Auto.ItemsSource = Autoitems;
        }
        /*  private string[] marketing = new string[] { "Raja vel", "Priyal" };
          private string[] design = new string[] { "Rohit", "John davit" };
          private string[] support = new string[] { "Menaga", "Bholo shankar" };
          private string[] vcliq = new string[] { "Senthil Kumar Kalaiselvan", "Arivazhagan"};
          private string[] vcliqdes = new string[] {  "Lakshmi", "Sharukhan" };
          private string[] vcliqmac = new string[] { "Lavanya", "Abdula" };
          private string[] vbigin = new string[] { "Devi Manikam", "Sowjanya Marpine" };
          private string[] vmail = new string[] { "Gayathri ragunathan",  "Harinath" };
          private string[] vmailwin = new string[] { "Madhu chandrashekar", "Vallimeena ganesh" };
          private string[] vmailmac = new string[] { "Saravana kumar" };
          private string[] vbiginandr = new string[] { "Baby anandan", "Dhanabal"};
          private string[] vbiginios = new string[] { "Honest raj", "Bhuvaneshwari sivagurunathan" };*/

        private string[] managersugg = new string[1];

         private  void managername_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            bool pteam = false;
            string parent = "None";
            var checkquery = conn.Table<Employee>();

            string teamname = tname.Text;
            foreach (Employee det in checkquery)
            {
                if (teamname == det.Teamname && det.Designation == "Member Leadership Staff")
                {
                    pteam = true;
                    break;
                }
            }
            if (pteam == false)
            {
                parent = "Childteam";
                string[] words = new string[2];
                words = teamname.Split("-");
                foreach (Employee de in checkquery)
                {
                    if (de.Designation == "Member Leadership Staff")
                    {
                        string[] words2 = new string[2];
                        words2 = de.Teamname.Split("-");
                        if (words[1] == words2[1])
                        {
                            parent = de.Teamname;

                            break;
                        }
                    }
                }

                if (pteam == true)
                {
                    parent = "None";

                }
            }
            int count = 0;
            var selquery = conn.Table<Employee>();
            foreach (Employee det in selquery)
            {
                if (det.Teamname == tname.Text && det.Designation== "Member Leadership Staff")
                {
                    managersugg[count] = det.Firstname+ " "  + det.Lastname;
                    count++;
                    break;
                }
            }
            if (count == 0)
            {
             foreach(Employee de in selquery)
                {
                    if(parent==de.Teamname)
                    {
                        managersugg[count] = de.Firstname + " " + de.Lastname;
                        count++;
                        break;
                    }
                }
            }
            var Auto = (AutoSuggestBox)sender;
            Auto.ItemsSource = managersugg;

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
