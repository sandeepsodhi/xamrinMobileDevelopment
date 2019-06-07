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
    [Activity(Label = "welcomeScreen")]
    public class welcomeScreen : Activity
    {
        DBHelper myDbInstace;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.welcome);

            string id = Intent.GetStringExtra("id");
            TextView name = FindViewById<TextView>(Resource.Id.welcomMessage);

            myDbInstace = new DBHelper(this);

            user userInfo = myDbInstace.selectMyValues(id);



            name.Text = "Welcome " + userInfo.fname + "Welcome " + userInfo.lname + "Welcome " + userInfo.email + "Welcome " + userInfo.password + "Welcome " + userInfo.age;


        }
    }
}