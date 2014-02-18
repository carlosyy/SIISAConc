using System.Collections;
using System.Web;
using System.Text;
using System;
using System.Web.UI;

namespace Business
{
    public class MessageBox
    {
        private static Hashtable m_executingPages = new Hashtable();
        private static Int32 _tipoAlerta;
        private static Boolean _autoOcultar;
        private static String _elemento;
        private static String _posicion;
        //Int32 tipoAlerta = 1;
        private MessageBox() { }

        /// <summary>TipoAlerta
        /// 1=error, 2=ok, 3=warning, 4=info        
        /// </summary>


        public static void show(String sMessage, Int32 tipoAlerta = 1, Boolean autoOcultar = true, String elemento="", String posicion ="")
        {
            _tipoAlerta = tipoAlerta;
            _autoOcultar = autoOcultar;
            _elemento = elemento;
            _posicion = posicion;
            // If this is the first time a page has called this method then

            if (!m_executingPages.Contains(HttpContext.Current.Handler))
            {
                // Attempt to cast HttpHandler as a Page.

                Page executingPage = HttpContext.Current.Handler as Page;

                if (executingPage != null)
                {
                    // Create a Queue to hold one or more messages.

                    Queue messageQueue = new Queue();

                    // Add our message to the Queue

                    messageQueue.Enqueue(sMessage);

                    // Add our message queue to the hash table. Use our page reference

                    // (IHttpHandler) as the key.

                    m_executingPages.Add(HttpContext.Current.Handler, messageQueue);

                    // Wire up Unload event so that we can inject 

                    // some JavaScript for the alerts.

                    executingPage.Unload += new EventHandler(ExecutingPage_Unload);
                }
            }
            else
            {
                // If were here then the method has allready been 

                // called from the executing Page.

                // We have allready created a message queue and stored a

                // reference to it in our hastable. 

                Queue queue = (Queue)m_executingPages[HttpContext.Current.Handler];

                // Add our message to the Queue

                queue.Enqueue(sMessage);
            }
        }


        // Our page has finished rendering so lets output the

        // JavaScript to produce the alert's

        private static void ExecutingPage_Unload(object sender, EventArgs e)
        {
            // Get our message queue from the hashtable

            Queue queue = (Queue)m_executingPages[HttpContext.Current.Handler];

            if (queue != null)
            {
                StringBuilder sb = new StringBuilder();

                // How many messages have been registered?

                int iMsgCount = queue.Count;

                // Use StringBuilder to build up our client slide JavaScript.

                sb.Append("<script language='javascript'>");

                // Loop round registered messages

                String sMsg;
                while (iMsgCount-- > 0)
                {
                    sMsg = (String)queue.Dequeue();
                    sMsg = sMsg.Replace("\n", "\\n");
                    sMsg = sMsg.Replace("\"", "'");
                    
                    if (_elemento != "")
                    {
                        sb.Append("var _control = document.getElementById(" + _elemento + ");");
                        sb.Append("$(_control)");
                    }
                    else
                    {
                        sb.Append("$");
                    }

                    sb.Append(".notify('" + sMsg + "', ");
                    
                    String className = (_tipoAlerta == 1
                            ? "error"
                            : _tipoAlerta == 2 ? "success" : _tipoAlerta == 3 ? "warn" : _tipoAlerta == 4 ? "info" : "");

                    sb.Append(" { className:'" + className + "' ");

                    if (!_autoOcultar)
                    {
                        sb.Append(", autoHide: false");
                    }

                    if (_posicion != "")
                    {
                        sb.Append(", position: '" + _posicion + "'");
                    }
                    sb.Append(" } );");
                }
                
                // Close our JS

                sb.Append(@"</script>");

                // Were done, so remove our page reference from the hashtable

                m_executingPages.Remove(HttpContext.Current.Handler);

                // Write the JavaScript to the end of the response stream.

                HttpContext.Current.Response.Write(sb.ToString());
            }
        }
    }
}