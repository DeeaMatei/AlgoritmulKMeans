using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app2
{
    class Centroid
    {
        public List<Coordonate> punctSimilar { get; set; }
        public Coordonate coordonateCentroid { get; set; }

        public Centroid(int x, int y)
        {
            coordonateCentroid = new Coordonate(x, y);
            punctSimilar = new List<Coordonate>();
        }
    }
}
