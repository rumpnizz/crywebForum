using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace cryWeb
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include("~/Content/Css/Bootstrap/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/bundles/css/style").Include("~/Content/Css/style.css").Include("~/Content/Css/menu.css"));

            bundles.Add(new ScriptBundle("~/bundles/js/jquery").Include("~/Content/Scripts/jquery-1.10.2.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap").Include("~/Content/Scripts/bootstrap.min.js"));
        }
    }
}