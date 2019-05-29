﻿using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace activityOne
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText name;
        EditText password;
        Button loginBtn;
        Android.App.AlertDialog.Builder myAlert;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            name = FindViewById<EditText>(Resource.Id.userName);
            password = FindViewById<EditText>(Resource.Id.password);

            loginBtn = FindViewById<Button>(Resource.Id.login);

            loginBtn.Click += myButtonClick;

        }

        private void myButtonClick(object sender, EventArgs e)
        {
            var nameVar = name.Text;
            var passwordVar = password.Text;

            myAlert = new Android.App.AlertDialog.Builder(this);

            
            if(nameVar == " "  || nameVar.Equals(""))
            {
                myAlert.SetTitle("Error");
                myAlert.SetMessage("Please enter a username.");
                myAlert.SetPositiveButton("OK", OkAction);
                Dialog myDialog = myAlert.Create();
                myDialog.Show();
            }
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            System.Console.WriteLine("Ok button is clicked!!!");
        }
    }
}

