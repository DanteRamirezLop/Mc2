using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RegistrarProyecto : MonoBehaviour {

    public InputField nombre;
    public GameObject Panel_msj;

    public void Registrar()
    {
        if (nombre.text != "")
        {
            //Debug.Log("Correcto");
            StartCoroutine(RegistraBD(nombre.text));
            LimpiarCampos();
        }
        else
        {
            Panel_msj.SetActive(true);
        }
    }

    private void LimpiarCampos()
    {
        nombre.text = "";
    }

    private IEnumerator RegistraBD(string nombre)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre",nombre);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Proyecto.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

}
