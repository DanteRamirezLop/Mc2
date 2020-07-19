using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroFiltro : MonoBehaviour {

   // public Text id;
    public InputField nombre;


    public GameObject Panel_msj;
    
    public void RegistrarAmbiente()
    {
        if (nombre.text != "")
        {
            //validar que solo se ingrese numeros o texto
            StartCoroutine(RegistraBD(nombre.text));
            SceneManager.LoadScene("EscenaConstruccion");
        }else {
            Panel_msj.SetActive(true);
        }
    }

    private IEnumerator RegistraBD(string nombre)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", nombre);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Filtro.php", form))
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
