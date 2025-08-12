using EFCoreCompile;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Compiled query: Get all blogs ordered by BlogId
    private static readonly Func<BloggingContext, IEnumerable<Blog>> GetAllBlogs =
        EFWrap.CompileQuery(
            (BloggingContext ctx) =>
                ctx.Blogs
                   .Where(b => b.BlogId > 1)
            );

    static void Main()
    {
        using var db = new BloggingContext();

        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create sample blogs
        Console.WriteLine("Inserting blogs");
        db.AddRange(
            new Blog { Url = "http://blogs.msdn.com/adonet" },
            new Blog { Url = "https://devblogs.microsoft.com/dotnet" }
        );
        db.SaveChanges();

        // Read list using compiled query
        Console.WriteLine("Querying all blogs");
        var blogs = GetAllBlogs(db).ToList(); // Materialize to List

        foreach (var blog in blogs)
        {
            Console.WriteLine($"BlogId: {blog.BlogId}, Url: {blog.Url}");
        }

        // Update first blog
        if (blogs.Any())
        {
            var firstBlog = blogs.First();
            Console.WriteLine("Updating the first blog and adding a post");
            firstBlog.Url = "https://dotnet.microsoft.com";
            firstBlog.Posts.Add(new Post
            {
                Title = "Hello World",
                Content = "I wrote an app using EF Core!"
            });
            db.SaveChanges();
        }

        // Delete last blog
        if (blogs.Any())
        {
            var lastBlog = blogs.Last();
            Console.WriteLine("Deleting last blog");
            db.Remove(lastBlog);
            db.SaveChanges();
        }
    }
}
