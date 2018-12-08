using System;
using System.Collections.Generic;
using System.Text;

namespace ypologismosMorion.Models
{
    public class EidikaMathimataDB
    {
      

        public class EidikaMathimataProperties
        {
            public string eidikomathima { get; set; }
            public double vathmos { get; set; }
            public double moria { get; set; }
            public double vathmos2 { get; set; }
            public double vathmos3 { get; set; }
            public string pediopouanoigei { get; set; }
        }

        public static List<EidikaMathimataProperties> DbData = new List<EidikaMathimataProperties>();
        
        public static int count;
    }

}
