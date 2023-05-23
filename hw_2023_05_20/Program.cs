using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
            List<MusicAlbum> list = new List<MusicAlbum>();

            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Добавить альбом\n2 - Распечатать альбом\n3 - Сериализация\n4 - Десериализация\n" +
                "5 - Сохранить в Xml\n");
                Console.Write(" > ");

                key = Console.ReadKey();

                Console.Clear();

                switch (key.KeyChar)
                {
                    case '1':
                        AddAlbum(ref list);
                        break;
                    case '2':
                        PrintAlbum(list);
                        Console.ReadKey();
                        break;
                    case '3':
                        SerializeObj(list);
                        Console.ReadKey();
                        break;
                    case '4':
                        list.Clear();
                        DeserializeObj(ref list);
                        Console.ReadKey();
                        break;
                }
            }
            while (key.Key != ConsoleKey.Escape);

        }
        static void AddAlbum(ref List<MusicAlbum> list)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Добавить альбом\n");

                MusicAlbum album = new MusicAlbum();
                album.AddAlbum();

                list.Add(album);

                Console.Write("\nПродолжить? (y/n): ");
                char ch = Console.ReadKey().KeyChar;

                if (ch != 'y')
                    break;
            }
        }
        static void PrintAlbum(List<MusicAlbum> list)
        {
            foreach (var item in list)
            {
                item.PrintAlbum();
                Console.WriteLine();
            }
        }
        static void SerializeObj(List<MusicAlbum> list)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (Stream stream = File.Create("data.bin"))
            {
                bf.Serialize(stream, list);
            }

            Console.WriteLine("BinarySerialize OK!\n");
        }
        static void DeserializeObj(ref List<MusicAlbum> list)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (Stream stream = File.OpenRead("data.bin"))
            {
                list = (List<MusicAlbum>)bf.Deserialize(stream);
            }

            Console.WriteLine("BinaryDeserialize OK!\n");
        }
    }
}
