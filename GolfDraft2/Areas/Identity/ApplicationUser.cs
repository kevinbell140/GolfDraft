using GolfDraft2.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfDraft2.Areas.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public virtual IEnumerable<MyTeam> MyTeamNav { get; set; }
    }
}
