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
        ArrayAdapter myAdapter;
        DBHelper myDbInstance;
        List<string> stringArray = new List<string>();

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
                stringArray.Add(result.GetString(result.GetColumnIndexOrThrow("fname")));

            }

            myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, stringArray);

            myListView.Adapter = myAdapter;
            myListView.ItemClick += MyListView_ItemClick;
            mySearchView.QueryTextChange += MySearchView_QueryTextChange;
            // Create your application here
        }

        private void MySearchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            string searchValue = e.NewText;
            System.Console.WriteLine("value is: " + searchValue);

            List<string> newStringArray = new List<string>();

            foreach (string str in stringArray)
            {
                if (str.Contains(searchValue))
                {
                    newStringArray.Add(str.ToString());
                }
            }

            myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, newStringArray);
            myListView.Adapter = myAdapter;

        }

        private void MyListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
            var myValue = stringArray[index];
        }
    }
}