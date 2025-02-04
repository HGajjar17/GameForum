using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameForum.Models;

namespace GameForum.Data
{
    public class GameForumContext : DbContext
    {
        public GameForumContext (DbContextOptions<GameForumContext> options)
            : base(options)
        {
        }

        public DbSet<GameForum.Models.Discussion> Discussion { get; set; } = default!;
        public DbSet<GameForum.Models.Comment> Comment { get; set; } = default!;
    }
}
