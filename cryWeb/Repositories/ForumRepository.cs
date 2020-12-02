using cryWeb.DataContext;
using cryWeb.Factories;
using cryWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cryWeb.Repositories
{
    public class ForumRepository
    {
        private IForumContext _context;
        protected IForumContext Context
        {
            get { return _context ?? (_context = ForumContextFactory.GetForumContext()); }
        }

        public List<Category> GetCategories()
        {
            return Context.Categories.Where(i => i.ParentId == null).ToList();
        }

        public Category GetCategory(int id)
        {
            return Context.Categories.FirstOrDefault(i => i.Id == id);
        }

        public Thread GetThread(int id)
        {
            return Context.Threads.Include(i => i.Parent).FirstOrDefault(i => i.Id == id);
        }

        public void AddPost(int id, string text)
        {
            var thread = Context.Threads.FirstOrDefault(i => i.Id == id);
            var post = new Post { Text = @text, ThreadId = id, Created = DateTime.Now, Thread = thread };
            thread.Posts.Add(post);

            Context.Posts.Add(post);
            Context.SaveChanges();
        }

        public void DeletePost(int id)
        {
            Context.Posts.Remove(Context.Posts.FirstOrDefault(i => i.Id == id));
            Context.SaveChanges();
        }

        public void SaveThread(Thread thread, Post post, out Thread t)
        {
            thread.Created = DateTime.Now;
            post.Created = DateTime.Now;

            var newPost = new Post
            {
                Text = post.Text,
                Created = post.Created
            };

            Context.Posts.Add(newPost);

            var newThread = new Thread
            {
                Title = thread.Title,
                Created = thread.Created,
                ParentId = thread.ParentId,
                Parent = GetCategory(thread.ParentId),
                Posts = new List<Post> { post }
            };

            //thread.Posts.Add(post);

            Context.Threads.Add(newThread);
            newPost.ThreadId = newThread.Id;
            newPost.Thread = newThread;


            newThread.Parent.Threads.Add(newThread);

            Context.SaveChanges();

            t = newThread;
        }

        public void DeleteThread(int id)
        {
            var thread = new Thread() { Id = id };

            Context.Threads.Attach(thread);
            Context.Threads.Remove(thread);
            Context.SaveChanges();
        }
    }
}