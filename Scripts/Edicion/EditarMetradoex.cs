﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EditarMetradoex : MonoBehaviour {

    public void Editar(Metradoex datos)
    {
        StartCoroutine(RegistraBD(datos));
    }


    private IEnumerator RegistraBD(Metradoex datos)
    {
        WWWForm form = new WWWForm();
		form.AddField("id", datos.id.ToString());
        form.AddField("idEquipo", datos.idEquipo.ToString());
        form.AddField("dima", datos.dima.ToString());
        form.AddField("dimb", datos.dimb.ToString());
        form.AddField("tipo", datos.tipo.ToString());
        form.AddField("multi", datos.multi.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(DatosScena.URL + "Editar/Metradoex.php", form))
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
