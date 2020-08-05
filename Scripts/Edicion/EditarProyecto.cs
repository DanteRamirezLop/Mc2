using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EditarProyecto : MonoBehaviour {

    public void Editar(string nombre)
    {
        StartCoroutine(RegistraBD(nombre));
    }

    private IEnumerator RegistraBD(string nombre)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre",nombre);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Editar/Proyecto.php", form))
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
