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
        Button updateBtn, deleteBtn, allUsersBtn;

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
            
            EnabledisableEditBox(false);

            myDbInstace = new DBHelper(this);
            user userInfo = myDbInstace.selectMyValues(id);

            welcomeMessageText.Text = "Welcome " + userInfo.fname;
            fnameEdit.Text = userInfo.fname;
            lnameEdit.Text = userInfo.lname;
            emailEdit.Text = userInfo.email;
            ageEdit.Text = userInfo.age;
            passwordEdit.Text = userInfo.password;

            updateBtn = FindViewById<Button>(Resource.Id.btnUpdate);
            updateBtn.Click += updateInfo;

            deleteBtn = FindViewById<Button>(Resource.Id.btnDelete);
            deleteBtn.Click += deleteRecord;

            allUsersBtn = FindViewById<Button>(Resource.Id.btnAllUsers);
            allUsersBtn.Click += AllUsersBtn_Click;

        }

        private void AllUsersBtn_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(showUsers));
            StartActivity(i);

        }

        private void updateInfo(object sender, EventArgs e)
        {
            if (!fnameEdit.Enabled)
            {
                EnabledisableEditBox(true);
                updateBtn.Text = "Update";
            }
            else
            {
                var vfname = fnameEdit.Text;
                var vlname = lnameEdit.Text;
                var vage = ageEdit.Text;
                var vpassword = passwordEdit.Text;
                var vemail = emailEdit.Text;
                myDbInstace.updateData(id, vfname, vlname, vage, vpassword, vemail);
                updateBtn.Text = "Edit";
                EnabledisableEditBox(false);
                Toast.MakeText(this, "Update successfull",ToastLength.Long).Show();
;            }
        }

        private void deleteRecord(object sender, EventArgs e)
        {
            myDbInstace.deleteData(id);
            Toast.MakeText(this, "Deletion successful", ToastLength.Long).Show();

            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }

        private void EnabledisableEditBox(bool flag)
        {
            fnameEdit.Enabled = flag;
            lnameEdit.Enabled = flag;
            emailEdit.Enabled = flag;
            ageEdit.Enabled = flag;
            passwordEdit.Enabled = flag;
        }
    }
}