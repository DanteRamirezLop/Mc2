using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirMetradoex : MonoBehaviour
{
    public string URL;
    public string Id_Foranea;
    public string id_buscar;

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(MetradoexOnReponse(Id_Foranea));
    }

    private IEnumerator MetradoexOnReponse(string Id_Foranea)
    {
        //using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "metradoex"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);

            }
            else
            {

                int Cantidad;
                ListaMetradoex listaMetradoexs = JsonUtility.FromJson<ListaMetradoex>(req.downloadHandler.text);
                Cantidad = listaMetradoexs.metradoexs.Count;

                if (Cantidad != 0)
                {
                    listaMetradoexs.CargarMetradoex(id_buscar);
                }
                else
                {
                    Debug.Log("No hay ductos");
                }
            }
        }
    }	



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
