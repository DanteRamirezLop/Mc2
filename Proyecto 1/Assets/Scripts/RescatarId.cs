using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescatarId : MonoBehaviour {

    public Text cod_id;
    
	void Start () {
        cod_id.text = DatosScena.Id_proyecto;    //.ToString();
	}
	
	void Update () {
		
	}
}
