using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogAdminApp
{
    public partial class ArticlesListBox : UserControl
    {
        public ArticlesListBox()
        {
            InitializeComponent();
        }

        private void HandleAddButton(object sender, EventArgs e)
        {
            this.BlogPostsListBox.Items.Add("[New Article]");
        }

        private void HandleRemoveButton(object sender, EventArgs e)
        {
            var selectedItem = BlogPostsListBox.SelectedIndex;
            if (selectedItem == -1) return;
            BlogPostsListBox.Items.RemoveAt(selectedItem);
        }

        public void SetArticles(IEnumerable<String> blogPostTitles)
        {
            if (blogPostTitles == null) throw new ArgumentNullException(nameof(blogPostTitles));

            BlogPostsListBox.Items.Clear();
            BlogPostsListBox.Items.AddRange(blogPostTitles.ToArray());
        }

        public Int32 SelectedIndex { get { return BlogPostsListBox.SelectedIndex; } }

        public event EventHandler SelectionChanged;

        private void BlogPostsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectionChanged();
        }

        protected virtual void OnSelectionChanged()
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(this, EventArgs.Empty);
            }
        }
    }
}
