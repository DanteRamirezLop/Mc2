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
    // public Dropdown ComboAmnietnes;

    private List<string> aux = new List<string>();

    void Start() {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(EquipovOnReponse(Id_Foranea));
    }

    public List<string> DatosEquipov(string id_busqueda) {
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
                    listaEquipovs.CargarEquipov(datos);
                    aux = datos;
                    //En la lista datos estan cargados todos los campos
                    //*****utilizar los datos en este lugar si los necesitas al ejecutar el programa*****


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

    }
}
