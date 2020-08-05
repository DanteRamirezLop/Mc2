using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EliminarEspfiltro : MonoBehaviour {

    public void Eliminar(int idEquip,int idFiltro)
    {
            StartCoroutine(RegistraBD(idEquip,idFiltro));

    }

    private IEnumerator RegistraBD(int idEquip,int idFiltro)
    {
        WWWForm form = new WWWForm();
        form.AddField("idEquip", idEquip);
        form.AddField("idFiltro", idFiltro);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Eliminar/Espfiltro.php", form))
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
