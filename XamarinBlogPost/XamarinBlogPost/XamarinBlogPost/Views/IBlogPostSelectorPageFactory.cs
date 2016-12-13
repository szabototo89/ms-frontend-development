using System;
using System.Linq;
using Xamarin.Forms;
using XamarinBlogPost.ViewModels;

namespace XamarinBlogPost.Views
{
    public interface IBlogPostSelectorPageFactory
    {
        Page CreatePage(ApplicationViewModel applicationViewModel);
    }
}