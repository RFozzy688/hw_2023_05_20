using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2023_05_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicAlbum album = new MusicAlbum();
            album.AddAlbum();
            album.PrintAlbum();
        }
    }
}
