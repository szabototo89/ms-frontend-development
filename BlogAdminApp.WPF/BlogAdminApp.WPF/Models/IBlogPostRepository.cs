using System.Collections.Generic;

namespace BlogAdminApp.WPF.Models
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetBlogPosts();

        void Save(BlogPost blogPost);
    }
}