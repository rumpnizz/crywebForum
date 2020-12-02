namespace cryWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using cryWeb.DataContext;
    using cryWeb.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ForumContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var categories = new List<Category> {
                new Category { Name = "Datorer, Teknik & Prylar" },
                new Category { Name = "Dator- och konsolspel", ParentId = 1 },
                new Category { Name = "Spel: allmänt", ParentId = 2 },
                new Category { Name = "Diablo 3", ParentId = 3 },
                new Category { Name = "Spel: support", ParentId = 2 },
                new Category { Name = "Fildelning", ParentId = 1 },
                new Category { Name = "Hemelektronik, ljud och bild", ParentId = 1 },
                new Category { Name = "Hårdvara - MAC", ParentId = 1 },
                new Category { Name = "Hårdvara - PC", ParentId = 1 },
                new Category { Name = "Droger" },
                new Category { Name = "Cannabis", ParentId = 10 },
                new Category { Name = "Kultur & Media" },
                new Category { Name = "Censur och yttrandefrihet", ParentId = 12 }
            };

            categories.ForEach(category => context.Categories.AddOrUpdate(c => c.Name, category));
            context.SaveChanges();

            var threads = new List<Thread>
            {
                new Thread { Title = "Asus moderkort", ParentId = 9, Created = DateTime.Now },
                new Thread { Title = "Matrox grafikkort", ParentId = 9, Created = DateTime.Now }
            };

            threads.ForEach(thread => context.Threads.AddOrUpdate(c => c.Title, thread));
            context.SaveChanges();

            var posts = new List<Post>();

            for (var i = 0; i < 18; i++)
            {
                posts.Add(new Post { Text = "Post " + (i + 1), ThreadId = 1, Created = DateTime.Now });
            }

            posts.ForEach(post => context.Posts.AddOrUpdate(p => p.Text, post));
            context.SaveChanges();
        }
    }
}
