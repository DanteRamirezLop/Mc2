using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruirDuctoex : MonoBehaviour
{


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
    public class ListaDuctoexs {
		
	 public List<Ductoex> ductoexs;

     public void CargarDuctoexs(string id_buscar)
     {
		foreach (Ductoex ductoex in ductoexs) {
			
			if (id_buscar == ductoex.idDucto) {
					Debug.Log(ductoex.tipo);
					Debug.Log(ductoex.nombre);
					Debug.Log(ductoex.dimA);
					Debug.Log(ductoex.dimB);
					Debug.Log(ductoex.flujoCFM);
					Debug.Log(ductoex.damAb100);
					Debug.Log(ductoex.damCer10);
					Debug.Log(ductoex.damCer50);
					Debug.Log(ductoex.tranRec);
					Debug.Log(ductoex.conVen);
					Debug.Log(ductoex.lumAli);

			}

		}
	 }
    }
	
	
}
