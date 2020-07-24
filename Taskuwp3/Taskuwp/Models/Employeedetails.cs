using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskuwp.Views;
using SQLite.Net.Attributes;
using Windows.Security.Authentication.OnlineId;
using System.ComponentModel;

namespace Taskuwp.Models
{
    class Employeedetails:INotifyPropertyChanged
    {
        [PrimaryKey]
        public String id { get; set; }
        public int userid;
        public string Username { get; set; }
        public string Password { get; set; }
        public string user;
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
        private string gender;
        public string Gendervalue
        {
            get
            {
                return gender;
            }
            set
            {

                gender = value;
                onPropertyChanged("Gendervalue");

            }

        }
        private float salary;
        public float Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
                onPropertyChanged("Salary");
            }
        }
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
        private long phoneno;
        public long Phoneno
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
        private string shift;
        public string Shift
        {
            get
            {
                return shift;
            }
            set
            {
                shift = value;
                onPropertyChanged("Shift");
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

        private string imagesource;
        public string Imagesource
        {
            get
            {
                return imagesource;
            }
            set
            {
                imagesource = value;


                // onPropertyChanged("Gendervalue");
                onPropertyChanged("Imagesource");

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

