using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace activityOne
{
    class showUsersFragment : Fragment
    {
        ListView myListView;
        SearchView mySearchView;
        //ArrayAdapter myAdapter;
        DBHelper myDbInstance;
        //List<string> stringArray = new List<string>();
        List<user> myUserList = new List<user>();
        Android.App.AlertDialog.Builder myAlert;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View myView = inflater.Inflate(Resource.Layout.showUsers, container, false);

            myDbInstance = new DBHelper(Activity);

            myListView = myView.FindViewById<ListView>(Resource.Id.listView1);
            mySearchView = myView.FindViewById<SearchView>(Resource.Id.searchView1);

            ICursor result = myDbInstance.showAllData();

            while (result.MoveToNext())
            {
                var fNameFromDb = result.GetString(result.GetColumnIndexOrThrow("fname"));
                var lNameFromDb = result.GetString(result.GetColumnIndexOrThrow("lname"));
                var emailFromDb = result.GetString(result.GetColumnIndexOrThrow("emails"));
                var ageFromDb = result.GetString(result.GetColumnIndexOrThrow("age"));
                var passwordFromDb = result.GetString(result.GetColumnIndexOrThrow("password"));

                //stringArray.Add(result.GetString(result.GetColumnIndexOrThrow("fname")));
                myUserList.Add(new user(fNameFromDb, lNameFromDb, emailFromDb, passwordFromDb, ageFromDb));
            }

            //myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, stringArray);
            var myAdapter = new CustomAdapter(Activity, myUserList);

            myListView.Adapter = myAdapter;
            myListView.ItemClick += MyListView_ItemClick;
            mySearchView.QueryTextChange += MySearchView_QueryTextChange;


            return myView;
            //            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        private void MySearchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            string searchValue = e.NewText;
            System.Console.WriteLine("value is: " + searchValue);

            //List<string> newStringArray = new List<string>();
            List<user> newUsers = new List<user>();

            //foreach (string str in stringArray)
            //{
            //    if (str.Contains(searchValue))
            //    {
            //        newStringArray.Add(str.ToString());
            //    }
            //}

            foreach (user userObj in myUserList)
            {
                if (userObj.fname.Contains(searchValue) || userObj.lname.Contains(searchValue))
                {
                    newUsers.Add(userObj);
                }
            }

            //myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, newStringArray);

            var myAdapter = new CustomAdapter(Activity, newUsers);
            myListView.Adapter = myAdapter;

        }

        private void MyListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
          //  AlertDialog.Builder
            //    var myValue = stringArray[index];
        }

    }
}