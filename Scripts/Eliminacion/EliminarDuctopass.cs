using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EliminarDuctopass : MonoBehaviour {

    public void Eliminar(int idDucto)
    {
            StartCoroutine(RegistraBD(idDucto));

    }


    private IEnumerator RegistraBD(int idDucto)
    {
        WWWForm form = new WWWForm();
        form.AddField("idDucto", idDucto.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Eliminar/Ductopass.php", form))
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
