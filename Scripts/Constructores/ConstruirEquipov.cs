using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirEquipov : MonoBehaviour
{
    public string URL;
    public string Id_Foranea;

    private List<string> aux = new List<string>();

    /// <summary>
    /// Rescata el Id del proyecto
    /// Ejecuta una corutina para traer lo datos de la API
    /// </summary>
    void Start() {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(EquipovOnReponse(Id_Foranea));
    }
    /// <summary>
    /// Filtra los datos por la varibale id_busqueda que es el ID de la tabla Equipov y los retorna en una variable List
    /// </summary>
    /// <param name="id_busqueda"></param> id de la tabla
    /// <returns></returns>
    public List<string> DatosEquipovId(string id_busqueda) {
        List<string> datosEquipov = new List<string>();
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
                varAux = varAux + 15;
            }

            if (bandera) {
                datosEquipov.Add(item);
            }
            cont++;
            
        }
        return datosEquipov;
    }

	public List<string> DatosEquipov() {
        List<string> datosEquipov = new List<string>(aux);

        return datosEquipov;
    }
	
    /// <summary>
    /// Corutina que extrae los datos del servidor por medio de la URL y los trae en formato Json
    /// en la corrutina se trabaja con las clases [System.Serializable] para organizar y manejar los datos en funciones
    /// 
    /// </summary>
    /// <param name="Id_Foranea"></param>
    /// <returns></returns>
    private IEnumerator EquipovOnReponse(string Id_Foranea)
    {
        List<string> datos = new List<string>();

        using (UnityWebRequest req = UnityWebRequest.Get(URL + "equipov/" + Id_Foranea))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error)){
                Debug.Log(req.error);
            }
            else{
                int Cantidad;
                ListaEquipov listaEquipovs = JsonUtility.FromJson<ListaEquipov>(req.downloadHandler.text);
                Cantidad = listaEquipovs.equipovs.Count;

                if (Cantidad != 0){

                    //*****utilizar los datos en este lugar si los necesitas al ejecutar el programa*****
                    //****Comentar el  listaEquipovs.CargarEquipov(datos) si se necesita utilizar los datos en en el start y utilizar ' listaEquipovs.CargarEquipovId '
                      //listaEquipovs.CargarEquipovId(datos,"1");

                      listaEquipovs.CargarEquipov(datos);
                      aux = datos;

             
                    //
                }
                else{
                    Debug.Log("No hay equipos");
                }
            }
        }
    }

    [System.Serializable]
    public class Equipov
    {
        public string id;
        public string idProyecto;
        public string codigo;
        public string tipo;
        public string velocidadIny;
        public string velocidadExt;
        public string porcentajeIny;
		public string porcentajeExt;
        public string calculo;
        public string vinculo;
        public string nivel;
        public string idAmbiente;
        public string ccx;
        public string ccy;
        public string ccz;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", id, idProyecto, codigo, tipo, velocidadIny, velocidadExt, porcentajeIny,porcentajeExt, calculo, vinculo, nivel, idAmbiente, ccx, ccy, ccz);
        }
    }

    [System.Serializable]
    public class ListaEquipov
    {
        public List<Equipov> equipovs;

        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarEquipov(List<string> datos)
        {
            foreach (Equipov equipov in equipovs)
            {
                datos.Add(equipov.id);
                datos.Add(equipov.idProyecto);
                datos.Add(equipov.codigo);
                datos.Add(equipov.tipo);
                datos.Add(equipov.velocidadIny);
                datos.Add(equipov.velocidadExt);
                datos.Add(equipov.porcentajeIny);
                datos.Add(equipov.porcentajeExt);
                datos.Add(equipov.calculo);
                datos.Add(equipov.vinculo);
                datos.Add(equipov.nivel);
                datos.Add(equipov.idAmbiente);
                datos.Add(equipov.ccx);
                datos.Add(equipov.ccy);
                datos.Add(equipov.ccz);
            }
        }
        /// <summary>
        /// Asigna a la variable 'datos' los datos de la tabla filtrados por 'id_busqueda'
        /// </summary>
        /// <param name="datos"></param> variable por valor
        /// <param name="id_busqueda"></param> variable por referencia
        public void CargarEquipovId(List<string> datos, string id_busqueda)
        {
            foreach (Equipov equipov in equipovs)
            {
                if (equipov.id == id_busqueda)
                {
                    datos.Add(equipov.id);
                    datos.Add(equipov.idProyecto);
                    datos.Add(equipov.codigo);
                    datos.Add(equipov.tipo);
                    datos.Add(equipov.velocidadIny);
                    datos.Add(equipov.velocidadExt);
                    datos.Add(equipov.porcentajeIny);
                    datos.Add(equipov.porcentajeExt);
                    datos.Add(equipov.calculo);
                    datos.Add(equipov.vinculo);
                    datos.Add(equipov.nivel);
                    datos.Add(equipov.idAmbiente);
                    datos.Add(equipov.ccx);
                    datos.Add(equipov.ccy);
                    datos.Add(equipov.ccz);
                }
            }
        }

    }
}
