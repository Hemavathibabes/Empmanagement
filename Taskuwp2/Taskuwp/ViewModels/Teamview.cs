using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskuwp.Models;
using Taskuwp.Views;
using Windows.UI.Popups;

namespace Taskuwp.ViewModels
{
    public class Teamview
    {
        public static ObservableCollection<Teamdetails> getdetails(ObservableCollection<Teamdetails> team)
        {
            var selectquery = DBAdapter.conn.Table<Teamdetails>();
            foreach (Teamdetails details in selectquery)
            {
                if (details.parentteamname == "None" && details.teammember == "null")
                {
                    team.Add(details);
                }
            }
            return team;

        }
        public static bool selectedteamdetails(string tname,string mname,ObservableCollection<Teamdetails> tdetails)
        {
            int c = 0;
            string pteam;
            bool backarrowshow = false;

            var squery = DBAdapter.conn.Table<Teamdetails>();
            foreach (Teamdetails cdetails in squery)
            {
                if (cdetails.teamname == tname)
                {
                    if (cdetails.parentteamname != "None")
                    {
                        backarrowshow = true;
                       
                    }
                    c++;
                }

            }
            foreach (Teamdetails detail in squery)
            {
                if (detail.teamname == tname)
                {
                    if (detail.teamhead == "null")
                    {
                        pteam = detail.parentteamname;
                        foreach (Teamdetails details in squery)
                        {
                            if (pteam == details.teamname && details.teamhead != "null")
                            {
                                mname = details.teamhead;
                                detail.teamhead = details.teamhead;
                            }
                        }
                    }
                    if (tdetails.Any(p => p.teamname == detail.teamname) == false)
                    {
                        detail.teamcount = c;
                        tdetails.Add(detail);

                    }

                }
            }
            return backarrowshow;
        }
        public  static bool getsubteamdetails(string tname,ObservableCollection<Teamdetails> subteam)
        {
            bool ifsubteamexist = false;
            var squery = DBAdapter.conn.Table<Teamdetails>();
            foreach (Teamdetails det in squery)
            {
                if (tname == det.parentteamname)
                {
                    
                    if (subteam.Any(p => p.teamname == det.teamname) == false)
                    {
                        ifsubteamexist = true;
                        subteam.Add(det);
                    }
              
                }
            }
            return ifsubteamexist;
        }
        public static void getselectedempdetails(string tname,string mname,ObservableCollection<Employee> thead,ObservableCollection<Employee> empl)
        {
            var selectquery = DBAdapter.conn.Table<Employee>();
            foreach (Employee hdetails in selectquery)
            {
                if (hdetails.Firstname + " " + hdetails.Lastname == mname)
                {
                    hdetails.imagesource = "ms-appx:///Assets/" + hdetails.empid + ".jpg";
                    thead.Add(hdetails);
                }
            }
            foreach (Employee details in selectquery)
            {
                if (details.Teamname == tname && details.Designation != "Member Leadership Staff")
                {
                    details.imagesource = "ms-appx:///Assets/" + details.empid + ".jpg";
                    empl.Add(details);
                }
            }
        }
    }
}
