using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
    
    [System.Serializable]
    public class Espfiltro
    {
        public int idEquip;
        public int idFiltro;
        public bool estado;

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", idEquip, idFiltro,estado);
        }
    }

    [System.Serializable]
    public class ListaEspfiltro
    {
        public List<Espfiltro> espfiltros;

        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarEspfiltro(List<Espfiltro> datos)
        {
            foreach (Espfiltro atributo in espfiltros)
            {
                datos.Add(atributo);
            }
        }

    }



