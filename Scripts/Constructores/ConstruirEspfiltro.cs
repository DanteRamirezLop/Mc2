using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConstruirEspfiltro : MonoBehaviour{} 
    
    [System.Serializable]
    public class Espfiltro
    {
        public string idEquip;
        public string idFiltro;

        public override string ToString()
        {
            return string.Format("{0},{1}", idEquip, idFiltro);
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
        public void CargarEspfiltro(List<string> datos)
        {
            foreach (Espfiltro espfiltro in espfiltros)
            {

                datos.Add(espfiltro.idEquip);
                datos.Add(espfiltro.idFiltro);

            }
        }

    }



