using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroFiltro : MonoBehaviour {

    public void Registrar(Filtro datos)
    {
		StartCoroutine(RegistraBD(datos));
    }


    private IEnumerator RegistraBD(Filtro datos)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", datos.nombre);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registrar/Filtro.php", form))
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
