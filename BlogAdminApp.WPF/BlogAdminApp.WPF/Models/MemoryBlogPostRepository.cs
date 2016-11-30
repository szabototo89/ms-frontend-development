using System;
using System.Collections.Generic;

namespace BlogAdminApp.WPF.Models
{
    public class MemoryBlogPostRepository : IBlogPostRepository
    {
        private readonly List<BlogPost> blogPosts;

        public MemoryBlogPostRepository()
        {
            blogPosts = new List<BlogPost>
            {
                new BlogPost
                {
                    Id = 1,
                    Author = "John Doe",
                    Category = Category.Personal,
                    Content = "Lorem ipsum",
                    Title = "Test 1"
                },

                new BlogPost
                {
                    Id = 2,
                    Author = "Jane Doe",
                    Category = Category.Technical,
                    Content = "Lorem ipsum",
                    Title = "Test 2"
                }
            };
        }

        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return blogPosts;
        }

        // newly blogpost
        // edit existing blogpost
        public void Save(BlogPost blogPost)
        {
            if (blogPost == null) throw new ArgumentNullException(nameof(blogPost));

            var index = blogPosts.FindIndex(post => post.Id == blogPost.Id);
            if (index != -1)
            {
                blogPosts[index] = blogPost;
                return;
            }
            
            blogPosts.Add(blogPost);
        }
    }
}
