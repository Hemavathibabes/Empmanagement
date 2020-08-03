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
   public class Selfservice
    {
       
        public static ObservableCollection<Employee> getdetails(string mid,ObservableCollection<Employee> Emp)
        {
            var selectquery = DBAdapter.conn.Table<Employee>();
            foreach (Employee details in selectquery)
            {
                if (mid == details.Emailid)
                {
                    details.Dob = Convert.ToString(details.Dob);
                    Emp.Add(details);
                    break;
                }
            }
            return Emp;
        }
        public async static void updatedetails(string mailId,string pno,string mstatus,string fathername,string mothertongue,
            string presentaddr,string emergency,string daob,string Accno,string bloodgup,string permnentaddr)
        {
           
            bool ustatus = false;

            var updatequery =DBAdapter.conn.Table<Employee>();
            foreach (Employee items in updatequery)
            {
                if (mailId == items.Emailid)
                {
                    ustatus = true;
                    DBAdapter.conn.Execute("UPDATE Employee SET Phoneno=?,Emergencyno=?,Maritialstatus=?," +
                        "Dob=?,Fathername=?,Salaryaccno=?,Presentaddr=?,Permnentaddr=?,Mothertongue=?,Bloodgroup=? Where Emailid=?"
                        , pno, emergency, mstatus, daob, fathername, Accno, presentaddr, permnentaddr, mothertongue, bloodgup, mailId);
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
    }
}
