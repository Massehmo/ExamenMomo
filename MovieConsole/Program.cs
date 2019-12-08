using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MovieDAL;

namespace MovieConsole
{
    class Program
    {
        //static StreamReader f;
        static void Main(string[] args)
        {

            ReadMovie rm = new ReadMovie();
            MovieDBContext context = new MovieDBContext();
            int cpt = rm.readAnddecodeline();
            Console.WriteLine("Nombre de films inseres = " + cpt);


            //Lecture + affichage de 5 premiers films
            /*int[] tabIdFilm = { 2, 3, 5, 6, 9 };
             foreach(int FilmId in tabIdFilm)
             {

                 Film film = context.Films.Find(FilmId);
                 List<Actor> listeActors = film.Actors.ToList();
                 Console.WriteLine(film);
                 foreach (Actor actor in listeActors)
                     Console.WriteLine(actor);
             }*/

            //affichage des Star Wars
            /* List<Film> listeStarWars = (from film in context.Films where film.FilmTitle.Equals("Star Wars") select film).ToList();
             foreach (Film f in listeStarWars)
                 Console.WriteLine(f);*/

            //Affichage des films dans lesquels joue Harrison Ford ou Tom Hanks
            /*Actor a = context.Actors.SingleOrDefault(aa =>aa.ActorName.Equals("Harrison") && aa.ActorSurname== "Ford");
            Console.WriteLine(a);
            if (a != null)
            {
                List<Film> listeFilms = a.Films.ToList();
                foreach (Film ff in listeFilms)
                    Console.WriteLine(ff);
            }
            else
                Console.WriteLine("Aucun film trouve");*/

            //Mrs Doubtfire (dans lequel Robin Williams joue plusieurs rôles).
            /*
             select Films.*, Actors.*,Characters.*
            from Films join CharacterActors on Films.FilmId=CharacterActors.FilmId
	        join Actors on Actors.ActorId=CharacterActors.ActorId
	        join Characters on Characters.CharacterId=CharacterActors.CharacterId
	        where Films.FilmTitle='Mrs. Doubtfire' and Actors.ActorName='Robin' and Actors.ActorSurname='Williams';
             */
            Console.ReadKey();
        }
        



    }
}
