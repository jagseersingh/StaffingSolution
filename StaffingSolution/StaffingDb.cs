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
using System.Collections;

using Android.Database.Sqlite;
using Android.Database;

// database file
namespace StaffingSolution
{
    class StaffingDb : SQLiteOpenHelper
    {

        //Step: 1 - 3:
        private static string _DatabaseName = "staffingDb.db";
        private const string userTable = "users";
        private const string listTable = "availableUsers";

        private const string ColumnID = "id";
        private const string FNAME = "fname";
        private const string LNAME = "lname";
        private const string AGE = "age";
        private const string EMAILID = "email";
        private const string userType = "userType"; // 1,2
        private const string PASSWORD = "password";
        private const string userStatus = "userStatus";


        public const string CreateUserTableQuery = "CREATE TABLE " +
        userTable + " ( " + ColumnID + " INTEGER PRIMARY KEY AUTOINCREMENT,"
            + FNAME + " TEXT NOT NULL,"
            + LNAME + " TEXT,"
            + AGE + " TEXT,"
            + EMAILID + " TEXT,"
            + userType + " TEXT,"
            + userStatus + " Text,"
            + PASSWORD + " TEXT)";

        

        SQLiteDatabase myDBObj;
        Context myContext;
        public StaffingDb(Context context) : base(context, name: _DatabaseName, factory: null, version: 1) //Step 2;
        {
            myContext = context;
            myDBObj = WritableDatabase;
        }
        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(CreateUserTableQuery);
        }


        public void insertUserRecord(string fname, string lname, string age, string emailId, string password , string type) {
            int available = 0;

            String insertSQL = "insert into " + userTable + " values (" +
               " null ," +
                "'" + fname + "'" + "," +
                "'" + lname + "'" + "," +
                "'" + age + "'" + "," +
                "'" + emailId + "'" + "," +
                "'" + type + "'" + "," +
                "'" + available + "'" + "," +
                "'" + password + "'" + ");";

            

            System.Console.WriteLine(" Insert SQL " + insertSQL);

            myDBObj.ExecSQL(insertSQL);

           // return true;
        }

        public List<String> getUserDetails(string username) {
            List<String> userDetail = new List<String>();

            string query = "select * from " + userTable + " where " + EMAILID + "='"+username+"'";
            System.Console.WriteLine(query);

            ICursor  result =  myDBObj.RawQuery(query, null);
            String fnamefromDB = "";
            String lnamefromDB = "";
            String emailfromDB = "";
            String agefromDB = "";
            String passwordfromDB = "";

            while (result.MoveToNext()) {

                fnamefromDB = "";
                fnamefromDB = result.GetString(result.GetColumnIndexOrThrow(FNAME));
                lnamefromDB = result.GetString(result.GetColumnIndexOrThrow(LNAME));
                emailfromDB = result.GetString(result.GetColumnIndexOrThrow(EMAILID));
                agefromDB = result.GetString(result.GetColumnIndexOrThrow(AGE));
                passwordfromDB = result.GetString(result.GetColumnIndexOrThrow(PASSWORD));
                //items.Add( fnamefromDB );

                System.Console.WriteLine("user found list " + fnamefromDB + ", " + lnamefromDB + ", " + emailfromDB + ", " + Resource.Drawable.nouser );

                

                System.Console.WriteLine("User is being fetched.." + fnamefromDB + " \n");
            }

            userDetail = new List<String>() { fnamefromDB, lnamefromDB, agefromDB , emailfromDB, passwordfromDB };

            return userDetail;
        }

        public Boolean updateUserRecord(string fname, string lname, string age, string emailId, string password)
        {
            String insertSQL = "update " + userTable + " set " +
                FNAME + " = '" + fname + "'" + "," +
                LNAME + " = '" + lname + "'" + "," +
                AGE + " = '" + age + "'" + "," +
                PASSWORD + " = '" + password + "'  WHERE " +
                EMAILID + " = '" + emailId + "'";

            System.Console.WriteLine(" Insert SQL " + insertSQL);

            myDBObj.ExecSQL(insertSQL);

            return true;

        }
        public string checkLoginCredentials(String emailId, String password)
        {
            string selectRecord = "Select " + ColumnID + ",userType  from " + userTable + "  Where  "
                + EMAILID + " = '" + emailId + "' and "
                + PASSWORD + " = '" + password + "'";

            System.Console.WriteLine(selectRecord);

            ICursor result = myDBObj.RawQuery(selectRecord, null);
            string uT = "";
            while (result.MoveToNext())
            {
                uT = result.GetString(result.GetColumnIndexOrThrow("userType"));
            }


                if (result.Count > 0)
            {

                System.Console.WriteLine("Email found");
                //return true;
                
            }
            else
            {
                System.Console.WriteLine("Not Email found");
                //return false;
            }
            return uT;
        }

        public List<SingleUser> getAllusers()
        {


            String sqlQuery = " Select * from " + userTable;

            ICursor result = myDBObj.RawQuery(sqlQuery, null);

            
            string fnamefromDB = "";
            string lnamefromDB = "";
            string emailfromDB = "";
            
            ArrayList items = new ArrayList();

            //List<String> myViewList = new List<String>();
            List<SingleUser> myViewList = new List<SingleUser>();

            int i = 0 ;
            int uid = 0;

            while (result.MoveToNext())
            {
                
                fnamefromDB = "";
                fnamefromDB = result.GetString(result.GetColumnIndexOrThrow(FNAME));
                lnamefromDB = result.GetString(result.GetColumnIndexOrThrow(LNAME));
                emailfromDB = result.GetString(result.GetColumnIndexOrThrow(EMAILID));
                uid = result.GetInt(result.GetColumnIndexOrThrow(ColumnID));
                //items.Add( fnamefromDB );

                System.Console.WriteLine("user found list " + fnamefromDB +", "+ lnamefromDB + ", " + emailfromDB + ", " + Resource.Drawable.nouser + ", " + uid);

                myViewList.Add(new SingleUser(fnamefromDB, lnamefromDB, emailfromDB, Resource.Drawable.nouser, uid));

                System.Console.WriteLine("User is being fetched.." + fnamefromDB + " \n");

                i++;

            }

            System.Console.WriteLine("user list above this");

            //List<String> userRecord = new List<String>() { IDfromDB, fnamefromDB, lnamefromDB, agefromDB, emailfromDB, passwordfromDB };


            return myViewList;
        }


        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }

    }
}