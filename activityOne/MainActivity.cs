using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Database;
using Android.Database.Sqlite;

namespace activityOne
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText email;
        EditText password;
        Button loginBtn;
        Button signUpbtn;
        DBHelper myDbInstace;

        Intent i;

        Android.App.AlertDialog.Builder myAlert;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            myDbInstace = new DBHelper(this);


            email = FindViewById<EditText>(Resource.Id.userName);
            password = FindViewById<EditText>(Resource.Id.password);

            loginBtn = FindViewById<Button>(Resource.Id.login);

            loginBtn.Click += myButtonClick;

            signUpbtn = FindViewById<Button>(Resource.Id.signUp);

            signUpbtn.Click += SignUpbtnClick;

        }

        private void SignUpbtnClick(object sender, EventArgs e)
        {
            i = new Intent(this, typeof(register));
            StartActivity(i);
        }

        private void myButtonClick(object sender, EventArgs e)
        {
            var vName = email.Text;
            var vPassword= password.Text;

            myAlert = new Android.App.AlertDialog.Builder(this);

            
            if(vName == " "  || vName.Equals(""))
            {
                errorMessageDialog("username");
            
            }else if(vPassword == " " || vPassword.Equals(""))
            {
                errorMessageDialog("password");
            }
            else
            {
                int IDfromDB = myDbInstace.validateLogin(vName, vPassword);
                if (IDfromDB != 0)
                {

                    i = new Intent(this, typeof(welcomeScreen));
                    i.PutExtra("id", IDfromDB.ToString());
                    StartActivity(i);
                }
                else
                {
                    myAlert.SetTitle("Error!!!");
                    myAlert.SetMessage("Invalid Username or password");
                    myAlert.SetPositiveButton("OK", OkAction);
                    Dialog myDialog = myAlert.Create();
                    myDialog.Show();
                }
            }
        }

        private void errorMessageDialog(string msg)
        {
            myAlert.SetTitle("Error");
            myAlert.SetMessage("Please enter a " + msg);
            myAlert.SetPositiveButton("OK", OkAction);
            Dialog myDialog = myAlert.Create();
            myDialog.Show();
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            System.Console.WriteLine("Ok button is clicked!!!");
        }
    }
}

