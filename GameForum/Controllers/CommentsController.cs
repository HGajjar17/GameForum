using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameForum.Data;
using GameForum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GameForum.Controllers
{
    // only logged in users have access
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly GameForumContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(GameForumContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Deleted the folowing action code
        // GET: Comments
        // GET: Comments/Details/5
        // GET: Comments/Edit/5
        // POST: Comments/Edit/5
        // GET: Comments/Delete/5
        // POST: Comments/Delete/5
        // -----------

        // GET: Comments/Create
        public async Task<IActionResult> Create(int? id)
        {
            // id = DiscussionId
            if (id == null)
            {
                return NotFound();
            }

            // get the logged in user ID
            var userId = _userManager.GetUserId(User);

            var discussion = await _context.Discussion
                .Where(m => m.ApplicationUserId == userId) // filter by user Id
                .FirstOrDefaultAsync(m => m.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }
            else
            {
                _context.Discussion.Remove(discussion);
            }

            // Pass DiscussionId to the view using ViewBag
            ViewData["DiscussionId"] = id;
            return View();

        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Content,CreateDate,DiscussionId")] Comment comment)
        {
            // TO-Do embed the user ID in the form and validate

            if (ModelState.IsValid)
            {
                // Set's the current date and Time
                comment.CreateDate = DateTime.Now;

                _context.Add(comment);
                await _context.SaveChangesAsync();

                // re-direct to /Discussions/Edit/{id}
                return RedirectToAction("GetDiscussion", "Home", new { id = comment.DiscussionId });
            }
            return View(comment);
        }
    }
}
