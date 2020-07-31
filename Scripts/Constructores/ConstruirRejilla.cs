using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

    [System.Serializable]
    public class Rejilla:Item
    {
       // public string id; //no se utiliza por que se repite nen idItem
        public string nombre;
        public string cfm;
        public bool estado;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}",id,idItem,idEquipo,conexion, this.nombre, this.cfm,this.estado);
        }
    }

    [System.Serializable]
    public class ListaRejilla{
        public List<Rejilla> rejillas;
        
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarRejilla(List<Rejilla> datos)
        {
            foreach (Rejilla atributo in rejillas)
            {
                datos.Add(atributo);
            }
        }
    }

