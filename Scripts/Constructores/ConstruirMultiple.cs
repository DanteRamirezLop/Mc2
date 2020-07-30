using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
    
    [System.Serializable]
    public class Multiple
    {
        public int id;
        public float giroX;
        public float giroY;
        public bool estado;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", id, giroX, giroY,estado);
        }
    }

    [System.Serializable]
    public class ListaMultiple
    {
        public List<Multiple> multiples;
        
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarMultiple(List<Multiple> datos)
        {
            foreach (Multiple atributo in multiples)
            {
                datos.Add(atributo);
            }
        }
		
    }
