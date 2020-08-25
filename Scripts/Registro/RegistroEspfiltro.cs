using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroEspfiltro : MonoBehaviour {

    public void Registrar(Espfiltro datos)
    {
		StartCoroutine(RegistraBD(datos));
    }


    private IEnumerator RegistraBD(Espfiltro datos)
    {
        WWWForm form = new WWWForm();
        form.AddField("idEquip", datos.idEquip.ToString());
        form.AddField("idFiltro", datos.idFiltro.ToString());


        using (UnityWebRequest www = UnityWebRequest.Post(DatosScena.URL + "Registrar/Espfiltro.php", form))
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
