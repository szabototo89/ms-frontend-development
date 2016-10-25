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
        public MainForm()
        {
            InitializeComponent();
            Articles.SetArticles(new List<String> { "Test 1" });

            BlogPostDetailedView.BlogPost = new BlogPost
            {
                Author  = "John Doe",
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minima necessitatibus temporibus voluptas sunt ullam voluptatum, voluptates sapiente maiores aliquam accusantium dolor eligendi. Nesciunt molestiae totam voluptate, neque cumque explicabo eveniet odio minus! Esse praesentium amet explicabo magni sunt molestias saepe ipsa, accusamus! A distinctio ut error quidem, consectetur, rem, consequatur laudantium dolor illum aperiam nisi reprehenderit magnam laboriosam veniam non. Minima ab repellendus ad dicta labore corrupti provident voluptas reiciendis aliquam, tempore, sapiente sint.",
                Title = "Lorem ipsum dolor",
                Category = Category.Personal
            };
        }

        private void Articles_SelectionChanged(object sender, EventArgs e)
        {
            var articles = (sender as ArticlesListBox);
            if (articles == null) return;

            MessageBox.Show(this, articles.SelectedIndex.ToString());
        }

        private void BlogPostDetailedView_SaveBlogPost(object sender, EventArgs e)
        {
            MessageBox.Show("Value has been changed");
        }
    }
}
