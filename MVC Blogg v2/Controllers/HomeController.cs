using MVC_Blogg_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using AutoMapper;

namespace MVC_Blogg_v2.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();


        //string sortOrder, string category
        public ActionResult Index(string sortOrder, string category, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParam = sortOrder = "date_desc";

            if(category != null)
            {
                page = 1;
            }
            else
            {
                category = currentFilter;
            }

            ViewBag.CurrentFilter = category;

            var posts = from p in db.Posts
                        select p;

            if (!String.IsNullOrEmpty(category))
            {
                posts = posts.Where(p => p.Category.Name.Contains(category));
            }

            switch (sortOrder)
            {
                case "date_desc":
                    posts = posts.OrderByDescending(p => p.DateCreated);
                    break;
                default:
                    posts = posts.OrderByDescending(p => p.DateCreated);
                    break;
            }


            var postViewModel = new PostViewModel();
            
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            postViewModel.Posts = posts.ToList().ToPagedList(pageNumber, pageSize);
            postViewModel.Categories = db.Categories.Take(6);

            return View(postViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Post(int id)
        {
            var post = new CommentViewModel(); 
                post.Post = db.Posts.Find(id);
                post.Comments = db.Comments.ToList();
                post.Comment = db.Comments.Find(id);

            ViewBag.PostId = new SelectList(db.Posts, "PostId", "Title");
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(CommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                var comment = Mapper.Map<CommentViewModel, Comment>(commentViewModel);
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostId = new SelectList(db.Posts, "PostId", "Title", commentViewModel.Comment.PostId);
            return View(commentViewModel);
        }
    }
}