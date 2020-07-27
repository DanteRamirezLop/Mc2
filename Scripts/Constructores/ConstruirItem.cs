using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConstruirItem : MonoBehaviour{} 

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
		
    }
