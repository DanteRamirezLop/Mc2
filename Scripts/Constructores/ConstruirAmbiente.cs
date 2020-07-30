using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

    [System.Serializable]
    public class Ambiente
    {
        public int id;
        public int idProyecto;
        public string nAmbiente;
        public double largo;
        public double ancho;
        public double altura;
        public double area;
        public double recambios;
        public double flujo;
        public double cfm;
        public string coordenada;
        public bool estado;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", id, idProyecto, nAmbiente, largo, ancho, altura, area, recambios, flujo, cfm, coordenada,estado);
        }
    }

    [System.Serializable]
    public class ListaAmbiente
    {
        public List<Ambiente> ambientes;
 
        public void CargarAmbiente(List<Ambiente> datos)
         { 
            foreach (Ambiente atributo in ambientes)
            {
                datos.Add(atributo);
            }
                         
         }
      }


