using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;

public class ListarMenu : MonoBehaviour {

    public string URL;
    private List<GameObject> coleccionBotones;
    public GameObject PrefabButtonCarg;
    public GameObject PrefabButtonElim;
    public GameObject PrefabText;
    public GameObject Ancla;

    public int Cantidad;

    private Dictionary<string, string> localizedText;

    void Start()
    {
        coleccionBotones = new List<GameObject>();
        RefreshProyectos();
    }
    public void RefreshProyectos()
    {
        foreach (var item in coleccionBotones)
        {
            Destroy(item);
        }
        coleccionBotones.Clear();
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

                float posY = 0.0f;

                foreach (var pr in listaProyectos.proyectos)
                {
                    CrearControles(posY,pr);
                    posY += 35;
                }
            }
        }
    }
    private void CrearControles(float ejey, Proyecto pr)
    {
        GameObject textoClon = Instantiate(PrefabText);
        PosisionarControles(textoClon, ejey, 5, RectTransform.Edge.Left);
        textoClon.GetComponent<Text>().text = pr.nombre;

        GameObject CargaClon = Instantiate(PrefabButtonCarg);
        CargaClon.GetComponent<Cargar>().IdProyecto = pr.id;
        PosisionarControles(CargaClon, ejey, 70, RectTransform.Edge.Right);
        
        GameObject EliminarClon = Instantiate(PrefabButtonElim);
        PosisionarControles(EliminarClon, ejey, 10, RectTransform.Edge.Right);

        coleccionBotones.Add(textoClon);
        coleccionBotones.Add(CargaClon);
        coleccionBotones.Add(EliminarClon);
    }
    private void PosisionarControles(GameObject control, float ejey, float ejex, RectTransform.Edge edge)
    {
        control.transform.SetParent(Ancla.transform);
        RectTransform cached = control.GetComponent<RectTransform>();
        cached.SetInsetAndSizeFromParentEdge(edge, ejex, cached.sizeDelta.x);
        cached.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, ejey, 30);
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
