using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirMetradoex : MonoBehaviour
{
    public string URL;
    public string Id_Foranea;
    private List<string> aux = new List<string>();

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(MetradoexOnReponse(Id_Foranea));
    }


    public List<string> DatosMetradoex (string id_busqueda) {
        List<string> datosMetradoex = new List<string>();
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
                datosMetradoex .Add(item);
            }
            cont++;
            
        }
        return datosMetradoex ;
    }
	
	
    private IEnumerator MetradoexOnReponse(string Id_Foranea)
    {
		List<string> datos = new List<string>();
	   //using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "metradoex"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);

            }
            else
            {

                int Cantidad;
                ListaMetradoex listaMetradoexs = JsonUtility.FromJson<ListaMetradoex>(req.downloadHandler.text);
                Cantidad = listaMetradoexs.metradoexs.Count;

                if (Cantidad != 0)
                {
                    listaMetradoexs.CargarMetradoex(datos);
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

        public void CargarMetradoex(List<string> datos)
        {
            foreach (Metradoex metradoex in metradoexs)
            {

                    datos.Add(metradoex.idEquipo);
                    datos.Add(metradoex.dima);
                    datos.Add(metradoex.dimb);
                    datos.Add(metradoex.tipo);
                    datos.Add(metradoex.multi);

            }
        }
    }
}
