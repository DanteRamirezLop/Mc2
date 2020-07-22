using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirRejilla : MonoBehaviour
{

    public string URL;
    public string Id_Foranea;
    private List<string> aux = new List<string>();

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(RejillaOnReponse(Id_Foranea));
    }

	
    public List<string> DatosRejilla(string id_busqueda) {
        List<string> datosRejilla = new List<string>();
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
                varAux = varAux + 3;
            }

            if (bandera) {
                datosRejilla.Add(item);
            }
            cont++;
            
        }
        return datosRejilla;
    }
	
	
    private IEnumerator RejillaOnReponse(string Id_Foranea)
    {
        List<string> datos = new List<string>();
		//using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "rejilla"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);

            }
            else
            {

                int Cantidad;
                ListaRejilla listaRejillas = JsonUtility.FromJson<ListaRejilla>(req.downloadHandler.text);
                Cantidad = listaRejillas.rejillas.Count;

                if (Cantidad != 0)
                {
                    listaRejillas.CargarRejilla(datos);
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
    public class Rejilla
    {
        public string id;
        public string nombre;
        public string cfm;

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", id, nombre, cfm);
        }
    }

    [System.Serializable]
    public class ListaRejilla
    {

        public List<Rejilla> rejillas;

        public void CargarRejilla(List<string> datos)
        {
            foreach (Rejilla rejilla in rejillas)
            {

                    datos.Add(rejilla.nombre);
                    datos.Add(rejilla.cfm);
            }
        }

    }
}
