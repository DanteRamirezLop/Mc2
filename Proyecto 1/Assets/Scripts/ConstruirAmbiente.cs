using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;

public class ConstruirAmbiente : MonoBehaviour {

    public string URL;
    public string Id_Foranea;

    public GameObject PrefabObj;
    public GameObject Ancla;

    private Dictionary<string, string> localizedText;

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
      //  if (Application.internetReachability != NetworkReachability.NotReachable) //validacion a internet reemplazar por validadcion al servidor
        //{
            WWW requestA = new WWW(URL + "ambiente/" + Id_Foranea);
            StartCoroutine(AmbienteOnReponse(requestA));
       // }
    }

    private IEnumerator AmbienteOnReponse(WWW req)
    {
        yield return req;

        int Cantidad;

        ListaAmbientes listaAmbientes = JsonUtility.FromJson<ListaAmbientes>(req.text);
        string ArchivoAmbientes = JsonUtility.ToJson(listaAmbientes);
        PlayerPrefs.SetString("KeySaveAmbientes", ArchivoAmbientes);

        Cantidad = listaAmbientes.ambientes.Count;


        float posRang = 0.0f;
        float posY = 40.0f;  // espacio entre ambientes

        Debug.Log(Cantidad);
        for (int i = 0; i < Cantidad; i++)
        {
            //******** parete de la construccion***********

            posRang = posY * (i + 1);

            GameObject AmbienteClon = Instantiate(PrefabObj, Ancla.transform.position, Ancla.transform.rotation) as GameObject;
            AmbienteClon.transform.SetParent(Ancla.transform);
            //AmbienteClon.GetComponent<RectTransform>().anchoredPosition = new Vector3(posRang, 0.0f, 0.0f);// new Vector2(-135.0f, 0.0f);
            AmbienteClon.transform.position = new Vector3(posRang, 0.0f, 0.0f);
            listaAmbientes.CargarAmbientes(AmbienteClon,i);

            //***********************
        }
        
    }

    [System.Serializable]
    public class Ambiente
    {
        public string id;
        public string idProyecto;
        public string nAmbiente;
        public string largo;
        public string ancho;
        public string altura;
        //public string area;
        //public string recambios;
        //public string flujo;
        //public string cfm;
        public string coordenadas;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}", id, idProyecto, nAmbiente, largo, ancho, altura, coordenadas);
        }
    }

    [System.Serializable]
    public class ListaAmbientes
    {
        public List<Ambiente> ambientes;

        public void CargarAmbientes(GameObject AmbienteClon, int num)
         {
             int count = 0;
             string Altura;
             string Largo;
             string Ancho;

             float varX = 0.0f;
             float varY = 0.0f;
             float varZ = 0.0f;

             foreach (Ambiente ambiente in ambientes)
             {
                 if (count == num)
                 {
                    //***Construir****
                       Altura = ambiente.altura;
                       Largo = ambiente.largo;
                       Ancho = ambiente.ancho;

                       varX = float.Parse(Ancho);
                       varY = float.Parse(Altura);
                       varZ = float.Parse(Largo);

                       AmbienteClon.transform.localScale = new Vector3(varX, varY, varZ);
                       Debug.Log(ambiente.coordenadas);
                       
                     //
                 }
                 count++;
             }
         }
    }








}
