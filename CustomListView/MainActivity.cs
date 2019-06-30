using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;

namespace CustomListView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ListView myListView;
        SearchView mySearchView;
        List<Subject> myMovieList = new List<Subject>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            myListView = FindViewById<ListView>(Resource.Id.myListView);
            mySearchView = FindViewById<SearchView>(Resource.Id.searchView1);


            myMovieList.Add(new Subject("Mobile Development", Resource.Drawable.image, "Action"));
            myMovieList.Add(new Subject("Emerging Technologies", Resource.Drawable.image, "Action"));
            myMovieList.Add(new Subject("Project Management", Resource.Drawable.image, "Action"));
            myMovieList.Add(new Subject("C# .net", Resource.Drawable.image, "Action"));
            myMovieList.Add(new Subject("Web Development", Resource.Drawable.image, "Action"));

            var myAdapter = new MyCustomAdapter(this, myMovieList);

            myListView.Adapter = myAdapter;
            mySearchView.QueryTextChange += MySearchView_QueryTextChange;

        }

        private void MySearchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            string searchValue = e.NewText;
            System.Console.WriteLine("value is: " + searchValue);

            List<Subject> newStringArray = new List<Subject>();

            foreach (Subject sub in myMovieList)
            {
                if (sub.subjectName.Contains(searchValue))
                {
                    newStringArray.Add(sub);
                }
            }

            var myAdapter = new MyCustomAdapter(this, newStringArray);
            myListView.Adapter = myAdapter;

        }
    }
}