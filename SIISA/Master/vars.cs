using System.Data;
using Entities;
using System;

namespace SIISAConc.Master
{
    public class vars
    {
        public Meses meses = null;
        public String mesUsuario = null; 
        private static vars _singleton = null;

        public vars()
        {
            /*if (_singleton == null)
            {
                _singleton = new Rips();
            }*/
        }


        public static vars GetInstance()
        {
            if (_singleton == null)
            {
                _singleton = new vars();
            }
            return (_singleton);
        }
    }
}