using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EditarDuctopass : MonoBehaviour {

    public void Editar(Ductopass datos)
    {
        StartCoroutine(RegistraBD(datos));
    }

    private IEnumerator RegistraBD(Ductopass datos)
    {
        WWWForm form = new WWWForm();
		form.AddField("idDucto", datos.idDucto.ToString());
        form.AddField("ccx", datos.ccx.ToString());
        form.AddField("ccy", datos.ccy.ToString());
        form.AddField("ccz", datos.ccz.ToString());
        form.AddField("paso", datos.paso.ToString());
        form.AddField("dibujar", datos.dibujar.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(DatosScena.URL + "Editar/Ductopass.php", form))
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
