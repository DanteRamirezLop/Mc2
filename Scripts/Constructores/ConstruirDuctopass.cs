using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

    [System.Serializable]
    public class Ductopass
    {
        public int idDucto;
        public float ccx;
        public float ccy;
        public float ccz;
        public int paso;
        public int dibujar;// boll
        public bool estado;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}", idDucto, ccx, ccy, ccz, paso, dibujar,estado);
        }
    }
	
	
	[System.Serializable]
    public class ListaDuctopass 
    {
	 public List<Ductopass> ductopasss;

     public void CargarDuctopass(List<Ductopass> datos)
     {
         foreach (Ductopass atributo in ductopasss)
         {
             datos.Add(atributo);
         }
	 }
	 
}

