using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Content;

using Android.Database.Sqlite;
using Android.Database;

namespace StaffingSolution
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button myLoginBtn;
        StaffingDb customDb;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            customDb = new StaffingDb(this);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.WelComeScreen);

            myLoginBtn = FindViewById<Button>(Resource.Id.loginButton);

            myLoginBtn.Click += goToLoginScreen_Click;
        }


        private void goToLoginScreen_Click(object sender, System.EventArgs e)
        {

            Intent loginPage = new Intent(this, typeof(Login)); ;

            StartActivity(loginPage);

            //throw new System.NotImplementedException();
        }
    }
}