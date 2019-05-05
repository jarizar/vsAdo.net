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
    public class GenreTXLocalDA: BaseConnection
    {

        public List<Genre> GetAllSP(string filterByName = "")
        {
            var result = new List<Genre>();

            var sql = "usp_GetAllGenre";

            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                IDbCommand cmd = new SqlCommand(sql);

                /*indica que ahora es un procedimiento almacenado*/
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();

                filterByName = $"%{filterByName}%";
                cmd.Parameters.Add(new SqlParameter("@pfilterByName", filterByName));

                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    var Genre = new Genre();

                    indice = reader.GetOrdinal("GenreId");
                    Genre.GenreId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    Genre.Name = reader.GetString(indice);
                                      
                    result.Add(Genre);
                }
                return result;
            }


        }

        public int Insert(Genre entity)
        {
            var Result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                cn.Open();
                //Iniciando el bloque de transacción local
                var transaccion = cn.BeginTransaction();

                try
                {

                    IDbCommand cmd = new SqlCommand("usp_InsertGenre");
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(
                        new SqlParameter("@pName", entity.Name)
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

        public int Update(Genre entity)
        {
            var Result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                cn.Open();
                //Iniciando el bloque de transacción local
                var transaccion = cn.BeginTransaction();

                try
                {

                    IDbCommand cmd = new SqlCommand("usp_UpdateGenre");
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(
                       new SqlParameter("@pName", entity.Name)
                       );                
                    cmd.Parameters.Add(
                     new SqlParameter("@pGenreId", entity.GenreId)
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

        public int delete(Genre entity)
        {
            var Result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                cn.Open();
                IDbCommand cmd = new SqlCommand("usp_DeleteGenre");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@pGenreId", entity.GenreId)
                    );
                Result = cmd.ExecuteNonQuery();
            }
            return Result;
        }

    }
}
