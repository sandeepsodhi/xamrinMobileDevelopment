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

namespace CustomListView
{
    class MyCustomAdapter : BaseAdapter<Subject>
    {
        Activity myContext;
        List<Subject> myListArray;

        public MyCustomAdapter(Activity context, List<Subject> myMovieList)
        {

            myContext = context;
            myListArray = myMovieList;

        }

        public override Subject this[int position]
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

            Subject subjObje = myListArray[position];

            if (myView == null)
            {
                myView = myContext.LayoutInflater.Inflate(Resource.Layout.myMovieView, null);

                myView.FindViewById<ImageView>(Resource.Id.myMovieImageId).SetImageResource(subjObje.subjectImage);
                myView.FindViewById<TextView>(Resource.Id.movieNameID).Text = subjObje.subjectName;
                myView.FindViewById<TextView>(Resource.Id.movieTypeID).Text = subjObje.subjectType;
            }

            return myView;
        }
    }
}