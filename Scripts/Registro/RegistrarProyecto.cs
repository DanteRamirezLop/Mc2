using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistrarProyecto : MonoBehaviour {

    public InputField nombre;

    public void Registrar()
    {
        StartCoroutine(RegistraBD(nombre.text));
    }

    private IEnumerator RegistraBD(string nombre)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre",nombre);

        using (UnityWebRequest www = UnityWebRequest.Post(DatosScena.URL + "Registrar/Proyecto.php", form))
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
