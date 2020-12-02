using cryWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cryWeb.DataContext
{
    public partial interface IForumContext
    {
        IDbSet<Category> Categories { get; set; }
        IDbSet<Thread> Threads { get; set; }
        IDbSet<Post> Posts { get; set; }
        IDbSet<User> Users { get; set; }

        int SaveChanges();

        void Dispose();
    }

    public partial class ForumContext : DbContext, IForumContext
    {
        public ForumContext()
            : base("name=ForumContext")
        { }

        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Thread> Threads { get; set; }
        public IDbSet<Post> Posts { get; set; }
        public IDbSet<User> Users { get; set; }

        void IForumContext.Dispose()
        {
            base.Dispose();
        }
    }

    public partial class MemoryPersitenceForumContext : ForumContext
    {
        public MemoryPersitenceForumContext()
        {
            Seed();
        }
        public void ClearAll()
        {
            this.Categories = new MemoryPersistenceDbSet<Category>();
            this.Threads = new MemoryPersistenceDbSet<Thread>();
            this.Posts = new MemoryPersistenceDbSet<Post>();
            this.Users = new MemoryPersistenceDbSet<User>();
        }
        public override int SaveChanges()
        {
            return 0;
        }

        public void Seed()
        {
            ClearAll();

            // TODO Add seed logic here, like.....
            this.Users.Add(new User {
                Id = 1, Username = "markus", 
                Created = DateTime.Now, 
                Salt = "JpF2PPL53EEKGf2QvZfr2GNT3cLzOZgw2fB5fHZNTtlUNS1AvMziGPcTGWdtv2JoItiMzMSY4cmxPMH0d5wHe+p9jS+pH8CqXMhSuCmD0hVVTR/Jfm4wGfpVcrkc7HMlexqMLfAu4SDTqt/EXPpaxaYPwB3yl", 
                Hash = "goHc6X1kzgeURbyuSzmTsxmkBXU=" });

            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Mat" },
                new Category { Id = 2, Name = "Programmering" },
                new Category { Id = 3, Name = "Film & Serier" },
                new Category { Id = 4, Name = "Övrigt" },
            };

            var threads = new List<Thread>
            {
                new Thread { ParentId = 1, Parent = categories[0], Id = 1, Title = "Korv & Makaroner", Created = DateTime.Now },
                new Thread { ParentId = 2, Parent = categories[1], Id = 2, Title = "Asynkront vs synkront?", Created = DateTime.Now },
                new Thread { ParentId = 3, Parent = categories[2], Id = 3, Title = "Avatar (2009)", Created = DateTime.Now },
                new Thread { ParentId = 4, Parent = categories[3], Id = 4, Title = "Bada med kläder på", Created = DateTime.Now },
            };

            var posts = new List<Post>
            {
                new Post { Id = 1, ThreadId = 1, Created = DateTime.Now, Text = "Jag tycker om makaroner.", Thread = threads[0] },
                new Post { Id = 2, ThreadId = 2, Created = DateTime.Now, Text = "Beror på situation.", Thread = threads[1] },
                new Post { Id = 3, ThreadId = 3, Created = DateTime.Now, Text = "Bra film!", Thread = threads[2] },
                new Post { Id = 4, ThreadId = 4, Created = DateTime.Now, Text = "Nej, jag föredrar att bada näck!", Thread = threads[3] }
            };

            threads[0].Posts = new List<Post> { posts[0] };
            threads[1].Posts = new List<Post> { posts[1] };
            threads[2].Posts = new List<Post> { posts[2] };
            threads[3].Posts = new List<Post> { posts[3] };

            categories[0].Threads = new List<Thread> { threads[0] };
            categories[1].Threads = new List<Thread> { threads[1] };
            categories[2].Threads = new List<Thread> { threads[2] };
            categories[3].Threads = new List<Thread> { threads[3] };

            foreach (var category in categories)
            {
                this.Categories.Add(category);
            }

            foreach (var thread in threads)
            {
                this.Threads.Add(thread);
            }

            foreach (var post in posts)
            {
                this.Posts.Add(post);
            }
        }
    }
}