using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConstruirMetradoex : MonoBehaviour{}	

    [System.Serializable]
    public class Metradoex
    {
        public string id;
        public string idEquipo;
        public string dima;
        public string dimb;
        public string tipo;
        public string multi;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", id, idEquipo, dima, dimb, tipo, multi);
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
        public void CargarMetradoex(List<string> datos)
        {
            foreach (Metradoex metradoex in metradoexs)
            {
					datos.Add(metradoex.id);
                    datos.Add(metradoex.idEquipo);
                    datos.Add(metradoex.dima);
                    datos.Add(metradoex.dimb);
                    datos.Add(metradoex.tipo);
                    datos.Add(metradoex.multi);

            }
        }		
    }

