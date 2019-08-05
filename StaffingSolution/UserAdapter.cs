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

namespace StaffingSolution
{
    class UserAdapter : BaseAdapter<SingleUser>
    {
        Activity myContext;
        List<SingleUser> myListArray;

        public UserAdapter(Activity context, List<SingleUser> userList)
        {
            myContext = context;
            myListArray = userList;

        }

        public override SingleUser this[int position]
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

            SingleUser userObj = myListArray[position];

            if (myView == null)
            {
                myView = myContext.LayoutInflater.Inflate(Resource.Layout.SingleUser, null);

                myView.FindViewById<ImageView>(Resource.Id.userPicId).SetImageResource(userObj.userpic);
                myView.FindViewById<TextView>(Resource.Id.userName).Text = userObj.fname;
                myView.FindViewById<TextView>(Resource.Id.userEmail).Text = userObj.email;
            }

            return myView;
        }
    }
}