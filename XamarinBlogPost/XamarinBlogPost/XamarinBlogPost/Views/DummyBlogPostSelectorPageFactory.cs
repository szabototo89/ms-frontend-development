using System;
using System.Linq;
using Xamarin.Forms;
using XamarinBlogPost.ViewModels;

namespace XamarinBlogPost.Views
{
    public class DummyBlogPostSelectorPageFactory : IBlogPostSelectorPageFactory
    {
        private readonly IBlogPostSelectorPageFactory factory;

        public DummyBlogPostSelectorPageFactory(IBlogPostSelectorPageFactory factory)
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            this.factory = factory;
        }

        public Page CreatePage(ApplicationViewModel applicationViewModel)
        {
            var innerPage = factory.CreatePage(applicationViewModel) as ContentPage;

            return new ContentPage
            {
                Title = "Debug Blog Posts View",
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = applicationViewModel.BlogPosts.Count().ToString()
                        },

                        (innerPage ?? new ContentPage()).Content
                    }
                }
            };
        }
    }
}