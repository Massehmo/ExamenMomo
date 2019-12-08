using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDTO
{
    public class ActorDTO
    {
        private int _id;
        private string _name;
        private string _surname;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }

        public ActorDTO()
        {
            Id = -1; Name = null; Surname = null;
        }
        public ActorDTO(int id, string name, string surname)
        {
            Id = id; Name = name; Surname = surname;
        }
    }
}
