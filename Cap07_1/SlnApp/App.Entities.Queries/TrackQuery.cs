using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Queries
{
    public class TrackQuery
    {        
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public string AlbumTitle { get; set; }
        public string MediaTypeName { get; set; }
        public string GenreName { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }
   
    }
}
