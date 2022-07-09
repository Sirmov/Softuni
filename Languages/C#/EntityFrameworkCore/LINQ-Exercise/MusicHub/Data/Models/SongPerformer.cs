using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        public int SongId { get; set; }

        public int PerformerId { get; set; }

        [ForeignKey(nameof(SongId))]
        public virtual Song Song { get; set; }

        [ForeignKey(nameof(PerformerId))]
        public virtual Performer Performer { get; set; }
    }
}
