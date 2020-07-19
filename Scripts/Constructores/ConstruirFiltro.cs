using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruirFiltro : MonoBehaviour
{
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

        public void CargarFiltro(string id_buscar)
        {
            foreach (Filtro filtro in filtros)
            {

                if (id_buscar == filtro.id)
                {
                    Debug.Log(filtro.nombre);
                }

            }
        }
    }
}
