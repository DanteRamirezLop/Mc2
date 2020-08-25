using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EditarDucto : MonoBehaviour {

    public void Editar(Ducto datos)
    {
        StartCoroutine(RegistraBD(datos));
    }

    private IEnumerator RegistraBD(Ducto datos)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", datos.id.ToString());
        form.AddField("longitud", datos.longitud.ToString());
        form.AddField("paso", datos.paso.ToString());
        form.AddField("dibujar", datos.dibujar.ToString());
		//-------------
		form.AddField("tipo", datos.tipo.ToString());
        form.AddField("nombre", datos.nombre.ToString());
        form.AddField("dimA", datos.dimA.ToString());
        form.AddField("dimB", datos.dimB.ToString());
        form.AddField("flujoCFM", datos.flujoCFM.ToString());
        form.AddField("damAb100", datos.damAb100.ToString());
        form.AddField("damCer10", datos.damCer10.ToString());
        form.AddField("damCer50", datos.damCer50.ToString());
        form.AddField("tranRec", datos.tranRec.ToString());
        form.AddField("conVen", datos.conVen.ToString());
		form.AddField("lumAli", datos.lumAli.ToString());
		//-----------
		form.AddField("idItem", datos.idItem.ToString());
        form.AddField("idEquipo", datos.idEquipo.ToString());
        form.AddField("conexion", datos.conexion.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(DatosScena.URL + "Editar/Ducto.php", form))
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
