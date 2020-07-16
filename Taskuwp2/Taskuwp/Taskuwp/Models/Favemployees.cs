using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskuwp.Models
{
   public class Favemployees:INotifyPropertyChanged
    {
        public int Empid_self { get; set; }
        public string Empname { get; set; }
        public int Empid_another { get; set; }
        
        private string isfav;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Isfav
        {
            get
            {
                return isfav;
            }
            set
            {
                isfav = value;
                onPropertychanged("Isfav");
            }
        }
        private void onPropertychanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
