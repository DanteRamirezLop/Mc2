using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirMultiple : MonoBehaviour
{
    public string URL;
    public string Id_Foranea;
    private List<string> aux = new List<string>();

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(MultipleOnReponse(Id_Foranea));
    }

	
    public List<string> DatosMultiple(string id_busqueda) {
        List<string> datosMultiple = new List<string>();
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
                datosMultiple.Add(item);
            }
            cont++;
            
        }
        return datosMultiple;
    }
	
	
    private IEnumerator MultipleOnReponse(string Id_Foranea)
    {
        List<string> datos = new List<string>();
		//using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "multiple"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);

            }
            else
            {

                int Cantidad;
                ListaMultiple listaMultiples = JsonUtility.FromJson<ListaMultiple>(req.downloadHandler.text);
                Cantidad = listaMultiples.multiples.Count;

                if (Cantidad != 0)
                {
                    listaMultiples.CargarMultiple(datos);
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
    public class Multiple
    {
        public string id;
        public string giroX;
        public string giroY;

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", id, giroX, giroY);
        }
    }

    [System.Serializable]
    public class ListaMultiple
    {

        public List<Multiple> multiples;

        public void CargarMultiple(List<string> datos)
        {
            foreach (Multiple multiple in multiples)
            {
                    datos.Add(multiple.giroX);
                    datos.Add(multiple.giroY);
            }
        }
    }
}
