using System;
using System.Data;
using System.Text;
using DataAccess;
using Entities;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DataManagement
{
	public class DM_entidad
	{
		#region "Objetos Globales"
		SQLConn oDataAccess = new SQLConn();
		Entidad Lista = new Entidad();
		EntidadEntidad DatosEmpresa = new EntidadEntidad();		
		#endregion 
		

		// selecciona todos los atributos de Entidad
		public Entidad Getentidad(String nit = "", String nombreEntidad = "", int limitInf = 0, int limitSup = 0)
		{			
			String sQuery = String.Format("EXEC SPS_Entidades @nit='{0}', @nombEntidad='{1}', @limitInf={2}, @limitSup={3}", nit, nombreEntidad, limitInf, limitSup); ;
			Entidad lista = new Entidad();

			IDataReader reader;

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sQuery.ToString());
				while (reader.Read())
				{
					EntidadEntidad eEntidad = new EntidadEntidad();
					eEntidad.capitado = Boolean.Parse(reader["capitado"].ToString());
					eEntidad.codDane = reader["codDane"].ToString();
					eEntidad.codTipoContrato = Int32.Parse(reader["codTipoContrato"].ToString());
					eEntidad.codTipoPrestador = Int32.Parse(reader["codTipoPrestador"].ToString());
					eEntidad.correoElectronico = reader["correoElectronico"].ToString();
					eEntidad.digitoVerif = short.Parse(reader["digitoVerif"].ToString());
					eEntidad.direccion = reader["direccion"].ToString();
					eEntidad.entidad = reader["Entidad"].ToString();
					eEntidad.nit = reader["nit"].ToString();
					eEntidad.represLegal = reader["represLegal"].ToString();
					eEntidad.revision = Boolean.Parse(reader["revision"].ToString());
					eEntidad.telefono = reader["telefono"].ToString();
					eEntidad.idTipoDoc = Int32.Parse(reader["tipoDoc"].ToString());
					eEntidad.zona = reader["zona"].ToString();
					eEntidad.municipio = reader["municipio"].ToString();
					eEntidad.depto = reader["departamento"].ToString();
					eEntidad.nombreReg = reader["nombreReg"].ToString();
					lista.Add(eEntidad);
				}
				reader.Close();
			}
			catch (Exception ex)
			{
				throw new Exception("Se ha generado el siguiente error : " + ex.Message);
			}
			finally
			{
				oDataAccess.close();
			}

			return (lista);
		}


		/*Seleccionar los datos de la entidad*/
		public Entidad ObtenerDatosEntidad(int Lote)
		{

			oDataAccess.open();
			
			IDataReader reader;


			String SP_DatosEntidadXLote = String.Format("Exec dbo.SPS_Encabezado @lote='" + Lote + "'");


			try
			{


				reader = oDataAccess.executeReader(CommandType.Text, SP_DatosEntidadXLote.ToString());
				while ((reader.Read() == true))
				{
					DatosEmpresa = new EntidadEntidad();
					DatosEmpresa.nit = (reader["NIT"].ToString());
					DatosEmpresa.entidad = reader["Entidad"].ToString();
					DatosEmpresa.Email = reader["correoElectronico"].ToString(); ;
					DatosEmpresa.Analista = reader["Analista"].ToString(); ; ;
					Lista.Add(DatosEmpresa);
				}
				reader.Close();
				DatosEmpresa  = new EntidadEntidad();
			}
			catch (Exception ex)
			{
				throw new Exception("Houston estamos presentando los siguientes problemas : " + ex.Message);

			}
			finally
			{
				oDataAccess.close();

			}

			return (Lista);


		}



		public Int32 getCantEntidades(String nombreEntidad)
		{
			Int32 cantEntidades = 0;
			StringBuilder sbEntidad = new StringBuilder();
			IDataReader reader;

			sbEntidad.Append("SELECT COUNT(nit) as cantEntidades FROM entidad");

			if (nombreEntidad != "")
			{
				sbEntidad.Append(" WHERE ((entidad LIKE '%" + nombreEntidad + "%'))");
			}
			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbEntidad.ToString());

				while (reader.Read())
				{
					cantEntidades = Int32.Parse(reader["cantEntidades"].ToString());
				}
				reader.Close();
				return cantEntidades;
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				oDataAccess.close();
			}
		}


		public Entidad GetEntidadYUbicacion(String nit = "")
		{
			StringBuilder sbNitNombre = new StringBuilder();
			IDataReader reader;
			Entidad lista = new Entidad();
			EntidadEntidad oNitNombre = new EntidadEntidad();

			sbNitNombre.Append("SELECT A.entidad, A.nit, B.municipio, B.departamento, A.digitoVerif, C.tipoDoc");
			sbNitNombre.Append(" FROM         entidad AS A INNER JOIN");
			sbNitNombre.Append(" dane AS B ON A.codDane = B.codDane INNER JOIN");
			sbNitNombre.Append(" tiposDoc AS C ON A.tipoDoc = C.idTipoDoc");

			if (nit != "")
			{
				sbNitNombre.Append(" WHERE nit ='" + nit + "'");
			}

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbNitNombre.ToString());

				while (reader.Read())
				{
					oNitNombre = new EntidadEntidad();
					oNitNombre.nit = reader["nit"].ToString();
					oNitNombre.entidad = reader["entidad"].ToString();
					oNitNombre.digitoVerif = Int32.Parse(reader["digitoVerif"].ToString());
					oNitNombre.municipio = reader["municipio"].ToString();
					oNitNombre.depto = reader["departamento"].ToString();
					oNitNombre.TipoDoc = reader["tipoDoc"].ToString();
					lista.Add(oNitNombre);
				}
				reader.Close();

				return lista;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				oDataAccess.close();
			}
		}

		public Entidad GetNitNombre(String nitNombre, Boolean entidadCapitada = false)
		{
			StringBuilder sbNitNombre = new StringBuilder();
			IDataReader reader;
			Entidad lista = new Entidad();
			EntidadEntidad oNitNombre = new EntidadEntidad();

			sbNitNombre.Append("SELECT");
			sbNitNombre.Append(" nit + N' / ' + entidad AS nitNombre");
			sbNitNombre.Append(", nit");
			sbNitNombre.Append(" FROM entidad");
			sbNitNombre.Append(" WHERE nit + N' / ' + entidad LIKE '%" + nitNombre + "%'");

			if (entidadCapitada == true)
			{
				sbNitNombre.Append(" AND capitado='" + entidadCapitada + "'");
			}



			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbNitNombre.ToString());

				while (reader.Read())
				{
					oNitNombre = new EntidadEntidad();
					oNitNombre.nit = reader["nit"].ToString();
					oNitNombre.entidad = reader["nitNombre"].ToString();
					lista.Add(oNitNombre);
				}
				reader.Close();

				return lista;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				oDataAccess.close();
			}
		}





		public String GetNombrexNit(String nitEntidad)
		{
			StringBuilder sbNitNombre = new StringBuilder();
			IDataReader reader;
			String nombEntidad = "";

			sbNitNombre.Append("SELECT");
			sbNitNombre.Append(" entidad");
			sbNitNombre.Append(" FROM entidad");
			sbNitNombre.Append(" WHERE nit='" + nitEntidad + "'");

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbNitNombre.ToString());

				while (reader.Read())
				{
					nombEntidad = reader["entidad"].ToString();
				}
				reader.Close();

				return nombEntidad;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				oDataAccess.close();
			}
		}

		public Entidad getNits(string nit = "")
		{
			StringBuilder sbEntidad = new StringBuilder();
			IDataReader reader;
			Entidad lista = new Entidad();
			//  AccionL lista = new AccionL();
			EntidadEntidad oEntidad = new EntidadEntidad();

			sbEntidad.Append("SELECT");
			sbEntidad.Append(" nit");
			sbEntidad.Append(" FROM entidad");

			if (nit != "")
			{
				sbEntidad.Append(" WHERE nit='" + nit + "'");
			}

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbEntidad.ToString());

				while (reader.Read())
				{
					oEntidad = new EntidadEntidad();
					oEntidad.nit = reader["nit"].ToString();
					lista.Add(oEntidad);

				}
				reader.Close();

				return lista;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				oDataAccess.close();
			}
		}

		public Entidad getDeptos()
		{
			StringBuilder sbDeptos = new StringBuilder();
			IDataReader reader;
			Entidad lista = new Entidad();
			EntidadEntidad oDeptos = new EntidadEntidad();

			sbDeptos.Append("SELECT");
			sbDeptos.Append(" departamento");
			sbDeptos.Append(", codDepto");
			sbDeptos.Append(" FROM dane");
			sbDeptos.Append(" GROUP BY departamento, codDepto");

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbDeptos.ToString());

				while (reader.Read())
				{
					oDeptos = new EntidadEntidad();
					oDeptos.depto = reader["departamento"].ToString();
					oDeptos.codDepto = reader["codDepto"].ToString();
					lista.Add(oDeptos);
				}
				reader.Close();

				return lista;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				oDataAccess.close();
			}
		}

		public Entidad getMpios(string codDepto = "")
		{
			StringBuilder sbMpios = new StringBuilder();
			IDataReader reader;
			Entidad lista = new Entidad();
			EntidadEntidad oMpios = new EntidadEntidad();

			sbMpios.Append("SELECT");
			sbMpios.Append(" municipio");
			sbMpios.Append(", codMunicipio");
			sbMpios.Append(" FROM dane");

			if (codDepto != "")
			{
				sbMpios.Append(" WHERE codDepto='" + codDepto + "'");
			}

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbMpios.ToString());

				while (reader.Read())
				{
					oMpios = new EntidadEntidad();
					oMpios.municipio = reader["municipio"].ToString();
					oMpios.codMpio = reader["codMunicipio"].ToString();
					lista.Add(oMpios);
				}
				reader.Close();

				return lista;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				oDataAccess.close();
			}
		}

		public Entidad getTipoDoc()
		{
			StringBuilder sbTipoDoc = new StringBuilder();
			IDataReader reader;
			Entidad lista = new Entidad();
			EntidadEntidad oTipoDoc = new EntidadEntidad();

			sbTipoDoc.Append("SELECT");
			sbTipoDoc.Append(" idTipoDoc");
			sbTipoDoc.Append(", tipoDoc");
			sbTipoDoc.Append(" FROM tiposDoc");

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbTipoDoc.ToString());

				while (reader.Read())
				{
					oTipoDoc = new EntidadEntidad();
					oTipoDoc.idTipoDoc = Int32.Parse(reader["idTipoDoc"].ToString());
					oTipoDoc.TipoDoc = reader["tipoDoc"].ToString();
					lista.Add(oTipoDoc);

				}
				reader.Close();

				return lista;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				oDataAccess.close();
			}
		}

		public Entidad getZona()
		{
			StringBuilder sbZona = new StringBuilder();
			IDataReader reader;
			Entidad lista = new Entidad();
			EntidadEntidad oZona = new EntidadEntidad();

			sbZona.Append("SELECT");
			sbZona.Append(" idZona");
			sbZona.Append(", zona");
			sbZona.Append(" FROM zona");

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbZona.ToString());

				while (reader.Read())
				{
					oZona = new EntidadEntidad();
					oZona.idZona = Int32.Parse(reader["idZona"].ToString());
					oZona.zona = reader["zona"].ToString();
					lista.Add(oZona);

				}
				reader.Close();

				return lista;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				oDataAccess.close();
			}
		}

		// adiciona una nueva Entidad
		public Int32 Addentidad(EntidadEntidad oentidad)
		{
			Int32 retorno = 0;
			String sQuery = (string.Format("SPI_Entidad '{0}', {1}, {2}, {3}, {4}, '{5}', '{6}', '{7}', '{8}', {9}, '{10}', '{11}', '{12}', {13}, {14}"
			, oentidad.nit
			, oentidad.idTipoDoc
			, oentidad.digitoVerif
			, oentidad.capitado
			, oentidad.revision
			, oentidad.entidad
			, oentidad.codDane
			, oentidad.direccion
			, oentidad.telefono
			, oentidad.idZona
			, oentidad.nombreReg
			, oentidad.correoElectronico
			, oentidad.represLegal
			, oentidad.codTipoPrestador
			, oentidad.codTipoContrato));

			try
			{
				oDataAccess.open();
				retorno = oDataAccess.executeNonQuery(CommandType.Text, sQuery.ToString());

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
		// Actualiza un registro de la tabla accion

		public Int32 Updateentidad(EntidadEntidad oentidad)
		{
			Int32 retorno = 0;
			StringBuilder sbentidad = new StringBuilder();
			{
				sbentidad.Append("UPDATE entidad SET");
				sbentidad.Append(" capitado='" + oentidad.capitado + "'");
				sbentidad.Append(", codDane='" + oentidad.codDane + "'");
				sbentidad.Append(", codTipoContrato= '" + oentidad.codTipoContrato + "'");
				sbentidad.Append(", codTipoPrestador= '" + oentidad.codTipoPrestador + "'");
				sbentidad.Append(", correoElectronico= '" + oentidad.correoElectronico + "'");
				sbentidad.Append(", digitoVerif= '" + oentidad.digitoVerif + "'");
				sbentidad.Append(", direccion= '" + oentidad.direccion + "'");
				sbentidad.Append(", Entidad= '" + oentidad.entidad + "'");
				sbentidad.Append(", nombreReg= '" + oentidad.nombreReg + "'");
				sbentidad.Append(", represLegal= '" + oentidad.represLegal + "'");
				sbentidad.Append(", revision= '" + oentidad.revision + "'");
				sbentidad.Append(", telefono= '" + oentidad.telefono + "'");
				sbentidad.Append(", tipoDoc= '" + oentidad.TipoDoc + "'");
				sbentidad.Append(", zona= '" + oentidad.idZona + "'");
				sbentidad.Append(" WHERE nit='" + oentidad.nit + "'");

				try
				{
					oDataAccess.open();
					retorno = oDataAccess.executeNonQuery(CommandType.Text, sbentidad.ToString());

					return retorno;
				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					oDataAccess.close();
				}
			}
		}
	}
}
