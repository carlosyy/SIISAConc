using System;
using System.Data;
using System.Data.Common;
using DataAccess;
using Entities;
using System.Text;

namespace DataManagement
{
    public class DM_Rips
    {
        SQLConn oDataAccess = new SQLConn();

        public Rips GetRips(string NIT = "", Int64 Factura = 0)
        {
            String sQuery = string.Format("SPS_Rips '{0}', '{1}'", NIT, Factura);
            Rips lista = new Rips();
            IDataReader reader;
            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sQuery);

                while (reader.Read())
                {
                    lista.Add(new Entities.RipsEntidad() { IdRip = Int32.Parse(reader["idRip"].ToString()), NIT = reader["NIT"].ToString(), Factura = Int32.Parse(reader["Factura"].ToString()) });
                }
                reader.Close();

            }
            catch (DbException ex)
            {

                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (lista);
        }

        public Rips GetTempAF()
        {
            StringBuilder sbRips = new StringBuilder();            
            Rips lista = new Rips();
            IDataReader reader;

            sbRips.Append("Select * FROM TEMPAF");

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbRips.ToString());

                while (reader.Read())
                {
                    lista.Add(new Entities.RipsEntidad() { NIT = reader["docIden"].ToString(), nFactura = reader["factura"].ToString() });
                }
                reader.Close();

            }
            catch (DbException ex)
            {

                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (lista);
        }

        public Afiliado getAfiliadosSinCrear()
        {
            StringBuilder sbRips = new StringBuilder();
            Afiliado lista = new Afiliado();
            AfiliadoEntidad eAfiliado = new AfiliadoEntidad();
            IDataReader reader;

            sbRips.Append("Select tipoDoc, docIden, nombreComp FROM TEMPCSV WHERE okAfiliadoXNombres=0");

            try
            {
                oDataAccess.open();
                reader = oDataAccess.executeReader(CommandType.Text, sbRips.ToString());

                while (reader.Read())
                {
                    eAfiliado = new AfiliadoEntidad();
                    eAfiliado.tipoDocumento = reader["tipoDoc"].ToString();
                    eAfiliado.documento = reader["docIden"].ToString();
                    eAfiliado.apellido1 = reader["nombreComp"].ToString();
                    lista.Add(eAfiliado);
                    
                }
                reader.Close();

            }
            catch (DbException ex)
            {

                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (lista);
        }


        public String ExisteNIT(String NIT = "")
        {
            //String retorno = "";
            String nit = "";

            oDataAccess.open();
            oDataAccess.addInParameters("@NIT", DbType.String, paramValue: NIT);

            try
            {                
                oDataAccess.executeNonQuery(CommandType.StoredProcedure, "SPS_ExisteNIT", true);
                nit = oDataAccess.commando.Parameters["@RETURN_VALUE"].Value.ToString();
            }
            catch (DbException ex)
            {
                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.commando.Parameters.Clear();
                oDataAccess.close();
            }
            return (nit);
        }

        public Int32 AddRips(RipsEntidad oRips)
        {
            Int32 retorno = 0;

            oDataAccess.open();
            oDataAccess.addInParameters("@NIT", DbType.String, paramValue: oRips.NIT);
            oDataAccess.addInParameters("@Factura", DbType.String, paramValue: oRips.Factura);
            oDataAccess.addInParameters("@nFactura", DbType.String, paramValue: oRips.nFactura);
            oDataAccess.addInParameters("@prefijoFact", DbType.String, paramValue: oRips.prefijoFact);            

            try
            {                
                retorno = oDataAccess.executeNonQuery(CommandType.StoredProcedure, "SPI_Rips", true);
                retorno = (Int32)(oDataAccess.commando.Parameters["@RETURN_VALUE"].Value);
            }
            catch (DbException ex)
            {
                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.commando.Parameters.Clear();
                oDataAccess.close();
            }
            return retorno;
        }




        public Int32 deleteTemporalesRips(Int32 tipo)
        {
            Int32 retorno = 0;
            String sQuery = string.Format("EXEC SPD_TemporalesRIPS @tipo={0}", tipo);

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, sQuery);

            }
            catch (DbException ex)
            {

                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (retorno);
        }

        public Int32 updateIdRips(String nit, String factura, Int32 idRips)
        {
            Int32 retorno = 0;
            String sQuery = "UPDATE TEMPAF SET idRips ='" + idRips + "' WHERE docIden='" + nit + "' AND factura='" + factura + "'";

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, sQuery);

            }
            catch (DbException ex)
            {

                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (retorno);
        }



        public Int32 subirRips(String tipoArchivo, String ruta, Int32 IVA = 0)
        {
            Int32 retorno = 0;
            String sQuery = string.Format("EXEC SPI_DatosRIPS @prefArchivo='{0}', @rutaArchivo='{1}'", tipoArchivo, ruta);

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, sQuery);

            }
            catch (DbException ex)
            {

                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (retorno);
        }


        public Int32 crearCarpetaRips(Int32 idUser)
        {            
            Int32 retorno = 0;
            oDataAccess.open();
            oDataAccess.addInParameters("@idUser", DbType.Int32, paramValue: idUser);            

            try
            {                
                retorno = oDataAccess.executeNonQuery(CommandType.StoredProcedure, "SPI_InsertCarpetaRIPS", true);
                retorno = (Int32)(oDataAccess.commando.Parameters["@RETURN_VALUE"].Value);
                oDataAccess.commando.Parameters.Clear();
            }
            catch (DbException ex)
            {
                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (retorno);
        }

        public Int32 agregarColumna(Int32 tipo)
        {            
            Int32 retorno = 0;

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, "EXEC SP_AddColumn @proc=" + tipo);                
            }
            catch (DbException ex)
            {
                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (retorno);
        }

        

        public Int32 UpdateAddAfiliadosRips()
        {            
            Int32 retorno = 0;

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, "EXEC SPUI_AfiliadoRIPS");                
            }
            catch (DbException ex)
            {
                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (retorno);
        }


        public Int32 AddRipsxServidor()
        {            
            Int32 retorno = 0;

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, "EXEC SPI_RIPSBD");                
            }
            catch (DbException ex)
            {
                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (retorno);
        }

        public Int32 AddRipsxArchivo(String ruta)
        {
            Int32 retorno = 0;

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, "EXEC SPI_DatosCSV '" + ruta + "'");
            }
            catch (DbException ex)
            {
                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (retorno);
        }

        public Int32 UpdateIdRipsEnTempAF()
        {            
            Int32 retorno = 0;

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, "EXEC SP_IdRipsEnTempAF");                
            }
            catch (DbException ex)
            {
                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (retorno);
        }

        public Int32 DeleteTemporalesRips(Int32 tipo)
        {            
            Int32 retorno = 0;
            String squery = String.Format("EXEC SPD_TemporalesRIPS @tipo={0}", tipo);

            try
            {
                oDataAccess.open();
                retorno = oDataAccess.executeNonQuery(CommandType.Text, squery.ToString());
            }
            catch (DbException ex)
            {
                throw new Exception("Se ha generado el siguiente error : " + ex.Message);
            }
            finally
            {
                oDataAccess.close();
            }
            return (retorno);
        }

        
        
    }
}
