using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroDuctopass : MonoBehaviour {

    //public Text idDucto;
    public InputField ccx;
    public InputField ccy;
    public InputField ccz;
    public InputField paso;
	public InputField dibujar;

    public GameObject Panel_msj;
    
    public void RegistrarAmbiente()
    {
        if (ccx.text != "" && ccy.text != "" && ccz.text != "" && paso.text != "" && dibujar.text != "")
        {
            //validar que solo se ingrese numeros o texto

            StartCoroutine(RegistraBD(ccx.text, ccy.text, ccz.text, paso.text, dibujar.text));
            SceneManager.LoadScene("EscenaConstruccion");
        }else {
            Panel_msj.SetActive(true);
        }
    }

    private IEnumerator RegistraBD(string ccx, string ccy, string ccz, string paso, string dibujar)
    {
        WWWForm form = new WWWForm();
        form.AddField("ccx", ccx);
        form.AddField("ccy", ccy);
        form.AddField("ccz", ccz);
        form.AddField("paso", paso);
        form.AddField("dibujar", dibujar);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Ductopass.php", form))
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
