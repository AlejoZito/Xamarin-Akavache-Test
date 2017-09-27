using Akavache;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XFApp4.Views;

namespace XFApp4
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            TabbedPage tabbedPage = new TabbedPage();
            var page1 = new NavigationPage(new Page1());
            page1.Title = "Test";
            tabbedPage.Children.Add(page1);
            var page2 = new NavigationPage(new View2());
            page2.Title = "Pag 2";
            tabbedPage.Children.Add(page2);

            //Set main page
            MainPage = tabbedPage;
        }

        protected override void OnStart()
        {
            base.OnStart();
            // Handle when your app starts
            MobileCenter.Start("dc6a22fa-9963-43d7-9c97-7bb84b65babf",
                               typeof(Analytics), typeof(Crashes));
            BlobCache.ApplicationName = "Test";
            BlobCache.EnsureInitialized();
            
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
