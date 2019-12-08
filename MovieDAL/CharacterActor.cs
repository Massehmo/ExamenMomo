using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDAL
{
    public class CharacterActor
    {
        [Key, Column(Order = 0)]
        public int ActorId { get; set; }
        [Key, Column(Order = 1)]
        public int CharacterId { get; set ; } 
        [Key, Column(Order = 2)]
        public int FilmId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Character Character { get; set; }
        public virtual  Film Film { get; set; }

        public CharacterActor(int filmid ,int actorid, int characterid)
        {
            FilmId = filmid; ActorId = actorid; CharacterId = characterid;
        }
        public CharacterActor(Film film, Actor a, Character c)
        {
            FilmId = film.FilmId; ActorId = a.ActorId; CharacterId = c.CharacterId;
            Actor = a;  Character = c;  Film = film; //inserer ds la base que les objets CharacterActor
        }

        
      
    }
}
