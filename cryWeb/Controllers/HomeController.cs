using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using cryWeb.Models;
using cryWeb.Repositories;
using cryWeb.Helpers;
using cryWeb.ViewModels;

namespace cryWeb.Controllers
{
    public class HomeController : Controller
    {
        ForumRepository cr = new ForumRepository();

        [MvcSiteMapNode(Title = "Index", ParentKey = "Home")]
        public ActionResult Index()
        {
            return View(cr.GetCategories());
        }

        public ActionResult CategoryDetails(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var c = cr.GetCategory(id.Value);
            ViewBag.Breadcrumbs = c.GetBreadcrumbs();

            string urlCrumbs = "/kategori/" + id;

            foreach (var crumb in ViewBag.Breadcrumbs)
            {
                urlCrumbs += "/" + crumb.Value;
            }

            urlCrumbs = urlCrumbs.Clean();

            if (Request.RawUrl != urlCrumbs)
                return Redirect(urlCrumbs);

            return View(c);
        }

        public string Test(int id)
        {
            var uri = new Uri(Request.Url.AbsoluteUri);
            var reqURL = uri.GetLeftPart(UriPartial.Path);
            
            return "dskg";
        }

        public ActionResult ThreadDetails(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var t = cr.GetThread(id.Value);

            ViewBag.Breadcrumbs = t.Parent.GetBreadcrumbs();

            string urlCrumbs = "/trood/" + id;

            foreach (var crumb in ViewBag.Breadcrumbs)
            {
                urlCrumbs += "/" + crumb.Value;
            }

            urlCrumbs += "/" + t.Title;

            urlCrumbs = urlCrumbs.Clean();

            if (Request.RawUrl != urlCrumbs)
                return Redirect(urlCrumbs);

            return View(t);
        }

        public ActionResult CreateThread(int id)
        {
            var vm = new CreateThreadVM();
            vm.Thread.ParentId = id;

            var crumbs = cr.GetCategory(id).GetBreadcrumbs();
            crumbs.Add(-1, "Skapa tråd");
            ViewBag.Breadcrumbs = crumbs;

            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateThread(CreateThreadVM vm)
        {
            Thread thread;
            
            cr.SaveThread(vm.Thread, vm.Post, out thread);

            return RedirectToAction("ThreadDetails", "Home", new { id = thread.Id });
        }

        public ActionResult DeleteThread(int id, int parentId)
        {
            cr.DeleteThread(id);

            return RedirectToAction("CategoryDetails", "Home", new { id = parentId });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatePost(int Id, string postText)
        {
            cr.AddPost(Id, postText);

            return RedirectToAction("ThreadDetails", new { id = Id });
        }

        public ActionResult DeletePost(int ThreadId, int id)
        {
            cr.DeletePost(id);

            return RedirectToAction("ThreadDetails", new { id = ThreadId });
        }

        //public void ReturnBreadcrumbUrl(Dictionary<int, string> crumbs, HttpContextBase request, int id, string name)
        //{

        //    string urlCrumbs = "/trood/" + id;

        //    foreach (var crumb in ViewBag.Breadcrumbs)
        //    {
        //        urlCrumbs += "/" + crumb.Value;
        //    }

        //    urlCrumbs += "/" + t.Title;

        //    urlCrumbs = urlCrumbs.Clean();

        //    if (Request.RawUrl != urlCrumbs)
        //        return Redirect(urlCrumbs);
        //}

    }
}
