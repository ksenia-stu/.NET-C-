using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsDb
{
    class Owner
    {
        public int Id { get; set; }
        string _fullName;
        public int CatId { get; set; }
        public string FullName { get => _fullName; set => _fullName = value; }

        public Owner(int id, string fullName, int catId)
        {
            Id = id;
            FullName = fullName;
            CatId = catId;
        }

        public Owner(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id"));
            FullName = reader.GetString(reader.GetOrdinal("FullName"));
            CatId = reader.GetInt32(reader.GetOrdinal("CatId"));
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} owns cat with id {2}", Id, FullName, CatId);
        }
    }
}
