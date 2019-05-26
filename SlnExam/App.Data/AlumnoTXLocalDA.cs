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
    public class AlumnoTXLocalDA : BaseConnection
    {
        public List<Alumno> GetAllSP(string filterByName = "")
        {
            var result = new List<Alumno>();
            var sql = "usp_GetAll";

            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                IDbCommand cmd = new SqlCommand(sql);
                /*Indica que ahora es un procedimientos almacenado*/
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();

                filterByName = $"%{filterByName}%";

                cmd.Parameters.Add(
                    new SqlParameter("@filterByName", filterByName));

                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    var alumno = new Alumno();

                    indice = reader.GetOrdinal("AlumnoId");
                    alumno.AlumnoID = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Nombres");
                    alumno.Nombres = reader.GetString(indice);

                    indice = reader.GetOrdinal("Apellidos");
                    alumno.Apellidos = reader.GetString(indice);

                    indice = reader.GetOrdinal("Direccion");
                    alumno.Direccion = reader.GetString(indice);

                    indice = reader.GetOrdinal("sexo");
                    alumno.Sexo = reader.GetString(indice);

                    indice = reader.GetOrdinal("FechaNacimiento");
                    alumno.FechaNacimiento = reader.GetDateTime(indice);

                    result.Add(alumno);
                }
                return result;
            }

        }

           

        public int Insert(Alumno entity)
        {
            var Result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                cn.Open();
                //Iniciando el bloque de transacción local
                var transaccion = cn.BeginTransaction();

                try
                {

                    IDbCommand cmd = new SqlCommand("sp_insertAlumno");
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pNombres", entity.Nombres));
                    cmd.Parameters.Add(new SqlParameter("@pApellidos", entity.Apellidos));
                    cmd.Parameters.Add(new SqlParameter("@pDireccion", entity.Direccion));
                    cmd.Parameters.Add(new SqlParameter("@pSexo", entity.Sexo));
                    cmd.Parameters.Add(new SqlParameter("@pFechaNacimiento", entity.FechaNacimiento));


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

       

    }
}
