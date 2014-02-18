using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Entities;
using DataAccess;

namespace DataManagement
{
	#region "Comentario de modificaciones"
	/*<autor>ZD</autor>
		    <fecha>09/09/2013 2113Z</fecha>
		    <justificacion>
	 					Se agrega ordenamiento para el selec del encabezado de la auditoria
				</justificacion>
		      <antes>
	 *					Linea 657:
	 *						sbdatosUSxFact.Append(" ORDER BY a.idDatosUs);
				 </antes>
		     <ahora>
		      sbdatosUSxFact.Append(" ORDER BY a.idDatosUs, ,B.apellido_a, B.nombre_a");
		     </ahora>*/
	#endregion
	public class DM_datosUSxFact
	{
		SQLConn oDataAccess = new SQLConn();
		// selecciona todos los atributos de accion
		public DatosUSxFact GetdatosUSxFact(Int32 idDatosUS = 0, String radicado = "", Boolean auditoria = false)
		{
			StringBuilder sbdatosUSxFact = new StringBuilder();
			IDataReader reader;
			DatosUSxFact lista = new DatosUSxFact();
			//  AccionL lista = new AccionL();
			DatosUSxFactEntidad odatosUSxFact = new DatosUSxFactEntidad();

			sbdatosUSxFact.Append("SELECT");
			sbdatosUSxFact.Append(" A.codDx1");
			sbdatosUSxFact.Append(", A.codDx2");
			sbdatosUSxFact.Append(", A.codDx3");
			sbdatosUSxFact.Append(", B.apellido_a");
			sbdatosUSxFact.Append(", B.apellido_b");
			sbdatosUSxFact.Append(", B.nombre_a");
			sbdatosUSxFact.Append(", B.nombre_b");
			sbdatosUSxFact.Append(", A.docIden");
			sbdatosUSxFact.Append(", A.estadoEg");
			sbdatosUSxFact.Append(", A.fechaEgr");
			sbdatosUSxFact.Append(", A.fechaIng");
			sbdatosUSxFact.Append(", A.idDatosUS");
			sbdatosUSxFact.Append(", A.idRIPS");
			sbdatosUSxFact.Append(", C.idUser");
			sbdatosUSxFact.Append(", A.origen");
			sbdatosUSxFact.Append(", ISNULL(A.programa,0) programa");
			sbdatosUSxFact.Append(", A.tipoAtencion");
			sbdatosUSxFact.Append(", C.radicado");
			sbdatosUSxFact.Append(", B.sexo");
			sbdatosUSxFact.Append(", ISNULL(B.tipoDoc,1) as tipoDoc");
			sbdatosUSxFact.Append(", A.vrAbono");
			sbdatosUSxFact.Append(", A.vrCopagosDet");
			sbdatosUSxFact.Append(", A.vrCuotaMod");
			sbdatosUSxFact.Append(", A.vrIva");
			sbdatosUSxFact.Append(", A.vrNotaCred");
			sbdatosUSxFact.Append(", A.vrNotaDeb");
			sbdatosUSxFact.Append(", A.vrTotBrutoDet");
			sbdatosUSxFact.Append(", A.vrTotDescDet");
			sbdatosUSxFact.Append(", A.vrTotNetoDet");
			sbdatosUSxFact.Append(", D.dx AS DescDx1");
			sbdatosUSxFact.Append(", E.dx AS DescDx2");
			sbdatosUSxFact.Append(", F.dx AS DescDx3");

			if (auditoria == true)
			{
				sbdatosUSxFact.Append(", A.idGuia");
				sbdatosUSxFact.Append(", B.fecNac");
				sbdatosUSxFact.Append(", B.fecAfil");
				sbdatosUSxFact.Append(", ISNULL(C.vrRecobro,0) as vrRecobro");
				sbdatosUSxFact.Append(", C.vrGlosa");
				sbdatosUSxFact.Append(", C.vrPagar");
				sbdatosUSxFact.Append(", ISNULL(C.vrAsumir,0) as vrAsumir");
				sbdatosUSxFact.Append(", A.listado");
				sbdatosUSxFact.Append(", A.codDane");
				sbdatosUSxFact.Append(", (SELECT sa.sitioAtencion FROM sitioAtencion AS sa WHERE sa.idSitioAtencion = A.idSitioAtencion) AS sitioAtencion");
				sbdatosUSxFact.Append(", A.idSitioAtencion");
				sbdatosUSxFact.Append(", ISNULL(A.idCabecera,0) idCabecera");
				sbdatosUSxFact.Append(", A.codDane");
				sbdatosUSxFact.Append(", (SELECT municipio + '-' + departamento from dane as d where(d.codDane=A.codDane)) as munDepto");
				sbdatosUSxFact.Append(", C.observAnalista");
				sbdatosUSxFact.Append(", (SELECT pr.programa FROM programas AS pr WHERE pr.idPrograma = A.programa) AS nPrograma");
				sbdatosUSxFact.Append(", A.patologia");
				sbdatosUSxFact.Append(", A.nivel");
				/*Autor: ZuluDelta*
				 Para traer el código de la cabecera*/
				//sbdatosUSxFact.Append(", ISNULL((Select IdCabecera");
				//sbdatosUSxFact.Append("		From SIISAConc.SIISAConc_Cabeceras");
				//sbdatosUSxFact.Append(" Where Cabecera LIKE ''+ A.cabecera + '%'), 0) AS IdCabecera");

				/*Autor: CarlosCarrero*
				 * Ya no es necesario buscar el codigo de la cabecera porque vamos a guardar en la tabla solo el id
				 * y el control dropdown representa el texto del id*/


			}
			/*Autor: ZuluDelta*
				 Para traer el código de la cabecera*/
			sbdatosUSxFact.Append(" FROM dx AS E RIGHT OUTER JOIN");
			sbdatosUSxFact.Append(" dx AS F RIGHT OUTER JOIN");
			sbdatosUSxFact.Append(" datosUSxFact AS A INNER JOIN");
			sbdatosUSxFact.Append(" afiliados AS B ON A.docIden = B.docIden INNER JOIN");
			sbdatosUSxFact.Append(" datosUSxProceso AS C ON A.idDatosUS = C.idDatosUS");
			sbdatosUSxFact.Append(" ON F.codDx = A.codDx3 ON E.codDx = A.codDx2");
			sbdatosUSxFact.Append(" LEFT OUTER JOIN");
			sbdatosUSxFact.Append(" dx AS D ON A.codDx1 = D.codDx");




			if (idDatosUS != 0)
			{
				sbdatosUSxFact.Append(" WHERE A.idDatosUS='" + idDatosUS + "'");
			}

			if (radicado != "")
			{
				sbdatosUSxFact.Append(" WHERE radicado = '" + radicado + "'");
			}


			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbdatosUSxFact.ToString());

				while (reader.Read())
				{
					DateTime dd = new DateTime();
					odatosUSxFact = new DatosUSxFactEntidad();
					odatosUSxFact.codDx1 = reader["codDx1"].ToString();
					odatosUSxFact.codDx2 = reader["codDx2"].ToString();
					odatosUSxFact.codDx3 = reader["codDx3"].ToString();
					odatosUSxFact.DescDx1 = reader["DescDx1"].ToString();
					odatosUSxFact.DescDx2 = reader["DescDx2"].ToString();
					odatosUSxFact.DescDx3 = reader["DescDx3"].ToString();
					odatosUSxFact.apellido_a = reader["apellido_a"].ToString();
					odatosUSxFact.apellido_b = reader["apellido_b"].ToString();
					odatosUSxFact.nombre_a = reader["nombre_a"].ToString();
					odatosUSxFact.nombre_b = reader["nombre_b"].ToString();
					odatosUSxFact.docIden = reader["docIden"].ToString();
					odatosUSxFact.estadoEg = Int32.Parse(reader["estadoEg"].ToString());
					dd = DateTime.Parse(reader["fechaIng"].ToString());
					odatosUSxFact.fechaIng = Convert.ToString(dd.ToShortDateString());
					dd = DateTime.Parse(reader["fechaEgr"].ToString());
					odatosUSxFact.fechaEgr = Convert.ToString(dd.ToShortDateString());
					odatosUSxFact.idDatosUS = Convert.ToInt32(Convert.ToDecimal(reader["idDatosUS"].ToString()));
					odatosUSxFact.idRIPS = Int32.Parse(reader["idRIPS"].ToString() == "" ? "0" : reader["idRIPS"].ToString());
					odatosUSxFact.idUser = Int32.Parse(reader["idUser"].ToString());
					odatosUSxFact.origen = Int32.Parse(reader["origen"].ToString());
					odatosUSxFact.programa = Int32.Parse(reader["programa"].ToString());
					odatosUSxFact.radicado = reader["radicado"].ToString();
					odatosUSxFact.sexo = reader["sexo"].ToString();
					odatosUSxFact.tipoAtencion = reader["tipoAtencion"].ToString();
					odatosUSxFact.idTipoDoc = Int32.Parse(reader["tipoDoc"].ToString());
					odatosUSxFact.vrAbono = Int32.Parse(reader["vrAbono"].ToString());
					odatosUSxFact.vrCopagosDet = Int32.Parse(reader["vrCopagosDet"].ToString());
					odatosUSxFact.vrCuotaMod = Int32.Parse(reader["vrCuotaMod"].ToString());
					odatosUSxFact.vrIva = Int32.Parse(reader["vrIva"].ToString());
					odatosUSxFact.vrNotaCred = Int32.Parse(reader["vrNotaCred"].ToString());
					odatosUSxFact.vrNotaDeb = Int32.Parse(reader["vrNotaDeb"].ToString());
					odatosUSxFact.vrTotBrutoDet = Int32.Parse(reader["vrTotBrutoDet"].ToString());
					odatosUSxFact.vrTotDescDet = Int32.Parse(reader["vrTotDescDet"].ToString());
					odatosUSxFact.vrTotNetoDet = Int32.Parse(reader["vrTotNetoDet"].ToString());

					if (auditoria == true)
					{
						odatosUSxFact.idGuia = Int32.Parse(reader["idGuia"].ToString());
						dd = (reader["fecNac"].ToString() != "" && reader["fecNac"].ToString() != "NULL") ? DateTime.Parse(reader["fecNac"].ToString()) : DateTime.Parse("01/01/1900");
						odatosUSxFact.fecNac = dd.ToShortDateString();
						dd = (reader["fecAfil"].ToString() != "" && reader["fecAfil"].ToString() != "NULL") ? DateTime.Parse(reader["fecAfil"].ToString()) : DateTime.Parse("01/01/1900");
						odatosUSxFact.fecAfil = dd.ToShortDateString();
						odatosUSxFact.vrRecobro = Decimal.Parse(reader["vrRecobro"].ToString());
						odatosUSxFact.vrGlosa = Decimal.Parse(reader["vrGlosa"].ToString());
						odatosUSxFact.vrPagar = Decimal.Parse(reader["vrPagar"].ToString());
						odatosUSxFact.vrAsumir = Decimal.Parse(reader["vrAsumir"].ToString());
						odatosUSxFact.listado = Int32.Parse(reader["listado"].ToString());
						odatosUSxFact.codDane = reader["codDane"].ToString();
						odatosUSxFact.sitioAtenc = reader["sitioAtencion"].ToString();
						odatosUSxFact.idSitioAtenc = Int32.Parse(reader["idSitioAtencion"].ToString());
						odatosUSxFact.IdCabecera = Int32.Parse(reader["idCabecera"].ToString());

						odatosUSxFact.observAnalista = reader["observAnalista"].ToString();
						odatosUSxFact.nPrograma = reader["nPrograma"].ToString();
						odatosUSxFact.departamento = reader["munDepto"].ToString();
						odatosUSxFact.municipio = reader["codDane"].ToString();
						odatosUSxFact.patologia = Int32.Parse(reader["patologia"].ToString() == "" ? "0" : reader["patologia"].ToString());
						odatosUSxFact.nivel = Int32.Parse(reader["nivel"].ToString() == "" ? "0" : reader["nivel"].ToString());
					}
					lista.Add(odatosUSxFact);
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

		public Int32 getTipoCuentaRadicado(String radicado)
		{
			IDataReader reader;
			Int32 tipoCuentaRadicado = 0;

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, "SELECT tc.tipoCuenta FROM radicacion as rad INNER JOIN tipoComprob as tc ON tc.id=rad.tipoComprobante WHERE radicado='" + radicado + "'");

				while (reader.Read())
				{
					tipoCuentaRadicado = Int32.Parse(reader["tipoCuenta"].ToString());

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
			return (tipoCuentaRadicado);
		}


		public DatosUSxFact getDatosUSxFactValores(Int32 idDatosUS = 0, String radicado = "")
		{
			StringBuilder sbdatosUSxFact = new StringBuilder();
			IDataReader reader;
			DatosUSxFact lista = new DatosUSxFact();
			//  AccionL lista = new AccionL();
			DatosUSxFactEntidad odatosUSxFact = new DatosUSxFactEntidad();

			sbdatosUSxFact.Append("SELECT");
			sbdatosUSxFact.Append(" A.vrAbono");
			sbdatosUSxFact.Append(", A.vrCopagosDet");
			sbdatosUSxFact.Append(", A.vrCuotaMod");
			sbdatosUSxFact.Append(", A.vrIva");
			sbdatosUSxFact.Append(", A.vrNotaCred");
			sbdatosUSxFact.Append(", A.vrNotaDeb");
			sbdatosUSxFact.Append(", A.vrTotBrutoDet");
			sbdatosUSxFact.Append(", A.vrTotDescDet");
			sbdatosUSxFact.Append(", A.vrTotNetoDet");
			sbdatosUSxFact.Append(", A.idDatosUS");
			sbdatosUSxFact.Append(", B.vrRecobro");
			sbdatosUSxFact.Append(" FROM datosUSxFact AS A");
			sbdatosUSxFact.Append(" INNER JOIN datosUSxProceso AS B ON A.idDatosUS = B.idDatosUS");

			if (idDatosUS != 0)
			{
				sbdatosUSxFact.Append(" WHERE A.idDatosUS='" + idDatosUS + "'");
			}

			if (radicado != "")
			{
				sbdatosUSxFact.Append(" WHERE radicado = '" + radicado + "'");
			}

			sbdatosUSxFact.Append(" AND b.eliminar=0");
			
			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbdatosUSxFact.ToString());

				while (reader.Read())
				{
					odatosUSxFact = new DatosUSxFactEntidad();
					odatosUSxFact.vrAbono = Int32.Parse(reader["vrAbono"].ToString());
					odatosUSxFact.vrCopagosDet = Int32.Parse(reader["vrCopagosDet"].ToString());
					odatosUSxFact.vrCuotaMod = Int32.Parse(reader["vrCuotaMod"].ToString());
					odatosUSxFact.vrIva = Int32.Parse(reader["vrIva"].ToString());
					odatosUSxFact.vrNotaCred = Int32.Parse(reader["vrNotaCred"].ToString());
					odatosUSxFact.vrNotaDeb = Int32.Parse(reader["VrNotaDeb"].ToString());
					odatosUSxFact.vrRecobro = Decimal.Parse(reader["vrRecobro"].ToString());
					odatosUSxFact.vrTotBrutoDet = Int32.Parse(reader["vrTotBrutoDet"].ToString());
					odatosUSxFact.vrTotDescDet = Int32.Parse(reader["vrTotDescDet"].ToString());
					odatosUSxFact.vrTotNetoDet = Int32.Parse(reader["vrTotNetoDet"].ToString());
					odatosUSxFact.idDatosUS = Int32.Parse(reader["idDatosUS"].ToString());
					lista.Add(odatosUSxFact);
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

		public Int32 contarEncabezados(String radicado)
		{
			Int32 cantEnc = 0;

			try
			{
				oDataAccess.open();
				oDataAccess.addInParameters("@radicado", DbType.String, paramValue: radicado);
				cantEnc = oDataAccess.executeNonQuery(CommandType.StoredProcedure, "SPS_ContarEncabezados", true);
				cantEnc = (Int32)(oDataAccess.commando.Parameters["@RETURN_VALUE"].Value);
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
			return (cantEnc);
		}



		public DatosUSxFact GetDatosUsxFactLista(String radicado = "", Int32 IdDatosUS = 0, Int32 limitInf = 0, Int32 limitSup = 0)
		{
			IDataReader reader;
			DatosUSxFact lista = new DatosUSxFact();			
			DatosUSxFactEntidad oDatosUsxFact = new DatosUSxFactEntidad();
			String sQuery = string.Format("EXEC SPS_DatosUSxFact @radicado='{0}', @IdDatosUS={1}, @LIMITINF={2}, @LIMITSUP={3}", radicado, IdDatosUS, limitInf, limitSup);

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sQuery);
				while (reader.Read())
				{
					DateTime dd = new DateTime();
					oDatosUsxFact = new DatosUSxFactEntidad();
					oDatosUsxFact.codDx1 = reader["codDx1"].ToString();
					oDatosUsxFact.apellido_a = reader["apellido_a"].ToString() + " " + reader["apellido_b"].ToString() + " " + reader["nombre_a"].ToString() + " " + reader["nombre_b"].ToString();
					oDatosUsxFact.docIden = reader["docIden"].ToString();
					dd = DateTime.Parse(reader["fechaIng"].ToString());
					oDatosUsxFact.fechaIng = Convert.ToString(dd.ToShortDateString());
					oDatosUsxFact.idDatosUS = Int32.Parse(reader["idDatosUS"].ToString());
					oDatosUsxFact.radicado = reader["radicado"].ToString();
					oDatosUsxFact.programa = Int32.Parse(reader["programa"].ToString());
					oDatosUsxFact.cantServs = Double.Parse(reader["cantServs"].ToString());
					oDatosUsxFact.vrTotBrutoDet = Int32.Parse(reader["vrTotBrutoDet"].ToString());
					oDatosUsxFact.totServs = Double.Parse(reader["totServs"].ToString());
					lista.Add(oDatosUsxFact);
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

		public DatosUSxFact getDatosUSxFactListaCtas1Vez(String radicado, Int32 Origen , String nit = "", Int32 auditoria = 0)
		{
			StringBuilder sbdatosUSxFact = new StringBuilder();
			IDataReader reader;
			DatosUSxFact lista = new DatosUSxFact();
			//  AccionL lista = new AccionL();
			DatosUSxFactEntidad odatosUSxFact = new DatosUSxFactEntidad();

			sbdatosUSxFact.Append("SELECT");
			sbdatosUSxFact.Append(" A.codDx1");
			sbdatosUSxFact.Append(", B.apellido_a");
			sbdatosUSxFact.Append(", B.apellido_b");
			sbdatosUSxFact.Append(", B.nombre_a");
			sbdatosUSxFact.Append(", B.nombre_b");
			sbdatosUSxFact.Append(", A.docIden");
			sbdatosUSxFact.Append(", A.fechaIng");
			sbdatosUSxFact.Append(", A.idDatosUS");
			sbdatosUSxFact.Append(", C.radicado");
			if (auditoria == 0)
			{
				sbdatosUSxFact.Append(", (SELECT COUNT(serviciosFactura.IdReg) FROM serviciosFactura WHERE serviciosFactura.idDatosUS = A.idDatosUS AND serviciosFactura.eliminar=0) as cantServs");
				sbdatosUSxFact.Append(", (SELECT ISNULL(SUM(serviciosFactura.vrTotal),0) FROM serviciosFactura WHERE serviciosFactura.idDatosUS = A.idDatosUS AND serviciosFactura.eliminar=0) as totServs");
			}

			sbdatosUSxFact.Append(", A.vrTotBrutoDet");
			sbdatosUSxFact.Append(", ISNULL(A.programa,0) programa ");
			sbdatosUSxFact.Append(", (SELECT programas.programa FROM programas WHERE programas.idPrograma = A.programa) as nPrograma");
			sbdatosUSxFact.Append(", A.vrTotNetoDet");
			sbdatosUSxFact.Append(", ISNULL(C.vrRecobro,0) AS vrRecobro");
			sbdatosUSxFact.Append(", C.vrGlosa");
			sbdatosUSxFact.Append(", C.vrPagar");
			sbdatosUSxFact.Append(", C.vrAsumir");
			sbdatosUSxFact.Append(", C.vrRecobro");

			if (auditoria == 1)
			{
				sbdatosUSxFact.Append(", D.guia");
				//Suma Recobros Generados a ese idDatosUS

			}

			sbdatosUSxFact.Append(" FROM datosUSxFact AS A");
			sbdatosUSxFact.Append(" INNER JOIN afiliados AS B ON A.docIden = B.docIden ");
			sbdatosUSxFact.Append(" INNER JOIN datosUSxProceso AS C ON A.idDatosUS = C.idDatosUS");

			if (auditoria == 1)
			{
				//Relaciona con la tabla de guias
				sbdatosUSxFact.Append(" LEFT OUTER JOIN guia AS D ON A.idGuia = D.idGuia");
			}

			sbdatosUSxFact.Append(" WHERE C.radicado = '" + radicado + "'");
			sbdatosUSxFact.Append(" AND c.eliminar=0");

			switch (Origen)
			{ 
				case 0:
					break;
				case 1:
					sbdatosUSxFact.Append(" ORDER BY B.apellido_a asc ");
					break;
				case 2:
					sbdatosUSxFact.Append(" ORDER BY B.apellido_a desc ");
					break;
				case 3:
					sbdatosUSxFact.Append(" ORDER BY programa");
					break;
			}
			
			
			


			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbdatosUSxFact.ToString());

				while (reader.Read())
				{
					DateTime dd = new DateTime();
					odatosUSxFact = new DatosUSxFactEntidad();
					odatosUSxFact.codDx1 = reader["codDx1"].ToString();
					odatosUSxFact.apellido_a = reader["apellido_a"].ToString() + " " + reader["apellido_b"].ToString() + " " + reader["nombre_a"].ToString() + " " + reader["nombre_b"].ToString();
					odatosUSxFact.docIden = reader["docIden"].ToString();
					dd = DateTime.Parse(reader["fechaIng"].ToString());
					odatosUSxFact.fechaIng = Convert.ToString(dd.ToShortDateString());
					odatosUSxFact.idDatosUS = Convert.ToInt32(Convert.ToDecimal(reader["idDatosUS"].ToString()));
					odatosUSxFact.radicado = reader["radicado"].ToString();
					odatosUSxFact.programa = Int32.Parse(reader["programa"].ToString());
					odatosUSxFact.nPrograma = reader["nPrograma"].ToString();

					if (auditoria == 0)
					{
						odatosUSxFact.cantServs = Double.Parse(reader["cantServs"].ToString());
						odatosUSxFact.vrTotBrutoDet = Int32.Parse(reader["vrTotBrutoDet"].ToString());
						odatosUSxFact.totServs = Double.Parse(reader["totServs"].ToString());
					}
					else if (auditoria == 1)
					{
						odatosUSxFact.vrTotNetoDet = Int32.Parse(reader["vrTotNetoDet"].ToString());
						odatosUSxFact.guia = reader["guia"].ToString();
						odatosUSxFact.vrRecobro = Decimal.Parse(reader["vrRecobro"].ToString());
						odatosUSxFact.vrGlosa = Decimal.Parse(reader["vrGlosa"].ToString());
						odatosUSxFact.vrPagar = Decimal.Parse(reader["vrPagar"].ToString());
						odatosUSxFact.vrAsumir = reader["vrAsumir"].ToString() == "" ? 0 : Decimal.Parse(reader["vrAsumir"].ToString());
					}
					lista.Add(odatosUSxFact);
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


		public DatosUSxFact getDatosUSxFactListaCtas2Vez(String radicado,Int16 Origen, String nit = "", Int32 auditoria = 0)
		{
			StringBuilder sbdatosUSxFact = new StringBuilder();
			IDataReader reader;
			DatosUSxFact lista = new DatosUSxFact();
			DatosUSxFactEntidad odatosUSxFact = new DatosUSxFactEntidad();

			//Auditoria = 0 : Grilla de Encabezados para auditoria
			//Auditoria = 1 : Grilla de Reutilizar digitacion

			sbdatosUSxFact.Append("SELECT");
			sbdatosUSxFact.Append(" C.codDx1");
			sbdatosUSxFact.Append(", D.apellido_a");
			sbdatosUSxFact.Append(", D.apellido_b");
			sbdatosUSxFact.Append(", D.nombre_a");
			sbdatosUSxFact.Append(", D.nombre_b");
			sbdatosUSxFact.Append(", D.docIden");
			sbdatosUSxFact.Append(", C.fechaIng");
			sbdatosUSxFact.Append(", C.idDatosUS");
			sbdatosUSxFact.Append(", A.radicado");
			sbdatosUSxFact.Append(", B.vrTotalGlosa");
			sbdatosUSxFact.Append(", A.vrAsumeIPS");
			sbdatosUSxFact.Append(", A.idglosa");
			sbdatosUSxFact.Append(", A.vrReiteraGlosa");
			sbdatosUSxFact.Append(", A.codGlosaReitera");
			sbdatosUSxFact.Append(", A.vrLevantaGlosa");
			sbdatosUSxFact.Append(", B.idDatosUs");


			if (auditoria == 0)
			{
				sbdatosUSxFact.Append(", F.guia");
			}


			//Trae el numero de factura inicial
			sbdatosUSxFact.Append(", (SELECT radicacion.noFactura FROM radicacion WHERE radicacion.radicado = (SELECT MIN(radicado) AS EXPR2 FROM datosUSxProceso WHERE (datosUSxProceso.idDatosUS = B.idDatosUS))) AS noFacturaMinRadicado");
			sbdatosUSxFact.Append(", A.factura AS noFacturaRadicado");
			sbdatosUSxFact.Append(" FROM glosasxProceso AS A");
			sbdatosUSxFact.Append(" INNER JOIN glosas AS B ON A.idGlosa = B.idGlosa ");
			sbdatosUSxFact.Append(" INNER JOIN datosUSxFact AS C ON B.idDatosUs = C.idDatosUS ");
			sbdatosUSxFact.Append(" INNER JOIN afiliados AS D ON C.docIden = D.docIden ");

			if (auditoria == 1)
			{
			
				sbdatosUSxFact.Append(" INNER JOIN radicacion AS E ON C.radicado = E.radicado");
			}

			if (auditoria == 0)
			{
				sbdatosUSxFact.Append(" LEFT OUTER JOIN guia AS F ON C.idGuia = F.idGuia");
			}

			sbdatosUSxFact.Append(" WHERE A.eliminar=0 AND A.radicado = '" + radicado + "'");

			if (auditoria == 1)
			{
			
				
				//Filtra por el nit de la IPS
			sbdatosUSxFact.Append(" AND E.nit = '" + nit + "'");
			}

			/*Cambio 09/09/2013/ By Zulu*/
			/*Cambio 20/09/2013/ 1649Z By Zulu
				Se agrego el switch para determinar que tipo de ordenamiento se le da a la consulta.
			 */
			switch (Origen)
			{
				case 0:
					break;
				case 1:
					sbdatosUSxFact.Append(" ORDER BY D.apellido_a asc ");
					break;
				case 2:
					sbdatosUSxFact.Append(" ORDER BY D.apellido_a desc ");
					break;
				case 3:
					sbdatosUSxFact.Append(" ORDER BY programa");
					break;
			}
			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbdatosUSxFact.ToString());
				String factura = "";
				while (reader.Read())
				{
					DateTime dd = new DateTime();
					odatosUSxFact = new DatosUSxFactEntidad();
					odatosUSxFact.codDx1 = reader["codDx1"].ToString();
					odatosUSxFact.apellido_a = reader["apellido_a"].ToString() + " " + reader["apellido_b"].ToString() + " " + reader["nombre_a"].ToString() + " " + reader["nombre_b"].ToString();
					factura = reader["noFacturaRadicado"].ToString();
					odatosUSxFact.nombre_a = factura == "" ? reader["noFacturaMinRadicado"].ToString() : factura;
					odatosUSxFact.docIden = reader["docIden"].ToString();
					dd = DateTime.Parse(reader["fechaIng"].ToString());
					odatosUSxFact.fechaIng = Convert.ToString(dd.ToShortDateString());
					odatosUSxFact.idDatosUS = Convert.ToInt32(Convert.ToDecimal(reader["idDatosUS"].ToString()));
					odatosUSxFact.radicado = reader["radicado"].ToString();
					odatosUSxFact.vrGlosa = Decimal.Parse(reader["vrTotalGlosa"].ToString());
					odatosUSxFact.guia = reader["guia"].ToString();
					odatosUSxFact.vrAceptaIPS = Int32.Parse(reader["vrAsumeIPS"].ToString());
					odatosUSxFact.idGlosa = Int32.Parse(reader["idGlosa"].ToString());
					odatosUSxFact.vrReiterar = Decimal.Parse(reader["vrReiteraGlosa"].ToString());
					odatosUSxFact.vrPagar = Decimal.Parse(reader["vrLevantaGlosa"].ToString());


					lista.Add(odatosUSxFact);
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




		public DatosUSxFact GetGlosasEncabezado(String radicado, Int32 idDatosUS = 0, Int32 idGlosa = 0, Int32 tipo = 0)
		{//TODO cambiar Metodo x getDatosUSxFactListaCtas2Vez
			StringBuilder sbDatosUSxFact = new StringBuilder();
			IDataReader reader;
			DatosUSxFact lista = new DatosUSxFact();
			//  AccionL lista = new AccionL();
			DatosUSxFactEntidad oDatosUSxFact = new DatosUSxFactEntidad();

			sbDatosUSxFact.Append("SELECT");
			sbDatosUSxFact.Append(" gp.idGlosa");
			sbDatosUSxFact.Append(", gp.vrAsumeIPS");
			sbDatosUSxFact.Append(", glo.idDatosUs");
			sbDatosUSxFact.Append(", glo.IdServ");
			sbDatosUSxFact.Append(", gp.radicado");
			sbDatosUSxFact.Append(", gp.codGlosaReitera");
			sbDatosUSxFact.Append(", gp.factura");
			sbDatosUSxFact.Append(", glo.glosaTipo");
			sbDatosUSxFact.Append(", glo.codGlosa");
			sbDatosUSxFact.Append(", glo.cantGlosa");			
			sbDatosUSxFact.Append(", gp.vrGlosa");			
			sbDatosUSxFact.Append(", glo.conceptoAudMed");
			sbDatosUSxFact.Append(", glo.observAudMed");
			sbDatosUSxFact.Append(", glo.auditor");
			sbDatosUSxFact.Append(", glo.grabar");
			sbDatosUSxFact.Append(", gp.vrReiteraGlosa");
			sbDatosUSxFact.Append(", gp.fecIngresoGlosa");			
			sbDatosUSxFact.Append(", gp.eliminar");
			sbDatosUSxFact.Append(", df.docIden");
			sbDatosUSxFact.Append(", df.fechaIng");
			sbDatosUSxFact.Append(", af.apellido_a");
			sbDatosUSxFact.Append(", af.apellido_b");
			sbDatosUSxFact.Append(", af.nombre_a");
			sbDatosUSxFact.Append(", af.nombre_b");
			sbDatosUSxFact.Append(", df.codDx1");

			if (tipo == 0 || tipo == 1 || tipo == 3)
			{
				sbDatosUSxFact.Append(", (SELECT radicacion.noFactura FROM radicacion WHERE radicacion.radicado = (SELECT MIN(radicado) AS EXPR2 FROM datosUSxProceso WHERE (datosUSxProceso.idDatosUS = glo.idDatosUS))) AS noFacturaMinRadicado, CASE WHEN ISNULL((SELECT TOP(1) glop.factura FROM glosasxProceso as glop Inner join glosas as gl on gl.idGLosa=glop.idGlosa WHERE glop.radicado=gp.radicado and gl.idDatosUs=glo.idDatosUS and gl.eliminar=0),'')='' THEN ((SELECT  CONVERT(varchar(20), radicacion.noFactura)FROM radicacion WHERE radicacion.radicado = (SELECT MIN(radicado) AS EXPR2 FROM datosUSxProceso WHERE (datosUSxProceso.idDatosUS = glo.idDatosUS)))) ELSE (SELECT TOP(1) glop.factura	FROM glosasxProceso as glop inner join glosas as gl on gl.idGLosa=glop.idGlosa where glop.radicado=gp.radicado and gl.idDatosUs=glo.idDatosUS and gl.eliminar=0) END As noFactura");
			}
			if (tipo == 2)
			{
				sbDatosUSxFact.Append(", gu.guia");
			}

			sbDatosUSxFact.Append(" FROM glosas AS glo INNER JOIN glosasxProceso AS gp ON glo.idGLosa = gp.idGlosa INNER JOIN datosUSxFact AS df ON glo.idDatosUs = df.idDatosUS INNER JOIN afiliados AS af ON df.docIden = af.docIden");

			if (tipo == 2)
			{
				sbDatosUSxFact.Append(" INNER JOIN guia AS gu ON gu.idGuia = df.idGuia");
			}

			sbDatosUSxFact.Append(" WHERE (gp.eliminar = 0)");
			sbDatosUSxFact.Append(" AND gp.radicado='" + radicado + "'");

			if (idGlosa != 0)
			{
				sbDatosUSxFact.Append(" AND (gp.idGLosa='" + idGlosa + "')");
			}

			if (idDatosUS != 0)
			{
				sbDatosUSxFact.Append(" AND idDatosUS='" + idDatosUS + "'");
			}

			if (tipo == 3)
			{
				sbDatosUSxFact.Append(" AND gp.vrReiteraGlosa>0");
			}

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbDatosUSxFact.ToString());

				while (reader.Read())
				{
					oDatosUSxFact = new DatosUSxFactEntidad();

					oDatosUSxFact.idGlosa = Int32.Parse(reader["idGlosa"].ToString());
					oDatosUSxFact.idDatosUS = Int32.Parse(reader["idDatosUs"].ToString());
					oDatosUSxFact.docIden = reader["docIden"].ToString();
					oDatosUSxFact.prefFactura = reader["factura"].ToString();
					DateTime dd = DateTime.Parse(reader["fechaIng"].ToString());
					oDatosUSxFact.fechaIng = Convert.ToString(dd.ToShortDateString());
					oDatosUSxFact.codGlosaResp = reader["codGlosaReitera"].ToString();
					oDatosUSxFact.codGlosaEfec = reader["codGlosa"].ToString();
					if (tipo == 0)
					{
						oDatosUSxFact.vrAceptaIPS = Decimal.Parse(reader["vrAsumeIPS"].ToString());
						//oDatosUSxFact.noFactura = Int32.Parse((reader["noFactura"].ToString()));
					}

					if (tipo == 2)
					{
						oDatosUSxFact.apellido_a = reader["apellido_a"].ToString();
						oDatosUSxFact.apellido_b = reader["apellido_b"].ToString();
						oDatosUSxFact.nombre_a = reader["nombre_a"].ToString();
						oDatosUSxFact.nombre_b = reader["nombre_b"].ToString();
					}
					else if (tipo == 0 || tipo == 1 || tipo == 3)
					{
						oDatosUSxFact.apellido_a = reader["apellido_a"].ToString() + " " + reader["apellido_b"].ToString() + " " + reader["nombre_a"].ToString() + " " + reader["nombre_b"].ToString();
						oDatosUSxFact.nombre_a = reader["noFacturaMinRadicado"].ToString();
						//oDatosUSxFact.noFactura = Int32.Parse((reader["noFactura"].ToString()));
					}
					if (tipo == 2)
					{
						oDatosUSxFact.guia = reader["guia"].ToString();
						oDatosUSxFact.cantServs = 1;

						oDatosUSxFact.vrTotNetoDet = Decimal.Parse(reader["vrGlosa"].ToString());
						oDatosUSxFact.vrGlosa = Decimal.Parse(reader["vrGlosa"].ToString());
						
					}
					if (tipo == 3)
					{//Se cambia el valor total glosa por el reitera glosa, pues siempre se debe trabajar con el valor reiterado para las respuestas de glosa
						oDatosUSxFact.vrTotNetoDet = Decimal.Parse(reader["vrReiteraGlosa"].ToString());
						oDatosUSxFact.vrGlosa = Decimal.Parse(reader["vrReiteraGlosa"].ToString());
						oDatosUSxFact.vrTotBrutoDet = Double.Parse(reader["vrReiteraGlosa"].ToString());
						oDatosUSxFact.totServs = Double.Parse(reader["vrReiteraGlosa"].ToString());
					}
					else
					{
						oDatosUSxFact.vrTotBrutoDet = Double.Parse(reader["vrGlosa"].ToString());
						oDatosUSxFact.totServs = Double.Parse(reader["vrGlosa"].ToString());
					}
					oDatosUSxFact.codDx1 = reader["codDx1"].ToString();
					oDatosUSxFact.radicado = reader["radicado"].ToString();
					oDatosUSxFact.cantServs = 1;
					lista.Add(oDatosUSxFact);

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

		public String getidRips1(Int32 idDatosUs)
		{
			IDataReader reader;
			String idRips1 = String.Empty;
			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, "SELECT idRIPS, docIden FROM datosUSxFact WHERE idDatosUs =" + idDatosUs + "");

				while (reader.Read())
				{
					idRips1 = reader["idRIPS"].ToString() + "-" + reader["docIden"].ToString();
				}
				reader.Close();
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				oDataAccess.close();
			}
			return idRips1;
		}

		public DatosUSxFact getDatosAfiliados(String docIden)
		{
			StringBuilder sbdatosUSxFact = new StringBuilder();
			IDataReader reader;
			DatosUSxFact lista = new DatosUSxFact();
			//  AccionL lista = new AccionL();
			DatosUSxFactEntidad odatosUSxFact = new DatosUSxFactEntidad();

			sbdatosUSxFact.Append("SELECT");
			sbdatosUSxFact.Append(" apellido_a");
			sbdatosUSxFact.Append(", apellido_b");
			sbdatosUSxFact.Append(", nombre_a");
			sbdatosUSxFact.Append(", nombre_b");
			sbdatosUSxFact.Append(", Sexo");
			sbdatosUSxFact.Append(", tipodoc");
			sbdatosUSxFact.Append(", docIden");
			sbdatosUSxFact.Append(", fecNac");
			sbdatosUSxFact.Append(", fecAfil");
			sbdatosUSxFact.Append(" FROM afiliados");
			sbdatosUSxFact.Append(" WHERE docIden = '" + docIden + "'");


			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbdatosUSxFact.ToString());

				while (reader.Read())
				{
					odatosUSxFact = new DatosUSxFactEntidad();
					odatosUSxFact.apellido_a = reader["apellido_a"].ToString();
					odatosUSxFact.apellido_b = reader["apellido_b"].ToString();
					odatosUSxFact.nombre_a = reader["nombre_a"].ToString();
					odatosUSxFact.nombre_b = reader["nombre_b"].ToString();
					odatosUSxFact.sexo = reader["Sexo"].ToString();
					odatosUSxFact.fecNac = reader["fecNac"].ToString();
					odatosUSxFact.fecAfil = reader["fecAfil"].ToString();
					odatosUSxFact.idTipoDoc = Int32.Parse((reader["tipodoc"].ToString() == "" ? "0" : reader["tipodoc"].ToString()));

					lista.Add(odatosUSxFact);
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

		public DatosUSxFact getDatosUSxFactxValidar(String radicado, String mesRad)
		{
			IDataReader reader;
			DatosUSxFact lista = new DatosUSxFact();
			DatosUSxFactEntidad odatosUSxFact = new DatosUSxFactEntidad();
			String sQuery = string.Format("EXEC SPS_ValidacionUS @radicado='{0}', @mesRad='{1}'", radicado, mesRad);


			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sQuery.ToString());

				while (reader.Read())
				{
					DateTime dd = new DateTime();
					odatosUSxFact = new DatosUSxFactEntidad();
					odatosUSxFact.radicado = reader["radicado"].ToString();
					odatosUSxFact.docIden = reader["docIden"].ToString();
					odatosUSxFact.codDane = reader["codDane"].ToString();
					odatosUSxFact.listado = Int32.Parse(reader["listado"].ToString() == "" ? "0" : reader["listado"].ToString());
					odatosUSxFact.idSitioAtenc = Int32.Parse(reader["idSitioAtencion"].ToString());
					dd = DateTime.Parse(reader["fechaIng"].ToString());
					odatosUSxFact.fechaIng = Convert.ToString(dd.ToShortDateString());
					odatosUSxFact.idDatosUS = Int32.Parse(reader["idDatosUS"].ToString());
					odatosUSxFact.programa = Int32.Parse(reader["programa"].ToString() == "" ? "0" : reader["programa"].ToString());
					odatosUSxFact.apellido_a = reader["apellido_a"].ToString();
					odatosUSxFact.apellido_b = reader["apellido_b"].ToString();
					odatosUSxFact.nombre_a = reader["nombre_a"].ToString();
					odatosUSxFact.nombre_b = reader["nombre_b"].ToString();
					odatosUSxFact.sexo = reader["sexo"].ToString();
					dd = DateTime.Parse(reader["fecnac"].ToString() == "" ? "01/01/1900" : reader["fecnac"].ToString());
					odatosUSxFact.fecNac = Convert.ToString(dd.ToShortDateString());
					dd = DateTime.Parse(reader["fecafil"].ToString() == "" ? "01/01/1900" : reader["fecafil"].ToString());
					odatosUSxFact.fecAfil = Convert.ToString(dd.ToShortDateString());
					odatosUSxFact.idTipoDoc = Int32.Parse(reader["tipoDoc"].ToString() == "" ? "0" : reader["tipoDoc"].ToString());
					odatosUSxFact.entidad = reader["entidad"].ToString();
					odatosUSxFact.tipoDoc = reader["nTipoDoc"].ToString();
					odatosUSxFact.municipio = reader["departamento"].ToString() + "-" + reader["municipio"].ToString();
					odatosUSxFact.departamento = reader["departamento"].ToString();
					odatosUSxFact.sitioAtenc = reader["sitioAtencion"].ToString();
					odatosUSxFact.nListado = reader["TipoListado"].ToString();
					odatosUSxFact.nPrograma = reader["nPrograma"].ToString();
					odatosUSxFact.codDane = reader["codDane"].ToString();
					lista.Add(odatosUSxFact);
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

		public DatosUSxFact getDatosUSxFactxAuditar(String radicado)
		{
			StringBuilder sbdatosUSxFact = new StringBuilder();
			IDataReader reader;
			DatosUSxFact lista = new DatosUSxFact();
			DatosUSxFactEntidad odatosUSxFact = new DatosUSxFactEntidad();

			sbdatosUSxFact.Append("SELECT");
			sbdatosUSxFact.Append(" A.docIden");
			sbdatosUSxFact.Append(", A.codDane");
			sbdatosUSxFact.Append(", A.listado");
			sbdatosUSxFact.Append(", A.sitioAtenc");
			sbdatosUSxFact.Append(", A.fechaIng");
			sbdatosUSxFact.Append(", A.idDatosUS");
			sbdatosUSxFact.Append(", A.programa");
			sbdatosUSxFact.Append(", A.codDx1");
			sbdatosUSxFact.Append(", B.apellido_a");
			sbdatosUSxFact.Append(", B.apellido_b");
			sbdatosUSxFact.Append(", B.nombre_a");
			sbdatosUSxFact.Append(", B.nombre_b");
			sbdatosUSxFact.Append(", B.sexo");
			sbdatosUSxFact.Append(", B.fecNac");
			sbdatosUSxFact.Append(", B.fecAfil");
			sbdatosUSxFact.Append(", B.tipodoc");
			sbdatosUSxFact.Append(", D.entidad");
			sbdatosUSxFact.Append(", C.radicado");
			sbdatosUSxFact.Append(" FROM datosUSxProceso AS E INNER JOIN");
			sbdatosUSxFact.Append(" datosUSxFact AS A INNER JOIN");
			sbdatosUSxFact.Append(" afiliados AS B ON A.docIden = B.docIden");
			sbdatosUSxFact.Append(" ON E.idDatosUS = A.idDatosUS INNER JOIN");
			sbdatosUSxFact.Append(" entidad AS D INNER JOIN");
			sbdatosUSxFact.Append(" radicacion AS C ON D.nit = C.nit ON E.radicado = C.radicado");
			sbdatosUSxFact.Append(" WHERE C.radicado = '" + radicado + "' and idestadorad='6'");
			sbdatosUSxFact.Append(" ORDER BY A.idDatosUs, B.apellido_a, B.nombre_a ");

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbdatosUSxFact.ToString());

				while (reader.Read())
				{
					DateTime dd = new DateTime();
					odatosUSxFact = new DatosUSxFactEntidad();
					odatosUSxFact.radicado = reader["radicado"].ToString();
					odatosUSxFact.docIden = reader["docIden"].ToString();
					odatosUSxFact.codDane = reader["codDane"].ToString();
					odatosUSxFact.listado = Int32.Parse(reader["listado"].ToString());
					odatosUSxFact.sitioAtenc = reader["sitioAtenc"].ToString();
					dd = DateTime.Parse(reader["fechaIng"].ToString());
					odatosUSxFact.fechaIng = Convert.ToString(dd.ToShortDateString());
					odatosUSxFact.idDatosUS = Int32.Parse(reader["idDatosUS"].ToString());
					odatosUSxFact.programa = Int32.Parse(reader["programa"].ToString());
					odatosUSxFact.apellido_a = reader["apellido_a"].ToString();
					odatosUSxFact.apellido_b = reader["apellido_b"].ToString();
					odatosUSxFact.nombre_a = reader["nombre_a"].ToString();
					odatosUSxFact.nombre_b = reader["nombre_b"].ToString();
					odatosUSxFact.sexo = reader["sexo"].ToString();
					dd = DateTime.Parse(reader["fecnac"].ToString());
					odatosUSxFact.fecNac = Convert.ToString(dd.ToShortDateString());
					dd = DateTime.Parse(reader["fecafil"].ToString());
					odatosUSxFact.fecAfil = Convert.ToString(dd.ToShortDateString());
					odatosUSxFact.idTipoDoc = Int32.Parse(reader["tipoDoc"].ToString());
					odatosUSxFact.entidad = reader["entidad"].ToString();
					lista.Add(odatosUSxFact);

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

		public DatosUSxFact GetDatosListados(String docIden, String mesListado)
		{
			String sbdatosUSxFact = String.Format("EXEC SPS_getDatosListados @docIden='{0}', @mesListado='{1}'", docIden, mesListado);
			IDataReader reader;
			DatosUSxFact lista = new DatosUSxFact();
			DatosUSxFactEntidad odatosUSxFact = new DatosUSxFactEntidad();

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbdatosUSxFact.ToString());

				while (reader.Read())
				{
					odatosUSxFact = new DatosUSxFactEntidad();
					odatosUSxFact.mesAtencion = reader["mesListado"].ToString();
					odatosUSxFact.programa = Int32.Parse(reader["programa"].ToString());
					odatosUSxFact.idTipoDoc = Int32.Parse(reader["tipoDoc"].ToString() == "" ? "0" : reader["tipoDoc"].ToString());
					odatosUSxFact.codDane = reader["codDane"].ToString();
					odatosUSxFact.IdCabecera = Int32.Parse(reader["idCabecera"].ToString());
					odatosUSxFact.idSitioAtenc = Int32.Parse(reader["sitioAtenc"].ToString());
					odatosUSxFact.apellido_a = reader["apellido_a"].ToString();
					odatosUSxFact.apellido_b = reader["apellido_b"].ToString();
					odatosUSxFact.nombre_a = reader["nombre_a"].ToString();
					odatosUSxFact.nombre_b = reader["nombre_b"].ToString();
					odatosUSxFact.sexo = reader["sexo"].ToString();
					odatosUSxFact.fecNac = reader["fecNac"].ToString();
					odatosUSxFact.fecAfil = reader["fecAfil"].ToString();
					odatosUSxFact.municipio = reader["munDept"].ToString();
					odatosUSxFact.nPrograma = reader["nPrograma"].ToString();
					odatosUSxFact.sitioAtenc = reader["nSitioAtencion"].ToString();
					odatosUSxFact.listado = Int32.Parse(reader["tipoListado"].ToString());
					lista.Add(odatosUSxFact);

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


		public DatosUSxFact getDUFxAuditar(String radicado)
		{
			StringBuilder sbdatosUSxFact = new StringBuilder();
			IDataReader reader;
			DatosUSxFact lista = new DatosUSxFact();
			//  AccionL lista = new AccionL();
			DatosUSxFactEntidad odatosUSxFact = new DatosUSxFactEntidad();

			sbdatosUSxFact.Append("SELECT");
			sbdatosUSxFact.Append(" dup.radicado");
			sbdatosUSxFact.Append(", duf.idDatosUS");
			sbdatosUSxFact.Append(", td.tipoDoc");
			sbdatosUSxFact.Append(", duf.docIden");
			sbdatosUSxFact.Append(", af.apellido_a");
			sbdatosUSxFact.Append(", af.apellido_b");
			sbdatosUSxFact.Append(", af.nombre_a");
			sbdatosUSxFact.Append(", af.nombre_b");
			sbdatosUSxFact.Append(", af.sexo");
			sbdatosUSxFact.Append(", duf.listado");
			sbdatosUSxFact.Append(", duf.codDx1");
			sbdatosUSxFact.Append(", duf.fechaIng");
			sbdatosUSxFact.Append(", duf.vrTotNetoDet");
			sbdatosUSxFact.Append(", gu.guia");
			//sbdatosUSxFact.Append(", duf.tarifa");
			//sbdatosUSxFact.Append(", duf.porcTarifa");
			sbdatosUSxFact.Append(", tl.TipoListado");
			sbdatosUSxFact.Append(" FROM datosUSxProceso AS dup INNER JOIN");
			sbdatosUSxFact.Append(" datosUSxFact AS duf INNER JOIN");
			sbdatosUSxFact.Append(" afiliados AS af ON duf.docIden = af.docIden");
			sbdatosUSxFact.Append(" ON dup.idDatosUS = duf.idDatosUS");
			sbdatosUSxFact.Append(" INNER JOIN tiposDoc as td ON td.idTipoDoc = af.tipodoc");
			sbdatosUSxFact.Append(" LEFT OUTER JOIN guia AS gu ON gu.idGuia = duf.idGuia");
			sbdatosUSxFact.Append(" INNER JOIN tipoListado AS tl ON tl.idTipoListado = duf.listado");
			sbdatosUSxFact.Append(" WHERE dup.radicado = '" + radicado + "'");

			try
			{
				oDataAccess.open();
				reader = oDataAccess.executeReader(CommandType.Text, sbdatosUSxFact.ToString());

				while (reader.Read())
				{
					DateTime dd = new DateTime();
					odatosUSxFact = new DatosUSxFactEntidad();
					odatosUSxFact.radicado = reader["radicado"].ToString();
					odatosUSxFact.idDatosUS = Int32.Parse(reader["idDatosUS"].ToString());
					odatosUSxFact.tipoDoc = reader["tipoDoc"].ToString();
					odatosUSxFact.docIden = reader["docIden"].ToString();
					odatosUSxFact.apellido_a = reader["apellido_a"].ToString();
					odatosUSxFact.apellido_b = reader["apellido_b"].ToString();
					odatosUSxFact.nombre_a = reader["nombre_a"].ToString();
					odatosUSxFact.nombre_b = reader["nombre_b"].ToString();
					odatosUSxFact.sexo = reader["sexo"].ToString();
					odatosUSxFact.nListado = reader["TipoListado"].ToString();
					odatosUSxFact.codDx1 = reader["codDx1"].ToString();
					dd = DateTime.Parse(reader["fechaIng"].ToString());
					odatosUSxFact.fechaIng = Convert.ToString(dd.ToShortDateString());
					odatosUSxFact.vrTotNetoDet = Int32.Parse(reader["vrTotNetoDet"].ToString());
					odatosUSxFact.guia = reader["guia"].ToString();
					//odatosUSxFact.tarifa = Int32.Parse(reader["tarifa"].ToString());
					//odatosUSxFact.porcTarifa = Int32.Parse(reader["porcTarifa"].ToString());
					lista.Add(odatosUSxFact);

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

		public Int32 getDiferenciaEncVsDet(Int32 idDatosUs)
		{
			Int32 retorno = 0;

			oDataAccess.addInParameters("@idDatosUs", DbType.String, paramValue: idDatosUs);

			try
			{
				oDataAccess.open();
				retorno = oDataAccess.executeNonQuery(CommandType.StoredProcedure, "SPS_getDiferenciaEncVsDet", true);
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



		public Int32 AddDetalleAgrupXidDatosUS(Int32 idDatosUs)
		{
			Int32 retorno = 0;
			String sQuery = String.Format("EXEC SPIU_ProcesarIdDatosUS @idDatosUS={0}", idDatosUs);


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


		// adiciona una nueva datosUSxFact
		public Int32 AdddatosUSxFact(DatosUSxFactEntidad odatosUSxFact)
		{
			Int32 retorno = 0;

			oDataAccess.addInParameters("@idRIPS", DbType.String, paramValue: odatosUSxFact.idRIPS);
			oDataAccess.addInParameters("@docIden", DbType.String, paramValue: odatosUSxFact.docIden);
			oDataAccess.addInParameters("@fechaIng", DbType.Date, paramValue: odatosUSxFact.fechaIng);
			oDataAccess.addInParameters("@fechaEgr", DbType.Date, paramValue: odatosUSxFact.fechaEgr);
			oDataAccess.addInParameters("@vrTotBrutoDet", DbType.Int32, paramValue: odatosUSxFact.vrTotBrutoDet);
			oDataAccess.addInParameters("@vrCopagosDet", DbType.Int32, paramValue: odatosUSxFact.vrCopagosDet);
			oDataAccess.addInParameters("@vrCuotaMod", DbType.Int32, paramValue: odatosUSxFact.vrCuotaMod);
			oDataAccess.addInParameters("@vrAbono", DbType.Int32, paramValue: odatosUSxFact.vrAbono);

			oDataAccess.addInParameters("@vrTotDescDet", DbType.Int64, paramValue: odatosUSxFact.vrTotDescDet);

			oDataAccess.addInParameters("@vrNotaCred", DbType.Int32, paramValue: odatosUSxFact.vrNotaCred);
			oDataAccess.addInParameters("@vrNotaDeb", DbType.Int32, paramValue: odatosUSxFact.vrNotaDeb);
			oDataAccess.addInParameters("@vrIva", DbType.Int32, paramValue: odatosUSxFact.vrIva);
			oDataAccess.addInParameters("@vrTotNetoDet", DbType.Int32, paramValue: odatosUSxFact.vrTotNetoDet);
			oDataAccess.addInParameters("@codDx1", DbType.String, paramValue: odatosUSxFact.codDx1);
			oDataAccess.addInParameters("@codDx2", DbType.String, paramValue: odatosUSxFact.codDx2);
			oDataAccess.addInParameters("@codDx3", DbType.String, paramValue: odatosUSxFact.codDx3);
			oDataAccess.addInParameters("@estadoEg", DbType.Int32, paramValue: odatosUSxFact.estadoEg);
			oDataAccess.addInParameters("@origen", DbType.Int32, paramValue: odatosUSxFact.origen);
			oDataAccess.addInParameters("@radicado", DbType.String, paramValue: odatosUSxFact.radicado);
			oDataAccess.addInParameters("@idTipoDigit", DbType.Int32, paramValue: odatosUSxFact.idTipoDigit);
			oDataAccess.addInParameters("@idUser", DbType.Int32, paramValue: odatosUSxFact.idUser);
			oDataAccess.addInParameters("@apellido_a", DbType.String, paramValue: odatosUSxFact.apellido_a);
			oDataAccess.addInParameters("@apellido_b", DbType.String, paramValue: odatosUSxFact.apellido_b);
			oDataAccess.addInParameters("@nombre_a", DbType.String, paramValue: odatosUSxFact.nombre_a);
			oDataAccess.addInParameters("@nombre_b", DbType.String, paramValue: odatosUSxFact.nombre_b);
			oDataAccess.addInParameters("@idTipoDoc", DbType.Int32, paramValue: odatosUSxFact.idTipoDoc);
			oDataAccess.addInParameters("@sexo", DbType.String, paramValue: odatosUSxFact.sexo);
			oDataAccess.addInParameters("@tipoAtencion", DbType.String, paramValue: odatosUSxFact.tipoAtencion);
			oDataAccess.addInParameters("@vrAceptaIPS", DbType.Int32, paramValue: odatosUSxFact.vrCopagosDet);
			oDataAccess.addInParameters("@factura", DbType.String, paramValue: odatosUSxFact.vrTotDescDet.ToString());
			oDataAccess.addInParameters("@codGlosaEfec", DbType.String, paramValue: odatosUSxFact.codGlosaEfec);
			oDataAccess.addInParameters("@codGlosaResp", DbType.String, paramValue: odatosUSxFact.codGlosaResp);
			oDataAccess.addInParameters("@codServGlosa", DbType.String, paramValue: odatosUSxFact.servGlosa);
			oDataAccess.addInParameters("@observIPS", DbType.String, paramValue: odatosUSxFact.observAnalista);
			oDataAccess.addInParameters("@tipoCuenta", DbType.Int32, paramValue: odatosUSxFact.tipoCuenta);


			try
			{
				oDataAccess.open();
				retorno = oDataAccess.executeNonQuery(CommandType.StoredProcedure, "SPI_datosUSxFact", true);
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

		public Int32 AdddatosUSxProceso(DatosUSxProcesoEntidad odatosUSxProceso)
		{

			Int32 retorno = 0;
			String sQuery = string.Format("SPI_DatosUSxProceso @radicado='{0}', @idDatosUS={1}, @idTipoDigit={2}, @idUser={3}",
					odatosUSxProceso.radicado, odatosUSxProceso.idDatosUS, odatosUSxProceso.idTipoDigit, odatosUSxProceso.idUser);

			try
			{
				oDataAccess.open();
				retorno = oDataAccess.executeNonQuery(CommandType.Text, sQuery);
			}
			catch (DbException ex)
			{
				throw new Exception("Se ha generado el siguiente error : " + ex.Message);
			}
			return (retorno);
		}

		public Int32 updateDatosUSxProceso(DatosUSxProcesoEntidad odatosUSxProceso)
		{
			Int32 retorno = 0;
			StringBuilder sbdatosUSxProceso = new StringBuilder();

			sbdatosUSxProceso.Append("UPDATE datosUSxProceso SET");
			sbdatosUSxProceso.Append(" idTipoDigit ='" + odatosUSxProceso.idTipoDigit + "'");
			sbdatosUSxProceso.Append(", idUser ='" + odatosUSxProceso.idUser + "'");
			sbdatosUSxProceso.Append(", codGlosaEfec='" + odatosUSxProceso.codGlosaEfec + "'");
			sbdatosUSxProceso.Append(", codGlosaResp='" + odatosUSxProceso.codGlosaResp + "'");
			sbdatosUSxProceso.Append(", vrAceptaIPS='" + odatosUSxProceso.vrAceptaIPS + "'");
			sbdatosUSxProceso.Append(" WHERE idDatosUS='" + odatosUSxProceso.idDatosUS + "'");
			sbdatosUSxProceso.Append(" AND radicado='" + odatosUSxProceso.radicado + "'");

			try
			{
				oDataAccess.open();
				retorno = oDataAccess.executeNonQuery(CommandType.Text, sbdatosUSxProceso.ToString());

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




		// Actualiza un registro de la tabla datosUSxFact

		public Int32 UpdatedatosUSxFact(DatosUSxFactEntidad odatosUSxFact, Boolean auditoria = false)
		{
			Int32 retorno = 0;
			StringBuilder sbdatosUSxFact = new StringBuilder();
			{
				sbdatosUSxFact.Append("UPDATE datosUSxFact SET");
				sbdatosUSxFact.Append(" codDx1='" + odatosUSxFact.codDx1 + "'");
				sbdatosUSxFact.Append(", codDx2='" + odatosUSxFact.codDx2 + "'");
				sbdatosUSxFact.Append(", codDx3='" + odatosUSxFact.codDx3 + "'");
				sbdatosUSxFact.Append(", docIden='" + odatosUSxFact.docIden + "'");
				sbdatosUSxFact.Append(", fechaEgr='" + odatosUSxFact.fechaEgr + "'");
				sbdatosUSxFact.Append(", fechaIng='" + odatosUSxFact.fechaIng + "'");
				if (auditoria == false)
				{
					sbdatosUSxFact.Append(", estadoEg='" + odatosUSxFact.estadoEg + "'");
					sbdatosUSxFact.Append(", origen='" + odatosUSxFact.origen + "'");
				}
				sbdatosUSxFact.Append(", vrAbono='" + odatosUSxFact.vrAbono + "'");
				sbdatosUSxFact.Append(", vrCopagosDet='" + odatosUSxFact.vrCopagosDet + "'");
				sbdatosUSxFact.Append(", vrCuotaMod='" + odatosUSxFact.vrCuotaMod + "'");
				sbdatosUSxFact.Append(", vrIva='" + odatosUSxFact.vrIva + "'");
				sbdatosUSxFact.Append(", vrNotaCred='" + odatosUSxFact.vrNotaCred + "'");
				sbdatosUSxFact.Append(", vrNotaDeb='" + odatosUSxFact.vrNotaDeb + "'");
				sbdatosUSxFact.Append(", vrTotBrutoDet='" + odatosUSxFact.vrTotBrutoDet + "'");
				sbdatosUSxFact.Append(", vrTotDescDet='" + odatosUSxFact.vrTotDescDet + "'");
				sbdatosUSxFact.Append(", vrTotNetoDet='" + odatosUSxFact.vrTotNetoDet + "'");
				sbdatosUSxFact.Append(", tipoAtencion='" + odatosUSxFact.tipoAtencion + "'");

				if (auditoria == true)
				{
					sbdatosUSxFact.Append(", idGuia='" + odatosUSxFact.idGuia + "'");
					sbdatosUSxFact.Append(", programa='" + odatosUSxFact.programa + "'");
					sbdatosUSxFact.Append(", listado='" + odatosUSxFact.listado + "'");
					sbdatosUSxFact.Append(", idCabecera='" + odatosUSxFact.IdCabecera + "'");
					sbdatosUSxFact.Append(", idSitioAtencion='" + odatosUSxFact.idSitioAtenc + "'");
					sbdatosUSxFact.Append(", codDane='" + odatosUSxFact.codDane + "'");
					sbdatosUSxFact.Append(", patologia='" + odatosUSxFact.patologia + "'");
					sbdatosUSxFact.Append(", nivel='" + odatosUSxFact.nivel + "'");
				}

				sbdatosUSxFact.Append(" WHERE idDatosUS='" + odatosUSxFact.idDatosUS + "'");

				try
				{
					oDataAccess.open();
					retorno = oDataAccess.executeNonQuery(CommandType.Text, sbdatosUSxFact.ToString());
					oDataAccess.executeNonQuery(CommandType.Text, "UPDATE datosUSxProceso SET observAnalista='" + odatosUSxFact.observAnalista + "' WHERE idDatosUS='" + odatosUSxFact.idDatosUS + "' and radicado='" + odatosUSxFact.radicado + "'");

					return retorno;
				}

				catch (Exception)
				{
					throw;
				}

				finally
				{
					oDataAccess.close();
					updateAfiliado(odatosUSxFact);
				}
			}
		}

		public Int32 UpdateDatosUSxFactValidacionUsuarios(DatosUSxFactEntidad odatosUSxFact)
		{
			Int32 retorno = 0;

			String sQuery = string.Format("SPU_ValidacionUS @idDatosUS={0}, @fechaIng='{1}', @idTipoDoc={2}, @docIden='{3}', @apellido_a='{4}', @apellido_b='{5}', @nombre_a='{6}', @nombre_b='{7}', @sexo='{8}', @codDane='{9}', @programa={10}, @idSitioAtenc={11}, @listado={12}, @fecNac='{13}', @fecAfil='{14}', @idUserValida={15}",
					odatosUSxFact.idDatosUS, odatosUSxFact.fechaIng, odatosUSxFact.idTipoDoc, odatosUSxFact.docIden, odatosUSxFact.apellido_a, odatosUSxFact.apellido_b, odatosUSxFact.nombre_a, odatosUSxFact.nombre_b, odatosUSxFact.sexo, odatosUSxFact.codDane, odatosUSxFact.programa, odatosUSxFact.idSitioAtenc, odatosUSxFact.listado, odatosUSxFact.fecNac, odatosUSxFact.fecAfil, odatosUSxFact.idUser);

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



		public Int32 UpdateDeleteRecsGlosDetAgrup(Int32 idDatosUS, String radicado, Int32 idUser)
		{
			Int32 retorno = 0;

			String sQuery = string.Format("SPD_RecsGlosDetAgrup @idDatosUS={0}, @radicado='{1}', @idUser={2}", idDatosUS, radicado, idUser);

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

		public Int32 UpdateRadicadoValidacionUsuarios(String radicado)
		{
			Int32 retorno = 0;
			oDataAccess.addInParameters("@radicado", DbType.String, paramValue: radicado);

			try
			{
				oDataAccess.open();
				retorno = oDataAccess.executeNonQuery(CommandType.StoredProcedure, "SPU_RadicadoVUs", true);
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

		public Int32 updateGuia(Int32 idDatosUS, Int32 idGuia)
		{
			Int32 retorno = 0;

			try
			{
				oDataAccess.open();
				retorno = oDataAccess.executeNonQuery(CommandType.Text, "UPDATE datosUSxFact SET idGuia='" + idGuia + "' WHERE idDatosUS='" + idDatosUS + "'");
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



		private Int32 updateAfiliado(DatosUSxFactEntidad odatosUSxFact)
		{
			Int32 retorno = 0;
			StringBuilder sbAfiliados = new StringBuilder();

			sbAfiliados.Append("UPDATE afiliados SET");
			sbAfiliados.Append(" apellido_a='" + odatosUSxFact.apellido_a + "'");
			sbAfiliados.Append(", apellido_b='" + odatosUSxFact.apellido_b + "'");
			sbAfiliados.Append(", nombre_a='" + odatosUSxFact.nombre_a + "'");
			sbAfiliados.Append(", nombre_b='" + odatosUSxFact.nombre_b + "'");
			sbAfiliados.Append(", sexo='" + odatosUSxFact.sexo + "'");
			sbAfiliados.Append(", tipoDoc='" + odatosUSxFact.idTipoDoc + "'");
			sbAfiliados.Append(", fecAfil='" + odatosUSxFact.fecAfil + "'");
			sbAfiliados.Append(", fecNac='" + odatosUSxFact.fecNac + "'");
			sbAfiliados.Append(" WHERE docIden='" + odatosUSxFact.docIden + "'");

			try
			{
				oDataAccess.open();
				retorno = oDataAccess.executeNonQuery(CommandType.Text, sbAfiliados.ToString());
				return retorno;

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				oDataAccess.close();

				if (retorno < 1)
				{
					addAfiliado(odatosUSxFact);
				}
			}

		}

		private Int32 addAfiliado(DatosUSxFactEntidad odatosUSxFact)
		{
			Int32 retorno = 0;
			StringBuilder sbAfiliadosAdd = new StringBuilder();

			sbAfiliadosAdd.Append("INSERT INTO afiliados(");
			sbAfiliadosAdd.Append(" apellido_a");
			sbAfiliadosAdd.Append(", apellido_b");
			sbAfiliadosAdd.Append(", nombre_a");
			sbAfiliadosAdd.Append(", nombre_b");
			sbAfiliadosAdd.Append(", sexo");
			sbAfiliadosAdd.Append(", tipoDoc");
			sbAfiliadosAdd.Append(", docIden");
			sbAfiliadosAdd.Append(", fecAfil");
			sbAfiliadosAdd.Append(", fecNac");
			sbAfiliadosAdd.Append(")");
			sbAfiliadosAdd.Append(" VALUES(");
			sbAfiliadosAdd.Append(" '" + odatosUSxFact.apellido_a + "'");
			sbAfiliadosAdd.Append(", '" + odatosUSxFact.apellido_b + "'");
			sbAfiliadosAdd.Append(", '" + odatosUSxFact.nombre_a + "'");
			sbAfiliadosAdd.Append(", '" + odatosUSxFact.nombre_b + "'");
			sbAfiliadosAdd.Append(", '" + odatosUSxFact.sexo + "'");
			sbAfiliadosAdd.Append(", '" + odatosUSxFact.idTipoDoc + "'");
			sbAfiliadosAdd.Append(", '" + odatosUSxFact.docIden + "'");
			sbAfiliadosAdd.Append(", '" + odatosUSxFact.fecAfil + "'");
			sbAfiliadosAdd.Append(", '" + odatosUSxFact.fecNac + "'");
			sbAfiliadosAdd.Append(")");

			try
			{
				oDataAccess.open();
				retorno = oDataAccess.executeNonQuery(CommandType.Text, sbAfiliadosAdd.ToString());
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

		private Int64 GetNumFactura(String factura)
		{
			String f = "";
			Int64 cantCero = 0;
			for (Int32 i = factura.Length - 1; i >= 0; i--)
			{
				char c = char.Parse(factura.Substring(i, 1));
				if ((((Int64)c) >= 48) && (((Int64)c) <= 57))
				{
					f = c + f;
				}
				else
				{
					i = 0;
				}
				if (((Int64)c) == 48)
				{
					cantCero++;
				}
				if (cantCero > 3)
				{
					i = 0;
				}
			}
			return (f == "" ? Int64.Parse(factura) : Int64.Parse(f));
		}

		private String GetPrefix(String factura)
		{
			String prefix = "";
			Int32 ind = 0;
			Int32 cantCero = 0;
			for (Int32 i = 0; i < factura.Length; i++)
			{
				char c = char.Parse(factura.Substring(i, 1));
				if ((((Int32)c) < 48) || (((Int32)c) > 57))
				{
					ind = i;
				}
				if (((Int32)c) == 48)
				{
					cantCero++;
				}
				else
				{
					cantCero = 0;
				}
				if (cantCero > 3)
				{
					ind = i;
				}
			}
			if (ind == 0)
			{
				for (Int32 i = 0; i < factura.Length; i++)
				{
					char c = char.Parse(factura.Substring(i, 1));
					if (((Int32)c) == 48)
					{
						ind = i;
					}
					else
					{
						i = factura.Length;
					}
				}
			}
			if (ind != 0)
			{
				prefix = obtenerTexto(factura, ind + 1);
			}
			return (prefix == "" ? "NULL" : prefix);
		}

		private String obtenerTexto(String Texto, Int32 caracteres, Int32 posicion = 0)
		{
			if (Texto.Length - (posicion + caracteres) < 0)
			{
				caracteres = caracteres - (caracteres - (Texto.Length - posicion));
			}
			String result = Texto.Substring(posicion, caracteres);
			return result;
		}
	}
}