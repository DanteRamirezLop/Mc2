using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirDucto : MonoBehaviour
{

	public string URL;
    public string Id_Foranea;
	public string id_buscar;
	
    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(DuctoOnReponse(Id_Foranea));
    }

	 private IEnumerator DuctoOnReponse(string Id_Foranea)
    {
        //using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/" + Id_Foranea))
      using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto"))
      {
          yield return req.SendWebRequest();

         if (!string.IsNullOrEmpty(req.error)){
            Debug.Log(req.error);

         }else {

			int Cantidad;
            ListaDuctos listaDuctos = JsonUtility.FromJson<ListaDuctos>(req.downloadHandler.text);
            Cantidad = listaDuctos.ductos.Count;

            if (Cantidad != 0){
                listaDuctos.CargarDuctos(id_buscar);
            }
             else {
                 Debug.Log("No hay ductos");
             }
        }
      }
    }	
	
    [System.Serializable]
    public class Ducto
    {
        public string id;
        public string longitud;
        public string paso;
        public string dibujar;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", id, longitud, paso, dibujar);
        }
    }
	
	[System.Serializable]
    public class ListaDuctos {
		
	 public List<Ducto> ductos;

     public void CargarDuctos(string id_buscar)
     {
		foreach (Ducto ducto in ductos) {
			
			if (id_buscar == ducto.id) {
					Debug.Log(ducto.longitud);
					Debug.Log(ducto.paso);
					Debug.Log(ducto.dibujar);

			}

		}
	 }
    }
}
