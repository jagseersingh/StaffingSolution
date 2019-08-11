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
    [Activity(Label = "ViewAllUsersList" )]
    public class ViewAllUsersList : Activity
    {
        StaffingDb tempDb;
        ListView mylistview;
        Fragment[] _fragmentsArray;
        UserAdapter tbvallList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            
            RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            
            base.OnCreate(savedInstanceState);
            
            tempDb = new StaffingDb(this);

                        
            SetContentView(Resource.Layout.FMlayout);

            

            List<SingleUser> userRecords =  tempDb.getAllusers();
            UserAdapter tbvallList = new UserAdapter(this, userRecords);

           //mylistview.Adapter = myAdapter;

            _fragmentsArray = new Fragment[]
            {
                new TabViewAllUsersList("All Users" , tbvallList , tempDb ,  this ),//, TabViewAllUsersList
                new TabViewAvailableUserList("Available Users" ,  tbvallList , tempDb ,  this ),
                new TabViewSelectedList("Selected" ,  tbvallList , tempDb ,  this ), //, myAdapter
            };


            AddTabToActionBar("View All"); //First Tab
            AddTabToActionBar("Available"); //Second Tab
            AddTabToActionBar("Selected"); //Third Tab

            //

        }
        

        void AddTabToActionBar(string tabTitle)
        {
            Android.App.ActionBar.Tab tab = ActionBar.NewTab();

            tab.SetText(tabTitle);

            tab.SetIcon(Android.Resource.Drawable.IcInputAdd);

            tab.TabSelected += TabOnTabSelected;

            ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
        {
            ActionBar.Tab tab = (ActionBar.Tab)sender;

            //Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Fragment frag = _fragmentsArray[tab.Position];

            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            this.MenuInflater.Inflate(Resource.Menu.loggedIn, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.homepage:
                    {
                        Intent listUsreScreem = new Intent(this, typeof(ProfileUpdate));
                        StartActivity(listUsreScreem);
                        
                        // add your code  
                        return true;
                    }
                case Resource.Id.profile:
                    {
                        Intent listUsreScreem = new Intent(this, typeof(ProfileUpdate));
                        StartActivity(listUsreScreem);
                        // add your code  
                        return true;
                    }
                case Resource.Id.logout:
                    {
                        Intent mainscreen = new Intent(this, typeof(MainActivity));
                        StartActivity(mainscreen);
                        // add your code  
                        return true;
                    }
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}