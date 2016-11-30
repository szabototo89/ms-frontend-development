using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using BlogAdminApp.WPF.Models;

namespace BlogAdminApp.WPF.ViewModels
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

            SaveCommand = new ActionCommand(SaveBlogPost);
        }

        private static IEnumerable<BlogPostViewModel> GetBlogPosts(IBlogPostRepository repository)
        {
            return repository.GetBlogPosts()
                             .Select(blogPost => new BlogPostViewModel(blogPost));
        }

        private void SaveBlogPost()
        {
            if (SelectedBlogPost == null) return;

            repository.Save(new BlogPost
            {
                Author = SelectedBlogPost.Author,
                Content = SelectedBlogPost.Content,
                Category = SelectedBlogPost.Category,
                Title = SelectedBlogPost.Title,
                Id = SelectedBlogPost.BlogPost.Id
            });
            BlogPosts = GetBlogPosts(repository);
        }

        public IEnumerable<BlogPostViewModel> BlogPosts
        {
            get { return blogPosts; }
            set { blogPosts = value; OnPropertyChanged(nameof(BlogPosts)); }
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

        public ICommand SaveCommand { get; }
    }
}