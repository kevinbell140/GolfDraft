using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GolfDraft2.Models
{
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlayerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public int? Weight { get; set; }

        public string Swings { get; set; }

        public int? PgaDebut { get; set; }

        public string Country { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public string BirthCity { get; set; }

        public string BirthState { get; set; }

        public string College { get; set; }

        public string PhotoUrl { get; set; }

        //public virtual IEnumerable<PlayerSeason> PlayerSeasons { get; set; }

        //public virtual IEnumerable<PlayerTournament> PlayerTournaments { get; set; }


        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
