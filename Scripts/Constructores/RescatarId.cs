using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescatarId : MonoBehaviour {

    public Text cod_id;
    public EliminarMetradoex ScriptA;

	void Start () {
     /*   cod_id.text = DatosScena.Id_proyecto;

        //Realizar una prueba
        //Probando las listas de DatosScena

        foreach (Ducto atributo in DatosScena.Ducto)
        {
            Debug.Log("-------");
            Debug.Log(atributo.idItem);
            Debug.Log(atributo.longitud);
            Debug.Log(atributo.estado);
        }*/
	}



    public void registrar()
    {
 
        ScriptA.Eliminar(3);
    }

}
