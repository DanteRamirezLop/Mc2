using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruirItem : MonoBehaviour
{

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
