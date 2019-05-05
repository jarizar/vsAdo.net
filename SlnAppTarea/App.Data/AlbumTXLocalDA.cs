using App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class AlbumTXLocalDA:BaseConnection
    {
       
        public List<Album> GetAllSP(string filterByTitle = "")
        {
            var result = new List<Album>();

            var sql = "usp_GetAllAlbum";

            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                IDbCommand cmd = new SqlCommand(sql);

                /*indica que ahora es un procedimiento almacenado*/
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();

                filterByTitle = $"%{filterByTitle}%";
                cmd.Parameters.Add(new SqlParameter("@pfilterByTitle", filterByTitle));

                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    var album = new Album();

                    indice = reader.GetOrdinal("AlbumId");
                    album.AlbumId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Title");
                    album.Title = reader.GetString(indice);

                    indice = reader.GetOrdinal("ArtistId");
                    album.ArtistId = reader.GetInt32(indice);

                    result.Add(album);
                }
                return result;
            }


        }

        public int Insert(Album entity)
        {
            var Result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                cn.Open();
                //Iniciando el bloque de transacción local
                var transaccion = cn.BeginTransaction();

                try
                {

                    IDbCommand cmd = new SqlCommand("usp_InsertAlbum");
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(
                        new SqlParameter("@pTitle", entity.Title)
                        );
                    cmd.Parameters.Add(
                       new SqlParameter("@ArtistId", entity.ArtistId)
                       );

                    //Asociando la transacción al objeto command
                    cmd.Transaction = transaccion;

                    Result = Convert.ToInt32(cmd.ExecuteScalar());
                    
                    //confirmando la transaccion
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    //Cancelando la transacción con el método Rollback
                    transaccion.Rollback();
                }


            }
            return Result;
        }
               
        public int Update(Album entity)
        {
            var Result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                cn.Open();
                //Iniciando el bloque de transacción local
                var transaccion = cn.BeginTransaction();

                try
                {

                    IDbCommand cmd = new SqlCommand("usp_UpdateAlbum");
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(
                       new SqlParameter("@pTitle", entity.Title)
                       );
                    cmd.Parameters.Add(
                       new SqlParameter("@pArtistId", entity.ArtistId)
                       );
                    cmd.Parameters.Add(
                     new SqlParameter("@pAlbumId", entity.AlbumId)
                     );

                    //Asociando la transacción al objeto command
                    cmd.Transaction = transaccion;

                    Result = cmd.ExecuteNonQuery();
                    
                    //confirmando la transaccion
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    //Cancelando la transacción con el método Rollback
                    transaccion.Rollback();
                }


            }
            return Result;
        }

        public int delete(Album entity)
        {
            var Result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                cn.Open();
                IDbCommand cmd = new SqlCommand("usp_DeleteAlbum");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@pAlbumId", entity.AlbumId)
                    );
                Result = cmd.ExecuteNonQuery();
            }
            return Result;
        }

    }
}
