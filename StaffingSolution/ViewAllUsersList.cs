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

using Android.Database.Sqlite; // Step: 1 - 1
using Android.Database;
using System.Collections;

namespace StaffingSolution
{
    [Activity(Label = "ViewAllUsersList")]
    public class ViewAllUsersList : Activity
    {
        StaffingDb tempDb;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            tempDb = new StaffingDb(this);

            SetContentView(Resource.Layout.AllUsersListScreen);

            List<SingleUser> userRecords =  tempDb.getAllusers();
            // Create your application here
            var myAdapter = new UserAdapter(this, userRecords);
        }
    }
}