using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinBlogPost.Models;
using XamarinBlogPost.ViewModels;
using XamarinBlogPost.Views;

namespace XamarinBlogPost
{
    public class App : Application
    {
        public App()
        {
            var repository = new MemoryBlogPostRepository();
            var applicationViewModel = new ApplicationViewModel(repository);
            var defaultFactory = new BlogPostSelectorPageFactory();
            var factory = new DummyBlogPostSelectorPageFactory(defaultFactory);

            MainPage = new ApplicationMasterDetailPage(applicationViewModel, defaultFactory);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
