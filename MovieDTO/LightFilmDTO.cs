using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDTO
{
    public class LightFilmDTO
    {
        private string _filmName;
        private int _score;

        public string FilmName { get => _filmName; set => _filmName = value; }
        public int Score { get => _score; set => _score = value; }

        public LightFilmDTO()
        {
            FilmName = null;
            Score = -1;
        }
        public LightFilmDTO(string name, int score)
        {
            FilmName = name;
            Score = score;
        }

    }
}
