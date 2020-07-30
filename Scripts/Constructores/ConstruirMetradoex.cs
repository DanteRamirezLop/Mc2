using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;	

    [System.Serializable]
    public class Metradoex
    {
        public int id;
        public int idEquipo;
        public int dima;
        public int dimb;
        public int tipo;
        public double multi;
        public bool estado;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}", id, idEquipo, dima, dimb, tipo, multi,estado);
        }
    }

    [System.Serializable]
    public class ListaMetradoex
    {
        public List<Metradoex> metradoexs;
   
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarMetradoex(List<Metradoex> datos)
        {
            foreach (Metradoex atributo in metradoexs)
            {
                datos.Add(atributo);
            }
        }		
    }

