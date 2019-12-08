using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDTO
{
    public class CharacterDTO
    {
        private int _id;
        private string _name;

        public int Id { get=>_id; set=>_id=value; }
        public string Name { get=>_name; set=>_name=value; }

        public CharacterDTO()
        {
            Id = -1;    Name = null;
        }
        public CharacterDTO(int id, string name)
        {
            Id = id;    Name = name;
        }
    }
}
