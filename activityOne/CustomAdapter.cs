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
    class CustomAdapter : BaseAdapter<user>
    {
        Activity myContext;
        List<user> myListArray;

        public CustomAdapter(Activity context, List<user> myUserList)
        {
            this.myContext = context;
            this.myListArray = myUserList;
        }

        public override user this[int position]
        {
            get { return myListArray[position]; }
        }

        public override int Count
        {
            get { return myListArray.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View myView = convertView;

            user usersObj = myListArray[position];

            if(myView == null)
            {
                myView = myContext.LayoutInflater.Inflate(Resource.Layout.customListLayout, null);

                myView.FindViewById<ImageView>(Resource.Id.image).SetImageResource(Resource.Drawable.image);
                myView.FindViewById<TextView>(Resource.Id.name).Text = usersObj.fname + " " + usersObj.lname;
                myView.FindViewById<TextView>(Resource.Id.email).Text = "Email: " + usersObj.email;
                myView.FindViewById<TextView>(Resource.Id.age).Text = "Age: " + usersObj.age;
            }

            return myView;
        }
    }
}