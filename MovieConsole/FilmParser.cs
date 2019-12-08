using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieConsole
{
    class FilmParser
    {
        private static string[] filmdetail;
        private static String[] acteurdetail;
        static int cpt = 0;
        
        //private Film f;
        public FilmParser()
        {
        }

        public static void DecodeFilmText(DBManager manager, string filmtext) // Méthode de la classe FilmParser
        {
            Film film = new Film();

            Char DOUDLE_VLINE = '\u2016';
            Char TRIANGLE_BULLET = '\u2023';
            Char DOT_LEADER = '\u2024';

            
            filmdetail = filmtext.Split(TRIANGLE_BULLET);

            film.FilmId = Int32.Parse(filmdetail[0]);
            film.FilmTitle = filmdetail[1];
            //if(filmdetail[0]!=null || filmdetail[2]!="")
            film.FilmOriginal_title = filmdetail[2];
            if(!filmdetail[7].Equals(""))
                film.FilmRuntime = Int32.Parse(filmdetail[7]);//!!!!!!!!!!!!!!
            film.FilmPosterpath = filmdetail[9];
            //var filmtmp = (from f in context.Films where f.FilmId == film.FilmId select f);//verifie si film deja insere
            var filmtmp = manager.GetFilmById(film.FilmId);
            if (filmtmp == null)
            {
                if (filmdetail.Length == 15)
                {
                    acteurdetail = filmdetail[14].Split(DOUDLE_VLINE);
                    foreach (String s in acteurdetail)
                    {
                        String[] tab = s.Split(DOT_LEADER);
                        
                        if(tab.Length==3)
                        { 
                            Actor actor = new Actor();     
                            actor.ActorId = Int32.Parse(tab[0]);
                            String fullNameActor = tab[1];
                            String[] detailNameActor = tab[1].Split(' ');
                            actor.ActorName = detailNameActor[0];
                            if(detailNameActor.Length==2)
                            {
                                actor.ActorSurname = detailNameActor[1];
                            }
                            else if(detailNameActor.Length==3)
                            {
                                actor.ActorSurname = detailNameActor[1] + " " + detailNameActor[2];
                            }
                            var actortemp = manager.GetActorById(actor.ActorId);
                            if (actortemp != null)
                                actor = actortemp;
                            Character character = new Character();
                            String[] detailCharacter = tab[2].Split('/');
                            character.CharacterName = detailCharacter[0];
                            var charactertemp = manager.GetCharacterByName(character.CharacterName);
                            if (charactertemp != null)
                                character = charactertemp;
                            //Console.WriteLine("Film=" + film.FilmId + ", Actor=" + actor.ActorName + ", Character=" + character.CharacterName + "\n");
                            CharacterActor characterActor = new CharacterActor(film, actor, character);
                            film.Actors.Add(actor);
                            actor.Films.Add(film);
                            manager.AddCharacterActor(characterActor);
                        }
                    }
                }
                
                Console.WriteLine("Nombre de lignes inseres = " + cpt); cpt++;
            }
            else
                Console.WriteLine("Le film existe deja");

            
            
        }
    }
}
