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
    private List<string> aux = new List<string>();

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(FiltroOnReponse(Id_Foranea));
    }

	
    public List<string> DatosFiltro(string id_busqueda) {
        List<string> datosFiltro = new List<string>();
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
                varAux = varAux + 2;
            }

            if (bandera) {
                datosFiltro.Add(item);
            }
            cont++;
            
        }
        return datosFiltro;
    }
	
	
    private IEnumerator FiltroOnReponse(string Id_Foranea)
    {
         List<string> datos = new List<string>();
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
                    listaFiltros.CargarFiltro(datos);
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

        public void CargarFiltro(List<string> datos)
        {
            foreach (Filtro filtro in filtros)
            {

                    datos.Add(filtro.nombre);

            }
        }
    }
}
