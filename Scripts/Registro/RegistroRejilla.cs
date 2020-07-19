using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroRejilla : MonoBehaviour {

    //public InputField id;
    public InputField nombre;
    public InputField cfm;

    public GameObject Panel_msj;
    
    public void RegistrarAmbiente()
    {
        if (nombre.text != "" && cfm.text != "")
        {
            //validar que solo se ingrese numeros o texto
            StartCoroutine(RegistraBD(nombre.text, cfm.text));
            SceneManager.LoadScene("EscenaConstruccion");
        }else {
            Panel_msj.SetActive(true);
        }
    }

    private IEnumerator RegistraBD(string nombre, string cfm)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", nombre);
        form.AddField("cfm", cfm);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Rejilla.php", form))
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
