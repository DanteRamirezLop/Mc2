using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirDuctoex : MonoBehaviour
{

    public string URL;
    public string Id_Foranea;
	private List<string> aux = new List<string>();
	
    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(DuctoexOnReponse(Id_Foranea));
    }

    public List<string> DatosDuctoex(string id_busqueda)
    {
        List<string> datosDuctoex = new List<string>();
        int cont = 0;
        int varAux = 0;
        bool bandera = false;

        foreach (string item in aux)
        {
            if (varAux == cont)
            {
                if (id_busqueda == item)
                {
                    bandera = true;
                }
                else
                    bandera = false;
                varAux = varAux + 12;
            }

            if (bandera)
            {
                datosDuctoex.Add(item);
            }
            cont++;

        }
        return datosDuctoex;

    }
	
    private IEnumerator DuctoexOnReponse(string Id_Foranea)
    {
        List<string> datos = new List<string>();
		//using (UnityWebRequest req = UnityWebRequest.Get(URL + "ductoex/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "ductoex"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);
            }
            else
            {
                int Cantidad;
                ListaDuctoexs listaDuctoexs = JsonUtility.FromJson<ListaDuctoexs>(req.downloadHandler.text);
                Cantidad = listaDuctoexs.ductoexs.Count;

                if (Cantidad != 0)
                {
                    listaDuctoexs.CargarDuctoex(datos);
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

     public void CargarDuctoex(List<string> datos)
     {
		foreach (Ductoex ductoex in ductoexs) {
			
			
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
	
	
}
