﻿using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Content;

namespace BMICalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        // Aaron Sanders: Creating instance objects of the view controls
        Button calculateButton, resultsButton;
        TextView resultTextView;
        EditText heightEditText, weightEditText;

        float bmi = 20.0f;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            // Aaron Sanders: Setting those instance objects to the view controls I created
            calculateButton = FindViewById<Button>(BMICalculator.Resource.Id.calculateButton);
            resultsButton = FindViewById<Button>(BMICalculator.Resource.Id.resultsButton);
            resultTextView = FindViewById<TextView>(BMICalculator.Resource.Id.resultTextView);
            heightEditText = FindViewById<EditText>(BMICalculator.Resource.Id.heightEditText);
            weightEditText = FindViewById<EditText>(BMICalculator.Resource.Id.weightEditText);

            calculateButton.Click += CalculateButton_Click;
            resultsButton.Click += ResultsButton_Click;
        }

        private void ResultsButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BMIDetailsActivity));
            intent.PutExtra("bmi_value", bmi);
            StartActivity(intent);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            float height = float.Parse(heightEditText.Text);
            float weight = float.Parse(weightEditText.Text);

            bmi = weight / (height * height);

            resultTextView.Text = bmi.ToString();

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

