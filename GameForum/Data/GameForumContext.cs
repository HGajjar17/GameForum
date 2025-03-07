using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameForum.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GameForum.Data
{
    // Changed Dbcontext to IdentityDbcontext
    public class GameForumContext : IdentityDbContext<ApplicationUser>
    {
        public GameForumContext (DbContextOptions<GameForumContext> options)
            : base(options)
        {
        }

        public DbSet<GameForum.Models.Discussion> Discussion { get; set; } = default!;
        public DbSet<GameForum.Models.Comment> Comment { get; set; } = default!;
    }
}
