using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruirMetradoex : MonoBehaviour
{

    [System.Serializable]
    public class Metradoex
    {
        public string id;
        public string idEquipo;
        public string dima;
        public string dimb;
        public string tipo;
        public string multi;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", id, idEquipo, dima, dimb, tipo, multi);
        }
    }

    [System.Serializable]
    public class ListaMetradoex
    {

        public List<Metradoex> metradoexs;

        public void CargarMetradoex(string id_buscar)
        {
            foreach (Metradoex metradoex in metradoexs)
            {

                if (id_buscar == metradoex.id)
                {
                    Debug.Log(metradoex.idEquipo);
                    Debug.Log(metradoex.dima);
                    Debug.Log(metradoex.dimb);
                    Debug.Log(metradoex.tipo);
                    Debug.Log(metradoex.multi);
                }

            }
        }
    }
}
