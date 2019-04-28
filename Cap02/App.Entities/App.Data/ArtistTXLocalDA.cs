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
    public class ArtistTXLocalDA : BaseConnection   
    {
        ///<summary>
        ///Permite obtener la cantidad de registros
        ///que existen en la tabla artista
        /// </summary>     
        /// <returns>Retorna el numero de registros
        /// </returns>
        public int GetCount() {

            var result = 0;

            var sql = "SELECT COUNT(1) FROM ARTIST";
            /*1.- Creando la instancia del objeto connection
             */
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                /*2. - Creando el objeto command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open();//abriendo la conexion a la base de datos;

                result = (int)cmd.ExecuteScalar();
            }
            
            return result;
        }

        /// <summary>
        /// Permite obtener la lista de artistas
        /// </summary>
        /// <returns>Lista de artistas</returns>
        
        public List<Artista> GetAll()
        {
            var result = new List<Artista>();

            var sql = "Select * from Artist";

            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open();

                var reader = cmd.ExecuteReader();
                var indice = 0;
                
                while (reader.Read())
                {
                    var artista = new Artista();

                    indice = reader.GetOrdinal("ArtistId");
                    artista.ArtistID = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artista.Name = reader.GetString(indice);

                    result.Add(artista);
                }
                return result;
            }
        }


        public Artista Get(int id) {
            var result = new Artista();

            var sql = "Select * from Artist where ArtistId=@id";            
                            
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                IDbCommand cmd = new SqlCommand(sql);
                /*configurando los parametros*/

                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Connection = cn;
                cn.Open();

                var reader = cmd.ExecuteReader();
                var indice = 0;
                while (reader.Read())
                {
                    
                    indice = reader.GetOrdinal("ArtistId");
                    result.ArtistID = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    result.Name = reader.GetString(indice);               
                }
            }
            return result;

        }


        public List<Artista> GetAllfilter(string filterByName="")
        {
            var result = new List<Artista>();

            var sql = "Select * from Artist where Name like @filterByName";

            filterByName = $"%{filterByName}%";

            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Parameters.Add(new SqlParameter("@filterByName", filterByName));
                cmd.Connection = cn;
                cn.Open();

                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    var artista = new Artista();

                    indice = reader.GetOrdinal("ArtistId");
                    artista.ArtistID = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artista.Name = reader.GetString(indice);

                    result.Add(artista);
                }
                return result;
            }
        }


        public List<Artista> GetAllSP(string filterByName = "")
        {
            var result = new List<Artista>();

            var sql = "usp_GetAll";
                       
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                IDbCommand cmd = new SqlCommand(sql);

                /*indica que ahora es un procedimiento almacenado*/
                cmd.CommandType = CommandType.StoredProcedure;    
                cmd.Connection = cn;
                cn.Open();

                filterByName = $"%{filterByName}%";
                cmd.Parameters.Add(new SqlParameter("@filterByName", filterByName));

                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    var artista = new Artista();

                    indice = reader.GetOrdinal("ArtistId");
                    artista.ArtistID = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artista.Name = reader.GetString(indice);

                    result.Add(artista);
                }
                return result;
            }
        }


        public int Insert(Artista entity)
        {
            var Result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                cn.Open();

                //Iniciando el bloque de transacción local
                var transaccion = cn.BeginTransaction();

                try
                {
                    IDbCommand cmd = new SqlCommand("usp_InsertArtist");
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(
                        new SqlParameter("@pName", entity.Name)
                        );

                    //Asociando la transacción al objeto command
                    cmd.Transaction = transaccion;
                    Result = Convert.ToInt32(cmd.ExecuteScalar());

                    //Generando una excepción
                    throw new Exception("Error");


                    //confirmando la transaccion
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    //Cancelando la transacción con el método Rollback
                    transaccion.Rollback();
                }
                return Result;
            }
              
        }

        public int Update(Artista entity)
        {
            var Result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {

                //Iniciando el bloque de transacción local
                var transaccion = cn.BeginTransaction();

                try
                {
                    cn.Open();
                    IDbCommand cmd = new SqlCommand("usp_UpdateArtist");
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(
                        new SqlParameter("@pName", entity.Name)
                        );
                    cmd.Parameters.Add(
                        new SqlParameter("@pId", entity.ArtistID)
                        );
                    Result = cmd.ExecuteNonQuery();

                    //Asociando la transacción al objeto command
                    cmd.Transaction = transaccion;

                    //Generando una excepción
                    throw new Exception("Error");


                    //confirmando la transaccion
                    transaccion.Commit();

                }
                catch (Exception ex)
                {
                    //Cancelando la transacción con el método Rollback
                    transaccion.Rollback();
                }

                return Result;

            }
        }


        public int delete(Artista entity)
        {
            var Result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                cn.Open();
                IDbCommand cmd = new SqlCommand("usp_DeleteArtist");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@pId", entity.ArtistID)
                    );
                Result = cmd.ExecuteNonQuery();
            }
            return Result;


        }

    }
}
