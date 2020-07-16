using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cargar : MonoBehaviour {

    public string Cod_id;

    public void CambiarEscena(string NombreEscena)
    {
        DatosScena.Id_proyecto = Cod_id;
        SceneManager.LoadScene(NombreEscena);
    }
}
