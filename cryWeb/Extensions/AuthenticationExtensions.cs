using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using cryWeb.Helpers;
using cryWeb.DataContext;
using cryWeb.Models;
using System.Web.Security;
using cryWeb.Factories;

namespace cryWeb.Extensions
{
    public class AuthenticationExtensions
    {
        private static IForumContext _context;
        protected static IForumContext Context
        {
            get { return _context ?? (_context = ForumContextFactory.GetForumContext()); }
        }

        public static bool SignIn(string username, string password)
        {
            var auth = new AuthenticationHelper();

            User user = Context.Users.FirstOrDefault(x => x.Username == username);

            if (user == null)
            {
                FeedbackSession.SetError("Fel användarnamn eller lösenord");
                return false;
            }

            string hash = auth.GenerateHash(password, user.Salt);

            if (hash != user.Hash)
            {
                FeedbackSession.SetError("Fel användarnamn eller lösenord");
                return false;
            }

            FormsAuthentication.SetAuthCookie(username, false);
            return true;
        }
        public static void SignOut()
        {
            FormsAuthentication.SignOut();
        }
        public static void Register(User u)
        {
            Context.Users.Add(u);
            Context.SaveChanges();
        }
    }
}