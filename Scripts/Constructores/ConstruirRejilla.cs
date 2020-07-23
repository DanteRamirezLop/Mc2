using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirRejilla : MonoBehaviour
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
        StartCoroutine(RejillaOnReponse(Id_Foranea));
    }

    /// <summary>
    /// Filtra los datos por la varibale id_busqueda que es el ID de la tabla Equipov y los retorna en una variable List
    /// </summary>
    /// <param name="id_busqueda"></param> id de la tabla
    /// <returns></returns>
    public List<string> DatosRejillaId(string id_busqueda) {
        List<string> datosRejilla = new List<string>();
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
                datosRejilla.Add(item);
            }
            cont++;
            
        }
        return datosRejilla;
    }
	
	
	public List<string> DatosRejilla() {
        List<string> datosRejilla = new List<string>(aux);

        return datosRejilla;
    }

    /// <summary>
    /// Corutina que extrae los datos del servidor por medio de la URL y los trae en formato Json
    /// en la corrutina se trabaja con las clases [System.Serializable] para organizar y manejar los datos en funciones
    /// 
    /// </summary>
    /// <param name="Id_Foranea"></param>
    /// <returns></returns>
    private IEnumerator RejillaOnReponse(string Id_Foranea)
    {
        List<string> datos = new List<string>();
		//using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "rejilla"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);

            }
            else
            {

                int Cantidad;
                ListaRejilla listaRejillas = JsonUtility.FromJson<ListaRejilla>(req.downloadHandler.text);
                Cantidad = listaRejillas.rejillas.Count;

                if (Cantidad != 0)
                {
                    //*****utilizar los datos en este lugar si los necesitas al ejecutar el programa*****
                    //****Comentar el  listaEquipovs.CargarRejilla(datos) si se necesita utilizar los datos en en el start y utilizar ' listaEquipovs.CargarRejillaId '
                    //listaEquipovs.CargarRejillaId(datos,"1");
                    listaRejillas.CargarRejilla(datos);
					aux = datos;

                    //
                }
                else
                {
                    Debug.Log("No hay rejilla");
                }
            }
        }
    }	
    
    
    [System.Serializable]
    public class Rejilla
    {
        public string id;
        public string nombre;
        public string cfm;

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", id, nombre, cfm);
        }
    }

    [System.Serializable]
    public class ListaRejilla
    {

        public List<Rejilla> rejillas;
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarRejilla(List<string> datos)
        {
            foreach (Rejilla rejilla in rejillas)
            {
					datos.Add(rejilla.id);
                    datos.Add(rejilla.nombre);
                    datos.Add(rejilla.cfm);
            }
        }
     /// <summary>
     /// Asigna a la variable 'datos' los datos de la tabla filtrados por 'id_busqueda'
     /// </summary>
     /// <param name="datos"></param> variable por valor
     /// <param name="id_busqueda"></param> variable por referencia	
		public void CargarRejillaId(List<string> datos,string id_busqueda)
        {
            foreach (Rejilla rejilla in rejillas)
            {
					if(id_busqueda==rejilla.id)
					{
						datos.Add(rejilla.id);
						datos.Add(rejilla.nombre);
						datos.Add(rejilla.cfm);
					}
            }
        }

    }
}
