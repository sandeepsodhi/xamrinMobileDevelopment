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

namespace activityOne
{
    public class user
    {
        public string fname;
        public string lname;
        public string email;
        public string password;
        public string age;

        public user(string fNameC, string lNameC, string emailC, string passwordC, string ageC)
        {
            this.fname = fNameC;
            this.lname = lNameC;
            this.email = emailC;
            this.password = passwordC;
            this.age = ageC;
        }

    }
}