using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroRejilla : MonoBehaviour {

    public void Registrar(Rejilla datos)
    {
		StartCoroutine(RegistraBD(datos));
    }

    private IEnumerator RegistraBD(Rejilla datos)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", datos.nombre.ToString());
        form.AddField("cfm", datos.cfm.ToString());
		//-----------
		form.AddField("idItem", datos.idItem.ToString());
        form.AddField("idEquipo", datos.idEquipo.ToString());
        form.AddField("conexion", datos.conexion.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registrar/Rejilla.php", form))
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
