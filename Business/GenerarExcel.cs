using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Business
{
    public class GenerarExcel
    {
        StreamWriter w;
        StringBuilder html = new StringBuilder();
        public Int32 crearFichero(String ruta)
        {
            FileStream fs = new FileStream(ruta, FileMode.Create, FileAccess.ReadWrite);
            w = new StreamWriter(fs);
            EscribeCabecera();            
            return 0;
        }

        public void EscribeCabecera()
        {
            html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD  HTML 4.0 Transitional//EN\">");
            html.Append("<html>");
            html.Append("  <head>");
            html.Append("<title>Auditoria Detallada por Radicado</title>");
            html.Append("<meta http-equiv=\"Content-Type\"  content=\"text/html; charset=UTF-8\" />");
            html.Append("  </head>");
            html.Append("<body>");
            html.Append("<p>");
            html.Append("<table>");            
        }

        public void EscribePiePagina()
        {
						html.Append("  </table>");
						html.Append("</p>");
						html.Append(" </body>");
						html.Append("</html>");
						w.Write(html.ToString());
            w.Close();
        }

        public void setCelda(String valorCelda, String estilo)
        {
            html.Append("<td " + estilo + ">" + valorCelda + "</td>");
        }

        public void cerrarLinea()
        {
            html.Append("</tr>");
            w.Write(html.ToString());
            html.Clear();
        }

        public void nuevaLinea()
        {
            html.Append("<tr>");
        }
    }
}
