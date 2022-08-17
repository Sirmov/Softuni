using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Footballers.Data.Models
{
    public class TeamFootballer
    {
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }

        public int FootballerId { get; set; }

        [ForeignKey(nameof(FootballerId))]
        public virtual Footballer Footballer { get; set; }
    }
}
