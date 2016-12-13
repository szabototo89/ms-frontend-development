using System;
using XamarinBlogPost.Models;

namespace XamarinBlogPost.ViewModels
{
    public class BlogPostViewModel : ViewModelBase
    {
        private readonly BlogPost blogPost;
        private String content;

        public BlogPostViewModel(BlogPost blogPost)
        {
            if (blogPost == null) throw new ArgumentNullException(nameof(blogPost));
            this.blogPost = blogPost;

            InitializeViewModel(blogPost);
        }

        private void InitializeViewModel(BlogPost blogPost)
        {
            Author = blogPost.Author;
            Title = blogPost.Title;
            Content = blogPost.Content;
            Category = blogPost.Category;
        }

        public String Author { get; set; }

        public String Title { get; set; }

        public String Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public Category Category { get; set; }

        public BlogPost BlogPost => blogPost;
    }
}