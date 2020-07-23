using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirDuctoex : MonoBehaviour
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
        StartCoroutine(DuctoexOnReponse(Id_Foranea));
    }

    /// <summary>
    /// Filtra los datos por ID de la tabla Equipov y los retorna en una variable List
    /// </summary>
    /// <param name="id_busqueda"></param>
    /// <returns></returns>
    public List<string> DatosDuctoexId(string id_busqueda)
    {
        List<string> datosDuctoex = new List<string>();
        int cont = 0;
        int varAux = 0;
        bool bandera = false;

        foreach (string item in aux)
        {
            if (varAux == cont)
            {
                if (id_busqueda == item)
                {
                    bandera = true;
                }
                else
                    bandera = false;
                varAux = varAux + 12;
            }

            if (bandera)
            {
                datosDuctoex.Add(item);
            }
            cont++;

        }
        return datosDuctoex;
    }
	
    public List<string> DatosDuctoex()
    {
        List<string> datosDuctoex = new List<string>(aux);
        return datosDuctoex;
    }
	
    /// <summary>
    /// Corutina que extrae los datos del servidor por medio de la URL y los trae en formato Json
    /// en la corrutina se trabaja con las clases [System.Serializable] para organizar y manejar los datos en funciones
    /// 
    /// </summary>
    /// <param name="Id_Foranea"></param>
    /// <returns></returns>
    private IEnumerator DuctoexOnReponse(string Id_Foranea)
    {
        List<string> datos = new List<string>();
		//using (UnityWebRequest req = UnityWebRequest.Get(URL + "ductoex/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "ductoex"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);
            }
            else
            {
                int Cantidad;
                ListaDuctoexs listaDuctoexs = JsonUtility.FromJson<ListaDuctoexs>(req.downloadHandler.text);
                Cantidad = listaDuctoexs.ductoexs.Count;

                if (Cantidad != 0)
                {
                    //*****utilizar los datos en este lugar si los necesitas al ejecutar el programa*****
                    //****Comentar el   listaDuctoexs.CargarDuctoex(datos); si se necesita utilizar los datos en en el start y utilizar ' listaDuctoexs.CargarDuctoexId'
                    //  listaDuctoexs.CargarDuctoexId(datos,"1");
					listaDuctoexs.CargarDuctoex(datos);
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
    public class Ductoex
    {
        public string idDucto;
        public string tipo;
        public string nombre;
        public string dimA;
        public string dimB;
        public string flujoCFM;
        public string damAb100;
        public string damCer10;
        public string damCer50;
        public string tranRec;
        public string conVen;
        public string lumAli;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", idDucto, tipo, nombre, dimA, dimB, flujoCFM, damAb100, damCer10, damCer50, tranRec, conVen, lumAli);
        }
    }
	
	[System.Serializable]
    public class ListaDuctoexs {
		
	 public List<Ductoex> ductoexs;
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
     public void CargarDuctoex(List<string> datos)
     {
		foreach (Ductoex ductoex in ductoexs) {
			
			        datos.Add(ductoex.idDucto);
					datos.Add(ductoex.tipo);
					datos.Add(ductoex.nombre);
					datos.Add(ductoex.dimA);
					datos.Add(ductoex.dimB);
					datos.Add(ductoex.flujoCFM);
					datos.Add(ductoex.damAb100);
					datos.Add(ductoex.damCer10);
					datos.Add(ductoex.damCer50);
					datos.Add(ductoex.tranRec);
					datos.Add(ductoex.conVen);
					datos.Add(ductoex.lumAli);
		}
	 }
	 /// <summary>
     /// Asigna a la variable 'datos' los datos de la tabla filtrados por 'id_busqueda'
     /// </summary>
     /// <param name="datos"></param> variable por valor
     /// <param name="id_busqueda"></param> variable por referencia
	 public void CargarDuctoexId(List<string> datos,string id_busqueda)
     {
		foreach (Ductoex ductoex in ductoexs) {
			
			if(id_busqueda ==ductoex.idDucto){
				
				    datos.Add(ductoex.idDucto);
					datos.Add(ductoex.tipo);
					datos.Add(ductoex.nombre);
					datos.Add(ductoex.dimA);
					datos.Add(ductoex.dimB);
					datos.Add(ductoex.flujoCFM);
					datos.Add(ductoex.damAb100);
					datos.Add(ductoex.damCer10);
					datos.Add(ductoex.damCer50);
					datos.Add(ductoex.tranRec);
					datos.Add(ductoex.conVen);
					datos.Add(ductoex.lumAli);

			}
		}
	 }
	 
	 
	 
    }
	
	
}
