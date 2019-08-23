using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace RepositorioGenerico
{
    public delegate void ExceptionEventHandler(object sender, ExceptionEvenArgs e);

    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        /// <summary>
        /// Evento para manejo de las excepciones lanzadas desde el repositorio genérico
        /// </summary>
        public event ExceptionEventHandler Excepcion;
        DbContext Contexto = null;

        /// <summary>
        /// Repositorio genérico con las operaciones básicas
        /// </summary>
        /// <param name="contexto">
        /// Recibe el contexto de la base de datos actual
        /// </param>
        /// <param name="lazyLoadingEnabled">
        /// Obtiene o establece un valor booleano que determina si los objetos relacionados se cargan automáticamente cuando se tiene acceso a una propiedad de navegación.
        /// </param>
        /// <param name="proxyCreationEnabled">
        /// Obtiene o establece un valor que indica si el marco creará o no instancias de clases proxy generadas dinámicamente siempre que cree una instancia de un tipo de entidad.Tenga en cuenta que incluso si la creación de proxy está habilitada con este indicador, las instancias de proxy solo se crearán para los tipos de entidad que cumplan con los requisitos para ser procesados.La creación de proxy está habilitada por defecto.
        /// </param>
        public Repositorio(DbContext contexto, bool lazyLoadingEnabled = false, bool proxyCreationEnabled = false)
        {
            this.Contexto = contexto;
            Contexto.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
            Contexto.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }

        private DbSet<TEntity> EntitySet { get { return Contexto.Set<TEntity>(); } }

        public TEntity Create(TEntity toCreate)
        {
            TEntity Result = null;
            try
            {
                Result = EntitySet.Add(toCreate);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                Excepcion?.Invoke(this, new ExceptionEvenArgs() { Message = ex.Message, InnerException = ex.InnerException, Source = ex.Source, StackTrace = ex.StackTrace, TargetSite = ex.TargetSite });
            }
            return Result;
        }

        public bool Delete(TEntity toDelete)
        {
            bool Result = false;
            try
            {
                EntitySet.Attach(toDelete);
                EntitySet.Remove(toDelete);
                Result = Contexto.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Excepcion?.Invoke(this, new ExceptionEvenArgs() { Message = ex.Message, InnerException = ex.InnerException, Source = ex.Source, StackTrace = ex.StackTrace, TargetSite = ex.TargetSite });
            }
            return Result;
        }

        public bool Update(TEntity toUpdate)
        {
            bool Result = false;
            try
            {
                EntitySet.Attach(toUpdate);
                Contexto.Entry<TEntity>(toUpdate).State = EntityState.Modified;
                Result = Contexto.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Excepcion?.Invoke(this, new ExceptionEvenArgs() { Message = ex.Message, InnerException = ex.InnerException, Source = ex.Source, StackTrace = ex.StackTrace, TargetSite = ex.TargetSite });
            }
            return Result;
        }

        public bool Update(Expression<Func<TEntity, bool>> criterio, string propertyName, object valor)
        {
            bool Result = false;
            try
            {
                Contexto.Entry<TEntity>(EntitySet.FirstOrDefault(criterio)).Property(propertyName).CurrentValue = valor;
                Result = Contexto.SaveChanges() > 0;
            }
            catch (DbEntityValidationException ex)
            {
                Excepcion?.Invoke(this, new ExceptionEvenArgs() { Message = ex.Message, InnerException = ex.InnerException, Source = ex.Source, StackTrace = ex.StackTrace, TargetSite = ex.TargetSite, EntityValidationErrors = ex.EntityValidationErrors });
            }
            catch (Exception ex)
            {
                Excepcion?.Invoke(this, new ExceptionEvenArgs() { Message = ex.Message, InnerException = ex.InnerException, Source = ex.Source, StackTrace = ex.StackTrace, TargetSite = ex.TargetSite });
            }
            return Result;
        }

        public TEntity Retrieve(Expression<Func<TEntity, bool>> criterio)
        {
            TEntity Result = null;
            try
            {
                Result = EntitySet.FirstOrDefault(criterio);
            }
            catch (Exception ex)
            {
                Excepcion?.Invoke(this, new ExceptionEvenArgs() { Message = ex.Message, InnerException = ex.InnerException, Source = ex.Source, StackTrace = ex.StackTrace, TargetSite = ex.TargetSite });
            }
            return Result;
        }

        public List<TEntity> Filter(Expression<Func<TEntity, bool>> criterio)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criterio).ToList();
            }
            catch (Exception ex)
            {
                Excepcion?.Invoke(this, new ExceptionEvenArgs() { Message = ex.Message, InnerException = ex.InnerException, Source = ex.Source, StackTrace = ex.StackTrace, TargetSite = ex.TargetSite });
            }
            return Result;
        }

        public List<TEntity> All()
        {
            List<TEntity> Result = new List<TEntity>();
            try
            {
                Result = EntitySet.ToList();
            }
            catch (Exception ex)
            {
                Excepcion?.Invoke(this, new ExceptionEvenArgs() { Message = ex.Message, InnerException = ex.InnerException, Source = ex.Source, StackTrace = ex.StackTrace, TargetSite = ex.TargetSite });
            }
            return Result;
        }

        public List<TEntity> All(int cantidad)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Take(cantidad).ToList();
            }
            catch (Exception ex)
            {
                Excepcion?.Invoke(this, new ExceptionEvenArgs() { Message = ex.Message, InnerException = ex.InnerException, Source = ex.Source, StackTrace = ex.StackTrace, TargetSite = ex.TargetSite });
            }
            return Result;
        }

        public List<TEntity> All(int desde, int hasta)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Skip(desde).Take(hasta).ToList();
            }
            catch (Exception ex)
            {
                Excepcion?.Invoke(this, new ExceptionEvenArgs() { Message = ex.Message, InnerException = ex.InnerException, Source = ex.Source, StackTrace = ex.StackTrace, TargetSite = ex.TargetSite });
            }
            return Result;
        }

        public void Dispose()
        {
            if (Contexto != null)
                Contexto.Dispose();
        }
    }

    public class ExceptionEvenArgs : EventArgs
    {
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public MethodBase TargetSite { get; set; }
        public Exception InnerException { get; set; }
        public IEnumerable<DbEntityValidationResult> EntityValidationErrors { get; set; }
    }

    public class Repositorio
    {
        /// <summary>
        /// Evento para manejo de las excepciones lanzadas desde el repositorio
        /// </summary>
        public static event ExceptionEventHandler Excepcion;
        /// <summary>
        /// Método para realizar una consulta directa mediante T-SQL
        /// </summary>
        /// <param name="query">
        /// T-SQL a ejecutar
        /// </param>
        /// <param name="connectionString">
        /// Cadena de conexión que se usará para realizar la consulta
        /// </param>
        /// <returns>
        /// DataTable con todas las filas retornadas en caso hayan
        /// </returns>
        public static DataTable QuerySQL(string query, string connectionString)
        {
            DataTable resultado = new DataTable();
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                    adapter.Fill(resultado);
                }
            }
            catch (Exception ex)
            {
                Excepcion?.Invoke(new { }, new ExceptionEvenArgs() { Message = ex.Message, InnerException = ex.InnerException, Source = ex.Source, StackTrace = ex.StackTrace, TargetSite = ex.TargetSite });
            }
            return resultado;
        }
    }
}