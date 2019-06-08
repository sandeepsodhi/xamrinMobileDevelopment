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
        TextView welcomeMessageText;
        EditText fnameEdit;
        EditText lnameEdit;
        EditText emailEdit;
        EditText ageEdit;
        EditText passwordEdit;
        string id;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.welcome);

            id = Intent.GetStringExtra("id");
            welcomeMessageText = FindViewById<TextView>(Resource.Id.welcomMessage);
            fnameEdit = FindViewById<EditText>(Resource.Id.fNameEdit);
            lnameEdit = FindViewById<EditText>(Resource.Id.lNameEdit);
            emailEdit = FindViewById<EditText>(Resource.Id.emailEdit);
            ageEdit = FindViewById<EditText>(Resource.Id.ageEdit);
            passwordEdit = FindViewById<EditText>(Resource.Id.passwordEdit);

            fnameEdit.Enabled = false;
            lnameEdit.Enabled = false;
            emailEdit.Enabled = false;
            ageEdit.Enabled = false;
            passwordEdit.Enabled = false;

            myDbInstace = new DBHelper(this);

            user userInfo = myDbInstace.selectMyValues(id);

            welcomeMessageText.Text = "Welcome " + userInfo.fname;
            fnameEdit.Text = userInfo.fname;
            lnameEdit.Text = userInfo.lname;
            emailEdit.Text = userInfo.email;
            ageEdit.Text = userInfo.age;
            passwordEdit.Text = userInfo.password;

            Button updateBtn = FindViewById<Button>(Resource.Id.btnUpdate);

            updateBtn.Click += updateInfo;



        }

        private void updateInfo(object sender, EventArgs e)
        {
            if (!fnameEdit.Enabled)
            {
                fnameEdit.Enabled = true;
                lnameEdit.Enabled = true;
                emailEdit.Enabled = true;
                ageEdit.Enabled = true;
                passwordEdit.Enabled = true;
            }
            else
            {
                var vfname = fnameEdit.Text;
                var vlname = lnameEdit.Text;
                var vage = ageEdit.Text;
                var vpassword = passwordEdit.Text;
                var vemail = emailEdit.Text;

                myDbInstace.updateData(id, vfname, vlname, vage, vpassword, vemail);
                

            }
        }
    }
}