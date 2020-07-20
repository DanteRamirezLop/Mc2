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
    public string id_buscar;

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(EquipoespOnReponse(Id_Foranea));
    }

    private IEnumerator EquipoespOnReponse(string Id_Foranea)
    {
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
                    listaEquipoesps.CargarEquipoesp(id_buscar);
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

        public void CargarEquipoesp(string id_buscar)
        {
            foreach (Equipoesp equipoesp in equipoesps)
            {

                if (id_buscar == equipoesp.idEquipoV)
                {
                    Debug.Log(equipoesp.potencia);
                    Debug.Log(equipoesp.voltaje);
                    Debug.Log(equipoesp.sistema);
                    Debug.Log(equipoesp.enfEntrada1);
                    Debug.Log(equipoesp.enfEntrada2);
                    Debug.Log(equipoesp.enfSalida1);
                    Debug.Log(equipoesp.enfSalida2);
                    Debug.Log(equipoesp.tipo);
                    Debug.Log(equipoesp.Hz);
                    Debug.Log(equipoesp.CSensible);
                    Debug.Log(equipoesp.CLatente);
                    Debug.Log(equipoesp.ESensible);
                    Debug.Log(equipoesp.ELatente);
                    Debug.Log(equipoesp.caudal);

                }

            }
        }

    }
}
