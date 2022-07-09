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
            Console.WriteLine(ExportAlbumsInfo(context, 2));
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
            throw new NotImplementedException();
        }
    }
}
