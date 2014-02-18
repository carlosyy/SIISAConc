using System.Data;
using System.Text;
using DataAccess;
using Entities;
using System;

namespace DataManagement
{
    public class DM_Notes
    {
        readonly SQLConn oDataAccess = new SQLConn();

				public Int32 AddNotes(notesEntidad notes)
        {
            Int32 retorno = 0;

						StringBuilder sbNotes = new StringBuilder();
            {
                sbNotes.Append("INSERT INTO notasAtencion(");               
                sbNotes.Append(", idDatosUS");
                sbNotes.Append(", nota");
                sbNotes.Append(", codServ");
                sbNotes.Append(", codDx");
                sbNotes.Append(")");
                sbNotes.Append(" VALUES(");
                sbNotes.Append("'" + notes.idDatosUS + "'");
                sbNotes.Append(", '" + notes.nota + "'");
                sbNotes.Append(", '" + notes.codServ + "'");
                sbNotes.Append(", '" + notes.codDx + "'");
                sbNotes.Append(")");

                try
                {
                    oDataAccess.open();
                    retorno = oDataAccess.executeNonQuery(CommandType.Text, sbNotes.ToString());

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
