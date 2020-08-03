using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskuwp.Models;
using Windows.UI.Popups;

namespace Taskuwp.ViewModels
{
  public  class Loginuser
    {
        public static int checkvaliduser(string email,string password)
        {
            int loginstatus = 0;
            var checkquery = DBAdapter.conn.Table<Employee>();
            foreach (var message in checkquery)
            {
                if (email == message.Emailid)
                {
                    loginstatus = 1;
                    if (email == message.Emailid && password == message.password)
                    {

                        loginstatus = 2;
                        break;
                    }
                }

            }
            return loginstatus;
        }
       public  static bool updatepassword(string emailid,string password)

        {
            bool ifupdate = false;
            try
            {
                var checkuserid = DBAdapter.conn.Table<Employee>();
                foreach (var details in checkuserid)

                {

                    if (emailid == details.Emailid)
                    {
                        ifupdate = true;
                        DBAdapter.conn.Execute("UPDATE Employee SET password = ? Where Emailid=?", password, emailid);
                        break;
                    }

                }
               
            }
            catch
            {
                ifupdate = false;
               
            }
            return ifupdate;
            
        }
    }
}
