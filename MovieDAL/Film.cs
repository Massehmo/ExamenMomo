using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDAL
{
    public class Film
    {
        
        public Film()
        {
            this.Actors = new HashSet<Actor>();
            this.Comments = new HashSet<Comment>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int FilmId { get ; set ; }
       
        public string FilmTitle { get ; set ; }
        public string FilmOriginal_title { get ; set ; }
        public int FilmRuntime { get ; set ; }
        public string FilmPosterpath { get ; set ; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }


        public override string ToString()
        {
            return this.FilmId + "\t" + this.FilmTitle + "\t" + this.FilmOriginal_title + "\t" + this.FilmRuntime + "\t" + this.FilmPosterpath + "\n";
        }
    }
}
