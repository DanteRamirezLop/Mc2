using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EditarFiltro : MonoBehaviour {

    public void Editar(Filtro datos)
    {
        StartCoroutine(RegistraBD(datos));
    }


    private IEnumerator RegistraBD(Filtro datos)
    {
        WWWForm form = new WWWForm();
		form.AddField("id", datos.id.ToString());
        form.AddField("nombre", datos.nombre);

        using (UnityWebRequest www = UnityWebRequest.Post(DatosScena.URL + "Editar/Filtro.php", form))
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
