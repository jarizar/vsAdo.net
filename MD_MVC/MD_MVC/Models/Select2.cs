using System.Collections.Generic;

namespace MD_MVC.Models
{
    public class Select2
    {
        public object id { get; set; }
        public object text { get; set; }

    }

    public class GrupoSelect2
    {
        public string text { get; set; }
        public List<children> children { get; set; }
    }

    public class children
    {
        public object id { get; set; }
        public object text { get; set; }

    }

}