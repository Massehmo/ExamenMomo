using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDAL
{
    public class Actor
    {

        public Actor()
        {
            this.Films = new HashSet<Film>();
            this.CharacterActors = new HashSet<CharacterActor>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int ActorId { get ; set ; } 
        
        public string ActorName { get ; set ; }
        public string ActorSurname { get ; set; } 

        public virtual ICollection<Film> Films { get; set; }
        public virtual ICollection<CharacterActor> CharacterActors { get; set; }

        

        public override string ToString()
        {
            return "\t\t"+this.ActorId + "\t" + this.ActorName + "\t" + this.ActorSurname + "\n";
        }
    }
}
