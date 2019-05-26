using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataAccess
{
    public class GenreDA
    {
        public IEnumerable<Genre> GetAll() {

            var result = new List<Genre>();

            using (var db = new DBModel())
            {
                result = db.Genre.ToList();
            }

                return result;
        }
    }
}
