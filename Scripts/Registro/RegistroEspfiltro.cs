using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroEspfiltro : MonoBehaviour {

    public InputField idEquipo;
    public InputField idFiltro;

    public GameObject Panel_msj;
    
    public void RegistrarAmbiente()
    {
        if ( idEquipo.text != "" && idFiltro.text != "" )
        {
            //validar que solo se ingrese numeros o texto
            StartCoroutine(RegistraBD(idEquipo.text,idFiltro.text));
            SceneManager.LoadScene("EscenaConstruccion");
        }else {
            Panel_msj.SetActive(true);
        }
    }

    private IEnumerator RegistraBD(string idEquipo, string idFiltro )
    {
        WWWForm form = new WWWForm();
        form.AddField("idEquipo", idEquipo);
        form.AddField("idFiltro", idFiltro);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Espfiltro.php", form))
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
