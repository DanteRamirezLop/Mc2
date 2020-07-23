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

    /// <summary>
    /// Rescata el Id del proyecto
    /// Ejecuta una corutina para traer lo datos de la API
    /// </summary>
    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(ItemOnReponse(Id_Foranea));
    }

    /// <summary>
    /// Filtra los datos por la varibale id_busqueda que es el ID de la tabla Equipov y los retorna en una variable List
    /// </summary>
    /// <param name="id_busqueda"></param> id de la tabla
    /// <returns></returns>
    public List<string> DatosItemId(string id_busqueda) {
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

	
	public List<string> DatosItem() {
        List<string> datosItem = new List<string>(aux);

        return datosItem;
    }
    /// <summary>
    /// Corutina que extrae los datos del servidor por medio de la URL y los trae en formato Json
    /// en la corrutina se trabaja con las clases [System.Serializable] para organizar y manejar los datos en funciones
    /// 
    /// </summary>
    /// <param name="Id_Foranea"></param>
    /// <returns></returns>
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
                    //*****utilizar los datos en este lugar si los necesitas al ejecutar el programa*****
                    //****Comentar el  listaItems.CargarItem(datos); si se necesita utilizar los datos en en el start y utilizar '  listaItems.CargarItemId'
                    // listaItems.CargarItemId(datos,"1");
                    listaItems.CargarItem(datos);
					aux = datos;
                    //
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
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarItem(List<string> datos)
        {
            foreach (Item item in items)
            {
					datos.Add(item.id);
                    datos.Add(item.idItem);
                    datos.Add(item.idEquipo);
                    datos.Add(item.conexion);

            }
        }
	 /// <summary>
     /// Asigna a la variable 'datos' los datos de la tabla filtrados por 'id_busqueda'
     /// </summary>
     /// <param name="datos"></param> variable por valor
     /// <param name="id_busqueda"></param> variable por referencia		
		public void CargarItemId(List<string> datos,string id_busqueda)
        {
            foreach (Item item in items)
            {
					datos.Add(item.id);
                    datos.Add(item.idItem);
                    datos.Add(item.idEquipo);
                    datos.Add(item.conexion);

            }
        }
		
    }
}
