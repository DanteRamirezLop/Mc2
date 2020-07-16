using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroDucto : MonoBehaviour {

    //public Text id;
	public InputField idItem;
    public InputField conexion;
    public InputField longitud;

    public GameObject Panel_msj;
    
    public void RegistrarAmbiente()
    {
        if (idItem.text != "" && conexion.text != "" && longitud.text != "")
        {
            //validar que solo se ingrese numeros o texto
            StartCoroutine(RegistraBD(idItem.text, conexion.text, longitud.text));
            SceneManager.LoadScene("EscenaConstruccion");
        }else {
            Panel_msj.SetActive(true);
        }
    }

    private IEnumerator RegistraBD(string idItem, string conexion, string longitud)
    {
        WWWForm form = new WWWForm();
        form.AddField("idItem", idItem);
        form.AddField("conexion", conexion);
        form.AddField("longitud", longitud);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Ducto.php", form))
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
