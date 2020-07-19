using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruirDuctopass : MonoBehaviour
{

    [System.Serializable]
    public class Ductopass
    {
        public string idDucto;
        public string ccx;
        public string ccy;
        public string ccz;
        public string paso;
        public string dibujar;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", idDucto,ccx, ccy, ccz, paso,dibujar);
        }
    }
	
	
	[System.Serializable]
    public class ListaDuctopasss {
		
	 public List<Ductopass> ductopasss;

     public void CargarDuctopass(string id_buscar)
     {
		foreach (Ductopass ductopass in ductopasss) {
			
			if (id_buscar == ductopass.idDucto) {
					Debug.Log(ductopass.ccx);
					Debug.Log(ductopass.ccy);
					Debug.Log(ductopass.ccz);
					Debug.Log(ductopass.paso);
					Debug.Log(ductopass.dibujar);

			}

		}
	 }
    
}

}
