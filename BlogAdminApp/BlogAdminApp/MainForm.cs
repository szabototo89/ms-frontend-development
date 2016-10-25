using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlogAdminApp.Models;

namespace BlogAdminApp
{
    public partial class MainForm : Form
    {
        private readonly IBlogPostRepository repository;

        public MainForm()
        {
            InitializeComponent();

            repository = new MemoryBlogPostRepository();

            var blogPosts = repository.GetBlogPosts().ToList();

            Articles.SetArticles(
                blogPosts.Select(post => post.Title)
            );

            BlogPostDetailedView.BlogPost = blogPosts.FirstOrDefault();
        }

        private void Articles_SelectionChanged(object sender, EventArgs e)
        {
            var articles = (sender as ArticlesListBox);
            if (articles == null) return;

            var selectedIndex = articles.SelectedIndex;
            var blogPosts = repository.GetBlogPosts().ToList();

            if (selectedIndex >= blogPosts.Count) return;
            if (selectedIndex == -1) return;

            BlogPostDetailedView.BlogPost = blogPosts[selectedIndex];
        }

        private void BlogPostDetailedView_SaveBlogPost(object sender, EventArgs e)
        {
            var editedBlogPost = BlogPostDetailedView.BlogPost;
            if (editedBlogPost == null) return;

            repository.Save(editedBlogPost);
        }
    }
}
