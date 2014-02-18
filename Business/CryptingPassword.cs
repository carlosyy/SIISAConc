using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Business
{
   public class CryptingPassword
   {
      public String Texto { get;  set; }

        public String TextoEncript
        {
            get { return CriptText(); }
        }

        private String CriptText()
        {
           SHA512Cng objSha = new SHA512Cng();
           ASCIIEncoding encoding = new ASCIIEncoding();
           byte[] stream = null;
           StringBuilder sb = new StringBuilder();
           stream = objSha.ComputeHash(encoding.GetBytes(Texto));

           for(int i = 0; i < stream.Length; i++)
              sb.AppendFormat("{0:x2}", stream[i]);

           return sb.ToString();
        }
   }
}
