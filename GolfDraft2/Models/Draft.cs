using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfDraft2.Models
{
    public class Draft
    {
        public int DraftId { get; set; }

        public string DraftName { get; set; }

        public virtual MyTeam MyTeam { get; set; }

        public virtual IEnumerable<Player> Players { get; set; }
    }
}
