using System.Collections.Generic;

namespace XamarinBlogPost.Models
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetBlogPosts();

        void Save(BlogPost blogPost);
        void Remove(BlogPost blogPost);
    }
}