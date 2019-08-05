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
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        Button loginBtn;
        Android.App.AlertDialog.Builder myAlert;
        StaffingDb tempDb;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LoginScreen);
            // Create your application here
            tempDb = new StaffingDb(this);

            var gotoAccount = FindViewById<TextView>(Resource.Id.createAccount);
            loginBtn = FindViewById<Button>(Resource.Id.loginBtn1);
            gotoAccount.Click += GotoAccount_Click;
            loginBtn.Click += LoginBtn_Click;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {

            var userNameID = FindViewById<EditText>(Resource.Id.userNameID);
            var password = FindViewById<EditText>(Resource.Id.password);

            var uname = userNameID.Text;
            var upass = password.Text;
            var loginStatus = true;
            myAlert = new Android.App.AlertDialog.Builder(this);
            System.Console.WriteLine("My username : " + uname + " and Password: " + upass);

            if (uname == " " || uname.Equals(""))
            {
                System.Console.WriteLine("Empty Username");
                loginStatus = false;
            }
            if (upass == " " || upass.Equals(""))
            {
                System.Console.WriteLine("Empty Password");
                loginStatus = false;
            }

            if (loginStatus == false)
            {
                myAlert.SetTitle("Error");
                myAlert.SetMessage("Empty username or password");
                myAlert.SetPositiveButton("OK", OkAction);
                myAlert.SetNegativeButton("Cancel", CancelAction);
                Dialog myDialog = myAlert.Create();
                myDialog.Show();
            }

            if (loginStatus)
            {

                bool userStatus = tempDb.checkLoginCredentials(uname, upass);

                if (userStatus)
                {

                    //Intent listUsreScreem = new Intent(this, typeof(ViewUsers));
                    Intent listUsreScreem = new Intent(this, typeof(ViewAllUsersList));
                    listUsreScreem.PutExtra("userName", uname);
                    StartActivity(listUsreScreem);
                }
                else
                {
                    myAlert.SetTitle("Error");
                    myAlert.SetMessage("Invalid Login details");
                    myAlert.SetPositiveButton("OK", OkAction);
                    myAlert.SetNegativeButton("Cancel", CancelAction);
                    Dialog myDialog = myAlert.Create();
                    myDialog.Show();
                }
                //throw new NotImplementedException();
            }
        }
        private void GotoAccount_Click(object sender, EventArgs e)
        {
            Intent registerPage = new Intent(this, typeof(Register));
            StartActivity(registerPage);
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            System.Console.WriteLine("OK Button Cliked");
        }


        private void CancelAction(object sender, DialogClickEventArgs e)
        {
            System.Console.WriteLine("Cancel Button Cliked");
        }
    }
}