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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.welcome);

            string nameText = Intent.GetStringExtra("name");
            TextView name = FindViewById<TextView>(Resource.Id.welcomMessage);
            name.Text = "Welcome " + nameText;
        }
    }
}