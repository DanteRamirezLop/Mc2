using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConstruirAmbiente : MonoBehaviour {}

    [System.Serializable]
    public class Ambiente
    {
        public string id;
        public string idProyecto;
        public string nAmbiente;
        public string largo;
        public string ancho;
        public string altura;
        public string area;
        public string recambios;
        public string flujo;
        public string cfm;
        public string coordenada;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", id, idProyecto, nAmbiente, largo, ancho, altura, area, recambios, flujo, cfm, coordenada);
        }
    }

    [System.Serializable]
    public class ListaAmbiente
    {
        public List<Ambiente> ambientes;

        public void CargarAmbiente(List<string> datos)
         {

             foreach (Ambiente ambiente in ambientes)
             {
                 datos.Add(ambiente.id);
                 datos.Add(ambiente.idProyecto);
                 datos.Add(ambiente.nAmbiente);
                 datos.Add(ambiente.largo);
                 datos.Add(ambiente.ancho);
                 datos.Add(ambiente.altura);
                 datos.Add(ambiente.area);
                 datos.Add(ambiente.recambios);
                 datos.Add(ambiente.flujo);
                 datos.Add(ambiente.cfm);
                 datos.Add(ambiente.coordenada);
             }

           
         }
      }


