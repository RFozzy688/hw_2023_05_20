﻿using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using NLog;

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
                    case '5':
                        SaveToXml(list);
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
            Logger logger = LogManager.GetCurrentClassLogger();

            using (Stream stream = File.Create("data.bin"))
            {
                bf.Serialize(stream, list);
                logger.Info("Serialize success");
            }

            Console.WriteLine("BinarySerialize OK!\n");

        }
        static void DeserializeObj(ref List<MusicAlbum> list)
        {
            BinaryFormatter bf = new BinaryFormatter();
            Logger logger = LogManager.GetCurrentClassLogger();

            try
            {
                using (Stream stream = File.OpenRead("data.bin"))
                {
                    list = (List<MusicAlbum>)bf.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            Console.WriteLine("BinaryDeserialize OK!\n");
        }
        static void SaveToXml(List<MusicAlbum> list)
        {
            XmlTextWriter xmlText = new XmlTextWriter("albums.xml", System.Text.Encoding.Unicode);
            Logger logger = LogManager.GetCurrentClassLogger();

            xmlText.Formatting = Formatting.Indented;
            xmlText.WriteStartDocument();
            xmlText.WriteStartElement("albums");

            foreach (var item in list)
            {
                xmlText.WriteStartElement("album");
                xmlText.WriteElementString("name_album", item.NameAlbum);
                xmlText.WriteElementString("singer", item.Singer);
                xmlText.WriteElementString("year", item.Year);
                xmlText.WriteElementString("duration", item.Duration.ToString());
                xmlText.WriteElementString("lable", item.RecordingStudio);
                xmlText.WriteEndElement();
            }

            xmlText.WriteEndElement();

            if (xmlText != null)
            {
                xmlText.Close();
            }

            Console.WriteLine("The albums.xml file is generated!");

            logger.Info("The albums.xml file is generated!");
        }
    }
}
