namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var producerAlbums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Include(a => a.Producer)
                .Include(a => a.Songs)
                .ThenInclude(s => s.Writer)
                .Select(a => new
                {
                    Name = a.Name,
                    ReleaseDate = a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.Writer.Name)
                        .ToList(),
                    Price = a.Price
                })
                .ToList()
                .OrderByDescending(a => a.Price);

            StringBuilder output = new StringBuilder();

            foreach (var album in producerAlbums)
            {
                output.AppendLine($"-AlbumName: {album.Name}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine("-Songs:");

                int songCounter = 1;

                foreach (var song in album.Songs)
                {
                    output.AppendLine($"---#{songCounter++}")
                        .AppendLine($"---SongName: {song.Name}")
                        .AppendLine($"---Price: {song.Price:F2}")
                        .AppendLine($"---Writer: {song.Writer.Name}");
                }

                output.AppendLine($"-AlbumPrice: {album.Price:F2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Include(s => s.Album)
                .ThenInclude(a => a.Producer)
                .Include(s => s.SongPerformers)
                .ThenInclude(sp => sp.Performer)
                .Include(a => a.Writer)
                .Select(s => new
                {
                    s.Name,
                    s.Duration,
                    WritterName = s.Writer.Name,
                    ProducerName = s.Album.Producer.Name,
                    Performer = s.SongPerformers.FirstOrDefault().Performer
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WritterName)
                .ThenBy(s => s.Performer.FirstName)
                .ThenBy(s => s.Performer.LastName)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .ToList();

            StringBuilder output = new StringBuilder();
            int songCounter = 1;

            foreach (var song in songs)
            {
                output.AppendLine($"-Song #{songCounter++}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.WritterName}")
                    .AppendLine($"---Performer: {song?.Performer?.FirstName} {song?.Performer?.LastName}")
                    .AppendLine($"---AlbumProducer: {song.ProducerName}")
                    .AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
