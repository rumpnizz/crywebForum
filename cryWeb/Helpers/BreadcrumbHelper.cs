using cryWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cryWeb.Helpers
{
    public static class BreadcrumbHelper
    {
        public static Dictionary<int, string> GetBreadcrumbs(this Category category)
        {
            var breadcrumbs = new Dictionary<int, string>();

            breadcrumbs.Add(category.Id, category.Name);

            while (category.ParentId != null)
            {
                breadcrumbs.Add(category.Parent.Id, category.Parent.Name);
                category = category.Parent;
            }

            return breadcrumbs.ReversedBreadcrumbs();
        }

        private static Dictionary<int, string> ReversedBreadcrumbs(this Dictionary<int, string> breadcrumbs)
        {
            var reversed = new Dictionary<int, string>();

            for (var i = breadcrumbs.Count - 1; i >= 0; i--)
            {
                var crumb = breadcrumbs.ElementAt(i);
                reversed.Add(crumb.Key, crumb.Value);
            }

            return reversed;
        }
    }
}