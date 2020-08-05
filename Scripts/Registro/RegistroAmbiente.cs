using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroAmbiente : MonoBehaviour {

     public void Registrar(Ambiente datos)
    {
		StartCoroutine(RegistraBD(datos));
        Debug.Log("----2---");
    }

    private IEnumerator RegistraBD(Ambiente datos)
    {
        Debug.Log("----3---");
        WWWForm form = new WWWForm();
        form.AddField("idProyecto", datos.idProyecto.ToString());
        form.AddField("nAmbiente", datos.nAmbiente.ToString());
        form.AddField("largo", datos.largo.ToString());
        form.AddField("ancho", datos.ancho.ToString());
        form.AddField("altura", datos.altura.ToString());
        form.AddField("area", datos.area.ToString());
        form.AddField("recambios", datos.recambios.ToString());
        form.AddField("flujo", datos.flujo.ToString());
        form.AddField("cfm", datos.cfm.ToString());
        form.AddField("coordenada", datos.coordenada.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registrar/Ambiente.php", form))
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
