using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

    [System.Serializable]
    public class Ducto
    {
        public int id;
        public double longitud;
        public int paso;
        public int dibujar;
        public int idDucto;
        public int tipo;
        public string nombre;
        public double dimA;
        public double dimB;
        public double flujoCFM;
        public double damAb100;
        public double damCer10;
        public double damCer50;
        public double tranRec;
        public double conVen;
        public double lumAli;
        public bool estado;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}",
            id, longitud, paso, dibujar,idDucto, tipo, nombre, dimA, dimB, flujoCFM, damAb100, damCer10, damCer50, tranRec, conVen, lumAli,estado);
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
        public void ObtenerDucto(List<Ducto> datos)
        {
            foreach (Ducto atributo in ductos)
            {
                datos.Add(atributo);
            }
        }
    }
