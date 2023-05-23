using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2023_05_20
{
    internal class MusicAlbum
    {
        public string NameAlbum { get; set; }
        public string Singer { get; set; }
        public string Year { get; set; }
        public TimeSpan Duration { get; set; }
        public string RecordingStudio { get; set; }
        public MusicAlbum() { }
        public MusicAlbum AddAlbum() 
        {
            Console.Write("Название альбома: ");
            NameAlbum = Console.ReadLine();

            Console.Write("Исполнитель: ");
            Singer = Console.ReadLine();

            Console.Write("Год выпуска: ");
            Year = Console.ReadLine();

            try
            {
                Console.Write("Продолжительность (hh:mm:ss): ");

                Duration = TimeSpan.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
            }

            Console.Write("Студия звукозаписи: ");
            RecordingStudio = Console.ReadLine();

            return this;
        }
        public void PrintAlbum()
        {
            Console.WriteLine($"Название альбома: {NameAlbum}");
            Console.WriteLine($"Исполнитель: {Singer}");
            Console.WriteLine($"Год выпуска: {Year}");
            Console.WriteLine($"Продолжительность: {Duration.ToString()}");
            Console.WriteLine($"Студия звукозаписи: {RecordingStudio}");
        }
    }
}
