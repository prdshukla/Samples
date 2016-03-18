﻿using System;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MyDriving.UITests
{
    public class SettingsPage : BasePage
    {
        readonly Func<string, Query> CheckBox;
        readonly Query SettingsTab;

        public SettingsPage()
            : base ("Settings", "Settings")
        {
            if (OniOS)
            {
                SettingsTab = x => x.Class("UINavigationItemButtonView").Marked("Settings");
            }
            if (OnAndroid)
            { 
                CheckBox = (arg) => x => x.Marked(arg).Parent(0).Sibling().Descendant().Id("checkbox"); 
            }
        }

        public SettingsPage SetDistanceSetting()
        {
            if (OnAndroid)
            {
                app.Tap(CheckBox("Metric Distance"));
                app.Screenshot("Using Metric Distances");
            }
            if (OniOS)
            { 
                app.Tap("Distance");
                app.Tap("Metric (km)");
                app.Screenshot("Using Metric Distances");

                app.Tap(SettingsTab);
            }

            return this;
        }

        public SettingsPage SetCapacitySetting()
        {
            if (OnAndroid)
            {
                app.Tap(CheckBox("Metric Units"));
                app.Screenshot("Using Metric Capacity");
            }
            if (OniOS)
            {
                app.Tap("Capacity");
                app.Tap("Metric (liters)");
                app.Screenshot("Using Metric Capacity");

                app.Tap(SettingsTab);
            }

            return this;
        }

        new public void NavigateTo(string marked)
        {
            if (OnAndroid)
                base.NavigateTo(marked);
            
            if (OniOS)
                app.Tap("Back");
        }
    }
}

