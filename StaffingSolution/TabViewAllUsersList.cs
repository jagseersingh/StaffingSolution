using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace StaffingSolution
{
    class TabViewAllUsersList : Fragment
    {
        string mylocalName;
        UserAdapter allUserList;
        StaffingDb tempDb;
        ViewAllUsersList dhis;
        ListView allUserListView;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public TabViewAllUsersList( string name, UserAdapter uAdapter, StaffingDb argDbObj , ViewAllUsersList argDhis )
        { 
            mylocalName = name;
            allUserList = uAdapter;
            tempDb = argDbObj;
            dhis = argDhis;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
             
             // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
             View myview = inflater.Inflate(Resource.Layout.TabAllUsers, container, false);
            
             allUserListView = myview.FindViewById<ListView>(Resource.Id.allUserList);
             SearchView  mySearchView = myview.FindViewById<SearchView>(Resource.Id.mainSearchId);

             allUserListView.Adapter = allUserList;

             mySearchView.QueryTextChange += MySearchView_QueryTextChange;

             return myview;
            /* */
            //return base.OnCreateView(inflater, container, savedInstanceState);
            
        }



        private void MySearchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            String typedText = e.NewText;

            List<SingleUser> usersArray = tempDb.getAllusers();
            List<SingleUser> userList2 = new List<SingleUser>();

            

            if (typedText.Length >= 1)
            {
                string currentItemText = "";

                //Console.WriteLine("TYPED TEXT IS "+ typedText);

                for (int i = 0; i < usersArray.Count; i++)
                {
                    currentItemText = usersArray[i].fname;

                    Console.WriteLine(currentItemText);

                    if (currentItemText.Contains(typedText))
                    {
                        userList2.Add(usersArray[i]);
                    }
                }
                UserAdapter myAdapter2 = new UserAdapter(dhis, userList2);

                allUserListView.Adapter = myAdapter2;
            }
            else
            {
                
                allUserListView.Adapter = allUserList;
            }
        }

        public override void OnResume()
        {
            base.OnResume();
            System.Console.WriteLine("OnResume");

        }

    }
}