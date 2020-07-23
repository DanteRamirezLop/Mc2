using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirEspfiltro : MonoBehaviour
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
        StartCoroutine(EspfiltroOnReponse(Id_Foranea));
    }

    /// <summary>
    /// Filtra los datos por la varibale id_busqueda que es el ID de la tabla Equipov y los retorna en una variable List
    /// </summary>
    /// <param name="id_busqueda"></param> id de la tabla
    /// <returns></returns>
    public List<string> DatosEspfiltroId(string id_busqueda) {
        List<string> datosEspfiltro = new List<string>();
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
                varAux = varAux + 2;
            }

            if (bandera) {
                datosEspfiltro.Add(item);
            }
            cont++;
            
        }
        return datosEspfiltro;
    }

	public List<string> DatosEspfiltro() {
        List<string> datosEspfiltro = new List<string>(aux);

        return datosEspfiltro;
    }
	
	
    /// <summary>
    /// Corutina que extrae los datos del servidor por medio de la URL y los trae en formato Json
    /// en la corrutina se trabaja con las clases [System.Serializable] para organizar y manejar los datos en funciones
    /// 
    /// </summary>
    /// <param name="Id_Foranea"></param>
    /// <returns></returns>
    private IEnumerator EspfiltroOnReponse(string Id_Foranea)
    {
         List<string> datos = new List<string>();
		//using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "espfiltro"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);

            }
            else
            {
                int Cantidad;
                ListaEspfiltro listaEspfiltros = JsonUtility.FromJson<ListaEspfiltro>(req.downloadHandler.text);
                Cantidad = listaEspfiltros.espfiltros.Count;

                if (Cantidad != 0)
                {
                    //*****utilizar los datos en este lugar si los necesitas al ejecutar el programa*****
                    listaEspfiltros.CargarEspfiltro(datos);
					aux = datos;
                }
                else
                {
                    Debug.Log("No hay filtro");
                }
            }
        }
    } 
    
    [System.Serializable]
    public class Espfiltro
    {
        public string idEquip;
        public string idFiltro;

        public override string ToString()
        {
            return string.Format("{0},{1}", idEquip, idFiltro);
        }
    }

    [System.Serializable]
    public class ListaEspfiltro
    {

        public List<Espfiltro> espfiltros;
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarEspfiltro(List<string> datos)
        {
            foreach (Espfiltro espfiltro in espfiltros)
            {

                datos.Add(espfiltro.idEquip);
                datos.Add(espfiltro.idFiltro);

            }
        }

    }
}



