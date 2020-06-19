using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;

public class ListarMenu : MonoBehaviour {

    public string URL;
    public GameObject PrefabButtonCarg;//PrefabButtonCarg
    public GameObject PrefabButtonElim;
    public GameObject PrefabText;
    public GameObject Ancla;

    public int Cantidad;

    private Dictionary<string, string> localizedText;

    void Start()
    {        
        if (Application.internetReachability != NetworkReachability.NotReachable) //validacion a internet reemplazar por validadcion al servidor
        {                                                                  
            WWW requestP = new WWW(URL + "proyecto");
            StartCoroutine(ProyectoOnReponse(requestP));
        }
    }

    private IEnumerator ProyectoOnReponse(WWW req)
    {
        yield return req;

        ListaProyectos listaProyectos = JsonUtility.FromJson<ListaProyectos>(req.text);
        string ArchivoProyectos = JsonUtility.ToJson(listaProyectos);
        PlayerPrefs.SetString("KeySaveProyectos", ArchivoProyectos);

        Cantidad = listaProyectos.proyectos.Count;

        float posRang = 0.0f;
        float posY = 45.0f;

        for (int i = 0; i < Cantidad; i++)
        {
            posRang = posY * (i + 1);
            //CargarBotonCargar(posRang);
            CargarBotonEliminar(posRang);

            //----boton cargar-----
            GameObject BotonClon = Instantiate(PrefabButtonCarg, Ancla.transform.position, Ancla.transform.rotation) as GameObject;
            BotonClon.transform.SetParent(Ancla.transform);
            BotonClon.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, -posRang);
           // BotonClon.GetComponent<Cargar>().Cod_id = "1";

            //----- label-----
            GameObject TextoClon = Instantiate(PrefabText, Ancla.transform.position, Ancla.transform.rotation) as GameObject;
            TextoClon.transform.SetParent(Ancla.transform);
            TextoClon.GetComponent<RectTransform>().anchoredPosition = new Vector2(-135.0f, -posRang);

            listaProyectos.CargarText(TextoClon, i, BotonClon);
        }

    }

    private void CargarBotonEliminar(float posRang)
    {
        GameObject BotonClon = Instantiate(PrefabButtonElim, Ancla.transform.position, Ancla.transform.rotation) as GameObject;
        BotonClon.transform.SetParent(Ancla.transform);
        BotonClon.GetComponent<RectTransform>().anchoredPosition = new Vector2(120.0f, -posRang);
    }

 
 [System.Serializable]
 public class Proyecto
 {
     public string id;
     public string nombre;

     public override string ToString()
     {
         return string.Format("{0},{1}", id, nombre);
     }
 }

 [System.Serializable]
 public class ListaProyectos
 {
     public List<Proyecto> proyectos;
     public void CargarText(GameObject Texto, int pos, GameObject BotonClon)
      {
          int count = 0;
          foreach (Proyecto proyecto in proyectos)
          {
              if (count == pos) 
              {
                  //Debug.Log(proyecto.nombre);
                  Texto.GetComponent<Text>().text = proyecto.nombre; 
                   //Debug.Log(proyecto.id);
                  BotonClon.GetComponent<Cargar>().Cod_id = proyecto.id;
              }
              count++;
          }
      }
 }
    
   
}
