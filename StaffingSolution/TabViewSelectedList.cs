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
    class TabViewSelectedList : Fragment
    {
        string mylocalName;
        StaffingDb tempDb;
        ListView allUserListView;
        UserAdapter userList;
        ViewAllUsersList dhis;

        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public TabViewSelectedList(string name, UserAdapter uAdapter, StaffingDb argDbObj, ViewAllUsersList argDhis)  //, UserAdapter uAdapter
        {
            mylocalName = name;
            userList = uAdapter;
            tempDb = argDbObj;
            dhis = argDhis;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           
            View myView = inflater.Inflate(Resource.Layout.TabSelectedList, container, false);

            allUserListView = myView.FindViewById<ListView>(Resource.Id.selecetdList);
            SearchView mySearchView = myView.FindViewById<SearchView>(Resource.Id.selectedSearch);
            allUserListView.Adapter = userList;

            mySearchView.QueryTextChange += MySearchView_QueryTextChange;
            return myView;            
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

                allUserListView.Adapter = userList;
            }
        }

        public override void OnResume()
        {
            base.OnResume();
            System.Console.WriteLine(" OnResume selected List");

        }
    }
}