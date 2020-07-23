using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;


public class ConstruirEquipoesp : MonoBehaviour
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
        StartCoroutine(EquipoespOnReponse(Id_Foranea));
    }

    /// <summary>
    /// Filtra los datos por la varibale id_busqueda que es el ID de la tabla Equipov y los retorna en una variable List
    /// </summary>
    /// <param name="id_busqueda"></param> id de la tabla
    /// <returns></returns>
    public List<string> DatosEquipoesp(string id_busqueda) {
        List<string> datosEquipoesp = new List<string>();
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
                datosEquipoesp.Add(item);
            }
            cont++;
            
        }
        return datosEquipoesp;
    }

    /// <summary>
    /// Corutina que extrae los datos del servidor por medio de la URL y los trae en formato Json
    /// en la corrutina se trabaja con las clases [System.Serializable] para organizar y manejar los datos en funciones
    /// 
    /// </summary>
    /// <param name="Id_Foranea"></param>
    /// <returns></returns>
    private IEnumerator EquipoespOnReponse(string Id_Foranea)
    {
        List<string> datos = new List<string>();
		//using (UnityWebRequest req = UnityWebRequest.Get(URL + "ducto/" + Id_Foranea))
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "equipoesp"))
        {
            yield return req.SendWebRequest();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);

            }
            else
            {
                int Cantidad;
                ListaEquipoesps listaEquipoesps = JsonUtility.FromJson<ListaEquipoesps>(req.downloadHandler.text);
                Cantidad = listaEquipoesps.equipoesps.Count;

                if (Cantidad != 0)
                {
					//*****utilizar los datos en este lugar si los necesitas al ejecutar el programa*****
                    //****Comentar el   listaEquipoesps.CargarEquipoesp(datos) si se necesita utilizar los datos en en el start y utilizar '   listaEquipoesps.CargarEquipoespId'
                    //  listaEquipoesps.CargarEquipoespID(datos,"1");
                    listaEquipoesps.CargarEquipoesp(datos);
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
    public class Equipoesp
    {
        public string idEquipoV;
        public string potencia;
        public string voltaje;
        public string sistema;
        public string enfEntrada1;
        public string enfEntrada2;
        public string enfSalida1;
        public string enfSalida2;
        public string tipo;
        public string Hz;
        public string CSensible;
        public string CLatente;
        public string ESensible;
        public string ELatente;
        public string caudal;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", idEquipoV, potencia, voltaje, sistema, enfEntrada1, enfEntrada2, enfSalida1, enfSalida2, tipo, Hz, CSensible, CLatente, ESensible, ELatente, caudal);
        }
    }

    [System.Serializable]
    public class ListaEquipoesps
    {

        public List<Equipoesp> equipoesps;
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarEquipoesp(List<string> datos)
        {
            foreach (Equipoesp equipoesp in equipoesps)
            {
					datos.Add(equipoesp.idEquipoV);
                    datos.Add(equipoesp.potencia);
                    datos.Add(equipoesp.voltaje);
                    datos.Add(equipoesp.sistema);
                    datos.Add(equipoesp.enfEntrada1);
                    datos.Add(equipoesp.enfEntrada2);
                    datos.Add(equipoesp.enfSalida1);
                    datos.Add(equipoesp.enfSalida2);
                    datos.Add(equipoesp.tipo);
                    datos.Add(equipoesp.Hz);
                    datos.Add(equipoesp.CSensible);
                    datos.Add(equipoesp.CLatente);
                    datos.Add(equipoesp.ESensible);
                    datos.Add(equipoesp.ELatente);
                    datos.Add(equipoesp.caudal);


            }
        }
		
	 /// <summary>
     /// Asigna a la variable 'datos' los datos de la tabla filtrados por 'id_busqueda'
     /// </summary>
     /// <param name="datos"></param> variable por valor
     /// <param name="id_busqueda"></param> variable por referencia
		public void CargarEquipoespId(List<string> datos,string id_busqueda)
        {
            foreach (Equipoesp equipoesp in equipoesps)
            {
					if(equipoesp.idEquipoV== id_busqueda)
					{
						datos.Add(equipoesp.idEquipoV);
						datos.Add(equipoesp.potencia);
						datos.Add(equipoesp.voltaje);
						datos.Add(equipoesp.sistema);
						datos.Add(equipoesp.enfEntrada1);
						datos.Add(equipoesp.enfEntrada2);
						datos.Add(equipoesp.enfSalida1);
						datos.Add(equipoesp.enfSalida2);
						datos.Add(equipoesp.tipo);
						datos.Add(equipoesp.Hz);
						datos.Add(equipoesp.CSensible);
						datos.Add(equipoesp.CLatente);
						datos.Add(equipoesp.ESensible);
						datos.Add(equipoesp.ELatente);
						datos.Add(equipoesp.caudal);
					}

            }
        }
    }
}
