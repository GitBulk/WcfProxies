﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfProxies.Data.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        static List<Blog> Blogs = new List<Blog>()
        {
            new Blog()
            {
                BlogId = 1,
                Name = "chsakell's Blog",
                Owner = "Chris S.",
                URI = "https://chsakell.com/",
                Posts = new List<Post>()
                {
                    new Post() {
                        PostId = 1,
                        Author = "Chris S.",
                        DateCreated = DateTime.Now.AddDays(-5),
                        Title = "Building SPA using Web API & angularJS",
                        BlogId = 1,
                        URI = "http://wp.me/p3mRWu-PT"
                    },
                    new Post() {
                        PostId = 2,
                        Author = "Chris S.",
                        DateCreated = DateTime.Now.AddDays(-10),
                        Title = "WCF Security using encrypted tokens",
                        BlogId = 2,
                        URI ="http://wp.me/p3mRWu-CI"
                    }
                }
            },
            new Blog()
            {
                BlogId = 2,
                Name = "DotNetCodeGeeks",
                Owner = ".NET Community",
                URI = "http://www.dotnetcodegeeks.com/",
                Posts = new List<Post>()
                {
                    new Post() {
                        PostId = 3,
                        Author = "Chris S.",
                        DateCreated = DateTime.Now.AddMonths(-2),
                        Title = "TypeScript, AngularJS, Gulp and Bower in Visual Studio 2015",
                        BlogId = 2,
                        URI = "http://www.dotnetcodegeeks.com/2015/09/typescript-angularjs-gulp-and-bower-in-visual-studio-2015.html"
                    },
                    new Post() {
                        PostId = 4,
                        Author = "Chris S.",
                        DateCreated = DateTime.Now.AddMonths(-2),
                        Title = "Dependency injection in WCF",
                        BlogId = 2,
                        URI = "http://www.dotnetcodegeeks.com/2015/08/dependency-injection-in-wcf.html"
                    },
                    new Post() {
                        PostId = 5,
                        Author = "Chris S.",
                        DateCreated = DateTime.Now.AddMonths(-2),
                        Title = "ASP.NET Web API feat. OData",
                        BlogId = 2,
                        URI = "http://www.dotnetcodegeeks.com/2015/06/asp-net-web-api-feat-odata.html"
                    }
                }
            },
        };
        public Blog GetBlog(int blogId)
        {
            return Blogs.FirstOrDefault(b => b.Id == blogId);
        }

        public List<Post> GetBlogPosts(int blogId)
        {
            List<Post> posts = null;
            Blog blog = Blogs.FirstOrDefault(b => b.Id == blogId);
            if (blog != null)
            {
                posts = new List<Post>();
                foreach (var post in blog.Posts)
                {
                    posts.Add(post);
                }
            }
            return posts;
        }

        public Post GetPost(int postId)
        {
            Post post = null;
            Blog blog = Blogs.FirstOrDefault(b => b.Posts.Any(p => p.Id == postId));
            if (blog != null)
            {
                post = blog.Posts.First(p => p.Id == postId);
            }
            return post;
        }
    }
}
