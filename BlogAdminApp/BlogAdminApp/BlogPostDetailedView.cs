using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlogAdminApp.Models;

namespace BlogAdminApp
{
    public partial class BlogPostDetailedView : UserControl
    {
        private BlogPost blogPost;

        public BlogPost BlogPost
        {
            get { return blogPost; }
            set
            {
                blogPost = value;
                RefreshComponent(value);
            }
        }

        public event EventHandler SaveBlogPost;

        private void RefreshComponent(BlogPost blogPost)
        {
            if (blogPost == null) return;

            this.AuthorTextBox.Text = blogPost.Author;
            this.ContentTextBox.Text = blogPost.Content;
            this.TitleTextBox.Text = blogPost.Title;
            this.CategoryComboBox.Text = blogPost.Category.ToString();
            // some change
        }

        public BlogPostDetailedView()
        {
            InitializeComponent();
        }

        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            BlogPost = new BlogPost
            {
                Id = blogPost.Id,
                Content = this.ContentTextBox.Text,
                Author = this.AuthorTextBox.Text,
                Title = this.TitleTextBox.Text,
                Category = (Category)Enum.Parse(typeof(Category), this.CategoryComboBox.Text)
            };

            OnSaveBlogPost();
        }

        protected virtual void OnSaveBlogPost()
        {
            SaveBlogPost?.Invoke(this, EventArgs.Empty);
        }
    }
}
