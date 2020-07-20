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
    public string id_buscar;

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(ItemOnReponse(Id_Foranea));
    }

    private IEnumerator ItemOnReponse(string Id_Foranea)
    {
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
                    listaItems.CargarItem(id_buscar);
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

        public void CargarItem(string id_buscar)
        {
            foreach (Item item in items)
            {

                if (id_buscar == item.id)
                {
                    Debug.Log(item.idItem);
                    Debug.Log(item.idEquipo);
                    Debug.Log(item.conexion);
                }

            }
        }
    }
}
