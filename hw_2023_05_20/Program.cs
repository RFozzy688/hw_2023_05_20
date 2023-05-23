using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace hw_2023_05_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicAlbum album = new MusicAlbum();
            List<MusicAlbum> list = new List<MusicAlbum>();
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Добавить альбом\n2 - Распечатать альбом\n3 - Сохранить\n4 - Загрузить\n" +
                "5 - Сохранить в Xml\n");
                Console.Write(" > ");

                key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case '1':
                        AddAlbum(album, list);
                        break;
                    case '2':
                        Console.Clear();
                        PrintAlbum(album, list);
                        Console.ReadKey();
                        break;
                }
            }
            while (key.Key != ConsoleKey.Escape);

        }
        static void AddAlbum(MusicAlbum album, List<MusicAlbum> list)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Добавить альбом\n");

                list.Add(album.AddAlbum());

                Console.Write("\nПродолжить? (y/n): ");
                char ch = Console.ReadKey().KeyChar;

                if (ch != 'y')
                    break;
            }
        }
        static void PrintAlbum(MusicAlbum album, List<MusicAlbum> list)
        {
            foreach (var item in list)
            {
                item.PrintAlbum();
                Console.WriteLine();
            }
        }

    }
}
