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
    [Activity(Label = "showUsers")]
    public class showUsers : Activity
    {
        ListView myListView;
        SearchView mySearchView;
        //ArrayAdapter myAdapter;
        DBHelper myDbInstance;
        //List<string> stringArray = new List<string>();
        List<user> myUserList = new List<user>();      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.showUsers);

            myDbInstance = new DBHelper(this);


            myListView = FindViewById<ListView>(Resource.Id.listView1);
            mySearchView = FindViewById<SearchView>(Resource.Id.searchView1);

            ICursor result =  myDbInstance.showAllData();

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
            var myAdapter = new CustomAdapter(this, myUserList);

            myListView.Adapter = myAdapter;
            myListView.ItemClick += MyListView_ItemClick;
            mySearchView.QueryTextChange += MySearchView_QueryTextChange;
            // Create your application here
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
                if(userObj.fname.Contains(searchValue) || userObj.lname.Contains(searchValue))
                {
                    newUsers.Add(userObj);
                }
            }

            //myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, newStringArray);

            var myAdapter = new CustomAdapter(this, newUsers);
            myListView.Adapter = myAdapter;

        }

        private void MyListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
        //    var myValue = stringArray[index];
        }
    }
}