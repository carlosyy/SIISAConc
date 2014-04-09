using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class SQLConn
    {
        #region Propiedades de la Clase

        /// <summary>Propiedad que Expone el DataReader en donde se encuentran los datos leidos
        /// </summary>
        public IDataReader DataReader;

        public String strConnection;

        /// <summary>Propiedad que almacena el objeto de Conexion a la BD
        /// </summary>
        public SqlConnection conexion { get; set; }

        /// <summary>Nombre de la Base de Datos
        /// </summary>
        public String baseDatos { get; set; }

        /// <summary>Password de la Base de datos si lo tiene
        /// </summary>
        public String password { get; set; }


        /// <summary>Propiedad que devuelve un objeto SqlCommand
        /// </summary>
        public SqlCommand commando { get; set; }        

        /// <summary>Ruta d ela base de datos si es diferente a la de la Aplicacion
        /// </summary>
        public String connectionString { get; set; }

        /// <summary>Objeto para el manejo de las Transacciones
        /// </summary>
        public SqlTransaction transaction { get; set; }

        /// <summary> Datatable con el resultado de la consulta
        /// </summary>
        public DataTable datos { get; set; }

        #endregion

        #region Constructores

        /// <summary>Constructor vacio de la Clase
        /// @"SERVER=MELBABAUT\SQLEXPRESS; Database=BDSIISAConc; User Id=sa; Password=123456"  --- Server				
        /// </summary>
				public SQLConn()
				{
					strConnection = @"SERVER=.\SQLEXPRESS; Database=BDSIISAConc; User Id=sa; Password=123456";                    
					commando = new SqlCommand();
					conexion = new SqlConnection();
					password = String.Empty;
				}
        #endregion

        #region Metodos


        /// <summary>Metodo que abre la conexion a la Base de datos
        /// </summary>
        public void open(Int32 tiempoEspera = 0)
        {
            // Si hay una conexion abierta la mantengo
            if (conexion.State == ConnectionState.Open)
                return;

            // Armo la cadena de conexion
            //Conexion.ConnectionString = ConnectionString;

            conexion.ConnectionString = strConnection;
            if (tiempoEspera > 0)
            {
                commando.CommandTimeout = tiempoEspera;

            }


            // Abro la conexion
            try
            {

                conexion.Open();


            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>Crea un Objeto SqlCeCommand para ser utilizado
        /// </summary>
        public void createParameter()
        {
            try
            {
                commando = conexion.CreateCommand();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>Metodo que permite crear los parametros de las diferentes consultas a realizar
        /// </summary>
        /// <param name="paramName">Nombre del parametro</param>
        /// <param name="typeParam">Tipo del parametro</param>
        /// <param name="paramValue">Valor del parametro</param>
        public void addInParameters(String paramName, DbType typeParam, Object paramValue)
        {
            try
            {
                SqlParameter objSqlParam = new SqlParameter();
                objSqlParam.ParameterName = paramName;
                objSqlParam.DbType = typeParam;
                objSqlParam.Value = paramValue;

                commando.Parameters.Add(objSqlParam);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        /// <summary>Ejecuta sentencias SQL en la BAse de datos SQL Mobile
        /// </summary>
        /// <param name="tipoComando">Un CommandType para saber que se hace con la instruccion</param>
        /// <param name="query">La sentencia SQL a Ejecutar</param>
        /// <returns>Un Datareader para ser recorrido</returns>
        public IDataReader executeReader(CommandType tipoComando, String query)
        {
            DataReader = null;
            verificarComando();

            commando.Connection = conexion;
            commando.CommandType = tipoComando;
            commando.CommandText = query;

            try
            {
                commando.CommandTimeout = 1200;
                DataReader = commando.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return DataReader;
        }

        /// <summary> Metodo que ejecuta una sentencia y devuelve un DataSet
        /// </summary>
        /// <param name="tipoComando"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataSet executeDataSet(CommandType tipoComando, String query)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            verificarComando();
            commando.Connection = conexion;
            commando.CommandType = tipoComando;
            commando.CommandText = query;

            try
            {
                da = new SqlDataAdapter(commando);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return ds;
        }


        /// <summary>Ejecuta Sentencias SQL pero devuelve un solo valor
        /// </summary>
        /// <param name="tipoComando">Tipo de comando a Ejecutar</param>
        /// <param name="query">Instruccion SQL a Ejecutar</param>
        /// <returns>Devuelve una cadena con el resultado d ela consulta SQL</returns>
        public String executeScalar(CommandType tipoComando, String query)
        {
            verificarComando();
            commando.Connection = conexion;
            commando.CommandType = tipoComando;
            commando.CommandText = query;
            String stReturn;

            try
            {
                stReturn = commando.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return stReturn;
        }

        /// <summary> Ejecuta sentencias de INSERT, DELETE y UPDATE 
        /// </summary>
        /// <param name="tipoComando">Tipo de comando a Ejecutar</param>
        /// <param name="query">Instruccion SQL a Ejecutar</param>
        /// <param name="retOp"></param>
        /// <returns>Un entero con el numero de registros Afectados</returns>
        public Int32 executeNonQuery(CommandType tipoComando, String query, Boolean retOp = false)
        {
            verificarComando();
            commando.Connection = conexion;
            commando.CommandType = tipoComando;
            commando.CommandText = query;
            if (retOp)
                commando.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            Int32 stReturn;

            try
            {
                stReturn = commando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return stReturn;
        }

        /// <summary>Metodo que Inicia una Transaccion para almacenar los datos y asegurarlos todos
        /// </summary>
        public void beginTransaction()
        {
            try
            {
                transaction = null;
                transaction = conexion.BeginTransaction();
                verificarComando();
                commando.Transaction = transaction;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>Metodo que le Hace Commit a la Transaccion
        /// </summary>
        public void commitTransaction()
        {
            try
            {
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>Metodo que hace RollBack a la transaccion
        /// </summary>
        public void rollBackTransaction()
        {
            try
            {
                transaction.Rollback();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception exg)
            {
                throw exg;
            }
        }

        /// <summary>Metodo que Cierra la conexion y libera recursos
        /// </summary>
        public void close()
        {
            try
            {
                conexion.Close();
                conexion.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que ejecuta una sentencia y devuelve un DataTable
        /// </summary>
        /// <param name="query">Sentencia SQl a ejecutar contra la base de datos</param>
        /// <returns>Un Datatable con los datos</returns>
        public DataTable executeDataTable(String query)
        {
            SqlDataAdapter daTmp = new SqlDataAdapter();
            try
            {
                DataReader = null;
                verificarComando();
                commando.Connection = conexion;
                commando.CommandType = CommandType.Text;
                commando.CommandText = query;
                daTmp = new SqlDataAdapter(commando);
                datos = new DataTable();
                daTmp.Fill(datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                daTmp.Dispose();
            }
            return datos;
        }
        /// <summary> Metodo que Verifica si el Comando no es nulo, si es nulo lo inicializa
        /// </summary>
        private void verificarComando()
        {
            if (commando == null)
            {
                createParameter();
            }
        }
        #endregion
    }
}
