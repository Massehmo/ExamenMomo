using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDTO
{
    public class FilmDTO
    {
        #region variables
        private int _id;
        private String _title;
        private String _original_title;
        private int _runtime;
        private String _posterpath;
        #endregion

        #region proprietes
        public int Id { get=>_id; set=> _id=value; }
        public string Title { get=>_title; set=>_title=value; }
        public string Original_title { get=>_original_title; set=>_original_title=value; }
        public int Runtime { get=>_runtime; set=>_runtime=value; }
        public string Posterpath { get=>_posterpath; set=>_posterpath=value; }
        #endregion

        public FilmDTO()
        {
            Id = -1; Title =null; Original_title = null; Runtime = -1; Posterpath = null;
        }
        public FilmDTO(int id, String title, String originaltitle, int runtime)
        {
            Id = id; Title = title; Original_title = originaltitle; Runtime = runtime; Posterpath = null;
        }
        public FilmDTO(int id, String title, String originaltitle, int runtime, String posterpath)
        {
            Id = id; Title = title; Original_title = originaltitle; Runtime = runtime; Posterpath = posterpath;
        }
        
    }
}
