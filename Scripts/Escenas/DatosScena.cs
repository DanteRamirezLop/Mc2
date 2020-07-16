using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosScena : MonoBehaviour {

    public static string Id_proyecto = "---";

    void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }
}
