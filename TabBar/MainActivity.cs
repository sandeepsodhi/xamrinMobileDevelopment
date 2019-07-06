using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace TabBar
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Fragment[] _fragmentsArray;
        string name = "Welcome to my  App";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //set our view from the "main layout" resource
            RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
            //Enable navigation mode to support tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _fragmentsArray = new Fragment[]
            {
                new FirstFragment(name),
                new SecondFragment(),
            };

            AddTabToActionBar("First");
            AddTabToActionBar("Second");
        }

        void AddTabToActionBar(string tabTitle)
        {
            Android.App.ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText(tabTitle);

            tab.SetIcon(Android.Resource.Drawable.IcMediaPlay);
            tab.TabSelected += TabOnTabSelected;

            ActionBar.AddTab(tab);
        }

        private void TabOnTabSelected(object sender, Android.App.ActionBar.TabEventArgs tabEventArgs)
        {
            Android.App.ActionBar.Tab tab = (Android.App.ActionBar.Tab)sender;

            //Log.Debug(Tag, "The tab {0} has been selected ", tab.Text);

            Fragment frag = _fragmentsArray[tab.Position];

            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }
    }
}

