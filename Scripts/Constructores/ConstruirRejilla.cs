using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConstruirRejilla : MonoBehaviour{}

    [System.Serializable]
    public class Rejilla{
        public string id;
        public string nombre;
        public string cfm;

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", id, nombre, cfm);
        }
    }

    [System.Serializable]
    public class ListaRejilla{
        public List<Rejilla> rejillas;
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void CargarRejilla(List<string> datos)
        {
            foreach (Rejilla rejilla in rejillas)
            {
					datos.Add(rejilla.id);
                    datos.Add(rejilla.nombre);
                    datos.Add(rejilla.cfm);
            }
        }
    }

