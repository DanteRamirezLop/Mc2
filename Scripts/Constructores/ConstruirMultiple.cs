using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConstruirMultiple : MonoBehaviour{}
    
    [System.Serializable]
    public class Multiple
    {
        public string id;
        public string giroX;
        public string giroY;

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", id, giroX, giroY);
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
        public void CargarMultiple(List<string> datos)
        {
            foreach (Multiple multiple in multiples)
            {
                    datos.Add(multiple.id);
					datos.Add(multiple.giroX);
                    datos.Add(multiple.giroY);
            }
        }
		
    }
