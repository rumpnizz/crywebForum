using cryWeb.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace cryWeb.Factories
{
    public class ForumContextFactory
    {
        public static IForumContext _staticContext = null;

        public static IForumContext GetForumContext()
        {
            string key = "UseInMemoryDatabase";
            string result = WebConfigurationManager.AppSettings[key];
            if (result == null) { throw new ApplicationException(string.Format("Could not find AppSetting[{0}].", key)); }
            bool useInMemoryDatabase = bool.Parse(result);

            if (useInMemoryDatabase)
            {
                if (_staticContext == null)
                {
                    _staticContext = new MemoryPersitenceForumContext();
                }

                return _staticContext;
            }

            return new ForumContext();
        }

    }
}