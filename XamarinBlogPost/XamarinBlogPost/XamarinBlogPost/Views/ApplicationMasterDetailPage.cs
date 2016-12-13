using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;
using XamarinBlogPost.ViewModels;

namespace XamarinBlogPost.Views
{
    public class ApplicationMasterDetailPage : MasterDetailPage
    {
        private readonly ApplicationViewModel applicationViewModel;
        private readonly IBlogPostSelectorPageFactory blogPostSelectorFactory;

        public ApplicationMasterDetailPage(ApplicationViewModel applicationViewModel, IBlogPostSelectorPageFactory blogPostSelectorFactory)
        {
            if (applicationViewModel == null)
                throw new ArgumentNullException(nameof(applicationViewModel));
            if (blogPostSelectorFactory == null)
                throw new ArgumentNullException(nameof(blogPostSelectorFactory));

            this.applicationViewModel = applicationViewModel;
            this.blogPostSelectorFactory = blogPostSelectorFactory;

            Master = CreateMasterPage(applicationViewModel);
            Detail = CreateDetailPage(applicationViewModel);
        }

        private Page CreateDetailPage(ApplicationViewModel applicationViewModel)
        {
            applicationViewModel.PropertyChanged += HandleSelectedBlogPostChanged;

            if (applicationViewModel.SelectedBlogPost == null)
            {
                return new ContentPage
                {
                   Content = new Label
                   {
                       Text = "There is no selected blog post",
                       VerticalOptions = LayoutOptions.CenterAndExpand,
                       HorizontalOptions = LayoutOptions.CenterAndExpand
                   }
                };
            }

            return new ContentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label {Text = "Title"},
                        new Entry {Placeholder = "Specify title here ..."}
                    }
                }
            };
        }

        private void HandleSelectedBlogPostChanged(Object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(ApplicationViewModel.SelectedBlogPost)) return;

            Detail = CreateDetailPage(applicationViewModel);
        }

        private Page CreateMasterPage(ApplicationViewModel applicationViewModel) 
            => blogPostSelectorFactory.CreatePage(applicationViewModel);
    }
}