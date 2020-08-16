using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Cargar : MonoBehaviour {

    public string IdProyecto;

    public void CargarEscena()
    {
        DatosScena.CargaProyecto(IdProyecto);
    }


}
