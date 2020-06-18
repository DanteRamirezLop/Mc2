using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cargar : MonoBehaviour {

    public string Cod_id;

    public void CambiarEscena()
    {
        DatosScena.Id_proyecto = Cod_id;
        SceneManager.LoadScene("EscenaConstruccion");
    }
}
