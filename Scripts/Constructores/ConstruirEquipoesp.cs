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
	
    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(EquipoespOnReponse(Id_Foranea));
    }

	
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

        public void CargarEquipoesp(List<string> datos)
        {
            foreach (Equipoesp equipoesp in equipoesps)
            {

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
