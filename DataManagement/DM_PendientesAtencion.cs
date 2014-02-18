using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;

namespace DataManagement
{
    public class DM_PendientesAtencion
    {
        SQLConn oDataAccess = new SQLConn();
        // selecciona todos los atributos de accion
        public pendientesAtencion getPendientesAtencion(Int32 id = 0, Int32 idDatosUs = 0)
        {
            StringBuilder sbPendientesAtencion = new StringBuilder();
            pendientesAtencion lista = new pendientesAtencion();
            pendientesAtencionEntidad oPendientesAtencion;

            sbPendientesAtencion.Append("SELECT");
            sbPendientesAtencion.Append(" idPdtesAtencion");
            sbPendientesAtencion.Append(", idDatosUS");
            sbPendientesAtencion.Append(", idAreaAtencion");
            sbPendientesAtencion.Append(", idPatologia");
            sbPendientesAtencion.Append(", codServ");
            sbPendientesAtencion.Append(", (SELECT s.descripcion FROM servicios as s WHERE s.codServ=pa.codServ) as descripServ");
            sbPendientesAtencion.Append(", cantServ");
            sbPendientesAtencion.Append(" FROM PendientesAtencion as pa");

            if (id != 0)
            {
                sbPendientesAtencion.Append(" WHERE idPdtesAtencion='" + id + "'");
            }

            if (idDatosUs != 0)
            {
                sbPendientesAtencion.Append(" WHERE idDatosUS='" + idDatosUs + "'");
            }

            try
            {
                oDataAccess.open();
                IDataReader reader = oDataAccess.executeReader(CommandType.Text, sbPendientesAtencion.ToString());

                while (reader.Read())
                {
                    oPendientesAtencion = new pendientesAtencionEntidad();
                    oPendientesAtencion.idPdtesAtencion = Int32.Parse(reader["idPdtesAtencion"].ToString());
                    oPendientesAtencion.idAreaAtencion = Int32.Parse(reader["idAreaAtencion"].ToString());
                    oPendientesAtencion.idPatologia = Int32.Parse(reader["idPatologia"].ToString());
                    oPendientesAtencion.codServ = reader["codServ"].ToString();
                    oPendientesAtencion.cantServ = Int32.Parse(reader["cantServ"].ToString());
                    oPendientesAtencion.descripServ = reader["descripServ"].ToString();
                    lista.Add(oPendientesAtencion);

                }
                reader.Close();

                return lista;
            }
            finally
            {
                oDataAccess.close();
            }
        }

        // adiciona una nueva accion
        public Int32 addPendientesAtencion(pendientesAtencionEntidad oPendientesAtencion)
        {
            StringBuilder sbPendientesAtencion = new StringBuilder();
            {
                sbPendientesAtencion.Append("INSERT INTO PendientesAtencion(");                
                sbPendientesAtencion.Append(" idDatosUS");
                sbPendientesAtencion.Append(", idAreaAtencion");
                sbPendientesAtencion.Append(", idPatologia");
                sbPendientesAtencion.Append(", codServ");
                sbPendientesAtencion.Append(", cantServ");
                sbPendientesAtencion.Append(")");
                sbPendientesAtencion.Append(" VALUES(");                
                sbPendientesAtencion.Append(" '" + oPendientesAtencion.idDatosUS + "'");
                sbPendientesAtencion.Append(", '" + oPendientesAtencion.idAreaAtencion + "'");
                sbPendientesAtencion.Append(", '" + oPendientesAtencion.idPatologia + "'");
                sbPendientesAtencion.Append(", '" + oPendientesAtencion.codServ + "'");
                sbPendientesAtencion.Append(", '" + oPendientesAtencion.cantServ + "'");
                sbPendientesAtencion.Append(")");

                try
                {
                    oDataAccess.open();
                    Int32 retorno = oDataAccess.executeNonQuery(CommandType.Text, sbPendientesAtencion.ToString());

                    return retorno;
                }
                finally
                {
                    oDataAccess.close();
                }
            }

        }

        // Actualiza un registro de la tabla accion

        public Int32 updatePendientesAtencion(pendientesAtencionEntidad oPendientesAtencion)
        {
            StringBuilder sbPendientesAtencion = new StringBuilder();
            {
                sbPendientesAtencion.Append("UPDATE accion SET");
                sbPendientesAtencion.Append(" idDatosUS='" + oPendientesAtencion.idDatosUS + "'");
                sbPendientesAtencion.Append(", idPatologia='" + oPendientesAtencion.idPatologia + "'");
                sbPendientesAtencion.Append(" WHERE idPdtesAtencion='" + oPendientesAtencion.idPdtesAtencion + "'");

                try
                {
                    oDataAccess.open();
                    Int32 retorno = oDataAccess.executeNonQuery(CommandType.Text, sbPendientesAtencion.ToString());
                    return retorno;
                }
                finally
                {
                    oDataAccess.close();
                }
            }
        }
    }
}
