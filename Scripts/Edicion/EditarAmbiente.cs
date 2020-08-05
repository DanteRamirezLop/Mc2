using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EditarAmbiente : MonoBehaviour {


    public void Editar(Ambiente datos)
    {
        StartCoroutine(RegistraBD(datos));
    }

    private IEnumerator RegistraBD(Ambiente datos)
    {
        WWWForm form = new WWWForm();
		form.AddField("id", datos.id.ToString());
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

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Editar/Ambiente.php", form))
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
