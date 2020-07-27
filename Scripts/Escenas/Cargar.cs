using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Cargar : MonoBehaviour {

    public string IdProyecto;

    public void CargarEscena(string NombreEscena)
    {
        DatosScena.Id_proyecto = IdProyecto;
        PantallaDeCarga.Instancia.CargarEscena(NombreEscena); //lamar a la pantalla de carga 
    }


}
