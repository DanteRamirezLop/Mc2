using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirDuctoex : MonoBehaviour{ }

    
    [System.Serializable]
    public class Ductoex
    {
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
        public string lumAli;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", idDucto, tipo, nombre, dimA, dimB, flujoCFM, damAb100, damCer10, damCer50, tranRec, conVen, lumAli);
        }
    }
	
	[System.Serializable]
    public class ListaDuctoex {
		
	 public List<Ductoex> ductoexs;
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
     public void CargarDuctoex(List<string> datos)
     {
		foreach (Ductoex ductoex in ductoexs) {
			
			        datos.Add(ductoex.idDucto);
					datos.Add(ductoex.tipo);
					datos.Add(ductoex.nombre);
					datos.Add(ductoex.dimA);
					datos.Add(ductoex.dimB);
					datos.Add(ductoex.flujoCFM);
					datos.Add(ductoex.damAb100);
					datos.Add(ductoex.damCer10);
					datos.Add(ductoex.damCer50);
					datos.Add(ductoex.tranRec);
					datos.Add(ductoex.conVen);
					datos.Add(ductoex.lumAli);
		}
	 }
    }
	
