using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDTO
{
    public class FullActorDTO : ActorDTO
    {
        private List<FilmDTO> _listFilm;
        private List<CharacterDTO> _listCharacter;

        public List<FilmDTO> ListFilm { get => _listFilm; set => _listFilm = value; }
        //public List<CharacterDTO> ListCharacter { get => _listCharacter; set => _listCharacter = value; }
    }
}
