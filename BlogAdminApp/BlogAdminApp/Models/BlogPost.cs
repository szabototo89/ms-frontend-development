using System;

namespace BlogAdminApp.Models
{
    public class BlogPost
    {
        public Int32 Id { get; set; }

        public String Author { get; set; }

        public String Content { get; set; }

        public String Title { get; set; }

        public Category Category { get; set; }
    }
}