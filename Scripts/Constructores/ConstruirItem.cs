using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirItem : MonoBehaviour
{
    public string URL;
    public string Id_Foranea;
   private List<string> aux = new List<string>();

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(ItemOnReponse(Id_Foranea));
    }

	
    public List<string> DatosItem(string id_busqueda) {
        List<string> datosItem = new List<string>();
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
                varAux = varAux + 4;
            }

            if (bandera) {
                datosItem.Add(item);
            }
            cont++;
            
        }
        return datosItem;
    }
	
	
    private IEnumerator ItemOnReponse(string Id_Foranea)
    {
        List<string> datos = new List<string>();
		//using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "item"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);

            }
            else
            {
                int Cantidad;
                ListaItem listaItems = JsonUtility.FromJson<ListaItem>(req.downloadHandler.text);
                Cantidad = listaItems.items.Count;

                if (Cantidad != 0)
                {
                    listaItems.CargarItem(datos);
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
    public class Item
    {
        public string id;
        public string idItem;
        public string idEquipo;
        public string conexion;


        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", id, idItem, idEquipo, conexion);
        }
    }

    [System.Serializable]
    public class ListaItem
    {

        public List<Item> items;

        public void CargarItem(List<string> datos)
        {
            foreach (Item item in items)
            {

                    datos.Add(item.idItem);
                    datos.Add(item.idEquipo);
                    datos.Add(item.conexion);

            }
        }
    }
}
