using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;

public class ListarMenu : MonoBehaviour {

    public string URL;
    public GameObject PrefabButtonCarg;
    public GameObject PrefabButtonElim;
    public GameObject PrefabText;
    public GameObject Ancla;

    public int Cantidad;

    private Dictionary<string, string> localizedText;

    void Start()
    {
       StartCoroutine(ProyectoOnReponse());
    }

    private IEnumerator ProyectoOnReponse()
    {
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "proyecto"))
        {

            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            { 
                Debug.Log(req.error);
            }
            else {

                ListaProyectos listaProyectos = JsonUtility.FromJson<ListaProyectos>(req.downloadHandler.text);
                string ArchivoProyectos = JsonUtility.ToJson(listaProyectos);
                Cantidad = listaProyectos.proyectos.Count;

                float posRang = 0.0f;
                float posY = 30.0f;

                for (int i = 0; i < Cantidad; i++)
                {
                    posRang = posY * (i + 1);
                    CargarBotonEliminar(posRang);

                    //----boton cargar-----
                    GameObject BotonClon = Instantiate(PrefabButtonCarg, Ancla.transform.position, Ancla.transform.rotation) as GameObject;
                    BotonClon.transform.SetParent(Ancla.transform);
                    BotonClon.GetComponent<RectTransform>().anchoredPosition = new Vector2(320.0f, -posRang);

                    //----- label-----
                    GameObject TextoClon = Instantiate(PrefabText, Ancla.transform.position, Ancla.transform.rotation) as GameObject;
                    TextoClon.transform.SetParent(Ancla.transform);
                    TextoClon.GetComponent<RectTransform>().anchoredPosition = new Vector2(70.0f, -posRang); 
                    listaProyectos.CargarText(TextoClon, i, BotonClon);
                }
            }
        }
    }

    private void CargarBotonEliminar(float posRang)
    {
        GameObject BotonClon = Instantiate(PrefabButtonElim, Ancla.transform.position, Ancla.transform.rotation) as GameObject;
        BotonClon.transform.SetParent(Ancla.transform);
        BotonClon.GetComponent<RectTransform>().anchoredPosition = new Vector2(470.0f, -posRang);
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
                  Texto.GetComponent<Text>().text = proyecto.nombre;
                  BotonClon.GetComponent<Cargar>().IdProyecto = proyecto.id; 
              }
              count++;
          }
      }
 }
    
   
}
