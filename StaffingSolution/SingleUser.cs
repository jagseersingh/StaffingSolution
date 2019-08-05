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
        public int userpic;

        public SingleUser(string argFname, string argLname, string argEmail, int argUserpic)
        {
            this.fname = argFname;
            this.lname = argLname;
            this.email = argEmail;
            this.userpic = argUserpic;
        }
    }
}