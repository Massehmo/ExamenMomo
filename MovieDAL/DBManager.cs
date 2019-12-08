using MovieDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieDAL
{
    public class DBManager
    {
        private MovieDBContext context;

        public DBManager()
        {
            context = new MovieDBContext();
        }

        public void AddCharacterActor(CharacterActor characterActor)
        {
            //Console.WriteLine("Dans manager.AddCharacterActor");
            context.CharacterActors.Add(characterActor);
            //Console.WriteLine("Dans manager.AddCharacterActor 2");
            context.SaveChanges();
        }

        public Film GetFilmById(int filmId)
        {
            //var filmtemp = (from f in context.Films where f.FilmId == filmId select f);
            return context.Films.Find(filmId);
            //return filmtemp.ToList();
        }

        public Actor GetActorById(int actorId)
        {
            return context.Actors.Find(actorId);
        }

        public Character GetCharacterByName(String characterName)
        {

            return context.Characters.SingleOrDefault(c => c.CharacterName == characterName);
        }
        public List<FilmDTO> GetListFilmsByIdActor(int idActor)
        {
            var listeFilmsDTO = context.Actors.Find(idActor).Films.Select(f =>new FilmDTO
            {
                Id = f.FilmId,
                Title = f.FilmTitle,
                Original_title = f.FilmOriginal_title,
                Runtime = f.FilmRuntime,
                Posterpath = f.FilmPosterpath
            }).ToList();
            return listeFilmsDTO;
        }
        public List<CharacterDTO> GetListCharacterByIdActorAndIdFilm(int idActor, int idFilm)
        {
            var listeCharactersDTO = (from ch in context.Characters
                                   join ca in context.CharacterActors on
                                    ch.CharacterId equals ca.CharacterId
                                   where ca.ActorId == idActor && ca.FilmId == idFilm
                                   select ch).Select(ch =>new CharacterDTO
                                   {
                                       Id = ch.CharacterId,
                                       Name = ch.CharacterName
                                   }).ToList();
            
            return listeCharactersDTO;
        }
        public List<FilmDTO> FindListFilmByPartialActorName(string name)
        {
            string[] tab = name.Split(' ');

            switch (tab.Length)
            {
                case 1:
                    
                    {
                        return context.Actors.FirstOrDefault(a => a.ActorName == tab[0]).Films.Select(f => new FilmDTO
                        {
                            Id = f.FilmId,
                            Title = f.FilmTitle,
                            Original_title = f.FilmOriginal_title,
                            Runtime = f.FilmRuntime,
                            Posterpath = f.FilmPosterpath
                        }).ToList();
                    }
                    break;
                case 2:
                    {
                       
                        return context.Actors.FirstOrDefault(a => a.ActorName == tab[0] && a.ActorSurname == tab[1]).Films.Select
                            (f => new FilmDTO
                            {
                                Id = f.FilmId,
                                Title = f.FilmTitle,
                                Original_title = f.FilmOriginal_title,
                                Runtime = f.FilmRuntime,
                                Posterpath = f.FilmPosterpath
                            }).ToList();
                    }
                    break;
                case 3:
                    {
                        
                        return context.Actors.FirstOrDefault(a => a.ActorName == tab[0] && a.ActorSurname == tab[1] + tab[2]).
                            Films.Select(f =>new FilmDTO
                            {
                                Id = f.FilmId,
                                Title = f.FilmTitle,
                                Original_title = f.FilmOriginal_title,
                                Runtime = f.FilmRuntime,
                                Posterpath = f.FilmPosterpath
                            }).ToList();
                            
                    }
                    break;
                default:
                    return null;
            }
        }
        public List<LightFilmDTO> GetFavoriteFilms()
        {
           return context.Comments.OrderByDescending(cm =>
                cm.CommentAverage).Take(10).Select(cm => new LightFilmDTO
                {
                    FilmName = cm.Film.FilmTitle,
                    Score = cm.CommentAverage
                }).ToList();
        }
        public FullActorDTO GetFullActorDetailsByIdActor(int idActor)
        {
            var fullActor = (from actor in context.Actors
                        where actor.ActorId == idActor
                        select actor).Select(a => new FullActorDTO
                        {
                            Id = a.ActorId,
                            Name = a.ActorName,
                            Surname = a.ActorSurname,
                            ListFilm = a.Films.Select(f => new FilmDTO
                            {
                                Id = f.FilmId,
                                Title = f.FilmTitle,
                                Original_title = f.FilmOriginal_title,
                                Runtime = f.FilmRuntime,
                                Posterpath = f.FilmPosterpath
                            }).ToList()
                                                        
                        });
            return fullActor.First();
        }
        public void InsertCommentOnActorId(CommentDTO cmt)
        {
            var film = context.Films.Find(cmt.FilmId);
            Comment cm = new Comment
            {
                CommentContent = cmt.Content,
                CommentActorId = cmt.ActorId,
                CommentAverage = cmt.Average,
                CommentAvatar = cmt.Avatar,
                CommentDate = cmt.Date
            };
            film.Comments.Add(cm);
            cm.Film = film;
            context.Comments.Add(cm);
            context.SaveChanges();
        }
    }
}
