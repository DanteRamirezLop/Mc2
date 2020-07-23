using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirMultiple : MonoBehaviour
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
        StartCoroutine(MultipleOnReponse(Id_Foranea));
    }

    /// <summary>
    /// Filtra los datos por la varibale id_busqueda que es el ID de la tabla Equipov y los retorna en una variable List
    /// </summary>
    /// <param name="id_busqueda"></param> id de la tabla
    /// <returns></returns>
    public List<string> DatosMultiple(string id_busqueda) {
        List<string> datosMultiple = new List<string>();
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
                varAux = varAux + 3;
            }

            if (bandera) {
                datosMultiple.Add(item);
            }
            cont++;
            
        }
        return datosMultiple;
    }

    /// <summary>
    /// Corutina que extrae los datos del servidor por medio de la URL y los trae en formato Json
    /// en la corrutina se trabaja con las clases [System.Serializable] para organizar y manejar los datos en funciones
    /// 
    /// </summary>
    /// <param name="Id_Foranea"></param>
    /// <returns></returns>
    private IEnumerator MultipleOnReponse(string Id_Foranea)
    {
        List<string> datos = new List<string>();
		//using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "multiple"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);

            }
            else
            {

                int Cantidad;
                ListaMultiple listaMultiples = JsonUtility.FromJson<ListaMultiple>(req.downloadHandler.text);
                Cantidad = listaMultiples.multiples.Count;

                if (Cantidad != 0)
                {
                    //*****utilizar los datos en este lugar si los necesitas al ejecutar el programa*****
                    //****Comentar el  listaMultiples.CargarMultiple(datos); si se necesita utilizar los datos en en el start y utilizar ' listaMultiples.CargarMultipleId'
                    //listaMultiples.CargarMultipleId(datos,"1");
                    listaMultiples.CargarMultiple(datos);
					aux = datos;
                }
                else
                {
                    Debug.Log("No hay ductos");
                }
            }
        }
    }	

    
    [System.Serializable]
    public class Multiple
    {
        public string id;
        public string giroX;
        public string giroY;

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", id, giroX, giroY);
        }
    }

    [System.Serializable]
    public class ListaMultiple
    {
        public List<Multiple> multiples;
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarMultiple(List<string> datos)
        {
            foreach (Multiple multiple in multiples)
            {
                    datos.Add(multiple.id);
					datos.Add(multiple.giroX);
                    datos.Add(multiple.giroY);
            }
        }
		
	 /// <summary>
     /// Asigna a la variable 'datos' los datos de la tabla filtrados por 'id_busqueda'
     /// </summary>
     /// <param name="datos"></param> variable por valor
     /// <param name="id_busqueda"></param> variable por referencia			
		public void CargarMultipleId(List<string> datos,string id_busqueda)
        {
            foreach (Multiple multiple in multiples)
            {
                    if(multiple.id==id_busqueda)
					{
						datos.Add(multiple.id);
						datos.Add(multiple.giroX);
						datos.Add(multiple.giroY);
					}
            }
        }
		
    }
}
