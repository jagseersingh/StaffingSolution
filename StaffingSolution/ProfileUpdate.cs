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
    [Activity(Label = "ProfileUpdate")]
    public class ProfileUpdate : Activity
    {
        private string username;
        private string pw;
        StaffingDb tempDp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            tempDp = new StaffingDb(this);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.UserProfile);

            username = System.Environment.GetEnvironmentVariable("username");
            pw = System.Environment.GetEnvironmentVariable("userpass");

            //Button profileUpdate = FindViewById<Button>(Resource.Id.profileEdit);

            List<String> userRecord = tempDp.getUserDetails(username);

            EditText fname = FindViewById<EditText>(Resource.Id.fname);
            EditText lname = FindViewById<EditText>(Resource.Id.lname);
            EditText age = FindViewById<EditText>(Resource.Id.age);
            EditText emailId = FindViewById<EditText>(Resource.Id.emailId);
            EditText password = FindViewById<EditText>(Resource.Id.password);

            fname.Text = userRecord[0];
            lname.Text = userRecord[1];
            age.Text = userRecord[2];
            emailId.Text = userRecord[3];
            password.Text = userRecord[4];

            fname.Enabled = false;
            lname.Enabled = false;
            age.Enabled = false;
            emailId.Enabled = false;
            password.Enabled = false;

            Button btnUpdate = FindViewById<Button>(Resource.Id.Edit);

           

            btnUpdate.Click += UpdateUserInfo;
            // Create your application here
        }



        void UpdateUserInfo(object sender, System.EventArgs e)
        {
            StaffingDb tempDb = new StaffingDb(this);
            //Button btnUpdate = FindViewById<Button>(Resource.Id.updateField);

            Button btnUpdate = FindViewById<Button>(Resource.Id.Edit);

            var screenAction = btnUpdate.Text;
            EditText fname = FindViewById<EditText>(Resource.Id.fname);
            EditText lname = FindViewById<EditText>(Resource.Id.lname);
            EditText age = FindViewById<EditText>(Resource.Id.age);
            EditText emailId = FindViewById<EditText>(Resource.Id.emailId);
            EditText password = FindViewById<EditText>(Resource.Id.password);

            if (screenAction == "Edit")
            {
                fname.Enabled = true;
                lname.Enabled = true;
                age.Enabled = true;
                emailId.Enabled = true;
                password.Enabled = true;
                btnUpdate.Text = "Save";
            }
            else
            {
               tempDb.updateUserRecord(fname.Text, lname.Text, age.Text, emailId.Text, password.Text);

                System.Console.Write("record updated");

                Intent alluserList = new Intent(this, typeof(ViewAllUsersList));

                StartActivity( alluserList );
            }
        }
    }
}