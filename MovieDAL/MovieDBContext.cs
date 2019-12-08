namespace MovieDAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MovieDBContext : DbContext
    {
        public MovieDBContext()
            : base(@"Server=LAPTOP-J30I3N3B\SQLEXPRESS;Database=movies;Trusted_Connection=True;")
        {

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterActor> CharacterActors { get; set; }
        public DbSet<Comment> Comments { get; set; }


        
    }
}
