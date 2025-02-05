using System.Diagnostics;
using GameForum.Data;
using GameForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly GameForumContext _context;

        // Constructor
        public HomeController(GameForumContext context)
        {
            _context = context;
        }

        // GET: Home HomePage - ../Home/Index
        public async Task<IActionResult> Index()
        {
            // get the discussion from the database
            var discussions = await _context.Discussion.Include(d => d.Comments) // Egarly load the Comments
                                            .OrderByDescending(d => d.CreateDate)
                                            .ToListAsync();

            return View(discussions);
        }


        // GET: Home/GetDiscussion/5
        public async Task<IActionResult> GetDiscussion(int id)
        {
            var discussion = await _context.Discussion
                                           .Include(d => d.Comments)
                                           .FirstOrDefaultAsync(d => d.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }

            return View(discussion);
        }


        // Display a discussion by id - ../Home/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // get discussion from database by id
            var discussion = await _context.Discussion.FirstOrDefaultAsync(m => m.DiscussionId == id);

            return View(discussion);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
