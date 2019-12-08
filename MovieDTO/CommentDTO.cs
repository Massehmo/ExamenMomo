using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDTO
{
    public class CommentDTO
    {
        private int _id;
        private string _content;
        private int _average;
        private int _actorId;
        private string _avatar;
        private DateTime _date;
        private int _filmId;


        public int Id { get=>_id; set=>_id=value; }
        public String Content { get=>_content; set=>_content=value; }
        public int Average { get=>_average; set=>_average=value; }
        public int ActorId { get=>_actorId; set=>_actorId=value; }
        public String Avatar { get=>_avatar; set=>_avatar=value; }
        public DateTime Date { get=>_date; set=>_date=value; }
        public int FilmId { get => _filmId; set => _filmId = value; }

        public CommentDTO()
        {
            Id = -1;    Content = null; Average = -1;   ActorId = -1;   Avatar = null;  Date = DateTime.Now;
        }
        public CommentDTO(int id, string content, int average, int actorId, string avatar, DateTime date)
        {
            Id = id; Content = content; Average = average;
            ActorId = actorId; Avatar = avatar; Date = date;
        }
    }
}
