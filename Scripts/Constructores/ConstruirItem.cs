using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

    [System.Serializable]
    public class Item
    {
        public int id;
        public int idItem;
        public int idEquipo;
        public int conexion;
        public bool estado;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}", id, idItem, idEquipo, conexion,estado);
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
        public void CargarItem(List<Item> datos)
        {
            foreach (Item atributo in items)
            {
                datos.Add(atributo);
            }
        }
		
    }
