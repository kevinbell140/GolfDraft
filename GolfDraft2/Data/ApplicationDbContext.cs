using System;
using System.Collections.Generic;
using System.Text;
using GolfDraft2.Areas.Identity;
using GolfDraft2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GolfDraft2.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Draft> Drafts { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<MyTeam> MyTeams { get; set; }
    }
}
