using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirFiltro : MonoBehaviour
{

    public string URL;
    public string Id_Foranea;
    public string id_buscar;

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(FiltroOnReponse(Id_Foranea));
    }

    private IEnumerator FiltroOnReponse(string Id_Foranea)
    {
        //using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "filtro"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);

            }
            else
            {
                int Cantidad;
                ListaFiltro listaFiltros = JsonUtility.FromJson<ListaFiltro>(req.downloadHandler.text);
                Cantidad = listaFiltros.filtros.Count;

                if (Cantidad != 0)
                {
                    listaFiltros.CargarFiltro(id_buscar);
                }
                else
                {
                    Debug.Log("No hay ductos");
                }
            }
        }
    } 
    
    
    
    [System.Serializable]
    public class Filtro
    {
        public string id;
        public string nombre;


        public override string ToString()
        {
            return string.Format("{0},{1}", id, nombre);
        }
    }

    [System.Serializable]
    public class ListaFiltro
    {

        public List<Filtro> filtros;

        public void CargarFiltro(string id_buscar)
        {
            foreach (Filtro filtro in filtros)
            {

                if (id_buscar == filtro.id)
                {
                    Debug.Log(filtro.nombre);
                }

            }
        }
    }
}
