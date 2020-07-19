using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroItem : MonoBehaviour {

    //public Text id;
    public InputField idItem;
    public InputField idEquipo;
    public InputField conexion;

    public GameObject Panel_msj;
    
    public void RegistrarAmbiente()
    {
        if (idItem.text != "" && idEquipo.text != "" && conexion.text != "")
        {
            //validar que solo se ingrese numeros o texto
            StartCoroutine(RegistraBD(idItem.text, idEquipo.text, conexion.text));
            SceneManager.LoadScene("EscenaConstruccion");
        }else {
            Panel_msj.SetActive(true);
        }
    }

    private IEnumerator RegistraBD(string idItem, string idEquipo, string conexion)
    {
        WWWForm form = new WWWForm();
        form.AddField("idItem", idItem);
        form.AddField("idEquipo", idEquipo);
        form.AddField("conexion", conexion);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Item.php", form))
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
