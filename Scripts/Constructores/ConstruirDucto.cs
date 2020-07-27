using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConstruirDucto : MonoBehaviour{}	
	
    [System.Serializable]
    public class Ducto
    {
        public string id;
        public string longitud;
        public string paso;
        public string dibujar;
        //-------
        public string idDucto2;
        public string ccx;
        public string ccy;
        public string ccz;
        public string paso2;
        public string dibujar2;
        /*
        public string idDucto;
        public string tipo;
        public string nombre;
        public string dimA;
        public string dimB;
        public string flujoCFM;
        public string damAb100;
        public string damCer10;
        public string damCer50;
        public string tranRec;
        public string conVen;
        public string lumAli;*/

        public override string ToString()
        {
            //return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}",
            //id, longitud, paso, dibujar, idDucto2, ccx, ccy, ccz, paso2, dibujar2,idDucto, tipo, nombre, dimA, dimB, flujoCFM, damAb100, damCer10, damCer50, tranRec, conVen, lumAli);
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", id, longitud, paso, dibujar, idDucto2, ccx, ccy, ccz, paso2, dibujar2);
        }
    }

    [System.Serializable]
    public class ListaDucto
    {
        public List<Ducto> ductos;
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarDucto(List<string> datos)
        {
            foreach (Ducto ducto in ductos)
            {
                datos.Add(ducto.id);
                datos.Add(ducto.longitud);
                datos.Add(ducto.paso);
                datos.Add(ducto.dibujar);
                //------
                datos.Add(ducto.idDucto2);
                datos.Add(ducto.ccx);
                datos.Add(ducto.ccy);
                datos.Add(ducto.ccz);
                datos.Add(ducto.paso2);
                datos.Add(ducto.dibujar2);
                /*
                datos.Add(ducto.idDucto);
                datos.Add(ducto.tipo);
                datos.Add(ducto.nombre);
                datos.Add(ducto.dimA);
                datos.Add(ducto.dimB);
                datos.Add(ducto.flujoCFM);
                datos.Add(ducto.damAb100);
                datos.Add(ducto.damCer10);
                datos.Add(ducto.damCer50);
                datos.Add(ducto.tranRec);
                datos.Add(ducto.conVen);
                datos.Add(ducto.lumAli);*/
            }
        }

    }
