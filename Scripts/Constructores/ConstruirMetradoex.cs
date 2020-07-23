using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirMetradoex : MonoBehaviour
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
        StartCoroutine(MetradoexOnReponse(Id_Foranea));
    }

    /// <summary>
    /// Filtra los datos por la varibale id_busqueda que es el ID de la tabla Equipov y los retorna en una variable List
    /// </summary>
    /// <param name="id_busqueda"></param> id de la tabla
    /// <returns></returns>
    public List<string> DatosMetradoexId (string id_busqueda) {
        List<string> datosMetradoex = new List<string>();
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
                varAux = varAux + 6;
            }

            if (bandera) {
                datosMetradoex .Add(item);
            }
            cont++;
            
        }
        return datosMetradoex ;
    }

	
	public List<string> DatosMetradoex() {
        List<string> datosMetradoex = new List<string>(aux);

        return datosMetradoex ;
    }
    /// <summary>
    /// Corutina que extrae los datos del servidor por medio de la URL y los trae en formato Json
    /// en la corrutina se trabaja con las clases [System.Serializable] para organizar y manejar los datos en funciones
    /// 
    /// </summary>
    /// <param name="Id_Foranea"></param>
    /// <returns></returns>
    private IEnumerator MetradoexOnReponse(string Id_Foranea)
    {
		List<string> datos = new List<string>();
	   //using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "metradoex"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);

            }
            else
            {

                int Cantidad;
                ListaMetradoex listaMetradoexs = JsonUtility.FromJson<ListaMetradoex>(req.downloadHandler.text);
                Cantidad = listaMetradoexs.metradoexs.Count;

                if (Cantidad != 0)
                {
                    //*****utilizar los datos en este lugar si los necesitas al ejecutar el programa*****
                    //****Comentar el  listaMetradoexs.CargarMetradoex(datos); si se necesita utilizar los datos en en el start y utilizar ' listaMetradoexs.CargarMetradoexId'
                    //listaMetradoexs.CargarMetradorex(datos,"1");
                    listaMetradoexs.CargarMetradoex(datos);
					aux = datos;

                    //
                }
                else
                {
                    Debug.Log("No hay ductos");
                }
            }
        }
    }	



    [System.Serializable]
    public class Metradoex
    {
        public string id;
        public string idEquipo;
        public string dima;
        public string dimb;
        public string tipo;
        public string multi;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", id, idEquipo, dima, dimb, tipo, multi);
        }
    }

    [System.Serializable]
    public class ListaMetradoex
    {
        public List<Metradoex> metradoexs;
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarMetradoex(List<string> datos)
        {
            foreach (Metradoex metradoex in metradoexs)
            {
					datos.Add(metradoex.id);
                    datos.Add(metradoex.idEquipo);
                    datos.Add(metradoex.dima);
                    datos.Add(metradoex.dimb);
                    datos.Add(metradoex.tipo);
                    datos.Add(metradoex.multi);

            }
        }
	 /// <summary>
     /// Asigna a la variable 'datos' los datos de la tabla filtrados por 'id_busqueda'
     /// </summary>
     /// <param name="datos"></param> variable por valor
     /// <param name="id_busqueda"></param> variable por referencia		
	    public void CargarMetradoexId(List<string> datos, string id_busqueda)
        {
            foreach (Metradoex metradoex in metradoexs)
            {
				if(id_busqueda==metradoex.id)
				{	
					datos.Add(metradoex.id);
                    datos.Add(metradoex.idEquipo);
                    datos.Add(metradoex.dima);
                    datos.Add(metradoex.dimb);
                    datos.Add(metradoex.tipo);
                    datos.Add(metradoex.multi);
				}
            }
        }	
		
		
    }
}
