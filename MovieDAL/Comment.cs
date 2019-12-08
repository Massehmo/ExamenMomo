using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDAL
{
    public class Comment
    {

        public int CommentId { get; set; }
        public String CommentContent { get; set; }
        public int CommentAverage { get; set; }
        public int CommentActorId { get; set; }
        public String CommentAvatar { get; set; }
        public DateTime CommentDate { get; set; } 

        public virtual Film Film { get; set; }

        
    }
}
