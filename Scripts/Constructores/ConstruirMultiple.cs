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
    public string id_buscar;

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(MultipleOnReponse(Id_Foranea));
    }

    private IEnumerator MultipleOnReponse(string Id_Foranea)
    {
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
                    listaMultiples.CargarMultiple(id_buscar);
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

        public void CargarMultiple(string id_buscar)
        {
            foreach (Multiple multiple in multiples)
            {

                if (id_buscar == multiple.id)
                {
                    Debug.Log(multiple.giroX);
                    Debug.Log(multiple.giroY);
                }

            }
        }
    }
}
