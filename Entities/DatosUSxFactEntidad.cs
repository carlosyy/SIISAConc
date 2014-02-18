using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Entities
{
	#region "Comentarios de actualizaciones"
	/*<resumen>
		 <autor>ZD</autor>
		    <fecha>09/07/2013 2106Z</fecha>
		    <justificacion>
		 				Se crean las propiedades de IdCabecera y IdSitioAtención necesarias para los ddl correspondientes.
				</justificacion>
		    <anterior>
		 				No exitia
		 		</anterior>
		     <ahora>
		     		public int IdCabecera { get; set; }
						
		     </ahora>

		  </resumen>*/
			/*<resumen>
						<autor>ZD</autor>
								<fecha>20/09/2013 1607Z</fecha>
							<justificacion>
		 							Se crea la propiedad para determinar si se va a mostrar el grid filtrado o no
							</justificacion>
							<anterior>
		 							No exitia
		 					</anterior>
							<ahora>
		     					public int IdCabecera { get; set; }
							</ahora>

		  </resumen>*/
	#endregion
	public class DatosUSxFactEntidad
	{
		public Boolean Activo { get; set; }
		public String apellido_a { get; set; }
		public String apellido_b { get; set; }
		public Int32 IdCabecera { get; set; }
	
		public String cabecera { get; set; }
		public Double cantServs { get; set; }
		public String codDane { get; set; }
		public String codDx1 { get; set; }
		public String codDx2 { get; set; }
		public String codDx3 { get; set; }
		public String codGlosaEfec { get; set; }
		public String codGlosaResp { get; set; }
		public String ConceptoAudMed { get; set; }
		public String DescDx1 { get; set; }
		public String DescDx2 { get; set; }
		public String DescDx3 { get; set; }
		public String departamento { get; set; }
		public String docIden { get; set; }
		public Boolean eliminar { get; set; }
		public String entidad { get; set; }
		public Int32 estadoEg { get; set; }
		public String fechaEgr { get; set; }
		public String fechaIng { get; set; }
		public String fecNac { get; set; }
		public String fecAfil { get; set; }
		public DateTime fechaRegistro { get; set; }
		public String guia { get; set; }
		public Int32 idDatosUS { get; set; }
		public Int32 idGlosa { get; set; }
		public Int32 idDatosUsAnt { get; set; }
		public Int32 idGuia { get; set; }
		public Int32 idSitioAtenc { get; set; }
		public Int32 idTipoDoc { get; set; }
		public Int32 idRIPS { get; set; }
		public Int32 idTipoDigit { get; set; }
		public Int32 idUser { get; set; }
		public Int32 listado { get; set; }
		public String mesAtencion { get; set; }
		public String municipio { get; set; }
		public String nListado { get; set; }
		public String nitRecobro { get; set; }
		public Int32 nivel { get; set; }
		public Int64 noFactura { get; set; }
		public String nombre_a { get; set; }
		public String nombre_b { get; set; }
		public String nPrograma { get; set; }
		public String observAnalista { get; set; }
		public Int32 origen { get; set; }
		public Int32 patologia { get; set; }
		public Int32 porcTarifa { get; set; }
		public Int32 programa { get; set; }
		public String prefFactura { get; set; }
		public String radAnt { get; set; }
		public String radicado { get; set; }
		public String sexo { get; set; }
		public String servGlosa { get; set; }
		public String sitioAtenc { get; set; }
		public Int32 tarifa { get; set; }
		public String tipoAtencion { get; set; }
		public Int32 tipoCuenta { get; set; }
		public Int32 tipoRecobro { get; set; }
		public String tipoDoc { get; set; }
		public Double totServs { get; set; }
		public Decimal vrAbono { get; set; }
		public Decimal vrCopagosDet { get; set; }
		public Decimal vrCuotaMod { get; set; }
		public Decimal vrIva { get; set; }
		public Decimal vrNotaCred { get; set; }
		public Decimal vrNotaDeb { get; set; }
		public Double vrTotBrutoDet { get; set; }
		public Decimal vrTotDescDet { get; set; }
		public Decimal vrTotNetoDet { get; set; }
		public Decimal vrGlosa { get; set; }
		public Decimal vrAceptaIPS { get; set; }
		public Decimal vrPagar { get; set; }
		public Decimal vrRecobro { get; set; }
		public Decimal vrAsumir { get; set; }
		public Decimal vrReiterar { get; set; }		
	}
}

