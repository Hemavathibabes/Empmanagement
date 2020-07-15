using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
namespace Taskuwp.Models
{
   public class Teamdetails
    {
        [PrimaryKey]
        [AutoIncrement]
        public int teamid { get; set; }
        public int Empid { get; set; }
        public string teamname { get; set; }
        public string teamhead { get; set; }
        public string teammember { get; set; }
        public string membermanagername { get; set; }
        public string parentteamname { get; set; }
        public string teammailid { get; set; }
        public int teamcount { get; set; }
    }
}
