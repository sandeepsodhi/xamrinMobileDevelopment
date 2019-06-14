using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;

namespace Week5
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ListView myListView;
        SearchView mySearchView;
        string[] myStringArray = { "m1 ", "a2" , "g3"};
        ArrayAdapter myAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            myListView = FindViewById<ListView>(Resource.Id.listView1);
            mySearchView = FindViewById<SearchView>(Resource.Id.searchView1);

            myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, myStringArray);
            
            myListView.Adapter = myAdapter;
            myListView.ItemClick += MyListView_ItemClick;
            mySearchView.QueryTextChange += MySearchView_QueryTextChange;

        }

        private void MySearchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            string searchValue = e.NewText;
            System.Console.WriteLine("value is: " +searchValue);

            List<string> newStringArray = new List<string>();

            foreach (string str in myStringArray)
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
            var myValue = myStringArray[index];
        }
    }
}