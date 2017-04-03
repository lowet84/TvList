using System.Collections.Generic;

namespace TvList.Model
{
    public class Credits
    {
        public List<Presenter> presenter { get; set; }
        public List<Actor> actor { get; set; }
        public List<Producer> producer { get; set; }
        public List<Writer> writer { get; set; }
        public List<Director> director { get; set; }
        public List<Commentator> commentator { get; set; }
    }
}