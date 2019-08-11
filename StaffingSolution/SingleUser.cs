using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace StaffingSolution
{
    class SingleUser
    {
        public String fname;
        public String lname;
        public String email;
        public int userId;
        public int userpic;
        public int movtoselect;

        public SingleUser(string argFname, string argLname, string argEmail, int argUserpic , int argusId)
        {
            this.fname = argFname;
            this.lname = argLname;
            this.email = argEmail;
            this.userpic = argUserpic;
            this.userId = argusId;
            this.movtoselect = argusId;
            System.Console.WriteLine(" user account id" + argusId);
        }
    }
}