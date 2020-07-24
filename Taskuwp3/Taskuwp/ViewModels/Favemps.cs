using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Taskuwp.Models;

namespace Taskuwp.ViewModels
{
   public class Favemps
    {
        //second parameter is another empid
        public static string favemp(string mailid,int empid)
        {
            var getdata = DBAdapter.conn.Table<Employee>();
             int empid_self=0;
            string empname_self=null;
            foreach(Employee details in getdata)
            {
                if(details.Emailid==mailid)
                {
                    empid_self = details.empid;
                    empname_self = details.Firstname + " " + details.Lastname;
                    break;
                }
            }
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
    }
}
