using System.Diagnostics;
using GameForum.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameForum.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        { 
        }

        public IActionResult Index()
        {
            // Create a list of photos
            List<Discussion> discussions = new List<Discussion>();

            Discussion discussions1 = new Discussion();
            discussions1.DiscussionId = 1;
            discussions1.Title = "War Games";
            discussions1.Content = "What an amazing Strategy game";
            discussions1.ImageFilename = "image.jpg";
            discussions1.CreateDate = DateTime.Now;
            discussions1.Comments = new List<Comment>();

            Discussion discussions2 = new Discussion();
            discussions2.DiscussionId = 2;
            discussions2.Title = "NFS Most Wanted";
            discussions2.Content = "Best ever rasing game";
            discussions2.ImageFilename = "image1.jpg";
            discussions2.CreateDate = DateTime.Now;
            discussions2.Comments = new List<Comment>();


            discussions.Add(discussions1);
            discussions.Add(discussions2);


            return View(discussions);
        }

        // Display a discussion thread
        public IActionResult Details(int id)
        {
            // To-do: Entity framework - fetch the discusstion by id

            Discussion discussion = new Discussion()
            {
                DiscussionId = id,
                Title = "Discussion Title",
                Content = "Discussion Content",
                ImageFilename = "image.jpg",
                CreateDate = DateTime.Now,
                //Comments = new List<Comment>()
            };
            return View(discussion);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
