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
	private List<string> aux = new List<string>();
	
    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(DuctoOnReponse(Id_Foranea));
    }

	
    public List<string> DatosDucto(string id_busqueda) {
        List<string> datosDucto = new List<string>();
        int cont = 0;
        int varAux = 0 ;
        bool bandera = false;

        foreach (string item in aux)
        {
            if (varAux == cont)
            {
                if (id_busqueda == item){
                    bandera = true;
                }else
                    bandera = false;
                varAux = varAux + 4;
            }

            if (bandera) {
                datosDucto.Add(item);
            }
            cont++;
            
        }
        return datosDucto;
    }
	

	 private IEnumerator DuctoOnReponse(string Id_Foranea)
    {
       List<string> datos = new List<string>();
	  //acceder a los datos por medio de la URL
      //using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/"+ Id_Foranea))
	  using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto"))
      {
         //validaciones de coneccion
         yield return req.SendWebRequest();

         if (!string.IsNullOrEmpty(req.error)){
            Debug.Log(req.error);

         }else {

			int Cantidad;
            //crear variables con las clases y asignarle los datos traidos de la API
            ListaDuctos listaDuctos = JsonUtility.FromJson<ListaDuctos>(req.downloadHandler.text);
            Cantidad = listaDuctos.ductos.Count;

            if (Cantidad != 0){

              listaDuctos.CargarDuctos(datos);
		      aux = datos;


            }
             else {
                 Debug.Log("No hay ductos");
             }
        }
      }
    }	
	
    //***** CLASES PARA ACCDER A LOS DATOS DE LA TABLA DUCTO**********
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
      // ********Fuincion para acceder a los datos y almacenarlos en la array datos*********
     public void CargarDuctos(List<string> datos)
     {
		foreach (Ducto ducto in ductos) {
			
              datos.Add(ducto.id);
              datos.Add(ducto.longitud);
              datos.Add(ducto.paso);
              datos.Add(ducto.dibujar);
		}
	 }
    }



}
