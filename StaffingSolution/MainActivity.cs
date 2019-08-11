using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Content;

using Android.Database.Sqlite;
using Android.Database;
using Android.Views;

namespace StaffingSolution
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
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

        
        //Android.Widget.SearchView searchView;
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // set the menu layout on Main Activity  
            MenuInflater.Inflate(Resource.Menu.menu1, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.homepage:
                    {
                        // add your code  
                        Intent listUsreScreem = new Intent(this, typeof(ProfileUpdate));
                        StartActivity(listUsreScreem);
                        return true;
                    }
                case Resource.Id.viewList:
                    {
                        // add your code  
                        Intent listUsreScreem = new Intent(this, typeof(ViewAllUsersList));
                        StartActivity(listUsreScreem);
                        return true;
                    }
            }

            return base.OnOptionsItemSelected(item);
        }
        /**/
    }
}