using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirAmbiente : MonoBehaviour {

    public string URL;
    public string Id_Foranea;
    public Dropdown ComboAmnietnes;

    private Dictionary<string, string> localizedText;

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(AmbienteOnReponse(Id_Foranea));	
    }

    private IEnumerator AmbienteOnReponse(string Id_Foranea)
    {

      using (WWW req = new WWW(URL + "ambiente/" + Id_Foranea))
      {   
        yield return req;

        if (!string.IsNullOrEmpty(req.error)){
            Debug.Log(req.error);

        }else {

            int Cantidad;

            ListaAmbientes listaAmbientes = JsonUtility.FromJson<ListaAmbientes>(req.text);
            Cantidad = listaAmbientes.ambientes.Count;

            if (Cantidad != 0)
            {
               //Construir el primer ambiente por defecto
                listaAmbientes.CargarAmbientes(ComboAmnietnes);
            }
             else {
                 Debug.Log("Este Proyecto no tiene ambientes");
                 ComboAmnietnes.options.Clear();
             }
       }
     }
    }

    [System.Serializable]
    public class Ambiente
    {
        public string id;
        public string idProyecto;
        public string nAmbiente;
        public string largo;
        public string ancho;
        public string altura;
        //public string area;
        //public string recambios;
        //public string flujo;
        //public string cfm;
        public string coordenadas;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}", id, idProyecto, nAmbiente, largo, ancho, altura, coordenadas);
        }
    }

    [System.Serializable]
    public class ListaAmbientes
    {
        public List<Ambiente> ambientes;

        public void CargarAmbientes(Dropdown ComboAmnietnes)
         {
             int count = 0;
             string Coordenadas;
             string Nombre= "";
             char newLine = '\n';

             ComboAmnietnes.options.Clear();
             List<string> nombres = new List<string>();

             foreach (Ambiente ambiente in ambientes)
             {
                 if (count == 0)
                 {
                     //****Construir primer ambiente

                     //se desmenusa las corrdenadas y se almacenan en split1
                     Coordenadas = ambiente.coordenadas;
                     string[] split1 = Coordenadas.Split(newLine);
                     //Debug.Log(split1[0]);
                     //Debug.Log(split1[1]);
                     //Debug.Log(split1[2]);
                     //Debug.Log(split1[3]);
                 }
                 Nombre = ambiente.nAmbiente;
                //ComboAmnietnes.options.Add(new Dropdown.OptionData() { text = Nombre });
                 nombres.Add(Nombre);
                 count++;
             }

             ComboAmnietnes.AddOptions(nombres);
         }
    }








}
