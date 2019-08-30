using System;
using System.Collections.Generic;
using System.Text;

namespace ypologismosMorion.Models
{
    public class VaseisDBnew
    {
        public int ID { get; set; }
        public int Mixanografiko { get; set; }
        public string idryma { get; set; }
        public string sxoli { get; set; }
        public string eidika { get; set; }
        public string typos { get; set; }
        public string poli { get; set; }
        public int? vasi { get; set; }
    }

    public class VaseisDBnewWithPedio : VaseisDBnew
    {
        public int Pedio { get; set; }
    }

    public class VaseisDBExtended : VaseisDBnew
    {
        public int? vasi2018 { get; set; }
        public bool? existsinlatest { get; set; }
    }

    public class VaseisWithexistsinNewest : VaseisDBnew
    {
        public string existsinNewest { get; set; }
    }
}
