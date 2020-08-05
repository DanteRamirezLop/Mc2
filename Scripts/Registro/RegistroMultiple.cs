using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroMultiple : MonoBehaviour {

    public void Registrar(Multiple datos)
    {
		StartCoroutine(RegistraBD(datos));
    }


    private IEnumerator RegistraBD(Multiple datos)
    {
        WWWForm form = new WWWForm();
        form.AddField("giroX", datos.giroX.ToString());
        form.AddField("giroY", datos.giroY.ToString());
		//-----------
		form.AddField("idItem", datos.idItem.ToString());
        form.AddField("idEquipo", datos.idEquipo.ToString());
        form.AddField("conexion", datos.conexion.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registrar/Multiple.php", form))
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
