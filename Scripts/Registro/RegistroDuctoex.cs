using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroDuctoex : MonoBehaviour {

    //public Text idDucto;
    public InputField tipo;
    public InputField nombre;
    public InputField dimA;
    public InputField dimB;
    public InputField flujoCFM;
    public InputField damAb100;
    public InputField damCer10;
    public InputField damCer50;
    public Text tranRec;
	public Text conVen;
	public Text lumAli;

    public GameObject Panel_msj;
    
    public void RegistrarAmbiente()
    {
        if (tipo.text != "" && nombre.text != "" && dimA.text != "" && dimB.text != "" && flujoCFM.text != "" && damAb100.text != "" && damCer10.text != "" && damCer50.text != ""&& tranRec.text != "" && conVen.text != ""&& lumAli.text != "")
        {
            //validar que solo se ingrese numeros o texto

            StartCoroutine(RegistraBD(tipo.text, nombre.text, dimA.text, dimB.text, flujoCFM.text,damAb100.text, damCer10.text, damCer50.text,tranRec.text, conVen.text,lumAli.text));
            SceneManager.LoadScene("EscenaConstruccion");
        }else {
            Panel_msj.SetActive(true);
        }
    }

    private IEnumerator RegistraBD(string tipo, string nombre, string dimA, string dimB, string flujoCFM, string damAb100, string damCer10, string damCer50, string tranRec, string conVen, string lumAli)
    {
        WWWForm form = new WWWForm();
        form.AddField("tipo", tipo);
        form.AddField("nombre", nombre);
        form.AddField("dimA", dimA);
        form.AddField("dimB", dimB);
        form.AddField("flujoCFM", flujoCFM);
        form.AddField("damAb100", damAb100);
        form.AddField("damCer10", damCer10);
        form.AddField("damCer50", damCer50);
        form.AddField("tranRec", tranRec);
        form.AddField("conVen", conVen);
		form.AddField("lumAli", lumAli);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Ductoex.php", form))
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
