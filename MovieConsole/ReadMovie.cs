using MovieDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieConsole
{
    class ReadMovie
    {
        String line;
        StreamReader f = null;//= new System.IO.StreamReader(@"C:\Users\pasca\Documents\MesCours\B3\C#\labo\movies.txt");
        int i = 0;
        FilmParser fp = new FilmParser();
        private DBManager manager;
        public ReadMovie()
        {
            f = new System.IO.StreamReader(@"C:\Users\pasca\Documents\MesCours\B3\C#\labo\movies.txt");
            manager = new DBManager();
            Console.WriteLine("Dans ReadMovie");
        }
        
        public int readAnddecodeline()
        {
            Console.WriteLine("Debut lecture de movies.txt");
            while((line = f.ReadLine())!=null && i<1800)
            {
                FilmParser.DecodeFilmText(manager,line);
                i++;
            }
            //line = f.ReadLine();
            f.Close();
            return i;
        }
    }
}
