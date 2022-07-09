using MusicHub.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.AlbumNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int? ProducerId { get; set; }

        [ForeignKey(nameof(ProducerId))]
        public virtual Producer Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

        public decimal Price => this.Songs.Sum(s => s.Price);
    }
}
