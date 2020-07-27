using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConstruirFiltro : MonoBehaviour{} 
       
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
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarFiltro(List<string> datos)
        {
            foreach (Filtro filtro in filtros)
            {
					datos.Add(filtro.id);
                    datos.Add(filtro.nombre);
            }
        }
    }