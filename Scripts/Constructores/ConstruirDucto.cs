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

    /// <summary>
    /// Rescata el Id del proyecto
    /// Ejecuta una corutina para traer lo datos de la API
    /// </summary>
    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(DuctoOnReponse(Id_Foranea));
    }

    /// <summary>
    /// Filtra los datos por la varibale id_busqueda que es el ID de la tabla Equipov y los retorna en una variable List
    /// </summary>
    /// <param name="id_busqueda"></param> id de la tabla
    /// <returns></returns>
    public List<string> DatosDuctoId(string id_busqueda) {
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

	
	    public List<string> DatosDucto() {
          List<string> datosDucto = new List<string>(aux);
            return datosDucto;
        }
        
    
	
    /// <summary>
    /// Corutina que extrae los datos del servidor por medio de la URL y los trae en formato Json
    /// en la corrutina se trabaja con las clases [System.Serializable] para organizar y manejar los datos en funciones
    /// 
    /// </summary>
    /// <param name="Id_Foranea"></param>
    /// <returns></returns>
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

                //*****utilizar los datos en este lugar si los necesitas al ejecutar el programa*****
                //****Comentar el  listaDuctos.CargarDuctos(datos); si se necesita utilizar los datos en en el start y utilizar '  listaDuctos.CargarDuctosId'
                //llistaDuctos.CargarDuctosId(datos,"1");
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
    public class ListaDuctos
    {

        public List<Ducto> ductos;
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarDuctos(List<string> datos)
        {
            foreach (Ducto ducto in ductos)
            {

                datos.Add(ducto.id);
                datos.Add(ducto.longitud);
                datos.Add(ducto.paso);
                datos.Add(ducto.dibujar);
            }
        }

        public void CargarDuctosID(List<string> datos, string id_busqueda)
        {
            foreach (Ducto ducto in ductos)
            {

                if (id_busqueda == ducto.id)
                {
                    datos.Add(ducto.id);
                    datos.Add(ducto.longitud);
                    datos.Add(ducto.paso);
                    datos.Add(ducto.dibujar);
                }
            }
        }

    }
    }

