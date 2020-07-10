using Org.BouncyCastle.Bcpg;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskuwp.Models
{
  public  class Employee:INotifyPropertyChanged
    {
        [PrimaryKey][AutoIncrement]
        public int empid { get; set; }
        public string imagesource { get; set; }
        public string password { get; set; }
        public string user_as { get; set; }
       
        private string designation;
        public string Designation
        {
            get
            {
                return designation;
            }
            set
            {
                designation = value;
                onPropertyChanged("Designation");
            }
        }
        private string firstname;
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {

                firstname = value;
                onPropertyChanged("Firstname");

            }

        }
        private string lastname;
        public string Lastname
        {
            get
            {
                return lastname;

            }
            set
            {
                lastname = value;
                onPropertyChanged("Lastname");
            }
        }
        private string phoneno;
        public string Phoneno
        {
            get
            {
                return phoneno;
            }
            set
            {
                phoneno = value;
                onPropertyChanged("Phoneno");
            }
        }
        public string Emailid { get; set; }
        private string teamname;
        public string Teamname
        {
            get
            {
                return teamname;
            }
            set
            {
                teamname = value;
                onPropertyChanged("Teamname");
            }
        }
      
        private string managername;
        public string Managername
        {
            get
            {
                return managername;
            }
            set
            {
                managername = value;
                onPropertyChanged("Managername");

            }
        }

        private string gender;
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {

                gender = value;
                onPropertyChanged("Gender");

            }

        }
        private string emergencyno;
        public string Emergencyno
        {
            get
            {
                return emergencyno;
            }
            set
            {
                emergencyno = value;
                onPropertyChanged("Emergencyno");
            }
        }
       
      
        private string maritialstatus;
        public string Maritialstatus
        {
            get
            {
                return maritialstatus;
            }
            set
            {
                maritialstatus = value;
                onPropertyChanged("Maritialstatus");
            }
        }
        private string dob;
        public string Dob
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
                onPropertyChanged("Dob");
            }
        }

        private string fathername;
        public string Fathername
        {
            get
            {
                return fathername;
            }
            set
            {
                fathername = value;
                onPropertyChanged("Fathername");

            }

        }
        private string salaryaccno;
        public string Salaryaccno
        {
            get
            {
                return salaryaccno;
            }
            set
            {
                salaryaccno = value;
                onPropertyChanged("Salaryaccno");
            }
        }
        private string presentaddr;
        public string Presentaddr
        {
            get
            {
                return presentaddr;
            }
            set
            {
                presentaddr = value;
                onPropertyChanged("Presentaddr");
            }
        }
        private string permnentaddr;
        public string Permnentaddr
        {
            get
            {
                return permnentaddr;
            }
            set
            {
                permnentaddr = value;
                onPropertyChanged("Permnentaddr");
            }
        }
        private string mothertongue;
        public string Mothertongue
        {
            get
            {
                return mothertongue;
            }
            set
            {
                mothertongue = value;
                onPropertyChanged("Mothertongue");
            }
        }
        private string bloodgroup;
        public string Bloodgroup
        {
            get
            {
                return bloodgroup;
            }
            set
            {
                bloodgroup = value;
                onPropertyChanged("Bloodgroup");
            }
        }
        private void onPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;


    }
}

