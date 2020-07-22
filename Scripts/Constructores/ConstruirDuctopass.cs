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
	
	 private List<string> aux = new List<string>();

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(DuctopassOnReponse(Id_Foranea));
    }


    public List<string> DatosDuctopass(string id_busqueda) {
        List<string> datosDuctopass = new List<string>();
        int cont = 0;
        int varAux = 0 ;
        bool bandera = false;

        foreach (string item in aux)
        {
            if (varAux == cont)
            {
                if (id_busqueda == item){
                    bandera = true;
                }else
                    bandera = false;
                varAux = varAux + 6;
            }

            if (bandera) {
                datosDuctopass.Add(item);
            }
            cont++;
            
        }
        return datosDuctopass;
    }
	
	
	
    private IEnumerator DuctopassOnReponse(string Id_Foranea)
    {
        List<string> datos = new List<string>();
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
                    listaDuctopasss.CargarDuctopass(datos);
					aux = datos;
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

     public void CargarDuctopass(List<string> datos)
     {
		foreach (Ductopass ductopass in ductopasss) {
			
			
					datos.Add(ductopass.ccx);
					datos.Add(ductopass.ccy);
					datos.Add(ductopass.ccz);
					datos.Add(ductopass.paso);
					datos.Add(ductopass.dibujar);

		}
	 }
    
}

}
