using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EliminarMultiple : MonoBehaviour {

    public void Eliminar(int id, int idItem)
    {
            StartCoroutine(RegistraBD(id,idItem));

    }


    private IEnumerator RegistraBD(int id, int idItem)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id.ToString());
        form.AddField("idItem", idItem.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(DatosScena.URL + "Eliminar/Multiple.php", form))
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
