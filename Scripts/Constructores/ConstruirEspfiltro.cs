using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruirEspfiltro : MonoBehaviour
{
    [System.Serializable]
    public class Espfiltro
    {
        public string idEquip;
        public string idFiltro;

        public override string ToString()
        {
            return string.Format("{0},{1", idEquip, idFiltro);
        }
    }

    [System.Serializable]
    public class ListaEspfiltro
    {

        public List<Espfiltro> espfiltros;

        public void CargarEspfiltro()
        {
            foreach (Espfiltro espfiltro in espfiltros)
            {

                Debug.Log(espfiltro.idEquip);
                Debug.Log(espfiltro.idFiltro);



            }
        }

    }
}



