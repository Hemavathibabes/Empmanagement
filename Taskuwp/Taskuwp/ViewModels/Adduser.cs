using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskuwp.Models;
using Windows.UI.Popups;

namespace Taskuwp.ViewModels
{
   public class Adduser
    {
       
        public static string getempid()
        {
            string empid;
            var query = DBAdapter.conn.Table<Employee>();
            int max = 0;
            foreach (Employee emp in query)
            {
                if (emp.empid >= max)
                {
                    max = emp.empid;
                }
            }
            max = max + 1;
            empid= Convert.ToString(max);
            return empid;
        }
        public async static void insertdata(string empid,string pwd,string newuser,string designation,string fname,string lname,string mobno,string email,string teamname,
            string maname,string gender,string emergencyno ,string mstatus,string dob,string fathername,string accno,
            string prstaddr,string permtaddr,string mtongue,string bgroup)
       
        {
            try
            {
                bool pteam = false;
                string parent = "None";
                var checkquery = DBAdapter.conn.Table<Employee>();
                var insert = DBAdapter.conn.Table<Teamdetails>();
              
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

                var insertquery = DBAdapter.conn.Insert(new Employee
                {
                    password =pwd,
                    user_as = newuser,
                    Designation = designation,
                    Firstname = fname,
                    Lastname = lname,
                    Phoneno = mobno,
                    Emailid = email,
                    Teamname = teamname,

                    Managername = maname,
                    Gender = gender,
                    Emergencyno = emergencyno,
                    Maritialstatus = mstatus,
                    Dob =dob,
                    Fathername = fathername,
                    Salaryaccno = accno,
                    Presentaddr = prstaddr,
                    Permnentaddr = permtaddr,
                    Mothertongue = mtongue,
                    Bloodgroup = bgroup,
                    Favop= "\uE1CE"
                });
                string teamlead = null;
                string teammember = null;
                string tmailid = null;
                if (designation == "Member Leadership Staff")
                {
                    teamlead = fname + " " + lname;
                    teammember = "null";
                }
                if (designation == "Member Technical Staff" || designation == "Project Trainee")
                {
                    teammember = fname + " " + lname;
                    teamlead = "null";
                }
                tmailid = (teamname).ToLower();
                tmailid = tmailid + "@gmail.com";
                var insertteam = DBAdapter.conn.Insert(new Teamdetails
                {
                    Empid = Convert.ToInt32(empid),
                    teamname = teamname,
                    teamhead = teamlead,
                    teammember = teammember,
                    membermanagername = maname,
                    parentteamname = parent,
                    teammailid = tmailid,
                });

                MessageDialog successdia = new MessageDialog("Datas added successfully!");
                await successdia.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog faildia = new MessageDialog(ex.Message);
                await faildia.ShowAsync();
            }

        }
        
        public static ObservableCollection<Employee> getdesignationdetails(ObservableCollection<Employee> emp)
        {
           
           
            var selquery = DBAdapter.conn.Table<Employee>();
            foreach (Employee det in selquery)
            {
               if(emp.Any(p=>p.Teamname==det.Teamname)==false)
               {
                    emp.Add(det);
                }
             
            }
            return emp;
        }
        public static ObservableCollection<Employee> getmanagerdetails(string teamname,ObservableCollection<Employee> thead)
        {
            bool pteam = false;
            string parent = "None";
            var checkquery = DBAdapter.conn.Table<Employee>();

           
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
            var selquery = DBAdapter.conn.Table<Employee>();
            foreach (Employee det in selquery)
            {
                if (det.Teamname == teamname && det.Designation == "Member Leadership Staff")
                {
                    det.imagesource = "ms-appx:///Assets/" + det.empid + ".jpg";
                    det.fullname = det.Firstname + " " + det.Lastname;
                    thead.Add(det);
                    count++;
                    break;
                }
            }
            if (count == 0)
            {
                foreach (Employee de in selquery)
                {
                    if (parent == de.Teamname)
                    {
                        de.imagesource = "ms-appx:///Assets/" + de.empid + ".jpg";
                        de.fullname = de.Firstname + " " + de.Lastname;
                        thead.Add(de);
                        count++;
                        break;
                    }
                }
            }
            return thead;
        }
    }
}
