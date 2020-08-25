using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EditarOrden : MonoBehaviour
{
    public void Registrar(ConstruirMain datos)
    {
        StartCoroutine(RegistraBD(datos));
    }
    public void Editar(ConstruirMain datos)
    {
        StartCoroutine(EditaBD(datos));
    }
    public void Eliminar(clsEliminar dato)
    {
        StartCoroutine(EliminaBD(dato));
    }
    private IEnumerator RegistraBD(ConstruirMain datos)
    {
        WWWForm form = new WWWForm();
        datos.FormFill(form, true);
        using (UnityWebRequest www = UnityWebRequest.Post(DatosScena.URL + "Registrar/" + datos.FormType() + ".php", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
                Debug.Log(www.error);
            else
                Debug.Log(www.downloadHandler.text);
        }
    }

    private IEnumerator EditaBD(ConstruirMain datos)
    {
        WWWForm form = new WWWForm();
        datos.FormFill(form, false);
        using (UnityWebRequest www = UnityWebRequest.Post(DatosScena.URL + "Editar/" + datos.FormType() + ".php", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
                Debug.Log(www.error);
            else
                Debug.Log(www.downloadHandler.text);
        }
    }
    private IEnumerator EliminaBD(clsEliminar id)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id.ToString());
        using (UnityWebRequest www = UnityWebRequest.Post(DatosScena.URL + "Eliminar/" + id.nom_Tabla + ".php", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
                Debug.Log(www.error);
            else
                Debug.Log(www.downloadHandler.text);
        }
    }
}
