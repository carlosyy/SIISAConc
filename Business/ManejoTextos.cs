using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Business
{
    public class ManejoTextos
    {
        public static Int64 GetNumFactura(String factura)
        {
            String f = "";
            Int32 cantCero = 0;
            for (Int32 i = factura.Length - 1; i >= 0; i--)
            {
                char c = char.Parse(factura.Substring(i, 1));
                if ((((Int32)c) >= 48) && (((Int32)c) <= 57))
                {
                    f = c + f;
                }
                else
                {
                    i = 0;
                }
                if (((Int32)c) == 48)
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

        public static String GetPrefix(String factura)
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
                prefix = ManejoTextos.obtenerTexto(factura, ind + 1);
            }
            return (prefix == "" ? "NULL" : prefix);
        }



        public static String arregloRadicado(String radArreglo)
        {            
            StringBuilder rad = new StringBuilder();
            rad.Insert(rad.Length, radArreglo);

            while (rad.Length < 8)
            {
                rad.Insert(0, "0");
            }
            return rad.ToString();
        }

        public static String arregloFecha(String txtFecha)
        {
            String arregloFecha = String.Empty;
            arregloFecha = obtenerTexto(txtFecha, 2, 0) + "/" + obtenerTexto(txtFecha, 2, 2) + "/" + obtenerTexto(txtFecha, 4, 4);
            return arregloFecha;
        }

        public static DateTime arregloMesRad(String fecha)
        {
            Int16 mes = 0;
            Int16 anho = 0; 

            if(fecha.Length==6)
            {
                mes = Int16.Parse(obtenerTexto(fecha, 1));
                anho = Int16.Parse(obtenerTexto(fecha, 4,3));
            }
            else if (fecha.Length == 7)
            {
                mes = Int16.Parse(obtenerTexto(fecha, 2));
                anho = Int16.Parse(obtenerTexto(fecha, 4, 4));
            }
            else if (fecha.Length == 10)
            {
                mes = Int16.Parse(obtenerTexto(fecha, 2, 3));
                anho = Int16.Parse(obtenerTexto(fecha, 4, 6));
            }
            return DateTime.Parse("01/" + mes + "/" + anho);
            
        }
        
        public static String obtenerTexto(String Texto, Int32 caracteres, Int32 posicion = 0)
        {
            if (Texto.Length - (posicion + caracteres) < 0)
            {
                caracteres = caracteres - (caracteres - (Texto.Length - posicion));
            }
            String result = Texto.Substring(posicion, caracteres);
            return result;
        }

        public static String ValidarNulo(String valor)
        {
            if (valor != "" && valor != null && valor != "NULL")
                return valor;
            else
                return "0";
        }

        private static String key = "abcdefgh";

        public static String Encriptar(String texto)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform = tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }

        public static String Desencriptar(String textoEncriptado)
        {
            textoEncriptado = textoEncriptado.Replace(" ", "+");
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

            tdes.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        

    }
}
