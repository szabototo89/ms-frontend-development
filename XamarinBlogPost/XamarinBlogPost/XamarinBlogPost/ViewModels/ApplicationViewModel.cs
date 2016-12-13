using System;
using System.Collections.Generic;
using System.Linq;
using XamarinBlogPost.Models;

namespace XamarinBlogPost.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        private readonly IBlogPostRepository repository;
        private BlogPostViewModel selectedBlogPost;
        private IEnumerable<BlogPostViewModel> blogPosts;

        public ApplicationViewModel(IBlogPostRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            this.repository = repository;

            BlogPosts = GetBlogPosts(repository);
        }

        private static IEnumerable<BlogPostViewModel> GetBlogPosts(IBlogPostRepository repository)
        {
            return repository.GetBlogPosts()
                             .Select(blogPost => new BlogPostViewModel(blogPost));
        }

        public void RemoveBlogPost(BlogPostViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            repository.Remove(viewModel.BlogPost);

            SelectedBlogPost = null;
            BlogPosts = GetBlogPosts(repository).ToList();
        }

        public void SaveBlogPost(BlogPostViewModel blogPost)
        {
            if (blogPost == null) return;

            repository.Save(new BlogPost
            {
                Author = blogPost.Author,
                Content = blogPost.Content,
                Category = blogPost.Category,
                Title = blogPost.Title,
                Id = blogPost.BlogPost.Id
            });

            BlogPosts = GetBlogPosts(repository);
        }

        public IEnumerable<BlogPostViewModel> BlogPosts
        {
            get { return blogPosts; }
            set
            {
                blogPosts = value;
                OnPropertyChanged(nameof(BlogPosts));
            }
        }

        public BlogPostViewModel SelectedBlogPost
        {
            get { return selectedBlogPost; }
            set
            {
                selectedBlogPost = value;
                OnPropertyChanged(nameof(SelectedBlogPost));
            }
        }
    }
}