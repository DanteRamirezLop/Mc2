using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirEspfiltro : MonoBehaviour
{

    public string URL;
    public string Id_Foranea;
    public string id_buscar;

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(EspfiltroOnReponse(Id_Foranea));
    }

    private IEnumerator EspfiltroOnReponse(string Id_Foranea)
    {
        //using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "espfiltro"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);

            }
            else
            {
                int Cantidad;
                ListaEspfiltro listaEspfiltros = JsonUtility.FromJson<ListaEspfiltro>(req.downloadHandler.text);
                Cantidad = listaEspfiltros.espfiltros.Count;

                if (Cantidad != 0)
                {
                    listaEspfiltros.CargarEspfiltro();
                }
                else
                {
                    Debug.Log("No hay ductos");
                }
            }
        }
    } 
    
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



