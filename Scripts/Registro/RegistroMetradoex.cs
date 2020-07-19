using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroMetradoex : MonoBehaviour {

    //public Text id;
    public InputField idEquipo;
    public InputField dima;
    public InputField dimb;
    public InputField tipo;
    public InputField multi;

    public GameObject Panel_msj;
    
    public void RegistrarAmbiente()
    {
        if (idEquipo.text != "" && dima.text != "" && dimb.text != "" && tipo.text != "" && multi.text != "")
        {
            //validar que solo se ingrese numeros o texto
            StartCoroutine(RegistraBD(idEquipo.text, dima.text, dimb.text, tipo.text, multi.text));
            SceneManager.LoadScene("EscenaConstruccion");
        }else {
            Panel_msj.SetActive(true);
        }
    }

    private IEnumerator RegistraBD(string idEquipo, string dima, string dimb, string tipo, string multi)
    {
        WWWForm form = new WWWForm();
        form.AddField("idEquipo", idEquipo);
        form.AddField("dima", dima);
        form.AddField("dimb", dimb);
        form.AddField("tipo", tipo);
        form.AddField("multi", multi);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Metradoex.php", form))
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
