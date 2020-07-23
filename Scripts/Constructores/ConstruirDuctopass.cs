using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirDuctopass : MonoBehaviour
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
        StartCoroutine(DuctopassOnReponse(Id_Foranea));
    }

    /// <summary>
    /// Filtra los datos por la varibale id_busqueda que es el ID de la tabla Equipov y los retorna en una variable List
    /// </summary>
    /// <param name="id_busqueda"></param> id de la tabla
    /// <returns></returns>
    public List<string> DatosDuctopass(string id_busqueda) {
        List<string> datosDuctopass = new List<string>();
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
                datosDuctopass.Add(item);
            }
            cont++;
            
        }
        return datosDuctopass;
    }


    /// <summary>
    /// Corutina que extrae los datos del servidor por medio de la URL y los trae en formato Json
    /// en la corrutina se trabaja con las clases [System.Serializable] para organizar y manejar los datos en funciones
    /// 
    /// </summary>
    /// <param name="Id_Foranea"></param>
    /// <returns></returns>
    private IEnumerator DuctopassOnReponse(string Id_Foranea)
    {
        List<string> datos = new List<string>();
		//using (UnityWebRequest req = UnityWebRequest.Get(URL + "ductoex/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "ductopass"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);
            }
            else
            {
                int Cantidad;
                ListaDuctopasss listaDuctopasss = JsonUtility.FromJson<ListaDuctopasss>(req.downloadHandler.text);
                Cantidad = listaDuctopasss.ductopasss.Count;

                if (Cantidad != 0)
                {
                    listaDuctopasss.CargarDuctopass(datos);
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
    public class Ductopass
    {
        public string idDucto;
        public string ccx;
        public string ccy;
        public string ccz;
        public string paso;
        public string dibujar;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", idDucto,ccx, ccy, ccz, paso,dibujar);
        }
    }
	
	
	[System.Serializable]
    public class ListaDuctopasss {
		
	 public List<Ductopass> ductopasss;
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
     public void CargarDuctopass(List<string> datos)
     {
		foreach (Ductopass ductopass in ductopasss) {
			
			        datos.Add(ductopass.idDucto);
					datos.Add(ductopass.ccx);
					datos.Add(ductopass.ccy);
					datos.Add(ductopass.ccz);
					datos.Add(ductopass.paso);
					datos.Add(ductopass.dibujar);

		}
	 }
	 
        /// <summary>
        /// Asigna a la variable 'datos' los datos de la tabla filtrados por 'id_busqueda'
        /// </summary>
        /// <param name="datos"></param> variable por valor
        /// <param name="id_busqueda"></param> variable por referencia	 
	 public void CargarDuctopassId(List<string> datos,string id_busqueda)
     {
		foreach (Ductopass ductopass in ductopasss) {
			
			if(id_busqueda==ductopass.idDucto){
				    datos.Add(ductopass.idDucto);
					datos.Add(ductopass.ccx);
					datos.Add(ductopass.ccy);
					datos.Add(ductopass.ccz);
					datos.Add(ductopass.paso);
					datos.Add(ductopass.dibujar);
			}
		}
	 }
    
}

}
