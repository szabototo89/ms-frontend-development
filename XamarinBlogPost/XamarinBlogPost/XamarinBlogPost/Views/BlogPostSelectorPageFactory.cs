using Xamarin.Forms;
using XamarinBlogPost.ViewModels;

namespace XamarinBlogPost.Views
{
    public class BlogPostSelectorPageFactory : IBlogPostSelectorPageFactory
    {
        public Page CreatePage(ApplicationViewModel applicationViewModel)
        {
            return new BlogPostSelectorPage(applicationViewModel);
        }
    }
}