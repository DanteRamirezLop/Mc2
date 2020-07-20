using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirDuctopass : MonoBehaviour
{

    public string URL;
    public string Id_Foranea;
    public string id_buscar;

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(DuctopassOnReponse(Id_Foranea));
    }

    private IEnumerator DuctopassOnReponse(string Id_Foranea)
    {
        //using (UnityWebRequest req = UnityWebRequest.Get(URL + "ductoex/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "ductopass"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);

            }
            else
            {

                int Cantidad;
                ListaDuctopasss listaDuctopasss = JsonUtility.FromJson<ListaDuctopasss>(req.downloadHandler.text);
                Cantidad = listaDuctopasss.ductopasss.Count;

                if (Cantidad != 0)
                {
                    listaDuctopasss.CargarDuctopass(id_buscar);
                }
                else
                {
                    Debug.Log("No hay ductos");
                }
            }
        }
    }	
	

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
