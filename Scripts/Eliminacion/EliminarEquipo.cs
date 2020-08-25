using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EliminarEquipo : MonoBehaviour {


    public void Eliminar(int id)
    {
            StartCoroutine(RegistraBD(id));

    }


    private IEnumerator RegistraBD(int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(DatosScena.URL + "Eliminar/Equipo.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError){
                Debug.Log(www.error);
            }
            else{
                Debug.Log(www.downloadHandler.text);
            }
        
        }
    }
}
