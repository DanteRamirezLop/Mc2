using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroMultiple : MonoBehaviour {

    //public Text id;
    public InputField giroX;
    public InputField giroY;

    public GameObject Panel_msj;
    
    public void RegistrarAmbiente()
    {
        if (giroX.text != "" && giroY.text != "")
        {
            //validar que solo se ingrese numeros o texto
            StartCoroutine(RegistraBD(giroX.text, giroY.text));
            SceneManager.LoadScene("EscenaConstruccion");
        }else {
            Panel_msj.SetActive(true);
        }
    }

    private IEnumerator RegistraBD(string giroX, string giroY)
    {
        WWWForm form = new WWWForm();
        form.AddField("giroX", giroX);
        form.AddField("giroY", giroY);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Multiple.php", form))
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
