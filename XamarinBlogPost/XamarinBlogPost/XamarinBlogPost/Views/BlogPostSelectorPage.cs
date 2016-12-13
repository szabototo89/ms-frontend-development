using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using XamarinBlogPost.ViewModels;

namespace XamarinBlogPost.Views
{
    public class BlogPostSelectorPage : ContentPage
    {
        private readonly ListView listView;

        public event EventHandler<SelectedItemChangedEventArgs> SelectionChanged
        {
            add { listView.ItemSelected += value; }
            remove { listView.ItemSelected -= value; }
        }

        public BlogPostSelectorPage(ApplicationViewModel applicationViewModel)
        {
            if (applicationViewModel == null) throw new ArgumentNullException(nameof(applicationViewModel));

            Title = "Blog posts";
            BindingContext = applicationViewModel;
            listView = new ListView
            {
                ItemsSource = applicationViewModel.BlogPosts,
                ItemTemplate = new DataTemplate(() =>
                {
                    var textCell = new TextCell();
                    textCell.SetBinding(TextCell.TextProperty, nameof(BlogPostViewModel.Title));
                    return textCell;
                })
            };

            listView.SetBinding(ListView.SelectedItemProperty, nameof(ApplicationViewModel.SelectedBlogPost));

            Content = listView;
        }
    }
}
