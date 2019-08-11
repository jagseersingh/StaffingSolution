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
    [Activity(Label = "Register")]
    public class Register : Activity
    {
        Button registerButton;
        EditText fname;
        EditText lname;
        EditText age;
        EditText emailId;
        EditText password;

        Android.App.AlertDialog.Builder myAlert;
        StaffingDb tempDb;        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RegisterScreen);
            // Create your application here
            tempDb = new StaffingDb(this);

            var accExist = FindViewById<TextView>(Resource.Id.accountExist);

            fname = FindViewById<EditText>(Resource.Id.fname);
            lname = FindViewById<EditText>(Resource.Id.lname);
            age = FindViewById<EditText>(Resource.Id.age);
            emailId = FindViewById<EditText>(Resource.Id.emailId);
            password = FindViewById<EditText>(Resource.Id.password);

            

            registerButton = FindViewById<Button>(Resource.Id.loginBtn1);


            

            //FindViewById<RadioButton>(Resource.Id.)

            //Spinner spinner1 = FindViewById<Spinner>(Resource.Id.userAccountType);

            //spinner1.ItemSelected += Spinner1_ItemSelected;

            //System.Console.WriteLine(spinner1.get);

            //var usertype = spinner1.getSelectedItem();

            //System.Console.WriteLine(usertype);

            accExist.Click += AccExist_Click;
            registerButton.Click += RegisterButton_Click;



        }

        private void Spinner1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var U_fname = fname.Text;
            var U_lname = lname.Text;
            var U_age = age.Text;
            var U_emailId = emailId.Text;
            var U_password = password.Text;


            RadioGroup rg1 = FindViewById<RadioGroup>(Resource.Id.userTypeField);
            String duserType;
            string userType;

            
            duserType = FindViewById<RadioButton>(rg1.CheckedRadioButtonId).Text;

            if (duserType == "Employer")
            {
                userType = "employer";
            }
            else {
                userType = "employe";
            }


            myAlert = new Android.App.AlertDialog.Builder(this);

            if (
                    (U_fname == "" || U_fname.Equals("")) ||
                    (U_lname == "" || U_lname.Equals("")) ||
                    (U_age == "" || U_age.Equals("")) ||
                    (U_emailId == "" || U_emailId.Equals("")) ||
                    (U_password == "" || U_password.Equals(""))
               )
            {

                myAlert.SetTitle("Error");
                myAlert.SetMessage("Please Enter all the fields");
                //myAlert.SetPositiveButton("OK", OkAction);
                //myAlert.SetNegativeButton("Cancel", CancelAction);
                Dialog myDialog = myAlert.Create();
                myDialog.Show();

            }
            else
            {

                System.Console.WriteLine(U_fname + "," + U_lname + "," + U_age + "," + U_emailId + "," + U_password);

                //int userType = 1;

                tempDb.insertUserRecord( U_fname, U_lname, U_age, U_emailId, U_password , userType );
                // all fields are entered just to save the data now
                System.Console.WriteLine("Record Inserted");

                Intent loginScreen = new Intent(this, typeof(MainActivity));

                StartActivity(loginScreen);
            }
        }

        private void AccExist_Click(object sender, EventArgs e)
        {
            Intent accountExist = new Intent(this, typeof(Login));
            StartActivity(accountExist);
        }
    }
}