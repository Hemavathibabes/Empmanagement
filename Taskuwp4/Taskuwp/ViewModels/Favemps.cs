using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Taskuwp.Models;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Animation;

namespace Taskuwp.ViewModels
{
   public class Favemps
    {
        //second parameter is another empid
      public static  int empid_self = 0;
      public static  string empname_self = null;
        public static void getempid(string mailid)
        {
            var getdata = DBAdapter.conn.Table<Employee>();
           
            foreach (Employee details in getdata)
            {
                if (details.Emailid == mailid)
                {
                    empid_self = details.empid;
                    empname_self = details.Firstname + " " + details.Lastname;
                    break;
                }
            }
        }
        public static string favemp(string mailid,int empid)
        {
            getempid(mailid);
           
            string fav = null;
            var isfav = DBAdapter.conn.Table<Favemployees>();
            foreach(Favemployees details in isfav)
            {
                if(details.Empid_self==empid_self && details.Empid_another==empid)
                {
                    fav = details.Isfav;
                    break;
                }
            }
            string empfav = null;
            if (fav == null)
            {
                empfav = "True";


                DBAdapter.conn.Insert(new Favemployees
                {
                    Empname = empname_self,
                    Empid_self = empid_self,
                    Empid_another = empid,
                    Isfav = empfav

                });
               
                DBAdapter.conn.Execute("UPDATE Employee SET Favop=? Where empid=?", "\uE1CF", empid);
            }
            else 
            {
                string favop = null;
                if (fav == "True")
                {
                    empfav = "False";
                    favop = "\uE1CE";
                }
                else
                {
                    empfav = "True";
                    favop = "\uE1CF";
                }
                DBAdapter.conn.Execute("UPDATE Favemployees SET Isfav=? Where Empid_self=? AND Empid_another=?",
                    empfav, empid_self, empid);
                
                
                DBAdapter.conn.Execute("UPDATE Employee SET Favop=? Where empid=?", favop, empid);
                
            }
            return empfav;
        }


        public async static void getfavemplist(string emailid,ObservableCollection<Employee> femp)
        {
            getempid(emailid);
            var getdetails = DBAdapter.conn.Table<Employee>();
            var getfav = DBAdapter.conn.Table<Favemployees>();
            foreach (Favemployees detail in getfav)
            {
                if (detail.Empid_self == empid_self)
                {
                    foreach (Employee details in getdetails)
                    {
                        if (details.empid ==detail.Empid_another && detail.Isfav=="True")
                        {
                            MessageDialog chuma = new MessageDialog(details.Firstname);
                            await chuma.ShowAsync();
                                details.imagesource = "ms-appx:///Assets/" + details.empid + ".jpg";
                                femp.Add(details);
                            
                        }
                    }
                }
            }
        }
        public static void getallempdetails(ObservableCollection<Employee> emp,string tname)
        {
            var query = DBAdapter.conn.Table<Employee>();
            foreach(Employee details in query)
            {
                if (details.Teamname == tname  || tname==null)
                {
                    details.imagesource = "ms-appx:///Assets/" + details.empid + ".jpg";
                    emp.Add(details);
                }
            }
        }
        public static void getclickedempdetails(int eid,string ename,ObservableCollection<Employee> emp)
        {
            var query = DBAdapter.conn.Table<Employee>();
            foreach(Employee details in query)
            {
                if(details.empid==eid && details.Firstname + " " +details.Lastname ==ename)
                {
                    details.imagesource = "ms-appx:///Assets/" + details.empid + ".jpg";
                    emp.Add(details);
                    break;
                }
            }

        }
       
    }
}
