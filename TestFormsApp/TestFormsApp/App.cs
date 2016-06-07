﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GoogleAnalytics;
using GoogleAnalytics.Core;
using Xamarin.Forms;


namespace TestFormsApp
{
    public class App : Application
    {
        public App ()
        {
            GAServiceManager.Current.PayloadSent += delegate (object s, PayloadSentEventArgs ev)
            {
                Debug.WriteLine($"Payload sent! Response:\n{ev.Response}");
            };

            GAServiceManager.Current.PayloadFailed += delegate (object s, PayloadFailedEventArgs ev)
            {
                Debug.WriteLine($"Payload Failed! Error: {ev.Error}");
            };

            GAServiceManager.Current.PayloadMalformed += delegate (object s, PayloadMalformedEventArgs ev)
            {
                Debug.WriteLine($"Payload Malformed! HttpStatusCode: {ev.HttpStatusCode}");
            };


            B_Clicked(null, null);
            var button = new Button();
            button.Text = "ClickMe";
            button.Clicked += B_Clicked;

            // The root page of your application
            MainPage = new ContentPage {
                Content = new StackLayout {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        },
                       button,
                    }
                }
            };
        }

        private void B_Clicked(object sender, EventArgs e)
        {

        
            var config = new TrackerConfig();
            config.AppVersion = "1.0.0.0";
            config.TrackingId = "UA-11111111-1";
            config.AppId = "AppID";
            config.AppName = "TEST";
            config.AppInstallerId = Guid.NewGuid().ToString();

            config.Debug = true;

            TrackerFactory.Config = config;


            Tracker tracker;

            try
            {
                tracker = new TrackerFactory().GetTracker();
                tracker.SendView("MainPage");
            }
            catch (Exception ex)
            {

                int a = 5;
            }

            
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}
