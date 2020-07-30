using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
       
    [System.Serializable]
    public class Filtro
    {
        public int id;
        public string nombre;
        public bool estado;

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", id, nombre,estado);
        }
    }

    [System.Serializable]
    public class ListaFiltro
    {
        public List<Filtro> filtros;

        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarFiltro(List<Filtro> datos)
        {
            foreach (Filtro atributo in filtros)
            {
                datos.Add(atributo);
            }
        }
    }