using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDAL
{
    public class Character
    {
        public Character()
        {
            this.CharacterActors = new HashSet<CharacterActor>();
        }
        public int CharacterId { get; set ; }
        public string CharacterName { get ; set ; }
        public virtual ICollection<CharacterActor> CharacterActors { get; set; }

        public void AddCharacter(Character character)
        {
            using (var mdbc = new MovieDBContext())
            {
                mdbc.Characters.Add(character);
                mdbc.SaveChanges();
            }
        }
    }
}
