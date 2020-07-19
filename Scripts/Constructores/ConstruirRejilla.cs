using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruirRejilla : MonoBehaviour
{
    [System.Serializable]
    public class Rejilla
    {
        public string id;
        public string nombre;
        public string cfm;

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", id, nombre, cfm);
        }
    }

    [System.Serializable]
    public class ListaRejilla
    {

        public List<Rejilla> rejillas;

        public void CargarRejilla(string id_buscar)
        {
            foreach (Rejilla rejilla in rejillas)
            {

                if (id_buscar == rejilla.id)
                {
                    Debug.Log(rejilla.nombre);
                    Debug.Log(rejilla.cfm);
                }

            }
        }

    }
}
