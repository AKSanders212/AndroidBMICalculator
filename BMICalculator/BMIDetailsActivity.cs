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

namespace BMICalculator
{
    [Activity(Label = "BMIDetailsActivity")]
    public class BMIDetailsActivity : Activity
    {
        // Aaron Sanders: Create instance of the controls
        TextView bmiDetailTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            // Aaron Sanders: Set your content for your new layout first
            SetContentView(Resource.Layout.BMIDetails);
            bmiDetailTextView = FindViewById<TextView>(BMICalculator.Resource.Id.bmiDetailTextView);

            float bmi = Intent.Extras.GetFloat("bmi_value");

            EvaluateBMI(bmi);
        }

        void EvaluateBMI(float bmi)
        {
            string result = String.Empty;

            if (bmi <= 16)
                result = "very low";
            else if (bmi < 18.5)
                result = "low";
            else if (bmi < 25)
                result = "normal";
            else if (bmi < 30)
                result = "high";
            else
                result = "too high !";

            bmiDetailTextView.Text = result;
        }
    }
}