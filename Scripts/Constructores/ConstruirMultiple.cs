using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruirMultiple : MonoBehaviour
{
   
    
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

        public void CargarMultiple(string id_buscar)
        {
            foreach (Multiple multiple in multiples)
            {

                if (id_buscar == multiple.id)
                {
                    Debug.Log(multiple.giroX);
                    Debug.Log(multiple.giroY);
                }

            }
        }
    }
}
